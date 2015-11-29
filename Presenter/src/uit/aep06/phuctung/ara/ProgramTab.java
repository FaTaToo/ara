package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.List;


import android.app.ListFragment;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView.FindListener;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;
import uit.aep06.phuctung.ara.CommonClass.Program;
import uit.aep06.phuctung.ara.custom_adapter.ProgramAdapter;

public class ProgramTab extends Fragment {
	List<Program> listProgram;	;
	ListView listView;
	String CustomerID;
	public ProgramTab(String userID,List<Program> list) {
		CustomerID = userID;
		listProgram = list;
	}
	@Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view =inflater.inflate(R.layout.program_tab,container,false);
        listView = (ListView)view.findViewById(R.id.lvProgramAll);
        return view;
    }
	
	@Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
       LoadListView();
    }
    @Override
    public void onResume() {
    	// TODO Auto-generated method stub
    	super.onResume();
    	LoadListView();
    }
    public void LoadListView()
    {
    	ProgramAdapter da = new ProgramAdapter(getActivity(), R.layout.program_list_item, listProgram);		
    	da.notifyDataSetChanged();
		listView.setAdapter(da);		
    }
}
