package uit.aep06.phuctung.ara.Service;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;

import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONTokener;

import uit.aep06.phuctung.ara.CommonClass.Subscription;

public class Service {
	protected String serviceURL = "http://ara288.somee.com/Services/Presenter/CustomerAccount.svc";

	protected JSONObject post(JSONObject jsonParam, String requestURL) {
		URL url;
		HttpURLConnection connection = null;

		try {
			// Create connection
			url = new URL(requestURL);
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
			return resultObject;
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		} finally {
			if (connection != null) {
				connection.disconnect();
			}
		}
	}

	protected int postSuccessful(JSONObject jsonParam, String requestURL) {
		JSONObject jsonResult = post(jsonParam, requestURL);
		if (jsonResult != null) {
			String result;
			try {
				result = jsonResult.getString("Message");
				if (result.equals("Successfully")) {
					return 1;
				} else {
					return 0;
				}
			} catch (JSONException e) {
				return 0;
			}			
		} else {
			return 0;
		}
	}
	
	protected JSONObject get(String requestURL) {
		JSONObject jsonResult = post(null, requestURL);
		return jsonResult;
	}
}
