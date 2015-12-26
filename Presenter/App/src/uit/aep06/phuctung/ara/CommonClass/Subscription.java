package uit.aep06.phuctung.ara.CommonClass;

import java.util.ArrayList;
import java.util.List;

public class Subscription {

	private String customerID;
	private String programID;
	private boolean isComplete;
	private List<String> completedMissions;
	private int numCompletedMissions;
	private String comment;
	private int rating;
	private String rowVersion;

	private String subcriptionID;

	public String getSubcriptionID() {
		return subcriptionID;
	}

	public void setSubcriptionID(String subcriptionID) {
		this.subcriptionID = subcriptionID;
	}

	public String getCustomerID() {
		return customerID;
	}

	public void setCustomerID(String customerID) {
		this.customerID = customerID;
	}

	public String getProgramID() {
		return programID;
	}

	public void setProgramID(String programID) {
		this.programID = programID;
	}

	public boolean isComplete() {
		return isComplete;
	}

	public void setComplete(boolean isComplete) {
		this.isComplete = isComplete;
	}

	public void setComplete(String comlete) {
		if (comlete.compareTo("True") == 0) {
			setComplete(true);
		} else {
			setComplete(false);
		}
	}

	public List<String> getCompletedMissions() {
		return completedMissions;
	}	

	public void setCompletedMissions(List<String> completedMissions) {
		this.completedMissions = completedMissions;
	}

	public void setCompletedMissions(String completedMissions) {
		String[] arrayMissions = completedMissions.split(";");
		for(int i=0; i<arrayMissions.length; i++) {
			this.completedMissions.add(arrayMissions[i]);
		}	
	}
	
	public int getNumCompletedMissions() {
		return numCompletedMissions;
	}

	public void setNumCompletedMissions(int numCompletedMissions) {
		this.numCompletedMissions = numCompletedMissions;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public int getRating() {
		return rating;
	}

	public void setRating(int rating) {
		this.rating = rating;
	}

	public String getRowVersion() {
		return rowVersion;
	}

	public void setRowVersion(String rowVersion) {
		this.rowVersion = rowVersion;
	}
}