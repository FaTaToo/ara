package uit.aep06.phuctung.ara.custom_adapter;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.text.Html;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;
import uit.aep06.phuctung.ara.R;
import uit.aep06.phuctung.ara.CommonClass.Target;

public class MissionAdapter extends BaseAdapter {
	List<Target> listTargets;
	Context context;
	int resource;
	Target target;
	private static LayoutInflater inflater = null;

	public MissionAdapter(Context context, int resource, List<Target> listTargets) {
		super();

		this.context = context;
		this.resource = resource;
		this.listTargets = listTargets;
		inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
	}

	public Context getContext() {
		return this.context;
	}

	@Override
	public int getCount() {
		return listTargets.size();
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
		TextView tvName, tvYear, tvDirection, tvActor, tvContent;
		ImageView imgMission, imgCheck;
		Button btnHeper;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View rowView;
		rowView = inflater.inflate(R.layout.mission_list_item, null);

		Holder holder = new Holder();
		holder.tvName = (TextView) rowView.findViewById(R.id.tvName);
		holder.tvYear = (TextView) rowView.findViewById(R.id.tvYear);
		holder.tvDirection = (TextView) rowView.findViewById(R.id.tvDirection);
		holder.tvActor = (TextView) rowView.findViewById(R.id.tvActor);
		holder.tvContent = (TextView) rowView.findViewById(R.id.tvContent);
		holder.imgMission = (ImageView) rowView.findViewById(R.id.imgMission);
		holder.imgCheck = (ImageView) rowView.findViewById(R.id.imgCheck);
		holder.btnHeper = (Button) rowView.findViewById(R.id.btnHelper);

		target = listTargets.get(position);
		if (target != null) {
			holder.tvName.setText(Html.fromHtml("<b>Tên:</b> " + target.getName()));
			holder.tvYear.setText(Html.fromHtml("<b>Năm sản xuất:</b> " + target.getYear()));
			holder.tvDirection.setText(Html.fromHtml("<b>Đạo diễn:</b> " + target.getDirector()));
			holder.tvActor.setText(Html.fromHtml("<b>Diễn viên:</b> " + target.getActor()));
			holder.tvContent.setText(Html.fromHtml("<b>Mô tả:</b> " + target.getTargetContent()));

			BackgroundTask backgroundTask = new BackgroundTask();
			backgroundTask.setImageView(holder.imgMission);
			backgroundTask.setUrl(target.getUrl());
			backgroundTask.execute();

			if (target.getState() != 0) {
				holder.imgCheck.setBackgroundResource(R.drawable.icon_check);
			} else {
				holder.imgCheck.setBackground(null);
			}

			holder.btnHeper.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					target.Helper();
				}
			});
		}
		return rowView;

	}

	private class BackgroundTask extends AsyncTask<Void, Void, Void> {
		Bitmap img;
		ImageView imageView;
		String url;

		public Bitmap getImg() {
			return img;
		}

		public void setImg(Bitmap img) {
			this.img = img;
		}

		public ImageView getImageView() {
			return this.imageView;
		}

		public void setImageView(ImageView imageView) {
			this.imageView = imageView;
		}

		public String getUrl() {
			return url;
		}

		public void setUrl(String url) {
			this.url = url;
		}

		@Override
		protected void onPreExecute() {
		}

		@Override
		protected void onPostExecute(Void result) {

		}

		@Override
		protected Void doInBackground(Void... params) {
			img = getBitmapFromURL(url);

			((Activity) getContext()).runOnUiThread(new Runnable() {
				@Override
				public void run() {
					imageView.setBackground(null);
					imageView.setImageBitmap(img);
					Log.e("Display lazy", "Load done");
				}
			});
			return null;
		}

	}

	public Bitmap getBitmapFromURL(String urlImage) {
		try {
			URL url = new URL(urlImage);
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setDoInput(true);
			connection.connect();
			InputStream input = connection.getInputStream();
			return BitmapFactory.decodeStream(input);
		} catch (IOException e) {
			e.printStackTrace();
			return null;
		}
	}

}
