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
		// TODO Auto-generated constructor stub
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
		// TODO Auto-generated method stub
		Button btn = new Button(getContext());
		btn.setText("Details");

		btn.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.WRAP_CONTENT));
		btn.setWidth(50);
		return btn;
	}

	@Override
	public View onPlay() {
		// TODO Auto-generated method stub
		ScrollView sv = new ScrollView(getContext());

		LinearLayout layout = new LinearLayout(this.getContext());
		LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FILL_PARENT,
				LinearLayout.LayoutParams.FILL_PARENT);
		layout.setLayoutParams(layoutParams);
		layout.setOrientation(LinearLayout.VERTICAL);
		layout.setGravity(Gravity.CENTER_HORIZONTAL);

		sv.setLayoutParams(layoutParams);
		sv.addView(layout);

		LinearLayout temp = new LinearLayout(getContext());
		temp.setLayoutParams(new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WRAP_CONTENT,
				LinearLayout.LayoutParams.FILL_PARENT));
		temp.setOrientation(LinearLayout.HORIZONTAL);

		ImageView img = new ImageView(getContext());
		try {
			URL url = new URL(data.getImageUrl());
			Bitmap image = BitmapFactory.decodeStream(url.openConnection().getInputStream());
			img.setImageBitmap(image);
			img.setScaleType(ImageView.ScaleType.FIT_CENTER);
			img.setLayoutParams(new LinearLayout.LayoutParams(550, 550));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		temp.addView(img);

		LinearLayout temp1 = new LinearLayout(this.getContext());
		temp1.setOrientation(LinearLayout.VERTICAL);

		ARTextProcessor tv = new ARTextProcessor(getContext());
		tv.setText(data.getName());
		tv.setColor(Color.RED);
		tv.setSize(25);
		temp1.addView(tv.onPlay());

		tv.setText(data.getDirector());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		temp1.addView(tv.onPlay());

		tv.setText(data.getActor());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		temp1.addView(tv.onPlay());

		tv.setText(data.getYear());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		temp1.addView(tv.onPlay());

		temp.addView(temp1);

		layout.addView(temp);

		tv.setText(data.getDescription());
		tv.setColor(Color.YELLOW);
		tv.setSize(25 - 5);
		layout.addView(tv.onPlay());

		return sv;
	}

}
