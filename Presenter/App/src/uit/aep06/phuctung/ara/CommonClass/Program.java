package uit.aep06.phuctung.ara.CommonClass;

import java.io.Serializable;

public class Program {
	public  String id;
	public  String name;
	public  String content;
	public  String dateStart;
	public  String dateEnd;
	public  String company;
	public int state;//0 for unchecked and 1 for checked state
	public int numTarget;
	public int numTargetFinish;
	
	public Program(String id, String name, String content, String dateStart, String dateEnd, String company, int state, int numTarget, int numTargetFinish){
		this.id = id;
		this.name = name;
		this.content = content;
		this.dateStart = dateStart;
		this.dateEnd = dateEnd;
		this.company = company;
		this.state = state;
		this.numTarget = numTarget;
		this.numTargetFinish = numTargetFinish;				
	}
	
	public int getNumTarget() {
		return numTarget;
	}
	public void setNumTarget(int numTarget) {
		this.numTarget = numTarget;
	}
	public int getNumTargetFinish() {
		return numTargetFinish;
	}
	public void setNumTargetFinish(int numTargetFinish) {
		this.numTargetFinish = numTargetFinish;
	}
	public int getState() {
		return state;
	}
	public void setState(int state) {
		this.state = state;
	}
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public String getDateStart() {
		return dateStart;
	}
	public void setDateStart(String dateStart) {
		this.dateStart = dateStart;
	}
	public String getDateEnd() {
		return dateEnd;
	}
	public void setDateEnd(String dateEnd) {
		this.dateEnd = dateEnd;
	}
	public String getCompany() {
		return company;
	}
	public void setCompany(String company) {
		this.company = company;
	}
}

