package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
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
import uit.aep06.phuctung.ara.Service.MissionService;
import uit.aep06.phuctung.ara.Service.ProgramService;
import uit.aep06.phuctung.ara.Service.SubscriptionService;
import uit.aep06.phuctung.ara.custom_adapter.MissionAdapter;

public class MissionActivity extends Activity {
	String customerID, programID;
	int programState, programType;
	List<Mission> listMissions = new ArrayList<Mission>();
	ListView listView;
	final Context context = this;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_mission);
		Intent intent = getIntent();
		programID = intent.getStringExtra("ID");
		customerID = intent.getStringExtra("CustomerID");
		programState = intent.getIntExtra("ProgramState", 0);
		programType = intent.getIntExtra("programType", 0);

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

		Button btnDoMission = (Button) findViewById(R.id.btnDoMission);
		if (programType == 0) {
			btnDoMission.setText("Check in");
		} else {
			btnDoMission.setText("Scan");
		}

		btnDoMission.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				// can phai check join hay chua
				if (programType == 0) {
					Mission mission = listMissions.get(0);
					boolean result = checkIn(mission.getMissionID());
					if (result) {
						Handler handler = new Handler();
						handler.postDelayed(new Runnable() {
							@Override
							public void run() {
								
								final Dialog dialog = new Dialog(context);
								dialog.setContentView(R.layout.custom_dialog);
								dialog.setTitle("CHÚC MỪNG");
								
								TextView text = (TextView) dialog.findViewById(R.id.text);
								text.setText("Xin chúc mừng bạn đã hoàn thành chiến dịch! Phần thưởng của bạn là giảm giá vé 10% khi xem phim Diệp Vấn 3");
							
								Button dialogButton = (Button) dialog.findViewById(R.id.dialogButtonOK);								
								dialogButton.setOnClickListener(new OnClickListener() {
									@Override
									public void onClick(View v) {
										dialog.dismiss();
									}
								});
								dialog.show();
							}
						}, 2000);						
					}
				} else {
					Intent intent = new Intent(getApplicationContext(), CameraActivity.class);
					intent.putExtra("customerID", customerID);
					startActivity(intent);
				}
			}
		});

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
					programState = 1; // implement code to update to service
				} else {
					DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {

						@Override
						public void onClick(DialogInterface dialog, int which) {
							switch (which) {
							case DialogInterface.BUTTON_POSITIVE:
								int result = subService.leaveProgram(sub);
								btnJoin.setText("Join program");
								programState = 0;// implement code to update to
													// service
								break;

							case DialogInterface.BUTTON_NEGATIVE:
								Toast.makeText(getApplicationContext(), "Cancel leaving program...", Toast.LENGTH_LONG)
										.show();
								break;
							}
						}
					};
					AlertDialog.Builder builder = new AlertDialog.Builder(MissionActivity.this);
					builder.setMessage("Are you sure to exit this program?")
							.setPositiveButton("Yes", dialogClickListener)
							.setNegativeButton("Cancel", dialogClickListener).show();
				}
			}
		});

		listView = (ListView) findViewById(R.id.lvMission);
		ListMissionTask task = new ListMissionTask();
		task.execute();
	}

	private void loadListViewMission() {
		MissionAdapter missionAdapter = new MissionAdapter(this, R.layout.mission_list_item, listMissions);
		for (Mission mission : listMissions) {
			// implement code to process TargetGPS
			MissionService missionService = new MissionService();
			mission.setState(missionService.checkTargetState(mission.getMissionID(), customerID));
			mission.setContext(this);
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

	private boolean checkIn(String missionID){
		ProgressDialog progress = new ProgressDialog(this);
		progress.setTitle("Loading");
		progress.setMessage("Wait while loading...");
		progress.show();
		
		
		// To dismiss the dialog
		progress.dismiss();
		return true;
	}

	private class CompleteMissionTask extends AsyncTask<String, Void, Integer> {

		@Override
		protected Integer doInBackground(String... params) {
			SubscriptionService subcriptionService = new SubscriptionService();
			String rowVersion = subcriptionService.getSubcription(customerID, programID).getRowVersion();
			try {
				return subcriptionService.updateCompletedMission(customerID, programID, params[0], rowVersion);
			} catch (JSONException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return 0;
		}

	}

	private class ListMissionTask extends AsyncTask<Void, Void, Void> {
		private ProgressDialog dialog;

		@Override
		protected void onPreExecute() {
			dialog = new ProgressDialog(MissionActivity.this);
			dialog.setCancelable(false);
			dialog.setMessage("Đang tải dữ liệu... Vui lòng chờ!");
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
