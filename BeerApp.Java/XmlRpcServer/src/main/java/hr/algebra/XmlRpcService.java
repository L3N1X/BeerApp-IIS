package hr.algebra;

import hr.algebra.models.Beers;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.xpath.*;
import java.io.IOException;
import java.io.StringReader;

public class XmlRpcService {
    public static final String DHMZ_URL = "https://vrijeme.hr/hrvatska_n.xml";
    public String findTemperatureByCityName(String cityName) throws ParserConfigurationException, IOException, SAXException, XPathExpressionException {
        DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();

        org.w3c.dom.Document cityTemperatures = documentBuilder.parse(DHMZ_URL);

        XPathFactory xPathFactory = XPathFactory.newInstance();
        XPath xPath = xPathFactory.newXPath();

        String xPathQuery = String.format("Hrvatska/Grad[contains(GradIme, \"%s\")]/Podatci/Temp", cityName);
        XPathExpression xPathTempExpression = xPath.compile(xPathQuery);
        NodeList temperatureNodeList = (NodeList) (xPathTempExpression.evaluate(cityTemperatures, XPathConstants.NODESET));
        if(temperatureNodeList.getLength() > 0) {
            return temperatureNodeList.item(0).getTextContent();
        }
        return "NOCANDO";
    }

    public String validateBeerXml(String xml){
        try {
            var context = JAXBContext.newInstance(Beers.class);
            var beers = (Beers) context.createUnmarshaller().unmarshal(new StringReader(xml));
        } catch (JAXBException e) {
            return e.getMessage();
        }
        return "VALID";
    }
}
