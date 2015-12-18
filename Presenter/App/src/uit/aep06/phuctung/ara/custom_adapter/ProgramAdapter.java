package uit.aep06.phuctung.ara.custom_adapter;

import java.util.List;

import android.content.Context;
import android.graphics.Color;
import android.graphics.PorterDuff.Mode;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import uit.aep06.phuctung.ara.R;
import uit.aep06.phuctung.ara.CommonClass.Program;

public class ProgramAdapter extends BaseAdapter {

	List<Program> listPrograms;
	Context context;
	int resource;
	Program program;
	private static LayoutInflater inflater = null;

	public ProgramAdapter(Context context, int resource, List<Program> listPrograms) {
		super();

		this.context = context;
		this.resource = resource;
		this.listPrograms = listPrograms;
		inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return listPrograms.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	private class Holder {
		TextView tvName, tvDateStart, tvDateEnd, tvCompany, tvContent, tvNum;
		ImageView imgCheck;
		ProgressBar pBar;
	}

	public View getView(int position, View convertView, ViewGroup parent) {
		View rowView;
		rowView = inflater.inflate(R.layout.program_list_item, null);
		Holder holder = new Holder();
		holder.tvName = (TextView) rowView.findViewById(R.id.txtName);
		holder.tvName.setTextColor(Color.BLACK);
		holder.tvName.setTextSize(20);

		holder.tvDateStart = (TextView) rowView.findViewById(R.id.txtStart);
		holder.tvDateStart.setTextSize(15);

		holder.tvDateEnd = (TextView) rowView.findViewById(R.id.txtEnd);
		holder.tvDateEnd.setTextSize(15);

		holder.tvCompany = (TextView) rowView.findViewById(R.id.txtCompany);
		holder.tvCompany.setTextSize(15);

		holder.tvContent = (TextView) rowView.findViewById(R.id.txtDescription);
		holder.tvContent.setTextSize(15);

		holder.imgCheck = (ImageView) rowView.findViewById(R.id.imgCheck);

		holder.tvNum = (TextView) rowView.findViewById(R.id.txtNumMission);
		holder.tvNum.setTextSize(17);

		holder.pBar = (ProgressBar) rowView.findViewById(R.id.pBar);

		program = listPrograms.get(position);
		if (program != null) {
			holder.tvName.setText(program.getName());
			holder.tvContent.setText(program.getContent());
			holder.tvDateStart.setText(program.getDateStart());
			holder.tvDateEnd.setText(program.getDateEnd());
			holder.tvCompany.setText(program.getCompany());
			holder.tvNum.setText(Html.fromHtml("<b>" + program.getNumMissionFinish() + "/" + program.getNumMission()));
			holder.pBar.setMax(program.getNumMission());
			holder.pBar.setProgress(program.getNumMissionFinish());
			holder.pBar.getProgressDrawable().setColorFilter(Color.RED, Mode.SRC_IN);
			if (program.state == 1) {
				holder.imgCheck.setBackgroundResource(uit.aep06.phuctung.ara.R.drawable.icon_check);
			}
//			if (program.)
		}
		return rowView;
	}
}
