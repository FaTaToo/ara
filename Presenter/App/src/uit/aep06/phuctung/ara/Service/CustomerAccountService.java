package uit.aep06.phuctung.ara.Service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;

import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONTokener;

import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;

public class CustomerAccountService extends Service{
	

	public int addNewCustomerAccount(CustomerAccount account) throws JSONException {
		String requestURL = serviceURL  + "/SignUp";
		
		JSONObject jsonParam = new JSONObject();
		jsonParam.put("FirstName", account.getFirstName());
		jsonParam.put("LastName", account.getLastName());
		jsonParam.put("Sex", account.getSex());
		jsonParam.put("BirthDay", account.getBirthDay());
		jsonParam.put("Address", account.getAddress());
		jsonParam.put("Email", account.getEmail());
		jsonParam.put("Phone", account.getPhone());
		jsonParam.put("UserName", account.getUsername());
		jsonParam.put("Password", account.getPass());

		return postSuccessful(jsonParam, requestURL);
	}

	public int authenticate(CustomerAccount account) throws IOException, JSONException {
		String requestURL = serviceURL + "/Authenticate";

		URL url;
		HttpURLConnection connection = null;

		JSONObject jsonParam = new JSONObject();
		jsonParam.put("UserName", account.getUsername());
		jsonParam.put("Password", account.getPass());

		return postSuccessful(jsonParam, requestURL);
	}	
	
	
}
