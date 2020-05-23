package com.ws;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.boot.web.server.LocalServerPort;
import org.springframework.oxm.jaxb.Jaxb2Marshaller;
import org.springframework.util.ClassUtils;
import org.xml.sax.SAXException;
import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;
import java.text.ParseException;
import java.util.HashMap;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
public class RPCServerTests {


	@Test
	public void testFxRateConvertor() throws SAXException, ParserConfigurationException, ParseException, IOException {

		//arrange
		fxRateConvertor fxRateConvertor = new fxRateConvertor();
		HashMap<String, String> FX_Rates = new HashMap<>();
		FX_Rates.put("USD", "1.860");
		FX_Rates.put("JPY", "116.86");
		FX_Rates.put("CZK", "27.163");

		double exchangeRate_toEUR;
		double exchangeRate_fromEUR;
		double exchangeRate_crossRate;

		//act
		exchangeRate_toEUR = fxRateConvertor.calcToEUR("USD", FX_Rates);
		exchangeRate_fromEUR = fxRateConvertor.calcFromEUR( "JPY", FX_Rates);
		exchangeRate_crossRate = fxRateConvertor.calcCrossRate("JPY", "CZK", FX_Rates);

		//assert
		assert(exchangeRate_toEUR == 0.5376344086021505);
		assert(exchangeRate_fromEUR == 116.86);
		assert(exchangeRate_crossRate == 0.23244052712647614);


	}
}
