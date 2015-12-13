package uit.aep06.phuctung.ara.ARResource;

import java.io.StringReader;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;

public class ARContainer {
	public  List<ARResource> listResource;

	public  List<ARResource> getListResource() {
		return listResource;
	}

	public  void setListResource(List<ARResource> listResource) {
		this.listResource = listResource;
	}
	
	private void LoadXML(String xml){};

	 
	public Document loadXMLFromString(String xml) throws Exception
	{
	    DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
	    DocumentBuilder builder = factory.newDocumentBuilder();
	    InputSource is = new InputSource(new StringReader(xml));
	    return builder.parse(is);
	}
}
