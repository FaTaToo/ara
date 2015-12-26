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

public class CustomerAccountService {
	String targetURL = "http://ara288.somee.com/Services/Presenter/CustomerAccount.svc";

	public int addNewCustomerAccount(CustomerAccount account) throws JSONException {
		targetURL += "/SignUp";
		// Create JSONObject here
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

		return accessCustomerAccountService(jsonParam);

	}

	public int authenticate(CustomerAccount account) throws IOException, JSONException {
		targetURL += "/Authenticate";

		URL url;
		HttpURLConnection connection = null;

		// Create JSONObject here
		JSONObject jsonParam = new JSONObject();
		jsonParam.put("UserName", account.getUsername());
		jsonParam.put("Password", account.getPass());

		return accessCustomerAccountService(jsonParam);
	}

	private int accessCustomerAccountService(JSONObject jsonParam) {
		URL url;
		HttpURLConnection connection = null;

		try {
			// Create connection
			url = new URL(targetURL);
			connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("POST");
			connection.setRequestProperty("Content-Type", "application/json; charset=UTF-8");
			connection.setRequestProperty("Accept", "application/json");

			connection.setUseCaches(false);
			connection.setDoInput(true);
			connection.setDoOutput(true);

			// Send request
			OutputStreamWriter wr = new OutputStreamWriter(connection.getOutputStream());
			wr.write(jsonParam.toString());
			wr.flush();

			// Get Response
			InputStream is = connection.getInputStream();
			BufferedReader rd = new BufferedReader(new InputStreamReader(is));
			String line;

			StringBuilder builder = new StringBuilder();
			while ((line = rd.readLine()) != null) {
				builder.append(line).append("\n");
			}
			rd.close();

			JSONTokener tokener = new JSONTokener(builder.toString());
			JSONObject resultObject = new JSONObject(tokener);
			String result = resultObject.getString("Message");
			if (result.equals("Successfully")) {
				return 1;
			} else {
				return 0;
			}
		} catch (Exception e) {
			e.printStackTrace();
			return 0;
		} finally {
			if (connection != null) {
				connection.disconnect();
			}
		}
	}	
}
