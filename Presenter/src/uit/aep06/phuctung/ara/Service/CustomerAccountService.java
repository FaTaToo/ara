package uit.aep06.phuctung.ara.Service;

import java.io.IOException;
import java.io.UnsupportedEncodingException;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.HttpContext;
import org.json.JSONException;
import org.json.JSONObject;
import android.R;
import android.provider.Telephony.Sms.Conversations;
import android.util.Log;
import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;

public class CustomerAccountService extends Service {


	public  int AddNewCustomerAccount(CustomerAccount acc) throws JSONException, ClientProtocolException, IOException
	{
		httpPost = new HttpPost("link to service");
		httpPost.setHeader("Content-type", "application/json");

		//Tao du lieu truyen di
		JSONObject newAccount = new JSONObject();
		newAccount.put("Username", acc.getUsername());
		newAccount.put("Password", acc.getPass());
		newAccount.put("Email", acc.getEmail());
		newAccount.put("Fullname", acc.getFullname());
		
		//Chuyen sang kieu String entity
		StringEntity postData = new StringEntity(newAccount.toString(),"UTF-8");
		httpPost.setEntity(postData);
		
		response = httpClient.execute(httpPost);
		HttpEntity entity = response.getEntity();
		String content = Service.ConvertFromEntityToString(entity);
		content = content.replace("\"", "").replace("\"", "");
		if (content.equals("0"))
			return 0;
		return Integer.parseInt(content);
		
	}
	
	public  int CheckExists(CustomerAccount acc){
		httpGet = new HttpGet("link to service" + acc.Username + "-" + acc.Pass);
		try {
			response = httpClient.execute(httpGet,localContext);
		} catch (ClientProtocolException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
			entity = response.getEntity();
			String content;
			try {
				content = Service.ConvertFromEntityToString(entity);
				content = content.replace("\"", "").replace("\"", "");

				if (content.equals("0"))
					return 0;
				return Integer.parseInt(content);
			} catch (IllegalStateException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
		return 0;
		
	}
	public String getName(String id)
	{
		httpGet = new HttpGet("link to server" + id);
		try {
			response = httpClient.execute(httpGet,localContext);
		} catch (ClientProtocolException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
			entity = response.getEntity();
			String content;
			try {
				content = Service.ConvertFromEntityToString(entity);
				content = content.replace("\"", "").replace("\"", "");
				return content;
				
			} catch (IllegalStateException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
		return "Null";
		
	}
}

