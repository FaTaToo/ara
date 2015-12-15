package uit.aep06.phuctung.ara.Presenter;

import android.content.Context;
import android.content.Intent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.LinearLayout;
import uit.aep06.phuctung.ara.CommentActivity;

public class ARCommentProcessor extends ARPresenterProcessor{

	public String userID;
	public  String getUserID() {
		return userID;
	}
	public void setUserID(String userID) {
		this.userID = userID;
	}
	
	public String targetID;
	public String getTargetID() {
		return targetID;
	}
	public void setTargetID(String targetID) {
		this.targetID = targetID;
	}
	
	public String urlShare;
	public String getUrlShare() {
		return this.urlShare;
	}
	public void setUrlShare(String urlShare) {
		this.urlShare = urlShare;
	}

	public ARCommentProcessor(Context context) {
		super(context);		
	}

	@Override
	public View onPlay() {		
		return null;
	}

	@Override
	public Button createButton() {
		Button btn = new Button(getContext());
		
		btn.setBackgroundResource(uit.aep06.phuctung.ara.R.drawable.icon_comment);
		btn.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		btn.setWidth(50);
		btn.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {				
				Intent intent = new Intent(getContext().getApplicationContext(),CommentActivity.class);
				intent.putExtra("UserID", userID);
				intent.putExtra("TargetID", targetID);
				intent.putExtra("Facebook", urlShare);
				getContext().startActivity(intent);
			}
		});
		return btn;
	}	
}

