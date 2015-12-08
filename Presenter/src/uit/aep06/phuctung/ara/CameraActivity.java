package uit.aep06.phuctung.ara;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.location.Address;
import android.location.Criteria;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.StrictMode;
import android.util.Log;
import android.view.GestureDetector;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.Toast;

import com.google.android.gms.maps.model.LatLng;
import com.google.android.youtube.player.YouTubeBaseActivity;

import org.apache.http.client.ClientProtocolException;
import org.json.JSONException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

import java.io.IOException;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import com.qualcomm.vuforia.CameraDevice;
import com.qualcomm.vuforia.ObjectTracker;
import com.qualcomm.vuforia.State;
import com.qualcomm.vuforia.TargetFinder;
import com.qualcomm.vuforia.TargetSearchResult;
import com.qualcomm.vuforia.Trackable;
import com.qualcomm.vuforia.Tracker;
import com.qualcomm.vuforia.TrackerManager;
import com.qualcomm.vuforia.Vuforia;

import uit.aep06.phuctung.ara.ARResource.ARContainer;
import uit.aep06.phuctung.ara.ARResource.ARMM_Text;
import uit.aep06.phuctung.ara.ARResource.ARSM_PictureGallery;
import uit.aep06.phuctung.ara.ARResource.ARSM_Youtube;
import uit.aep06.phuctung.ara.Presenter.ARDetailProcessor;
import uit.aep06.phuctung.ara.Presenter.ARPictureProcessor;
import uit.aep06.phuctung.ara.Presenter.ARYoutubeProcessor;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationControl;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationException;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationSession;
import uit.aep06.phuctung.ara.VuforiaImplement.utils.GLView;
import uit.aep06.phuctung.ara.VuforiaImplement.utils.MissionRenderer;

@SuppressLint("NewApi")
@TargetApi(Build.VERSION_CODES.GINGERBREAD)
public class CameraActivity extends YouTubeBaseActivity implements ApplicationControl { // ,LocationListener{

	ApplicationSession vuforiaAppSession;

	private static final String kAccessKey = "eb7ff5713833cc7e75f2b3075a41fa1ac4895936";
	private static final String kSecretKey = "eb2e4fb8320ec7e83b8a6512a4763e905663352d";

	// Our OpenGL view:
	private GLView mGlView;

	// Our renderer:
	private MissionRenderer mRenderer;

	// View overlays to be displayed in the Augmented View
	private RelativeLayout mUILayout;

	LinearLayout ARResourceLayout;
	LinearLayout ARResourceButtonLayout;

	private GestureDetector mGestureDetector;

	private final List<Bitmap> listBitmap = new ArrayList<Bitmap>();
	private int numberScan = 0;
	private boolean flag = false;
	private String mUserID;
	private String mTargetID = "";
	private String urlShare = "";
	LocationManager locationManager;
	String provider;
	public LatLng myPosition;
	public LatLng myPosition_temp;
	public LatLng end;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		Intent intent = getIntent();
		mUserID = intent.getStringExtra("customerID");

		if (android.os.Build.VERSION.SDK_INT > 8) {
			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
			StrictMode.setThreadPolicy(policy);
		}
		vuforiaAppSession = new ApplicationSession(this);

		// Khoi tao camera layout
		startLoadingAnimation();

		vuforiaAppSession.initAR(this, ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
		// Creates the GestureDetector listener for processing double tap
		mGestureDetector = new GestureDetector(this, new GestureListener());

		locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		Criteria criteria = new Criteria();
		provider = locationManager.getBestProvider(criteria, true);
		// Location location =
		// locationManager.getLastKnownLocation(locationManager.NETWORK_PROVIDER);
		// if (location != null && location.getTime() >
		// Calendar.getInstance().getTimeInMillis() - 2 * 60 * 1000) {
		// onLocationChanged(location);
		//
		// }
		// else {
		// locationManager.requestLocationUpdates(locationManager.NETWORK_PROVIDER,400,
		// 1, this);
		//
		// }

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
	protected void onResume() {
		super.onResume();
		// locationManager.requestLocationUpdates(locationManager.NETWORK_PROVIDER,
		// 400, 1, this);
		try {
			vuforiaAppSession.resumeAR();
		} catch (ApplicationException e) {
		}

		// Resume the GL view:
		if (mGlView != null) {
			mGlView.setVisibility(View.VISIBLE);
			mGlView.onResume();
		}

	}

	// Called when the system is about to start resuming a previous activity.
	@Override
	protected void onPause() {
		super.onPause();

		try {
			vuforiaAppSession.pauseAR();
		} catch (ApplicationException e) {
		}

		// Pauses the OpenGLView
		if (mGlView != null) {
			mGlView.setVisibility(View.INVISIBLE);
			mGlView.onPause();
		}
	}

	// The final call you receive before your activity is destroyed.
	@Override
	protected void onDestroy() {
		super.onDestroy();

		try {
			vuforiaAppSession.stopAR();
		} catch (ApplicationException e) {
		}

		System.gc();
	}

	public Document ConvertToXmlFromString(String xml) throws ParserConfigurationException, SAXException, IOException {

		xml = "<?xml version='1.0' encoding='utf-8'?>" + xml;
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder = factory.newDocumentBuilder();
		return builder.parse(new InputSource(new StringReader(xml)));

	}

	public void LoadXML(String data) throws ParserConfigurationException, SAXException, IOException {

		ARContainer arContainer = new ARContainer();
		DocumentBuilderFactory docBuilderFactory = DocumentBuilderFactory.newInstance();
		DocumentBuilder docBuilder = docBuilderFactory.newDocumentBuilder();

		Document doc = ConvertToXmlFromString(data);
		// normalize text representation
		doc.getDocumentElement().normalize();

		// Get list of ARResources
		NodeList nlARResources = doc.getElementsByTagName("ARResource");
		int temp = nlARResources.getLength();
		for (int i = 0; i < temp; i++) {

			Element eArresource = (Element) nlARResources.item(i);
			String type = ((Element) eArresource.getElementsByTagName("ARType").item(0)).getTextContent();
			Log.i("Type ", type);

			NodeList nlCommonAttributes = eArresource.getElementsByTagName("CommonAttributes");
			NodeList nlAttributes = ((Element) nlCommonAttributes.item(0)).getElementsByTagName("Attribute");
			int numAttributes = nlAttributes.getLength();

			if (type.equals("ARSM-Youtube")) {

				ARSM_Youtube arsmYoutube = new ARSM_Youtube();
				for (int j = 0; j < numAttributes; j++) {
					Element eAttribute = (Element) nlAttributes.item(j);
					String key = eAttribute.getElementsByTagName("Key").item(0).getTextContent();
					String value = eAttribute.getElementsByTagName("Value").item(0).getTextContent();
					Log.i(type, "Key: " + key);
					Log.i(type, "Value : " + value);

					if (key.equals("Title")) {
						arsmYoutube.setTitle(value);
					} else if (key.equals("Length")) {
						arsmYoutube.setLength(value);
					} else if (key.equals("URL")) {
						arsmYoutube.setUrl(value);
					} else if (key.equals("Uploader")) {
						arsmYoutube.setUploader(value);
					}
				}
				final ARYoutubeProcessor youtubeProcessor = new ARYoutubeProcessor(this);
				youtubeProcessor.setData(arsmYoutube);
				Button btnYoutube = youtubeProcessor.createButton();
				ARResourceButtonLayout.addView(btnYoutube,
						new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));

				btnYoutube.setOnClickListener(new OnClickListener() {

					@Override
					public void onClick(View arg0) {
						// TODO Auto-generated method stub
						doStopTrackers();
						if (ARResourceLayout.getChildCount() > 1)
							ARResourceLayout.removeViewAt(ARResourceLayout.getChildCount() - 1);
						ARResourceLayout.addView(youtubeProcessor.onPlay());
					}
				});

			} else if (type.equals("ARSM-PicturesGallery")) {

				ARSM_PictureGallery arsmGallery = new ARSM_PictureGallery();
				List<String> lstURL = new ArrayList<String>();
				for (int j = 0; j < numAttributes; j++) {
					Element eAttribute = (Element) nlAttributes.item(j);
					String key = eAttribute.getElementsByTagName("Key").item(0).getTextContent();
					String url = eAttribute.getElementsByTagName("Value").item(0).getTextContent();
					Log.i(type, "Key: " + key);
					Log.i(type, "Image URL : " + url);
					lstURL.add(url);
				}
				arsmGallery.setListUrl(lstURL);
				final ARPictureProcessor picturesProcessor = new ARPictureProcessor(this);
				picturesProcessor.setData(arsmGallery);
				Button btn = picturesProcessor.createButton();
				ARResourceButtonLayout.addView(btn,
						new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));

				btn.setOnClickListener(new OnClickListener() {

					@Override
					public void onClick(View arg0) {
						// TODO Auto-generated method stub
						doStopTrackers();
						if (ARResourceLayout.getChildCount() > 1)
							ARResourceLayout.removeViewAt(ARResourceLayout.getChildCount() - 1);
						ARResourceLayout.addView(picturesProcessor.onPlay());
					}
				});
			} else if (type.equals("ARSM-Facebook")) {
				for (int j = 0; j < numAttributes; j++) {
					Element eAttribute = (Element) nlAttributes.item(j);
					String value = eAttribute.getElementsByTagName("Value").item(0).getTextContent();
					urlShare = value;
				}
			} else if (type.equals("ARMM-Text")) {
				final ARMM_Text detail = new ARMM_Text();
				for (int j = 0; j < numAttributes; j++) {
					Element eAttribute = (Element) nlAttributes.item(j);
					String key = eAttribute.getElementsByTagName("Key").item(0).getTextContent();
					String value = eAttribute.getElementsByTagName("Value").item(0).getTextContent();
					if (key.equals("Name")) {
						detail.setName(value);
					} else if (key.equals("Year")) {
						detail.setYear(value);
					} else if (key.equals("Director")) {
						detail.setDirector(value);
					} else if (key.equals("Actor")) {
						detail.setActor(value);
					} else if (key.equals("Description")) {
						detail.setDescription(value);
					} else if (key.equals("URL")) {
						detail.setImageUrl(value);
					} else if (key.equals("TargetType")) {
						detail.setTargetType(Integer.parseInt(value));
					} else if (key.equals("Address")) {
						detail.setAddress(value);
					}
				}
				final ARDetailProcessor detailProcessor = new ARDetailProcessor(this);
				detailProcessor.setData(detail);
				Button btnText = detailProcessor.createButton();
				ARResourceButtonLayout.addView(btnText,
						new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));

				btnText.setOnClickListener(new OnClickListener() {

					@Override
					public void onClick(View arg0) {
						// TODO Auto-generated method stub
						doStopTrackers();
						if (detail.getTargetType() == 2) {
							String[] lstAddress = detail.getAddress().split(";");
							String nearestAddress = lstAddress[0];
							int numAddress = lstAddress.length;
							double distance = 99999;
							for (int k = 0; k < numAddress; k++) {

								Geocoder geo = new Geocoder(CameraActivity.this);
								try {
									List<Address> temp = geo.getFromLocationName(lstAddress[k], 1);
									end = new LatLng(temp.get(0).getLatitude(), temp.get(0).getLongitude());
									if (myPosition == null) {
										Address add = (geo.getFromLocationName(
												"227 Nguyễn Văn Cừ phường 4, Quận 5 Hồ Chí Minh, Vietnam", 6)).get(0);
										myPosition = new LatLng(add.getLatitude(), add.getLongitude());
									} else {
										Log.e("Hien", myPosition.latitude + " " + myPosition.longitude);
									}
									double myDistance = distance(myPosition.latitude, myPosition.longitude,
											end.latitude, end.longitude, 'K');
									Log.e("Hien error ", "myDistance" + myDistance);

									if (myDistance < distance) {
										distance = myDistance;
										nearestAddress = lstAddress[k];
									}
								} catch (Exception e) {
									// TODO Auto-generated catch block
									Log.e("Hien error ", e.getMessage());
								}
							}
							if (distance >= 0.1) {
								MessengerBox("Bạn còn cách khu vực gần nhất là : " + nearestAddress + " "
										+ distance + " Km");
								return;
							}
						}

						if (ARResourceLayout.getChildCount() > 1)
							ARResourceLayout.removeViewAt(ARResourceLayout.getChildCount() - 1);
						ARResourceLayout.addView(detailProcessor.onPlay());
					}
				});
			}
		}
	}

	@Override
	public void onConfigurationChanged(Configuration newConfig) {
		// TODO Auto-generated method stub
		super.onConfigurationChanged(newConfig);
		vuforiaAppSession.onConfigurationChanged();
	}

	private void LoadButton() {

		Button btn = new Button(this);
		// btn.setBackgroundResource(R.drawable.btn_rescan);
		btn.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				// Intent intent = new
				// Intent(getApplication(),CameraActivity.class);
				// startActivity(intent);
				ARResourceButtonLayout.removeAllViews();
				if (ARResourceLayout.getChildCount() > 1)
					ARResourceLayout.removeViewAt(ARResourceLayout.getChildCount() - 1);
				doStartTrackers();

			}
		});
		ARResourceButtonLayout.addView(btn, new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
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

	@Override
	public boolean doInitTrackers() {
		// TODO Auto-generated method stub
		TrackerManager tManager = TrackerManager.getInstance();
		Tracker tracker;

		// Indicate if the trackers were initialized correctly
		boolean result = true;

		tracker = tManager.initTracker(ObjectTracker.getClassType());
		if (tracker == null) {
			Log.e("cam", "Tracker not initialized. Tracker already initialized or the camera is already started");
			result = false;
		} else {
			Log.i("cam", "Tracker successfully initialized");
		}

		return result;
	}

	@Override
	public boolean doLoadTrackersData() {
		// TODO Auto-generated method stub
		// Get the image tracker:
		TrackerManager trackerManager = TrackerManager.getInstance();
		ObjectTracker objectTracker = (ObjectTracker) trackerManager.getTracker(ObjectTracker.getClassType());

		// Initialize target finder:
		TargetFinder targetFinder = objectTracker.getTargetFinder();

		// Start initialization:
		if (targetFinder.startInit(kAccessKey, kSecretKey)) {
			targetFinder.waitUntilInitFinished();
		}
		
		int resultCode = targetFinder.getInitState();
		if (resultCode != TargetFinder.INIT_SUCCESS) {

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
		ObjectTracker objectTracker = (ObjectTracker) trackerManager.getTracker(ObjectTracker.getClassType());
		objectTracker.start();

		// Start cloud based recognition if we are in scanning mode:
		TargetFinder targetFinder = objectTracker.getTargetFinder();
		targetFinder.startRecognition();
		LoadButton();
		return result;
	}

	@Override
	public boolean doStopTrackers() {
		// TODO Auto-generated method stub
		// Indicate if the trackers were stopped correctly
		boolean result = true;

		TrackerManager trackerManager = TrackerManager.getInstance();
		ObjectTracker objectTracker = (ObjectTracker) trackerManager.getTracker(ObjectTracker.getClassType());

		if (objectTracker != null) {
			objectTracker.stop();

			// Stop cloud based recognition:
			TargetFinder targetFinder = objectTracker.getTargetFinder();
			targetFinder.stop();

			// Clears the trackables
			targetFinder.clearTrackables();
		} else {
			result = false;
		}
		return result;
	}

	@Override
	public boolean doUnloadTrackersData() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean doDeinitTrackers() {
		// Indicate if the trackers were deinitialized correctly
		boolean result = true;

		TrackerManager tManager = TrackerManager.getInstance();
		tManager.deinitTracker(ObjectTracker.getClassType());

		return result;
	}

	@Override
	public void onInitARDone(ApplicationException exception) {
		// TODO Auto-generated method stub
		if (exception == null) {
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
			} catch (ApplicationException e) {
				Log.e("Cam", e.getString());
			}

			boolean result = CameraDevice.getInstance().setFocusMode(CameraDevice.FOCUS_MODE.FOCUS_MODE_CONTINUOUSAUTO);

			/*
			 * if (result) mContAutofocus = true; else Log.e(LOGTAG,
			 * "Unable to enable continuous autofocus");
			 */
			mUILayout.bringToFront();

			mUILayout.setBackgroundColor(Color.TRANSPARENT);

		} else {
			Log.e("cam", exception.getString());
			/*
			 * if(mInitErrorCode != 0) { showErrorMessage(mInitErrorCode,10,
			 * true); } else { finish(); }
			 */
		}
	}

	@Override
	public void onQCARUpdate(State state) {
		numberScan = numberScan + 1;
		if (numberScan == 500 && mTargetID.equals("")) {
			DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
				@Override
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {
					case DialogInterface.BUTTON_POSITIVE:

						Toast.makeText(getApplicationContext(), "You've stoped scan target", Toast.LENGTH_LONG).show();
						doStopTrackers();
						Intent intent = new Intent(getApplicationContext(), ProgramActivity.class);
						intent.putExtra("customerID", mUserID);
						startActivity(intent);
						break;

					case DialogInterface.BUTTON_NEGATIVE:
						numberScan = 0;
						// No button clicked
						break;
					}
				}
			};

			AlertDialog.Builder builder = new AlertDialog.Builder(CameraActivity.this);
			builder.setMessage("Could not find target, do you wanna stop?")
					.setPositiveButton("Yes", dialogClickListener).setNegativeButton("No", dialogClickListener).show();
		}
		// Get the tracker manager:
		TrackerManager trackerManager = TrackerManager.getInstance();

		// Get the image tracker:
		ObjectTracker objectTracker = (ObjectTracker) trackerManager.getTracker(ObjectTracker.getClassType());

		// Get the target finder:
		TargetFinder finder = objectTracker.getTargetFinder();

		// Check if there are new results available:
		final int statusCode = finder.updateSearchResults();

		// Show a message if we encountered an error:
		if (statusCode < 0) {
			Log.e("Cam", statusCode + "");

		} else if (statusCode == TargetFinder.UPDATE_RESULTS_AVAILABLE) {
			// Process new search results
			if (finder.getResultCount() > 0) {
				TargetSearchResult result = finder.getResult(0);

				// Check if this target is suitable for tracking:
				if (result.getTrackingRating() > 0) {
					Trackable trackable = finder.enableTracking(result);

					if (trackable != null) {
						// Lay ra ID cua doi tuong
						doStopTrackers();
						mTargetID = result.getUniqueTargetId();
						showToast(mTargetID);
						// TargetService ts = new TargetService();
						// String dataTarget= ts.GetDataTarget(mTargetID);
						// try {
						// // Sau khi lay duoc du lieu tu service thi bat dau
						// gui sang cho XML doc
						// LoadXML(dataTarget);
						// } catch (ParserConfigurationException e) {
						// // TODO Auto-generated catch block
						// e.printStackTrace();
						// } catch (SAXException e) {
						// // TODO Auto-generated catch block
						// Log.e("Hien", e.getMessage());
						// e.printStackTrace();
						// } catch (IOException e) {
						// // TODO Auto-generated catch block
						// e.printStackTrace();
						// }

					}
				}
			}
		}

	}

	private void showToast(String text) {
		Toast.makeText(this, text, Toast.LENGTH_SHORT).show();
	}

	// @Override
	// public void onLocationChanged(Location location) {
	// // TODO Auto-generated method stub
	// double latitude = location.getLatitude();
	// double longitude = location.getLongitude();
	// myPosition = new LatLng(latitude, longitude);
	// myPosition_temp = new LatLng(latitude, longitude);
	// Log.e("location",myPosition.latitude + "-"+ myPosition.longitude );
	// }

	private double distance(double lat1, double lon1, double lat2, double lon2, char unit) {
		double theta = lon1 - lon2;
		double dist = Math.sin(deg2rad(lat1)) * Math.sin(deg2rad(lat2))
				+ Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) * Math.cos(deg2rad(theta));
		dist = Math.acos(dist);
		dist = rad2deg(dist);
		dist = dist * 60 * 1.1515;
		if (unit == 'K') {
			dist = dist * 1.609344;
		} else if (unit == 'N') {
			dist = dist * 0.8684;
		}
		return (dist);
	}

	private double deg2rad(double deg) {
		return (deg * Math.PI / 180.0);
	}

	/* ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: */
	/* :: This function converts radians to decimal degrees : */
	/* ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: */
	private double rad2deg(double rad) {
		return (rad * 180.0 / Math.PI);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// MenuInflater inflater = getMenuInflater();
		// inflater.inflate(R.menu.camera_menu, menu);

		return true;

	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		Intent intent;
	    // Handle item selection
	    switch (item.getItemId()) {      
	        case R.id.profile:
	        	intent = new Intent(getApplicationContext(),ProfileActivity.class);
	    		intent.putExtra("customerID",mUserID );
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
	
	
	public void MessengerBox(String mes) {
		AlertDialog.Builder dlgAlert = new AlertDialog.Builder(this);
		dlgAlert.setMessage(mes);
		dlgAlert.setTitle("Thông báo");
		dlgAlert.setPositiveButton("OK", new DialogInterface.OnClickListener() {
			public void onClick(DialogInterface dialog, int whichButton) {
				// call your code here
				dialog.dismiss();
			}
		});
		dlgAlert.setCancelable(true);
		dlgAlert.create().show();

	}

}