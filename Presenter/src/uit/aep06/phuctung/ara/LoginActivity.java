package uit.aep06.phuctung.ara;

import java.io.IOException;

import org.json.JSONException;

import android.R.bool;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;
import uit.aep06.phuctung.ara.Service.CustomerAccountService;
import android.hardware.camera2.*;

public class LoginActivity extends Activity implements OnClickListener {
	Button btnLogin, btnRegister ;
	EditText etUserName, etPassword;
	TextView tvError;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_login);
		etUserName = (EditText)findViewById(R.id.etUsername);
		etPassword = (EditText)findViewById(R.id.etPassword);
		tvError = (TextView)findViewById(R.id.tvError);  
		btnLogin = (Button)findViewById(R.id.btnLogin);
		btnLogin.setOnClickListener(this);
		btnRegister = (Button)findViewById(R.id.btnRegister);
        btnRegister.setOnClickListener(this);			
	}
	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		if(v.getId() == R.id.btnLogin) {
			String userName = etUserName.getText().toString();
			String pass = etPassword.getText().toString();
			if (userName.isEmpty() || pass.isEmpty() ) {
				invalidLogin();
				return;
			}
			
			CustomerAccount customer = new CustomerAccount();
			customer.setUsername(userName);
			customer.setPass(pass);
			try {
				int value = checkExists(customer);
				if(value == 0)
				{
					invalidLogin();
					return;
				}else{
					Intent intent = new Intent(getApplicationContext(),ProgramActivity.class);
					intent.putExtra("customerID", value + "");
					startActivity(intent);
				}
			} catch (Exception e) {
				Log.e("error", e.getMessage());
			}
			
		}
		else if (v.getId() == R.id.btnRegister) {
			Intent intent = new Intent(getApplicationContext(),RegisterActivity.class);				
			startActivity(intent);
		}
		
	}
	private void invalidLogin() {
		etPassword.setText("");
		etUserName.setFocusable(true);
		tvError.setText("Username or Password can not be null");
	}
	private int checkExists(CustomerAccount customer) throws IOException, JSONException {
		// Implement code call service to check
		CustomerAccountService cusAccService = new CustomerAccountService();
		return 1;//cusAccService.authenticate(customer);		
	}	
	
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.login, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
	    // Handle item selection
	    switch (item.getItemId()) {
	       	case R.id.about:
	        	Intent intent = new Intent(getApplicationContext(),AboutActivity.class);
	    		startActivity(intent);
	            return true;
	        default:
	            return super.onOptionsItemSelected(item);
	    }
	}
	
}