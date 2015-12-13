package uit.aep06.phuctung.ara.Presenter;

import android.content.Context;
import android.view.View;
import android.widget.Button;

public abstract class ARPresenterProcessor {
	private Context context;
	

	public ARPresenterProcessor(Context context)
	{
		this.context = context;
	}
	
	public Context getContext() {
		return this.context;
	}
	
	public void setContext(Context context) {
		this.context = context;
	}

	public abstract Button createButton();
	public abstract View onPlay();
}
