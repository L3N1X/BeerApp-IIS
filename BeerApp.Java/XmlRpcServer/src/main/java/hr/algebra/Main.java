package hr.algebra;

import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServer;
import org.apache.xmlrpc.webserver.WebServer;

import java.io.IOException;

public class Main {
    private static final Integer PORT = 6969;
    public static void main(String[] args) {
        WebServer webServer = new WebServer(PORT);
        XmlRpcServer xmlRpcServer = webServer.getXmlRpcServer();
        PropertyHandlerMapping propertyHandlerMapping = new PropertyHandlerMapping();
        try {
            propertyHandlerMapping.addHandler("Temperature", TemperatureFinder.class);
            xmlRpcServer.setHandlerMapping(propertyHandlerMapping);
            webServer.start();
            System.out.println("[XMLRPC-SERVER]: Server starting on http://localhost:" + PORT);
        } catch (XmlRpcException | IOException e) {
            throw new RuntimeException(e);
        }
    }
}