package uit.aep06.phuctung.ara.Presenter;

import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnTouchListener;
import android.view.ViewGroup.LayoutParams;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageSwitcher;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ViewSwitcher;
import uit.aep06.phuctung.ara.ARResource.ARSM_PictureGallery;

public class ARPictureProcessor extends ARPresenterProcessor {

	public ARPictureProcessor(Context _context) {
		super(_context);
		// TODO Auto-generated constructor stub
	}
	public  ARSM_PictureGallery data = new ARSM_PictureGallery();
	public  ARSM_PictureGallery getData() {
		return data;
	}

	public  void setData(ARSM_PictureGallery data) {
		this.data = data;
	}
	private final  List<Bitmap> listBitmap = new ArrayList<Bitmap>();
	private int downX =0 ;
	private int upX =0;
	@Override
	public Button createButton() {
		// TODO Auto-generated method stub
		Button btn = new Button(getContext());
		
		btn.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.WRAP_CONTENT));
		btn.setWidth(50);
		return btn;
	}

	public View onPlay() {
		// TODO Auto-generated method stub
		for (String url : data.getListUrl() ) {
			listBitmap.add(getBitmapFromURL(url));
		}
		
		
		LinearLayout ViewPicturesLayout = new LinearLayout(getContext());
		LinearLayout.LayoutParams para = new LinearLayout.LayoutParams(LayoutParams.FILL_PARENT,LayoutParams.FILL_PARENT);
		para.weight = 0.0f;
		ViewPicturesLayout.setLayoutParams(para);
		
		final ImageSwitcher imgSwitcher = new ImageSwitcher(getContext());
		imgSwitcher.setFactory(new ViewSwitcher.ViewFactory() {

            public View makeView() {
                // TODO Auto-generated method stub

                // tao imageview cho anh
                ImageView imageView = new ImageView(getContext());
                imageView.setScaleType(ImageView.ScaleType.FIT_CENTER);
                imageView.setLayoutParams(new ImageSwitcher.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT, ViewGroup.LayoutParams.FILL_PARENT));              
                return imageView;
            }
        });
		
		Animation in = AnimationUtils.loadAnimation(getContext(),android.R.anim.fade_in);
		in.setDuration(1000);
		
        Animation out = AnimationUtils.loadAnimation(getContext(),android.R.anim.fade_out);
        out.setDuration(1000);
        
        imgSwitcher.setInAnimation(in);
        imgSwitcher.setOutAnimation(out);
        
        final int[] currentImg = {0};
        Drawable drawable = new BitmapDrawable(listBitmap.get(currentImg[0]));
        imgSwitcher.setImageDrawable(drawable);
        
        imgSwitcher.setOnTouchListener(new OnTouchListener() {
			
			@Override
			public boolean onTouch(View v, MotionEvent event) {
				// TODO Auto-generated method stub
				
				if(event.getAction() == MotionEvent.ACTION_DOWN)
				{
					downX= (int)event.getX();
					return true;
				}
				else if (event.getAction() == MotionEvent.ACTION_UP)
				{
					upX = (int)event.getX();
					if(downX < upX)
					{
						if (currentImg[0] == 0)
		                    currentImg[0] = listBitmap.size()-1;
		                else{
		                    currentImg[0] = currentImg[0] -1;
		                }
		                
					}
					else if( downX > upX)
					{
						if (currentImg[0] == listBitmap.size()-1)
		                    currentImg[0] = 0;
		                else{
		                    currentImg[0] = currentImg[0] +1;
		                }
		                
					}
				}
				Drawable drawable1 = new BitmapDrawable(listBitmap.get(currentImg[0]));
                imgSwitcher.setImageDrawable(drawable1);
				
				return false;
			}
		});
        
		ViewPicturesLayout.addView(imgSwitcher,new LayoutParams(LayoutParams.FILL_PARENT,
	            LayoutParams.FILL_PARENT) );
		Log.e("onplay","picture");
		return ViewPicturesLayout;
		
	}
	public  Bitmap getBitmapFromURL(String src) {
        try {
            /*URL url = new URL(src);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setDoInput(true);
            connection.connect();
            InputStream input = connection.getInputStream();
            Bitmap myBitmap = BitmapFactory.decodeStream(input);
            return myBitmap;*/
            
            URL url = new URL(src); 
            Bitmap image = BitmapFactory.decodeStream(url.openConnection().getInputStream());
            
            return image;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }
}
