package uit.aep06.phuctung.ara.Presenter;

import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import android.R;
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
	}
	
	public  ARSM_PictureGallery data = new ARSM_PictureGallery();
	public  ARSM_PictureGallery getData() {
		return data;
	}
	public  void setData(ARSM_PictureGallery data) {
		this.data = data;
	}
	
	private final  List<Bitmap> listBitmap = new ArrayList<Bitmap>();
	private int downX = 0 ;
	private int upX = 0;
	@Override
	public Button createButton() {
		Button btn = new Button(getContext());
		btn.setBackgroundResource(uit.aep06.phuctung.ara.R.drawable.icon_picture_gallery);
		btn.setLayoutParams(new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		btn.setWidth(50);
		return btn;
	}

	public View onPlay() {		
		for (String url : data.getListUrl() ) {
			listBitmap.add(getBitmapFromURL(url));
		}	
		
		LinearLayout ViewPicturesLayout = new LinearLayout(getContext());
		LinearLayout.LayoutParams para = new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT,LayoutParams.MATCH_PARENT);
		para.weight = 0.0f;
		ViewPicturesLayout.setLayoutParams(para);
		
		final ImageSwitcher imgSwitcher = new ImageSwitcher(getContext());
		imgSwitcher.setFactory(new ViewSwitcher.ViewFactory() {

            public View makeView() {
                // Crate image view 
            	ImageView imageView = new ImageView(getContext());
                imageView.setScaleType(ImageView.ScaleType.FIT_CENTER);
                imageView.setLayoutParams(new ImageSwitcher.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT));              
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
				if(event.getAction() == MotionEvent.ACTION_DOWN)
				{
					downX = (int)event.getX();
					return true;
				}
				else if (event.getAction() == MotionEvent.ACTION_UP)
				{
					upX = (int)event.getX();
					if(downX < upX)
					{
						if (currentImg[0] == 0)
		                    currentImg[0] = listBitmap.size() - 1;
		                else{
		                    currentImg[0] = currentImg[0] - 1;
		                }		                
					}
					else if( downX > upX)
					{
						if (currentImg[0] == listBitmap.size()-1)
		                    currentImg[0] = 0;
		                else {
		                    currentImg[0] = currentImg[0] +1;
		                }		                
					}
				}
				Drawable drawable1 = new BitmapDrawable(listBitmap.get(currentImg[0]));
                imgSwitcher.setImageDrawable(drawable1);
				
				return false;
			}
		});
        
		ViewPicturesLayout.addView(imgSwitcher,new LayoutParams(LayoutParams.MATCH_PARENT,
	            LayoutParams.MATCH_PARENT) );
		Log.e("ARPictureProcessor-onplay","picture");
		return ViewPicturesLayout;		
	}
	
	public  Bitmap getBitmapFromURL(String src) {
        try {
            URL url = new URL(src); 
            Bitmap image = BitmapFactory.decodeStream(url.openConnection().getInputStream());
            
            return image;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }
}
