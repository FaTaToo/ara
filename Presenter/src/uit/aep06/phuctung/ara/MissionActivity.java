package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.os.Bundle;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import uit.aep06.phuctung.ara.CommonClass.Target;

public class MissionActivity extends Activity {
	String CustomerID;
	String ProgramID;
	int ProgramState;
	List<Target> listTarget = new ArrayList<Target>();
	ListView lv;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_mission);
		Intent intent = getIntent();
		
		TextView  tvName = (TextView)findViewById(R.id.txtName);
        tvName.setTextColor(Color.RED);
        tvName.setTextSize(20);
        
        TextView tvDateStart =(TextView)findViewById(R.id.txtStart);
        tvDateStart.setTextSize(15);

        TextView tvDateEnd =(TextView)findViewById(R.id.txtEnd);
        tvDateEnd.setTextSize(15);
        
        TextView tvCompany =(TextView)findViewById(R.id.txtCompany);
        tvCompany.setTextSize(15);
        
        TextView tvContent =(TextView)findViewById(R.id.txtDescription);
        tvContent.setTextSize(15);

        tvName.setText("Program: " + intent.getStringExtra("Name"));
    	tvContent.setText("Description: " +intent.getStringExtra("Description"));
    	tvDateStart.setText("Start: " +intent.getStringExtra("Start").substring(0, 10));
    	tvDateEnd.setText("End: " +intent.getStringExtra("End").substring(0, 10));
    	tvCompany.setText("Company: " +intent.getStringExtra("Company"));
    	
    	TextView tvNumProgress = (TextView)findViewById(R.id.txtNumTarget);
    	tvNumProgress.setTextSize(17);
    	tvNumProgress.setText(intent.getIntExtra("NumTarget",0)+"/"+intent.getIntExtra("NumTargetFinish",0));
    	
    	ProgressBar pBar = (ProgressBar)findViewById(R.id.pBar);
    	pBar.setMax(intent.getIntExtra("NumTarget", 0));
    	pBar.setProgress(intent.getIntExtra("NumTargetFinish", 0));
    	pBar.getProgressDrawable().setColorFilter(Color.RED, Mode.SRC_IN);
    	
    	Button btnScan = (Button)findViewById(R.id.btnScan);
    	btnScan.setOnClickListener(new OnClickListener() {
    		@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(getApplicationContext(),CameraActivity.class);
				intent.putExtra("customerID", CustomerID);
				startActivity(intent);
			}
		});    	
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.mission, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
	    // Handle item selection
	    switch (item.getItemId()) {
	        case R.id.profile:
	        	Intent intent = new Intent(getApplicationContext(),ProfileActivity.class);
	    		intent.putExtra("customerID",CustomerID );
	    		startActivity(intent);
	            return true;
	        case R.id.scan:
	        	intent = new Intent(getApplicationContext(),CameraActivity.class);
	    		startActivity(intent);
	            return true;
	        case R.id.about:
	        	intent = new Intent(getApplicationContext(),AboutActivity.class);
	    		startActivity(intent);
	            return true;
	        default:
	            return super.onOptionsItemSelected(item);
	    }
	}
}
