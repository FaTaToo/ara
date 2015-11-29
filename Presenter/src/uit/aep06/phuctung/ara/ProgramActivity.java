package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;

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
import uit.aep06.phuctung.ara.custom_adapter.ViewPagerAdapter;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;

public class ProgramActivity extends FragmentActivity {
	String CustomerID;
	
	ViewPager pager;
    ViewPagerAdapter adapter;
    SlidingTabLayout tabs;
    CharSequence Titles[]={"All","Checked", "Unchecked"};
	List<Program> listProgram = new ArrayList<Program>();
	
    int Numboftabs = 3;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_program);
		
		// Creating The ViewPagerAdapter and Passing Fragment Manager, Titles fot the Tabs and Number Of Tabs.
		listProgram.add(new Program("1", "a", "content aa", "11/5/2015aaaaa", "11/6/2015sssss", "A", 1, 3, 0));
		listProgram.add(new Program("1", "b", "content bb", "11/5/201aaaaa5", "11/6/2015sssss", "B", 0, 3, 0));
		listProgram.add(new Program("1", "c", "content cc", "11/5/20aaaaaaa15", "11/6/2015sssss", "C", 0, 3, 0));
		listProgram.add(new Program("1", "d", "content dd", "11/5/2015aaaaa", "11/6/2015sssss", "D", 1, 3, 0));
		
		
        adapter =  new ViewPagerAdapter(getSupportFragmentManager(),Titles,Numboftabs,listProgram);
		
        // Assigning ViewPager View and setting the adapter
        pager = (ViewPager) findViewById(R.id.pager);
        pager.setAdapter(adapter);
 
        // Assiging the Sliding Tab Layout View
        tabs = (SlidingTabLayout) findViewById(R.id.tabs);
        tabs.setDistributeEvenly(true); // To make the Tabs Fixed set this true, This makes the tabs Space Evenly in Available width
 
        // Setting Custom Color for the Scroll bar indicator of the Tab View
        tabs.setCustomTabColorizer(new SlidingTabLayout.TabColorizer() {
            @Override
            public int getIndicatorColor(int position) {
                return getResources().getColor(R.color.tabsScrollColor);
            }
        });
 
        // Setting the ViewPager For the SlidingTabsLayout
        tabs.setViewPager(pager);
		
		
//		Intent intent = getIntent();
//		CustomerID = intent.getStringExtra("customerID");
//		BackgroundTask task = new BackgroundTask();
//		task.execute();
	}
	private class BackgroundTask extends AsyncTask<Void, Void, Void> {
		private ProgressDialog dialog;
		
		@Override
	    protected void onPreExecute() {
	    	dialog = new ProgressDialog(ProgramActivity.this);
	    	dialog.setCancelable(false);
	        dialog.setMessage("Waiting for loading....");
	        dialog.show();
	    }
		
		@Override
	    protected void onPostExecute(Void result) {
	        if (dialog.isShowing()) {
	            dialog.dismiss();
	        }
	    }
		
		@Override
		protected Void doInBackground(Void... params) {
			// TODO Auto-generated method stub
			return null;
		}
		
	}
}
