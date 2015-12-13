package uit.aep06.phuctung.ara.Presenter;

import java.io.IOException;
import java.net.URL;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import uit.aep06.phuctung.ara.ARResource.ARMM_Text;

public class ARDetailProcessor extends ARPresenterProcessor {

	public ARDetailProcessor(Context _context) {
		super(_context);		
	}

	ARMM_Text data = new ARMM_Text();

	public ARMM_Text getData() {
		return data;
	}

	public void setData(ARMM_Text data) {
		this.data = data;
	}

	@Override
	public Button createButton() {
		Button btn = new Button(getContext());
		btn.setBackgroundResource(uit.aep06.phuctung.ara.R.drawable.icon_description);

		btn.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		btn.setWidth(50);
		return btn;
	}

	@Override
	public View onPlay() {		
		ScrollView sv = new ScrollView(getContext());

		LinearLayout layout = new LinearLayout(this.getContext());
		LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,
				LinearLayout.LayoutParams.MATCH_PARENT);
		layout.setLayoutParams(layoutParams);
		layout.setOrientation(LinearLayout.VERTICAL);
		layout.setGravity(Gravity.CENTER_HORIZONTAL);

		sv.setLayoutParams(layoutParams);
		sv.addView(layout);

		LinearLayout layoutImage = new LinearLayout(getContext());
		layoutImage.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WRAP_CONTENT,
				LinearLayout.LayoutParams.MATCH_PARENT));
		layoutImage.setOrientation(LinearLayout.HORIZONTAL);

		ImageView img = new ImageView(getContext());
		try {
			URL url = new URL(data.getImageUrl());
			Bitmap image = BitmapFactory.decodeStream(url.openConnection().getInputStream());
			img.setImageBitmap(image);
			img.setScaleType(ImageView.ScaleType.FIT_CENTER);
			img.setLayoutParams(new LinearLayout.LayoutParams(550, 550));
		} catch (IOException e) {			
			e.printStackTrace();
		}
		layoutImage.addView(img);

		LinearLayout layoutText = new LinearLayout(this.getContext());
		layoutText.setOrientation(LinearLayout.VERTICAL);

		ARTextProcessor tv = new ARTextProcessor(getContext());
		tv.setText(data.getName());
		tv.setColor(Color.RED);
		tv.setSize(25);
		layoutText.addView(tv.onPlay());

		tv.setText(data.getDirector());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		layoutText.addView(tv.onPlay());

		tv.setText(data.getActor());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		layoutText.addView(tv.onPlay());

		tv.setText(data.getYear());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		layoutText.addView(tv.onPlay());

		layoutImage.addView(layoutText);

		layout.addView(layoutImage);

		tv.setText(data.getDescription());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		layout.addView(tv.onPlay());

		return sv;
	}

}
