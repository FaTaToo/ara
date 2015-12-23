package uit.aep06.phuctung.ara.CommonClass;

public class Subscription {
	public String ID;
	public String customerID;
	public String programID;
	public String dateStart;
	public String dateEnd;
	public String gift;
	
	public String getID(){
		return ID;
	}
	
	public String getCustomerID(){
		return customerID;
	}
	
	public String getProgramID(){
		return programID;
	}
	
	public String getDateStart(){
		return dateStart;
	}
	
	public String getDateEnd(){
		return dateEnd;
	}
	
	public String getGift(){
		return gift;
	}
	
	public void setID(String ID){
		this.ID = ID ;
	}
	
	public void setCustomerID(String customerID){
		this.customerID = customerID;
	}
	
	public void setProgramID(String programID){
		this.programID = programID;
	}
	
	public void setDateStart(String dateStart){
		this.dateStart = dateStart;
	}
	
	public void setDateEnd(String dateEnd){
		this.dateEnd = dateEnd;
	}
	
	
}
