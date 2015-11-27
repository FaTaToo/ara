package uit.aep06.phuctung.ara.custom_listview;

import java.util.List;

import android.content.Context;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import uit.aep06.phuctung.ara.R;
import uit.aep06.phuctung.ara.CommonClass.Program;

public class ProgramAdapter extends ArrayAdapter<Program> {

	List<Program> listPrograms;	
	Context context;	
	int resource;
	Program program;
	
	public ProgramAdapter(Context context, int resource, List<Program> listPrograms) {
		super(context, resource, listPrograms);
		// TODO Auto-generated constructor stub
		this.context = context;
		this.resource = resource;
		this.listPrograms = listPrograms;
	}

	public View getView(int position, View convertView, ViewGroup parent) {
		LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		View rowView = inflater.inflate(R.layout.program_list_item, parent, true);

		TextView tvName = (TextView) rowView.findViewById(R.id.txtName);
		tvName.setTextColor(Color.BLACK);
		tvName.setTextSize(20);

		TextView tvDateStart = (TextView) rowView.findViewById(R.id.txtStart);
		tvDateStart.setTextSize(15);

		TextView tvDateEnd = (TextView) rowView.findViewById(R.id.txtEnd);
		tvDateEnd.setTextSize(15);

		TextView tvCompany = (TextView) rowView.findViewById(R.id.txtCompany);
		tvCompany.setTextSize(15);

		TextView tvContent = (TextView) rowView.findViewById(R.id.txtDescription);
		tvContent.setTextSize(15);

		ImageView imgCheck = (ImageView) rowView.findViewById(R.id.imgCheck);

		TextView tvNum = (TextView) rowView.findViewById(R.id.txtNumTarget);
		tvNum.setTextSize(17);

		ProgressBar pBar = (ProgressBar) rowView.findViewById(R.id.pBar);
		
		program = listPrograms.get(position);
        if(program != null) {
        	tvName.setText("Program's name: " + program.getName());
        	tvContent.setText("Description: " + program.getContent());
        	tvDateStart.setText("Start date: " + program.getDateStart().substring(0, 10));
        	tvDateEnd.setText("   End date: " +program.getDateEnd().substring(0, 10));
        	tvCompany.setText("Company: " +program.getCompany());
        	tvNum.setText(Html.fromHtml("<b>"+program.getNumTargetFinish()+"/"+program.getNumTarget()+"</b>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" ));
        	pBar.setMax(program.getNumTarget());
        	pBar.setProgress(program.getNumTargetFinish());
        	pBar.getProgressDrawable().setColorFilter(Color.RED, Mode.SRC_IN);
        	//set check icon for program if done
        }		
		return rowView;
	}

}
