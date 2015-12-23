package uit.aep06.phuctung.ara;

import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.ExecutionException;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Display;
import android.view.Menu;
import android.view.MenuItem;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.TextView;

public class HelperTargetDefaultActivity extends Activity {
	String imageURL;
	ImageView imageView;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_helper_target_default);
	    	
		TextView tvHelper = (TextView) findViewById(R.id.tvHelper);
		tvHelper.setText("Bạn phải tìm và scan poster như hình bên để hoàn thành nhiệm vụ! Hình ảnh hiện đang có tại các rạp chiếu phim toàn quốc và những điểm công cộng khác");
		
		Intent intent = getIntent();
		imageURL  = intent.getStringExtra("Url");
		imageView = (ImageView)findViewById(R.id.imgHelper);
		
		URL url = null;
		try {
			url = new URL(imageURL);
		} catch (MalformedURLException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		ImageLoadingTask loadingImage = new ImageLoadingTask();
		Bitmap bitmap = null;
		try {
			bitmap = loadingImage.execute(url).get();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ExecutionException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		if (bitmap != null) {
			imageView.setImageBitmap(bitmap);
			imageView.setScaleType(ImageView.ScaleType.FIT_CENTER);
		}
	}
	
	private class ImageLoadingTask extends AsyncTask<URL, Void, Bitmap>{

		@Override
		protected Bitmap doInBackground(URL... params) {
			Bitmap bitmap = null;
			try {
				bitmap = BitmapFactory.decodeStream(params[0].openConnection().getInputStream());
				
			} catch(IOException e) {
				e.printStackTrace();
			}
			return bitmap;
		}		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.helper_target_default, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		Intent intent;
	    // Handle item selection
	    switch (item.getItemId()) {  
	        case R.id.scan:
	        	intent = new Intent(getApplicationContext(),CameraActivity.class);
	    		startActivity(intent);
	            return true; 
	        case R.id.about:
	        	intent = new Intent(getApplicationContext(),AboutActivity.class);
	    		startActivity(intent);
	            return true;
	        default:
	            return super.onOptionsItemSelected(item);
	    }
	}
}
