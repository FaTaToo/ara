package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;
import uit.aep06.phuctung.ara.CommonClass.Mission;
import uit.aep06.phuctung.ara.CommonClass.Subscription;
import uit.aep06.phuctung.ara.Service.ProgramService;
import uit.aep06.phuctung.ara.Service.SubscriptionService;
import uit.aep06.phuctung.ara.Service.TargetService;
import uit.aep06.phuctung.ara.custom_adapter.MissionAdapter;

public class MissionActivity extends Activity {
	String customerID;
	String programID;
	int programState;
	List<Mission> listMissions = new ArrayList<Mission>();
	ListView listView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_mission);
		Intent intent = getIntent();

		TextView tvName = (TextView) findViewById(R.id.txtName);
		tvName.setTextColor(Color.BLUE);
		tvName.setTextSize(20);

		tvName.setText(intent.getStringExtra("Name"));

		TextView tvNumProgress = (TextView) findViewById(R.id.txtNumMission);
		tvNumProgress.setTextSize(17);
		tvNumProgress.setTextColor(Color.RED);
		tvNumProgress.setText(intent.getIntExtra("NumMission", 0) + "/" + intent.getIntExtra("NumMissionFinish", 0));

		ProgressBar pBar = (ProgressBar) findViewById(R.id.pBar);
		pBar.setMax(intent.getIntExtra("NumMission", 0));
		pBar.setProgress(intent.getIntExtra("NumMissionFinish", 0));
		pBar.getProgressDrawable().setColorFilter(Color.RED, Mode.SRC_IN);

		Button btnScan = (Button) findViewById(R.id.btnScan);
		btnScan.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(getApplicationContext(), CameraActivity.class);
				intent.putExtra("customerID", customerID);
				startActivity(intent);
			}
		});
		
		programID = intent.getStringExtra("ID");
    	customerID = intent.getStringExtra("CustomerID");
    	programState = intent.getIntExtra("ProgramState", 0);

    	final SubscriptionService subService = new SubscriptionService();
		final Subscription sub = new Subscription();
		sub.setCustomerID(customerID);
		sub.setProgramID(programID);
		final Button btnJoin = (Button) findViewById(R.id.btnJoin);
		if (programState == 0) {
			btnJoin.setText("Join program");
		} else {
			btnJoin.setText("Leave program");
		}
		btnJoin.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				if (programState == 0) {
					int result = subService.joinProgram(sub);
					btnJoin.setText("Leave program");
				} else {
					DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {

						@Override
						public void onClick(DialogInterface dialog, int which) {							
							switch (which) {
							case DialogInterface.BUTTON_POSITIVE:
								int result = subService.leaveProgram(sub);
								btnJoin.setText("Join program");
								break;

							case DialogInterface.BUTTON_NEGATIVE:
								Toast.makeText(getApplicationContext(), "Cancel leaving program...", Toast.LENGTH_LONG).show();
								break;
							}
						}
						
					};
				}
			}
		});
		
		listView = (ListView) findViewById(R.id.lvMission);
		BackgroundTask task = new BackgroundTask();
		task.execute();
	}

	private void loadListViewMission() {
		MissionAdapter missionAdapter = new MissionAdapter(this, R.layout.mission_list_item, listMissions);
		for (Mission t : listMissions) {
			// implement code to process TargetGPS
			TargetService targetService = new TargetService();
			t.setState(targetService.checkTargetState(t.getTargetID(), customerID));
			t.setContext(this);
		}

		missionAdapter.notifyDataSetChanged();
		listView.setAdapter(missionAdapter);
	}

	private void loadMission() {
		ProgramService service = new ProgramService();
		try {
			listMissions = service.getListMission(programID);
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
			if (dialog.isShowing()) {
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
			intent.putExtra("customerID", customerID);
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
