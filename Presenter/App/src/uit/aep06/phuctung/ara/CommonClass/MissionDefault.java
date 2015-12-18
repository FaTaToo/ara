package uit.aep06.phuctung.ara.CommonClass;

import android.content.Intent;
import uit.aep06.phuctung.ara.HelperTargetDefaultActivity;

public class MissionDefault extends Mission {

	@Override
	public void Helper() {
		Intent intent = new Intent(getContext(),HelperTargetDefaultActivity.class);
		intent.putExtra("Url", this.url);
		getContext().startActivity(intent);
	}

}
