package com.ws;

import org.springframework.ws.WebServiceMessage;
import org.springframework.ws.soap.SoapHeader;
import org.springframework.ws.soap.SoapMessage;
import org.w3c.dom.Node;
import javax.xml.transform.Source;
import javax.xml.transform.dom.DOMSource;

public class ClientAuth {
    /*
    public boolean isAuthorised(WebServiceMessage webServiceMessageRequest){
        String name = "";
        String password = "";

        try {
            SoapMessage soapMessage = (SoapMessage) webServiceMessageRequest;
            SoapHeader soapHeader = soapMessage.getSoapHeader();
            Source bodySource = soapHeader.getSource();
            DOMSource bodyDomSource = (DOMSource) bodySource;
            Node bodyNode = bodyDomSource.getNode();

            name =  bodyNode.getChildNodes().item(0).getChildNodes().item(0).getTextContent().trim();
            password = bodyNode.getChildNodes().item(1).getChildNodes().item(0).getTextContent().trim();

        } catch (Exception e) {
            //log e
        }
        if (name.equals("CarRentalAPI") && password.equals("p455w0rd")){

            return true;
        } else {
            return false;
        }
    }

     */
}
