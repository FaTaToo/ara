package uit.aep06.phuctung.ara;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.client.ClientProtocolException;
import org.json.JSONException;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import uit.aep06.phuctung.ara.CommonClass.Comment;
import uit.aep06.phuctung.ara.Service.CommentService;
import uit.aep06.phuctung.ara.Service.LikeService;
import uit.aep06.phuctung.ara.custom_adapter.CommentAdapter;

public class CommentActivity extends Activity {
	private String mUserID;
	private String mTargetID;
	private String urlShare;
	private List<Comment> lstComment = new ArrayList<Comment>();

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_comment);
		Intent intent = getIntent();
		mUserID = intent.getStringExtra("UserID");
		mTargetID = intent.getStringExtra("TargetID");

		urlShare = intent.getStringExtra("Facebook");
		final LikeService service = new LikeService();
		int numLikes = service.getLikeFromTargetID(mTargetID);

		final TextView tvNumLikes = (TextView) findViewById(R.id.tvNumLikes);
		tvNumLikes.setText(numLikes + "");
			
		BackgroundTask task = new BackgroundTask();
		task.execute();

		final Button btnLike = (Button) findViewById(R.id.btnLike);
		btnLike.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				try {
					int newNumLikes = service.addNewLike(mTargetID);
					tvNumLikes.setText(newNumLikes + "");
					btnLike.setClickable(false);
				} catch (ClientProtocolException e) {
					e.printStackTrace();
				} catch (JSONException e) {
					e.printStackTrace();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		});

		final Button btnShare = (Button) findViewById(R.id.btnshare);
		btnShare.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent i = new Intent(Intent.ACTION_SEND);
				i.setType("text/plain");
				i.putExtra(android.content.Intent.EXTRA_TEXT, urlShare);
				startActivity(Intent.createChooser(i, "Share link"));
			}
		});

		Button btnSend = (Button) findViewById(R.id.btnSend);
		btnSend.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				Comment cmt = new Comment();
				RatingBar rbNewRating = (RatingBar) findViewById(R.id.rbRating);
				EditText etNewComment = (EditText) findViewById(R.id.etComment);
				cmt.setCustomerComment(etNewComment.getText().toString());
				cmt.setCustomerID(Integer.parseInt(mUserID));
				cmt.setTargetID(mTargetID);
				int rating = Math.round(rbNewRating.getRating());
				cmt.setRating(rating);
				try {
					CommentService s = new CommentService();
					s.addNewComment(cmt);
					Toast.makeText(getApplicationContext(), "Comment done", Toast.LENGTH_LONG).show();
					Intent i = new Intent(getApplicationContext(), CommentActivity.class);
					i.putExtra("TargetID", mTargetID);
					i.putExtra("UserID", mUserID);
					startActivity(i);
				} catch (ClientProtocolException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} catch (JSONException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

			}
		});
	}

	private class BackgroundTask extends AsyncTask<Void, Void, Void> {
		private ProgressDialog dialog;

		@Override
		protected void onPreExecute() {
			dialog = new ProgressDialog(CommentActivity.this);
			dialog.setCancelable(false);
			dialog.setMessage("Downloading data. Please wait!!!");
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
			CommentService service = new CommentService();
			try {
				lstComment = service.getAllComments(mTargetID);
			} catch (JSONException e) {
				e.printStackTrace();
			}

			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					ListView lvComment = (ListView) findViewById(R.id.lvComment);
					CommentAdapter ca = new CommentAdapter(CommentActivity.this, R.layout.comment_list_item,
							lstComment);
					lvComment.setAdapter(ca);
				}
			});
			return null;
		}

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle item selection
		Intent intent;
		switch (item.getItemId()) {
		case R.id.profile:
			intent = new Intent(getApplicationContext(), ProfileActivity.class);
			intent.putExtra("customerID", mUserID);
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
