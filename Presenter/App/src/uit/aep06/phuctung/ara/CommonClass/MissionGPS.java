package uit.aep06.phuctung.ara.CommonClass;

import android.content.Intent;
import uit.aep06.phuctung.ara.HelperTargetGPSActivity;

public class MissionGPS extends Mission {

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
		Intent intent = new Intent(getContext(), HelperTargetGPSActivity.class);
		intent.putExtra("GPS", getAddress());
		getContext().startActivity(intent);
	}

}
