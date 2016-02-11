package uit.aep06.phuctung.ara;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import org.w3c.dom.Document;

import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.Polyline;
import com.google.android.gms.maps.model.PolylineOptions;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.location.Address;
import android.location.Criteria;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;

import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import uit.aep06.phuctung.ara.CommonClass.GMapV2Direction;

public class HelperTargetGPSActivity extends Activity implements LocationListener {
	GoogleMap googleMap;
	LocationManager locationManager;
	String provider;
	private LatLng currentPosition, start, end;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_helper_target_gps);
		initilizeMap();
		Intent intent = getIntent();
		final String[] address = intent.getStringExtra("GPS").split(";");

		TextView tvHelper = (TextView) findViewById(R.id.tvHelper);
		tvHelper.setText("You have to find and scan poster of film at one of addresses below"
				+ " to complete mission. Click to the address to get direction!");

		ListView lv = (ListView) findViewById(R.id.lvAddress);
		ArrayAdapter da = new ArrayAdapter(this, android.R.layout.simple_list_item_1, address);
		lv.setAdapter(da);

		lv.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				if (currentPosition != null) {
					googleMap.clear();
					start = currentPosition;
					end = getPositionFromAddress(address[position]);
					googleMap.addMarker(new MarkerOptions().position(end).title("Destination")
							.snippet("You have to go to here!").alpha(0.7f));
					googleMap.addMarker(
							new MarkerOptions().position(start).title("Start").snippet("You are here!").alpha(0.7f));

					GMapV2Direction direction = new GMapV2Direction(getApplicationContext());
					Document doc = direction.getDocument(start, end, direction.MODE_DRIVING);
					if (doc != null) {
						ArrayList<LatLng> directionPoint = direction.getDirection(doc);
						PolylineOptions rectLine = new PolylineOptions().width(5).color(Color.RED);
						for (int i = 0; i < directionPoint.size(); i++) {
							rectLine.add(directionPoint.get(i));
						}
						Polyline polyline = googleMap.addPolyline(rectLine);
						zoomIn(end.latitude, end.longitude);
					} else {
						Toast.makeText(getApplicationContext(), "Can not get direction at this time!", Toast.LENGTH_LONG);
					}
				}
			}
		});
	}

	private LatLng getPositionFromAddress(String strAddress) {
		Geocoder coder = new Geocoder(this);
		List<Address> address;

		try {
			address = coder.getFromLocationName(strAddress, 5);
			if (address == null) {
				Toast.makeText(getApplicationContext(), "Cannot found this address!", Toast.LENGTH_LONG).show();
				return null;
			}
			Address location = address.get(0);
			return new LatLng(location.getLatitude(), location.getLongitude());
		} catch (Exception ex) {
			Toast.makeText(getApplicationContext(), "Cannot found this address!", Toast.LENGTH_LONG).show();
		}
		return null;
	}

	private void initilizeMap() {
		if (googleMap == null) {
			googleMap = ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();

			// check if map is created successfully or not
			if (googleMap == null) {
				Toast.makeText(getApplicationContext(), "Cannot load map at this time", Toast.LENGTH_SHORT).show();
			} else {
				googleMap.setMyLocationEnabled(true);
				locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
				Criteria criteria = new Criteria();
				provider = locationManager.getBestProvider(criteria, true);
				Location location = locationManager.getLastKnownLocation(locationManager.NETWORK_PROVIDER);
				if (location != null && location.getTime() > Calendar.getInstance().getTimeInMillis() - 2 * 60 * 1000) {
					onLocationChanged(location);

				} else {
					locationManager.requestLocationUpdates(locationManager.NETWORK_PROVIDER, 400, 1, this);
				}
			}
		}
	}

	public void zoomIn(double Lat, double Long) {
		CameraUpdate center = CameraUpdateFactory.newLatLng(new LatLng(Lat, Long));
		CameraUpdate zoom = CameraUpdateFactory.zoomTo(14);
		googleMap.moveCamera(center);
		googleMap.animateCamera(zoom);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.helper_target_gps, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		Intent intent;
		// Handle item selection
		switch (item.getItemId()) {
		case R.id.scan:
			intent = new Intent(getApplicationContext(), CameraActivity.class);
			startActivity(intent);
			return true;
		case R.id.about:
			intent = new Intent(getApplicationContext(), AboutActivity.class);
			startActivity(intent);
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void onLocationChanged(Location location) {
		double latitude = location.getLatitude();
		double longitude = location.getLongitude();
		currentPosition = new LatLng(latitude, longitude);
		zoomIn(currentPosition.latitude, currentPosition.longitude);
		googleMap.addMarker(new MarkerOptions().position(currentPosition).title("Current position")
				.snippet("You are here!").alpha(0.7f));
	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderEnabled(String provider) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onProviderDisabled(String provider) {
		// TODO Auto-generated method stub

	}
}
