package uit.aep06.phuctung.ara.CommonClass;

import android.content.Intent;
import uit.aep06.phuctung.ara.HelperTargetDefaultActivity;

public class TargetGPS extends Target {

	private String address;
	
	public String getAddress() {		
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	@Override
	public void Helper() {
		// TODO Auto-generated method stub
		Intent intent = new Intent(getContext(),HelperTargetDefaultActivity.class);
		intent.putExtra("GPS", getAddress());
		getContext().startActivity(intent);
	}

}
