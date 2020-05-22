package com.ws;

import com.google.gson.Gson;
import com.rabbitmq.client.*;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.text.ParseException;
//import org.apache.tomcat.util.json.JSONParser;

@SpringBootApplication
public class RPCServer {

    private static final String RPC_QUEUE_NAME = "rpc_queue";

    private static String getFX(String request) throws SAXException, ParserConfigurationException, ParseException, IOException {

        Gson g = new Gson();
        RpcRequest rcpRequest = g.fromJson(request, RpcRequest.class);

        fxRateConvertor fxConvertor = new fxRateConvertor();
        double exchangeRate = fxConvertor.calc(rcpRequest.fromCCY, rcpRequest.toCCY);

        RpcResponse rpcResponse = new RpcResponse();
        rpcResponse.fromCCY = rcpRequest.fromCCY;
        rpcResponse.toCCY = rcpRequest.toCCY;
        rpcResponse.exchangeRate = exchangeRate;

        String response =  g.toJson(rpcResponse);

        return response;
    }

    public static void main(String[] argv) throws Exception {
        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost("localhost");

        try (Connection connection = factory.newConnection();
             Channel channel = connection.createChannel()) {
            channel.queueDeclare(RPC_QUEUE_NAME, false, false, false, null);
            channel.queuePurge(RPC_QUEUE_NAME);

            channel.basicQos(1);

            System.out.println(" [x] Awaiting RPC requests");

            Object monitor = new Object();
            DeliverCallback deliverCallback = (consumerTag, delivery) -> {
                AMQP.BasicProperties replyProps = new AMQP.BasicProperties
                        .Builder()
                        .correlationId(delivery.getProperties().getCorrelationId())
                        .build();

                String response = "";

                try {
                    String message = new String(delivery.getBody(), "UTF-8");
                    //int n = Integer.parseInt(message);

                    System.out.println(" [.] fib(" + message + ")");
                    response += getFX(message);
                } catch (RuntimeException e) {
                    System.out.println(" [.] " + e.toString());
                } catch (ParseException e) {
                    e.printStackTrace();
                } catch (ParserConfigurationException e) {
                    e.printStackTrace();
                } catch (SAXException e) {
                    e.printStackTrace();
                } finally {
                    channel.basicPublish("", delivery.getProperties().getReplyTo(), replyProps, response.getBytes("UTF-8"));
                    channel.basicAck(delivery.getEnvelope().getDeliveryTag(), false);
                    // RabbitMq consumer worker thread notifies the RPC server owner thread
                    synchronized (monitor) {
                        monitor.notify();
                    }
                }
            };

            channel.basicConsume(RPC_QUEUE_NAME, false, deliverCallback, (consumerTag -> { }));
            // Wait and be prepared to consume the message from RPC client.
            while (true) {
                synchronized (monitor) {
                    try {
                        monitor.wait();
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
    }
}
