package uit.aep06.phuctung.ara.custom_adapter;

import java.util.List;

import android.content.Context;
import android.widget.BaseAdapter;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RatingBar;
import android.widget.TextView;

import uit.aep06.phuctung.ara.R;
import uit.aep06.phuctung.ara.CommonClass.Comment;

public class CommentAdapter extends BaseAdapter {
	List<Comment> listComments;
	Context context;
	int resource;
	Comment comment;
	private static LayoutInflater inflater = null;

	public CommentAdapter(Context context, int resource, List<Comment> listComment) {
		super();

		this.context = context;
		this.resource = resource;
		this.listComments = listComment;

		inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

	@Override
	public int getCount() {
		return listComments.size();
	}

	@Override
	public Object getItem(int position) {
		return position;
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	private class Holder {
		TextView tvFullname;
		TextView tvComment;
		RatingBar rbRating;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View rowView;
		rowView = inflater.inflate(R.layout.comment_list_item, null);
		Holder holder = new Holder();
		
		holder.tvFullname = (TextView) rowView.findViewById(R.id.tvFullname);
		holder.tvFullname.setTextSize(20);
		
		holder.tvComment = (TextView) rowView.findViewById(R.id.tvComment);
		holder.tvComment.setTextSize(20);
		
		holder.rbRating = (RatingBar) rowView.findViewById(R.id.rbRating);
		
		comment = listComments.get(position);		
		if (comment != null) {
			holder.tvFullname.setText(comment.getFullname());
			holder.tvComment.setText(comment.getCustomerComment());
			holder.rbRating.setRating(comment.getRating());			
		}
		return rowView;
	}
}

