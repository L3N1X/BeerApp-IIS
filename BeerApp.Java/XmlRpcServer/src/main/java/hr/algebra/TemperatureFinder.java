package hr.algebra;

import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.swing.text.Document;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.xpath.*;
import java.io.IOException;

public class TemperatureFinder {
    public static final String DHMZ_URL = "https://vrijeme.hr/hrvatska_n.xml";
    public String findTemperatureByCityName(String cityName) throws ParserConfigurationException, IOException, SAXException, XPathExpressionException {
        DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();

        Document cityTemperatures = (Document) documentBuilder.parse(DHMZ_URL);

        XPathFactory xPathFactory = XPathFactory.newInstance();
        XPath xPath = xPathFactory.newXPath();

        String xPathQuery = String.format("Hrvatska/Grad[contains(GradIme, \"%s\")]/Podaci/Temp", cityName);
        XPathExpression xPathTempExpression = xPath.compile(xPathQuery);
        NodeList temperatureNodeList = (NodeList) (xPathTempExpression.evaluate(cityTemperatures, XPathConstants.NODESET));
        if(temperatureNodeList.getLength() > 0) {
            return temperatureNodeList.item(0).getTextContent();
        }
        return String.format("No temperatures found for %s", cityName);
    }
}
