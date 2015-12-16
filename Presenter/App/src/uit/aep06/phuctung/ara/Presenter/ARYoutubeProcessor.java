package uit.aep06.phuctung.ara.Presenter;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.google.android.youtube.player.YouTubeInitializationResult;
import com.google.android.youtube.player.YouTubePlayer;
import com.google.android.youtube.player.YouTubePlayerView;
import com.google.android.youtube.player.YouTubePlayer.OnInitializedListener;
import com.google.android.youtube.player.YouTubePlayer.Provider;

import android.R;
import android.content.Context;
import android.graphics.Color;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import uit.aep06.phuctung.ara.ARResource.ARSM_Youtube;

public class ARYoutubeProcessor extends ARPresenterProcessor implements OnInitializedListener {

	public ARYoutubeProcessor(Context context) {
		super(context);		
	}

	public ARSM_Youtube data = new ARSM_Youtube();
	public YouTubePlayerView playerview;

	public ARSM_Youtube getData() {
		return data;
	}

	public void setData(ARSM_Youtube data) {
		this.data = data;
	}

	public YouTubePlayerView getPlayerview() {
		return playerview;
	}

	public void setPlayerview(YouTubePlayerView playerview) {
		this.playerview = playerview;
	}

	@Override
	public Button createButton() {		
		Button btn = new Button(getContext());
		btn.setBackgroundResource(uit.aep06.phuctung.ara.R.drawable.icon_youtube);
		btn.setLayoutParams(new LinearLayout.LayoutParams(50, 50));
		return btn;
	}

	@Override
	public View onPlay() {
		playerview = new YouTubePlayerView(getContext());
		playerview.initialize("AIzaSyAmvY-XRQTEo_-0bgDL7LzCH94YHTs5SjM", this);
		LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,
				LinearLayout.LayoutParams.MATCH_PARENT);
		layoutParams.setMargins(50, 50, 50, 50);
		playerview.setLayoutParams(layoutParams);
		playerview.setBackgroundColor(Color.BLACK);
		return playerview;

	}

	@Override
	public void onInitializationFailure(Provider arg0, YouTubeInitializationResult arg1) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onInitializationSuccess(Provider arg0, YouTubePlayer player, boolean wasRestored) {
		String idVideo = getIDYoutube(data.getUrl());
		if (!wasRestored && idVideo != null) {
			player.cueVideo(idVideo);
		}
	}

	private String getIDYoutube(String url) {
		String pattern = "(?<=watch\\?v=|/videos/|embed\\/)[^#\\&\\?]*";

		Pattern compiledPattern = Pattern.compile(pattern);
		Matcher matcher = compiledPattern.matcher(url);

		if (matcher.find()) {
			return matcher.group();
		}
		return null;
	}
}
