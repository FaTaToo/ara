package uit.aep06.phuctung.ara.CommonClass;

import java.io.InputStream;
import java.util.ArrayList;
import java.util.concurrent.ExecutionException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;
import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import com.google.android.gms.maps.model.LatLng;

import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;

@SuppressWarnings("deprecation")
public class GMapV2Direction {
	public String url = null;
	public final static String MODE_DRIVING = "driving";
	public final static String MODE_WALKING = "walking";
	public Context context;
	
	public GMapV2Direction(Context context) {
		this.context = context;
	}
	
	public Document getDocument(LatLng start, LatLng end, String mode) {
		url = "http://maps.googleapis.com/maps/api/directions/xml?"
	            + "origin=" + start.latitude + "," + start.longitude
	            + "&destination=" + end.latitude + "," + end.longitude
	            + "&sensor=false&units=metric&mode=driving";
		BackgroundTask task = new BackgroundTask();
		Document result;
		try {
			result = task.execute().get();
			return result;
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ExecutionException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}
	private class BackgroundTask extends AsyncTask<Void, Void, Document> {
		@Override
		protected Document doInBackground(Void... params) {
			try {
		        HttpClient httpClient = new DefaultHttpClient();
		        HttpContext localContext = new BasicHttpContext();
		        HttpPost httpPost = new HttpPost(url);
		        HttpResponse response = httpClient.execute(httpPost, localContext);
		        InputStream in = response.getEntity().getContent();
		        DocumentBuilder builder = DocumentBuilderFactory.newInstance()
		                .newDocumentBuilder();
		        Document doc = builder.parse(in);
		        return doc;
		    } catch (Exception e) {
		        e.printStackTrace();
		    }
		    return null;
		}
		
	}
	
	private int getNodeIndex(NodeList nl, String nodename) {
		for (int i = 0; i < nl.getLength(); i++) {
			if (nl.item(i).getNodeName().equals(nodename))
				return i;
		}
		return -1;
	}

	private ArrayList<LatLng> decodePoly(String encoded) {
		ArrayList<LatLng> poly = new ArrayList<LatLng>();
		int index = 0, len = encoded.length();
		int lat = 0, lng = 0;
		while (index < len) {
			int b, shift = 0, result = 0;
			do {
				b = encoded.charAt(index++) - 63;
				result |= (b & 0x1f) << shift;
				shift += 5;
			} while (b >= 0x20);
			int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
			lat += dlat;
			shift = 0;
			result = 0;
			do {
				b = encoded.charAt(index++) - 63;
				result |= (b & 0x1f) << shift;
				shift += 5;
			} while (b >= 0x20);
			int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
			lng += dlng;

			LatLng position = new LatLng((double) lat / 1E5, (double) lng / 1E5);
			poly.add(position);
		}
		return poly;

	}

	public ArrayList<LatLng> getDirection(Document doc) {
	    NodeList nl1, nl2, nl3;
	    ArrayList<LatLng> listGeopoints = new ArrayList<LatLng>();
	    nl1 = doc.getElementsByTagName("step");
	    if (nl1.getLength() > 0) {
	        for (int i = 0; i < nl1.getLength(); i++) {
	            Node node1 = nl1.item(i);
	            nl2 = node1.getChildNodes();

	            Node locationNode = nl2
	                    .item(getNodeIndex(nl2, "start_location"));
	            nl3 = locationNode.getChildNodes();
	            Node latNode = nl3.item(getNodeIndex(nl3, "lat"));
	            double lat = Double.parseDouble(latNode.getTextContent());
	            Node lngNode = nl3.item(getNodeIndex(nl3, "lng"));
	            double lng = Double.parseDouble(lngNode.getTextContent());
	            listGeopoints.add(new LatLng(lat, lng));

	            locationNode = nl2.item(getNodeIndex(nl2, "polyline"));
	            nl3 = locationNode.getChildNodes();
	            latNode = nl3.item(getNodeIndex(nl3, "points"));
	            ArrayList<LatLng> arr = decodePoly(latNode.getTextContent());
	            for (int j = 0; j < arr.size(); j++) {
	                listGeopoints.add(new LatLng(arr.get(j).latitude, arr
	                        .get(j).longitude));
	            }

	            locationNode = nl2.item(getNodeIndex(nl2, "end_location"));
	            nl3 = locationNode.getChildNodes();
	            latNode = nl3.item(getNodeIndex(nl3, "lat"));
	            lat = Double.parseDouble(latNode.getTextContent());
	            lngNode = nl3.item(getNodeIndex(nl3, "lng"));
	            lng = Double.parseDouble(lngNode.getTextContent());
	            listGeopoints.add(new LatLng(lat, lng));
	        }
	    }
	    return listGeopoints;
	}
}
