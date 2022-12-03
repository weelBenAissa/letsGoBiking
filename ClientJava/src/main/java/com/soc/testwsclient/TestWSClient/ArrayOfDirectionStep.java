
package com.soc.testwsclient.TestWSClient;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour ArrayOfDirection.Step complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfDirection.Step"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="Direction.Step" type="{http://schemas.datacontract.org/2004/07/RoutingServer}Direction.Step" maxOccurs="unbounded" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfDirection.Step", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", propOrder = {
    "directionStep"
})
public class ArrayOfDirectionStep {

    @XmlElement(name = "Direction.Step", nillable = true)
    protected List<DirectionStep> directionStep;

    /**
     * Gets the value of the directionStep property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the directionStep property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getDirectionStep().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link DirectionStep }
     * 
     * 
     */
    public List<DirectionStep> getDirectionStep() {
        if (directionStep == null) {
            directionStep = new ArrayList<DirectionStep>();
        }
        return this.directionStep;
    }

}
