//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2020.05.23 at 02:08:09 PM CEST 
//


package io.spring.guides.gs_producing_web_service;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="fromCCY" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="toCCY" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "fromCCY",
    "toCCY"
})
@XmlRootElement(name = "getExchangeRateRequest")
public class GetExchangeRateRequest {

    @XmlElement(required = true)
    protected String fromCCY;
    @XmlElement(required = true)
    protected String toCCY;

    /**
     * Gets the value of the fromCCY property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getFromCCY() {
        return fromCCY;
    }

    /**
     * Sets the value of the fromCCY property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setFromCCY(String value) {
        this.fromCCY = value;
    }

    /**
     * Gets the value of the toCCY property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getToCCY() {
        return toCCY;
    }

    /**
     * Sets the value of the toCCY property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setToCCY(String value) {
        this.toCCY = value;
    }

}
