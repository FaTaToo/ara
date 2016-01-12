package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;

import android.app.ActionBar;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import uit.aep06.phuctung.ara.CommonClass.Program;
import uit.aep06.phuctung.ara.Library.SlidingTabLayout;
import uit.aep06.phuctung.ara.Service.ProgramService;
import uit.aep06.phuctung.ara.custom_adapter.ViewPagerAdapter;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;

public class ProgramActivity extends FragmentActivity {
	String CustomerID;

	ViewPager pager;
	ViewPagerAdapter adapter;
	SlidingTabLayout tabs;
	CharSequence Titles[] = { "All", "Checked", "Unchecked" };
	List<Program> listProgram = new ArrayList<Program>();

	int Numboftabs = 3;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_program);

		// Creating The ViewPagerAdapter and Passing Fragment Manager, Titles
		// fot the Tabs and Number Of Tabs.
		ProgramBackgroundTask programTask = new ProgramBackgroundTask();
		try {
			listProgram = programTask.execute().get();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ExecutionException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		adapter = new ViewPagerAdapter(getSupportFragmentManager(), Titles, Numboftabs, listProgram);

		// Assigning ViewPager View and setting the adapter
		pager = (ViewPager) findViewById(R.id.pager);
		pager.setAdapter(adapter);

		// Assiging the Sliding Tab Layout View
		tabs = (SlidingTabLayout) findViewById(R.id.tabs);
		tabs.setDistributeEvenly(true); // To make the Tabs Fixed set this true,
										// This makes the tabs Space Evenly in
										// Available width

		// Setting Custom Color for the Scroll bar indicator of the Tab View
		tabs.setCustomTabColorizer(new SlidingTabLayout.TabColorizer() {
			@Override
			public int getIndicatorColor(int position) {
				return getResources().getColor(R.color.tabsScrollColor);
			}
		});

		// Setting the ViewPager For the SlidingTabsLayout
		tabs.setViewPager(pager);		
	}

	private class ProgramBackgroundTask extends AsyncTask<Void, Void, List<Program>> { 
		private ProgressDialog dialog;		

		@Override
		protected void onPreExecute() {
			dialog = new ProgressDialog(ProgramActivity.this);
			dialog.setCancelable(false);
			dialog.setMessage("Đang tải dữ liệu chiến dịch... Vui lòng chờ!");
			dialog.show();
		};

		@Override
		protected void onPostExecute(List<Program> result) {
			if (dialog.isShowing()) {
				dialog.dismiss();
			}
		};

		@Override
		protected List<Program> doInBackground(Void... params) {			
			ProgramService programService = new ProgramService();
			return programService.getListProgram();			
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
