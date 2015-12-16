package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.os.AsyncTask;
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
import uit.aep06.phuctung.ara.Service.ProgramService;
import uit.aep06.phuctung.ara.Service.TargetService;
import uit.aep06.phuctung.ara.custom_adapter.MissionAdapter;

public class MissionActivity extends Activity {
	String CustomerID;
	String ProgramID;
	int ProgramState;
	List<Target> listTargets = new ArrayList<Target>();
	ListView listView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_mission);
		Intent intent = getIntent();

		TextView tvName = (TextView) findViewById(R.id.txtName);
		tvName.setTextColor(Color.RED);
		tvName.setTextSize(20);

		TextView tvDateStart = (TextView) findViewById(R.id.txtStart);
		tvDateStart.setTextSize(15);

		TextView tvDateEnd = (TextView) findViewById(R.id.txtEnd);
		tvDateEnd.setTextSize(15);

		TextView tvCompany = (TextView) findViewById(R.id.txtCompany);
		tvCompany.setTextSize(15);

		TextView tvContent = (TextView) findViewById(R.id.txtDescription);
		tvContent.setTextSize(15);

		tvName.setText("Program: " + intent.getStringExtra("Name"));
		tvContent.setText("Description: " + intent.getStringExtra("Description"));
		tvDateStart.setText("Start: " + intent.getStringExtra("Start").substring(0, 10));
		tvDateEnd.setText("End: " + intent.getStringExtra("End").substring(0, 10));
		tvCompany.setText("Company: " + intent.getStringExtra("Company"));

		TextView tvNumProgress = (TextView) findViewById(R.id.txtNumTarget);
		tvNumProgress.setTextSize(17);
		tvNumProgress.setText(intent.getIntExtra("NumTarget", 0) + "/" + intent.getIntExtra("NumTargetFinish", 0));

		ProgressBar pBar = (ProgressBar) findViewById(R.id.pBar);
		pBar.setMax(intent.getIntExtra("NumTarget", 0));
		pBar.setProgress(intent.getIntExtra("NumTargetFinish", 0));
		pBar.getProgressDrawable().setColorFilter(Color.RED, Mode.SRC_IN);

		Button btnScan = (Button) findViewById(R.id.btnScan);
		btnScan.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(getApplicationContext(), CameraActivity.class);
				intent.putExtra("customerID", CustomerID);
				startActivity(intent);
			}
		});

		listView = (ListView) findViewById(R.id.lvMission);
		BackgroundTask task = new BackgroundTask();
		task.execute();
	}
	
	private void loadListViewMission() {
		MissionAdapter missionAdapter = new MissionAdapter(this, R.layout.mission_list_item, listTargets);
		for (Target t : listTargets) {
			// implement code to process TargetGPS
			TargetService targetService = new TargetService();
			t.setState(targetService.checkTargetState(t.getTargetID(), CustomerID));
			t.setContext(this);
		}

		missionAdapter.notifyDataSetChanged();
		listView.setAdapter(missionAdapter);
	}
	
	private void loadMission() {
		ProgramService service = new ProgramService();
		try {
			listTargets = service.getListTarget(ProgramID);
		} catch (JSONException e) {
			e.printStackTrace();
		}
	}

	private class BackgroundTask extends AsyncTask<Void, Void, Void> {
		private ProgressDialog dialog;
		
		@Override
		protected void onPreExecute() {
			dialog = new ProgressDialog(MissionActivity.this);
			dialog.setCancelable(false);
			dialog.setMessage("Downloading mission data. Please wait!");
			dialog.show();
		};
		
		@Override
		protected void onPostExecute(Void result) {
			if(dialog.isShowing()){
				dialog.dismiss();
			}
		};
		
		@Override
		protected Void doInBackground(Void... params) {
			loadMission();
			runOnUiThread(new Runnable() {
				
				@Override
				public void run() {
					// TODO Auto-generated method stub
					loadListViewMission();
				}
			});
			return null;
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle item selection
		switch (item.getItemId()) {
		case R.id.profile:
			Intent intent = new Intent(getApplicationContext(), ProfileActivity.class);
			intent.putExtra("customerID", CustomerID);
			startActivity(intent);
			return true;
		case R.id.scan:
			intent = new Intent(getApplicationContext(), CameraActivity.class);
			startActivity(intent);
			return true;
		case R.id.about:
			intent = new Intent(getApplicationContext(), AboutActivity.class);
			startActivity(intent);
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}
}
