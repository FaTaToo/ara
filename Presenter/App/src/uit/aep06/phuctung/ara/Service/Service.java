package uit.aep06.phuctung.ara.Service;

import java.io.IOException;
import java.io.InputStream;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;

public class Service {
	public  HttpGet httpGet;
	public  HttpContext localContext = new BasicHttpContext() ;
	public  HttpClient httpClient = new DefaultHttpClient();
	public  HttpPost httpPost ;
	public  HttpPut httpPut;
	public  HttpResponse response;
	public  HttpEntity entity ;
	    public static  String ConvertFromEntityToString(HttpEntity entity) throws IllegalStateException, IOException {

	        InputStream in = entity.getContent();

	        StringBuffer out = new StringBuffer();
	        int n = 1;
	        while (n>0) {
	            byte[] b = new byte[4096];

	            n =  in.read(b);

	            if (n>0) out.append(new String(b, 0, n));

	        }
	       
	        return  out.toString();

	    }
}