package uit.aep06.phuctung.ara.Service;

import org.json.JSONException;
import org.json.JSONObject;

import uit.aep06.phuctung.ara.CommonClass.Subscription;

public class SubscriptionService extends Service {

	public Subscription getSubcription(String customerID, String programID) {
		String requestURL = serviceURL + '/';
		JSONObject jsonResult = get(requestURL);
		Subscription subcsription = new Subscription();
		if (jsonResult != null) {			
			try {
				subcsription.setSubcriptionID(jsonResult.getString("SubscriptionID"));
				subcsription.setProgramID(jsonResult.getString("ProgramID"));
				subcsription.setCustomerID(jsonResult.getString("CustomerID"));
				subcsription.setRowVersion(jsonResult.getString("RowVersion"));
				subcsription.setComment(jsonResult.getString("Comment"));
				subcsription.setComment(jsonResult.getString("IsComplete"));
				subcsription.setNumCompletedMissions(jsonResult.getInt("NumCompletedMissions"));
				subcsription.setRating(jsonResult.getInt("Rating"));
				subcsription.setCompletedMissions(jsonResult.getString("CompletedMissions"));				
			} catch (JSONException e) {				
				e.printStackTrace();
				return subcsription;
			}
		}
		return subcsription;
	}

	public int updateCompletedMission(String customerID, String programID, String missionID, String rowVersion)
			throws JSONException {
		String requestURL = serviceURL + '/';

		JSONObject jsonParam = new JSONObject();
		jsonParam.put("CustomerID", customerID);
		jsonParam.put("ProgramID", programID);
		jsonParam.put("MissionID", missionID);
		jsonParam.put("RowVersion", rowVersion);

		return postSuccessful(jsonParam, requestURL);
	}

	public int joinProgram(Subscription subcription) {
		return 1;
	}

	public int leaveProgram(Subscription subcription) {
		return 1;
	}
}
