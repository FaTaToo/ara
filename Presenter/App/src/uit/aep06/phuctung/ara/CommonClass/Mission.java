package uit.aep06.phuctung.ara.CommonClass;

import java.io.Serializable;

import android.content.Context;

public abstract class Mission{		    		  
	public  String targetID;
	public  String targetContent;
	public  String url;
	public  String name;
	public  String videoUrl;
	public  String facebookUrl;
	public  String director;
	public  String actor;
	public  String year;
	public  String description;
	public  String programID;
	public int state;
	public int type;
	public int getType() {
		return type;
	}
	public void setType(int type) {
		this.type = type;
	}

	public Context context;
	
	public Context getContext() {
		return context;
	}
	public void setContext(Context context) {
		this.context = context;
	}
	
	public int getState() {
		return state;
	}
	public void setState(int state) {
		this.state = state;
	}
	public String getTargetID() {
		return targetID;
	}
	public void setTargetID(String targetID) {
		this.targetID = targetID;
	}
	public String getTargetContent() {
		return targetContent;
	}
	public void setTargetContent(String targetContent) {
		this.targetContent = targetContent;
	}
	public String getUrl() {
		return url;
	}
	public void setUrl(String url) {
		this.url = url;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getVideoUrl() {
		return videoUrl;
	}
	public void setVideoUrl(String videoUrl) {
		this.videoUrl = videoUrl;
	}
	public String getFacebookUrl() {
		return facebookUrl;
	}
	public void setFacebookUrl(String facebookUrl) {
		this.facebookUrl = facebookUrl;
	}
	public String getDirector() {
		return director;
	}
	public void setDirector(String director) {
		this.director = director;
	}
	public String getActor() {
		return actor;
	}
	public void setActor(String actor) {
		this.actor = actor;
	}
	public String getYear() {
		return year;
	}
	public void setYear(String year) {
		this.year = year;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getProgramID() {
		return programID;
	}
	public void setProgramID(String programID) {
		this.programID = programID;
	}
	
	public abstract void Helper();
	
}
