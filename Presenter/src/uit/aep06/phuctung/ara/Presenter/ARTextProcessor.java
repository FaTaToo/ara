package uit.aep06.phuctung.ara.Presenter;

import android.content.Context;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class ARTextProcessor extends ARPresenterProcessor {
	
	public ARTextProcessor(Context _context) {
		super(_context);
		// TODO Auto-generated constructor stub
	}
	public  String text;
	public  int color;
	public  float size;
	public  String getText() {
		return text;
	}
	public  void setText(String text) {
		this.text = text;
	}
	public  int getColor() {
		return color;
	}
	public  void setColor(int color) {
		this.color = color;
	}
	public  float getSize() {
		return size;
	}
	public  void setSize(float size) {
		this.size = size;
	}
	@Override
	public Button createButton() {
		// TODO Auto-generated method stub
		return null;
	}
	@Override
	public View onPlay() {
		// TODO Auto-generated method stub
		TextView tv = new TextView(getContext());
		tv.setText(text);
		tv.setTextColor(color);
		tv.setTextSize(size );

		return tv;
	}
}

