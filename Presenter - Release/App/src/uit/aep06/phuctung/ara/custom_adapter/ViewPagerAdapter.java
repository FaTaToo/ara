package uit.aep06.phuctung.ara.custom_adapter;

import java.util.ArrayList;
import java.util.List;

import android.app.ListFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import uit.aep06.phuctung.ara.ProgramTab;
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
    	ProgramTab tabAll; 
    	switch (position) {
		case 0:
			//textView
            tabAll = new ProgramTab("0", this.listPrograms);
            break;
		case 1: 
			tabAll = new ProgramTab("1", getListProgramsChecked(this.listPrograms));
			break;
		default: 
			tabAll = new ProgramTab("2", getListProgramsUnchecked(this.listPrograms));
		}    	
    	return tabAll;
	}
 
    private List<Program> getListProgramsChecked(List<Program> listPrograms){
    	List<Program> checkedList = new ArrayList<Program>();
    	for(int i = 0; i < listPrograms.size(); i++) {
    		if(listPrograms.get(i).state == 1) {
    			checkedList.add(listPrograms.get(i));
    		}
    	}
    	return checkedList;
    }
    
    private List<Program> getListProgramsUnchecked(List<Program> listPrograms){
    	List<Program> uncheckedList = new ArrayList<Program>();
    	for(int i = 0; i < listPrograms.size(); i++) {
    		if(listPrograms.get(i).state == 0) {
    			uncheckedList.add(listPrograms.get(i));
    		}
    	}
    	return uncheckedList;
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
