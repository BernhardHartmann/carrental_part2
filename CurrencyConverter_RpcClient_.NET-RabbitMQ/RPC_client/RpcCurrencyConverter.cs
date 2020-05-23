using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Net.Cache;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RpcClientCCY
{
    public class RpcCurrencyConverter
    {

        //TODO: the following main class is meant only for demonstration how to get values from the currency converter RPC in synchronous code flow.
        public static void Main(string[] args)
        {
            Console.WriteLine("RPC Client initiated");
            string fromCCY = args.Length > 0 ? args[0] : "USD";
            string toCCY = args.Length > 0 ? args[0] : "EUR";

            RpcRequest request = new RpcRequest
            {
                fromCCY = fromCCY,
                toCCY = toCCY
            };

            RpcResponse rpcResponse = Task.Run(async () => await GetRpcResult(request)).Result;

            //Console for testing and demo only
            Console.WriteLine(rpcResponse.fromCCY);
            Console.WriteLine(rpcResponse.toCCY);
            Console.WriteLine(rpcResponse.exchangeRate);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            
        }

        private static async Task<RpcResponse> GetRpcResult(RpcRequest request)
        {

            string jsonRequest = JsonSerializer.Serialize(request);

            var rpcClient = new RpcClientCCY();

            var response = await rpcClient.CallAsync(jsonRequest);

            rpcClient.Close();

            RpcResponse rpcResponse = JsonSerializer.Deserialize<RpcResponse>(response);

            return rpcResponse;
        }
    }
}
