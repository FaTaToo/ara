package uit.aep06.phuctung.ara;

import java.io.IOException;

import javax.xml.parsers.ParserConfigurationException;

import org.xml.sax.SAXException;

import com.qualcomm.vuforia.CameraDevice;
import com.qualcomm.vuforia.ObjectTracker;
import com.qualcomm.vuforia.State;
import com.qualcomm.vuforia.TargetFinder;
import com.qualcomm.vuforia.TargetSearchResult;
import com.qualcomm.vuforia.Trackable;
import com.qualcomm.vuforia.Tracker;
import com.qualcomm.vuforia.TrackerManager;
import com.qualcomm.vuforia.Vuforia;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.os.StrictMode;
import android.util.Log;
import android.view.GestureDetector;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.Toast;

import com.qualcomm.vuforia.State;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationControl;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationException;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationSession;
import uit.aep06.phuctung.ara.VuforiaImplement.utils.GLView;
import uit.aep06.phuctung.ara.VuforiaImplement.utils.MissionRenderer;

public class CameraActivity extends Activity implements ApplicationControl {
	// Vuforia
	ApplicationSession vuforiaAppSession;
	private GestureDetector mGestureDetector;
	private GLView mGlView;
	private MissionRenderer mRenderer;
	// Layout
	RelativeLayout mUILayout;
	LinearLayout ARResourceButtonLayout, ARResourceLayout;

	// Primitive variables
	private String mUserID;
	private String kAccessKey = "";
	private String kSecretKey = "";
	private String mTargetID = "";
	private int numberScan = 0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_camera);

		Intent intent = getIntent();
		mUserID = intent.getStringExtra("customerID");

		if (android.os.Build.VERSION.SDK_INT > 8) {
			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
			StrictMode.setThreadPolicy(policy);
		}

		// Create Vuforia session
		vuforiaAppSession = new ApplicationSession(this);

		// Create Camera Layout
		startLoadingAnimation();
	}

	private void startLoadingAnimation() {
		// Inflates the Overlay Layout to be displayed above the Camera View
		LayoutInflater inflater = LayoutInflater.from(this);
		mUILayout = (RelativeLayout) inflater.inflate(R.layout.activity_camera, null, false);

		mUILayout.setVisibility(View.VISIBLE);
		mUILayout.setBackgroundColor(Color.BLACK);

		addContentView(mUILayout, new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));

		ARResourceButtonLayout = (LinearLayout) findViewById(R.id.ARResourceButtonLayout);
		ARResourceLayout = (LinearLayout) findViewById(R.id.ARResourceLayout);

		vuforiaAppSession.initAR(this, ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
		// Creates the GestureDetector listener for processing double tap
		mGestureDetector = new GestureDetector(this, new GestureListener());
	}

	// Process Single Tap event to trigger autofocus
	private class GestureListener extends GestureDetector.SimpleOnGestureListener {
		// Used to set autofocus one second after a manual focus is triggered
		private final Handler autofocusHandler = new Handler();

		@Override
		public boolean onDown(MotionEvent e) {
			return true;
		}

		@Override
		public boolean onSingleTapUp(MotionEvent e) {
			// Generates a Handler to trigger autofocus
			// after 1 second
			autofocusHandler.postDelayed(new Runnable() {
				public void run() {
					boolean result = CameraDevice.getInstance()
							.setFocusMode(CameraDevice.FOCUS_MODE.FOCUS_MODE_TRIGGERAUTO);

					if (!result)
						Log.e("SingleTapUp", "Unable to trigger focus");
				}
			}, 1000L);

			return true;
		}
	}

	@Override
	public boolean doInitTrackers() {
		// TODO Auto-generated method stub
		TrackerManager tManager = TrackerManager.getInstance();
        Tracker tracker;
        
        // Indicate if the trackers were initialized correctly
        boolean result = true;
        
        tracker = tManager.initTracker(ObjectTracker.getClassType());
        if (tracker == null)
        {
            Log.e(
                "cam",
                "Tracker not initialized. Tracker already initialized or the camera is already started");
            result = false;
        } else
        {
            Log.i("cam", "Tracker successfully initialized");
        }
        
        return result;

	}

	@Override
	public boolean doLoadTrackersData() {
		TrackerManager trackerManager = TrackerManager.getInstance();
		ObjectTracker objectTracker = (ObjectTracker) trackerManager
            .getTracker(ObjectTracker.getClassType());
        
        
        // Initialize target finder:
        TargetFinder targetFinder = objectTracker.getTargetFinder();
        
        // Start initialization:
        if (targetFinder.startInit(kAccessKey, kSecretKey))
        {
            targetFinder.waitUntilInitFinished();
        }
        
        int resultCode = targetFinder.getInitState();
        if (resultCode != TargetFinder.INIT_SUCCESS)
        {
            
                
            Log.e("cam", "Failed to initialize target finder.");
            return false;
        }

        Log.d("cam", "Successfully loaded and activated data set.");
        return true;

	}

	@Override
	public boolean doStartTrackers() {
		// TODO Auto-generated method stub
		// Indicate if the trackers were started correctly
        boolean result = true;
        
        // Start the tracker:
        TrackerManager trackerManager = TrackerManager.getInstance();
        ObjectTracker objectTracker = (ObjectTracker) trackerManager
            .getTracker(ObjectTracker.getClassType());
        objectTracker.start();
        
        // Start cloud based recognition if we are in scanning mode:
        TargetFinder targetFinder = objectTracker.getTargetFinder();
        targetFinder.startRecognition();
        return result;
	}

	@Override
	public boolean doStopTrackers() {
		boolean result = true;
        
        TrackerManager trackerManager = TrackerManager.getInstance();
        ObjectTracker objectTracker = (ObjectTracker) trackerManager
            .getTracker(ObjectTracker.getClassType());
        
        if(objectTracker != null)
        {
            objectTracker.stop();
            
            // Stop cloud based recognition:
            TargetFinder targetFinder = objectTracker.getTargetFinder();
            targetFinder.stop();
            
            // Clears the trackables
            targetFinder.clearTrackables();
        }
        else
        {
            result = false;
        }
        return result;
	}

	@Override
	public boolean doUnloadTrackersData() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean doDeinitTrackers() {
		boolean result = true;
        
        TrackerManager tManager = TrackerManager.getInstance();
        tManager.deinitTracker(ObjectTracker.getClassType());
        
        return result;
	}

	@Override
	public void onInitARDone(ApplicationException e) {
		if (e == null) {
			initApplicationAR();

			// Now add the GL surface view. It is important
			// that the OpenGL ES surface view gets added
			// BEFORE the camera is started and video
			// background is configured.
			addContentView(mGlView, new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));

			// Start the camera:
			try {
				showToast("start cam");
				vuforiaAppSession.startAR(CameraDevice.CAMERA.CAMERA_DEFAULT);
			} catch (ApplicationException exception) {
				Log.e("Cam", exception.getString());
			}

			boolean result = CameraDevice.getInstance().setFocusMode(CameraDevice.FOCUS_MODE.FOCUS_MODE_CONTINUOUSAUTO);

			/*
			 * if (result) mContAutofocus = true; else Log.e(LOGTAG,
			 * "Unable to enable continuous autofocus");
			 */
			mUILayout.bringToFront();

			mUILayout.setBackgroundColor(Color.TRANSPARENT);

		} else {
			Log.e("cam", e.getString());
			/*
			 * if(mInitErrorCode != 0) { showErrorMessage(mInitErrorCode,10,
			 * true); } else { finish(); }
			 */
		}

	}

	// Initializes AR application components.
	private void initApplicationAR() {
		// Create OpenGL ES view:
		int depthSize = 16;
		int stencilSize = 0;
		boolean translucent = Vuforia.requiresAlpha();

		// Initialize the GLView with proper flags
		mGlView = new GLView(this);
		mGlView.init(translucent, depthSize, stencilSize);

		// Setups the Renderer of the GLView
		mRenderer = new MissionRenderer(vuforiaAppSession);
		mGlView.setRenderer(mRenderer);
	}

	private void showToast(String text) {
		Toast.makeText(this, text, Toast.LENGTH_SHORT).show();
	}

	@Override
	public void onQCARUpdate(State state) {
		numberScan = numberScan+1;
    	if(numberScan == 500 && mTargetID.equals("")){
    		DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
			    @Override
			    public void onClick(DialogInterface dialog, int which) {
			        switch (which){
			        case DialogInterface.BUTTON_POSITIVE:

			        	Toast.makeText(getApplicationContext(), "You've stoped scan target", Toast.LENGTH_LONG).show();
			        	doStopTrackers();	
			        	Intent intent = new Intent(getApplicationContext(),ProgramActivity.class);
			    		intent.putExtra("customerID",mUserID);
			    		startActivity(intent);
			            break;

			        case DialogInterface.BUTTON_NEGATIVE:
			        	numberScan = 0;
			            //No button clicked
			            break;
			        }
			    }
			};

			AlertDialog.Builder builder = new AlertDialog.Builder(CameraActivity.this);
			builder.setMessage("Could not find target, do you wanna stop?").setPositiveButton("Yes", dialogClickListener)
			    .setNegativeButton("No", dialogClickListener).show();
    	}
		// Get the tracker manager:
        TrackerManager trackerManager = TrackerManager.getInstance();
        
        // Get the object tracker:
        ObjectTracker objectTracker = (ObjectTracker) trackerManager
            .getTracker(ObjectTracker.getClassType());
        
        // Get the target finder:
        TargetFinder finder = objectTracker.getTargetFinder();
        
        // Check if there are new results available:
        final int statusCode = finder.updateSearchResults();
        
        // Show a message if we encountered an error:
        if (statusCode < 0)
        {
        	Log.e("Cam", statusCode + "");
            
            
        } else if (statusCode == TargetFinder.UPDATE_RESULTS_AVAILABLE)
        {
            // Process new search results
            if (finder.getResultCount() > 0)
            {
                TargetSearchResult result = finder.getResult(0);
               
                               
                // Check if this target is suitable for tracking:
                if (result.getTrackingRating() > 0)
                {
                    Trackable trackable = finder.enableTracking(result);
                   
                    
                    if (trackable != null)
                    {                       
                        //xu li ket qua                      
                    }
                }
            }
        }


	}
}
