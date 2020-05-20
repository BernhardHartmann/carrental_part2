package com.ws;

import io.spring.guides.gs_producing_web_service.ExchangeRate;
import org.springframework.ws.context.MessageContext;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import io.spring.guides.gs_producing_web_service.GetExchangeRateRequest;
import io.spring.guides.gs_producing_web_service.GetExchangeRateResponse;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.text.ParseException;

//@Endpoint
public class ExchangeRateEndpoint {
	/*
	private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

	@PayloadRoot(namespace = NAMESPACE_URI, localPart = "getExchangeRateRequest")
	@ResponsePayload
	public GetExchangeRateResponse getExchangeRate(@RequestPayload GetExchangeRateRequest request, MessageContext messageContext) throws SAXException, ParserConfigurationException, ParseException, IOException {

		ClientAuth clientAuth = new ClientAuth();

		//SOAP Security Header is handled in the application layer
		if (clientAuth.isAuthorised(messageContext.getRequest())) {

			GetExchangeRateResponse response = new GetExchangeRateResponse();

			String fromCCY = request.getFromCCY();
			String toCCY = request.getToCCY();

			fxRateConvertor fxConvertor = new fxRateConvertor();

			double exchangeRate = fxConvertor.calc(fromCCY, toCCY);

			ExchangeRate resp = new ExchangeRate();
			resp.setName("ResponseFromCurrencyConvertor");
			resp.setExchangeRate(exchangeRate);
			resp.setFromCCY(fromCCY);
			resp.setToCCY(toCCY);

			response.setExchangeRate(resp);

			return response;

		} else {
			//ignore and do nothing
			return null;
		}

	}

	 */
}
