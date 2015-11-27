package uit.aep06.phuctung.ara;

import java.util.List;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import uit.aep06.phuctung.ara.CommonClass.Program;

public class ViewPagerAdapter extends FragmentStatePagerAdapter {
	 
    CharSequence Titles[]; // This will Store the Titles of the Tabs which are Going to be passed when ViewPagerAdapter is created
    int NumbOfTabs; // Store the number of tabs, this will also be passed when the ViewPagerAdapter is created
    List<Program> listPrograms;
 
    // Build a Constructor and assign the passed Values to appropriate values in the class
    public ViewPagerAdapter(FragmentManager fm,CharSequence mTitles[], int mNumbOfTabsumb,List<Program> listPrograms ) {
        super(fm);
 
        this.Titles = mTitles;
        this.NumbOfTabs = mNumbOfTabsumb;
        this.listPrograms = listPrograms;
    }
 
    //This method return the fragment for the every position in the View Pager
    @Override
    public Fragment getItem(int position) {
    	ProgramTabAll tabAll; 
    	switch (position) {
		case 0:
			//textView
            tabAll = new ProgramTabAll("", listPrograms);
            break;
		case 1: 
			tabAll = new ProgramTabAll("", listPrograms);
			break;
		default: 
			tabAll = new ProgramTabAll("", listPrograms);
		}    	
    	return tabAll;
	}
 
    // This method return the titles for the Tabs in the Tab Strip
 
    @Override
    public CharSequence getPageTitle(int position) {
        return Titles[position];
    }
 
    // This method return the Number of tabs for the tabs Strip
 
    @Override
    public int getCount() {
        return NumbOfTabs;
    }
}
