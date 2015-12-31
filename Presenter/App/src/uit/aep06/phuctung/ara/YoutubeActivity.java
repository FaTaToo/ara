package uit.aep06.phuctung.ara;

import com.google.android.youtube.player.YouTubeBaseActivity;
import com.google.android.youtube.player.YouTubePlayerView;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.LinearLayout;
import uit.aep06.phuctung.ara.ARResource.ARSM_Youtube;
import uit.aep06.phuctung.ara.Presenter.ARYoutubeProcessor;

public class YoutubeActivity extends YouTubeBaseActivity {
	LinearLayout youtubeLayout;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_youtube);
		
		youtubeLayout = (LinearLayout) findViewById(R.id.youtubeLayout);
		
		Intent intent = getIntent();
		String title = intent.getStringExtra("Title");
		String length = intent.getStringExtra("Length");
		String URL = intent.getStringExtra("URL");
		String uploader = intent.getStringExtra("Uploader");
		ARSM_Youtube arsmYoutube = new ARSM_Youtube();
		arsmYoutube.setTitle(title != null ? title : "");
		arsmYoutube.setLength(length != null ? length : "");
		arsmYoutube.setUrl(URL != null ? URL : "");
		arsmYoutube.setUploader(uploader != null ? uploader : "");		
		ARYoutubeProcessor youtubeProcessor = new ARYoutubeProcessor(this);
		youtubeProcessor.setData(arsmYoutube);
		
		youtubeLayout.addView(youtubeProcessor.onPlay());		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.youtube, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
}
