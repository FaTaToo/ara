package uit.aep06.phuctung.ara.Service;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;

import org.apache.http.HttpEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.json.JSONException;
import org.json.JSONObject;



import android.provider.Telephony.Sms.Conversations;
import android.util.Log;
import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;

public class CustomerAccountService extends Service {


	public  int addNewCustomerAccount(CustomerAccount acc)
	{
		return 0;
	}
	
	@SuppressWarnings("deprecation")
	public  int authenticate(CustomerAccount account)  throws IOException, JSONException{
		String targetURL = "http://localhost:52396/Services/Presenter/CustomerAccount.svc/Authenticate";
			
		URL url;
	    HttpURLConnection connection = null;  
	    
    	//Create JSONObject here
		JSONObject jsonParam = new JSONObject();
		jsonParam.put("userName", account.getUsername());
		jsonParam.put("pass", account.getPass());
	    
	    try {
	      //Create connection
	      url = new URL(targetURL);
	      connection = (HttpURLConnection)url.openConnection();
	      connection.setRequestMethod("POST");
	      connection.setRequestProperty("Content-Type", 
	           "application/x-www-form-urlencoded");
				
	      connection.setRequestProperty("Content-Length", "" + 
	               Integer.toString(jsonParam.toString().getBytes().length));
	      connection.setRequestProperty("Content-Language", "en-US");  
				
	      connection.setUseCaches (false);
	      connection.setDoInput(true);
	      connection.setDoOutput(true);

	      //Send request
	      DataOutputStream wr = new DataOutputStream (connection.getOutputStream ());
	      wr.writeBytes (jsonParam.toString());
	      wr.flush ();
	      wr.close ();

	      //Get Response	
	      InputStream is = connection.getInputStream();
	      BufferedReader rd = new BufferedReader(new InputStreamReader(is));
	      String line;
	      StringBuffer response = new StringBuffer(); 
	      while((line = rd.readLine()) != null) {
	        response.append(line);
	        response.append('\r');
	      }
	      rd.close();
	      Log.d("JSON POST", response.toString());
	      return 1 ;

	    } catch (Exception e) {

	      e.printStackTrace();
	      return 0;

	    } finally {

	      if(connection != null) {
	        connection.disconnect(); 
	      }
	    }		

//		HttpPost httppost = new HttpPost(targetURL);
//		
//		JSONObject accValue = new JSONObject();
//		JSONObject acc = new JSONObject();
//		accValue.put("UserName", account.getUsername());
//		accValue.put("Password", account.getPass());
//		
//		acc.put("account", accValue.toString());
//		
//	    httppost.setEntity(new StringEntity(acc.toString(), "UTF-8"));
//		
//	    response = httpClient.execute(httppost);
//		HttpEntity entity = response.getEntity();
//		String content = Service.ConvertFromEntityToString(entity);
//		return 1;
		//way 1;
//		URL url;
//		URLConnection urlConn;
//		DataOutputStream printout;
//				
//		url = new URL("");;
//		urlConn = url.openConnection();
//		urlConn.setDoInput (true);
//		urlConn.setDoOutput (true);
//		urlConn.setUseCaches (false);
//		urlConn.setRequestProperty("Content-Type","application/json");   
//		urlConn.setRequestProperty("Host", "android.schoolportal.gr");//eo hieu, can sua
//		urlConn.connect();  
//		//Create JSONObject here
//		JSONObject jsonParam = new JSONObject();
//		jsonParam.put("userName", account.getUsername());
//		jsonParam.put("pass", account.getPass());
//		//Send POST output
//		printout = new DataOutputStream(urlConn.getOutputStream());
//		printout.writeChars(URLEncoder.encode(jsonParam.toString(), "UTF-8"));
//		printout.flush();
//		printout.close();
	}
	public String getName(String id)
	{
		return "";
	}
}

