package uit.aep06.phuctung.ara;

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
import android.hardware.camera2.*;

public class LoginActivity extends Activity implements OnClickListener {
	Button btnLogin;
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
	}
	private void invalidLogin() {
		etPassword.setText("");
		etUserName.setFocusable(true);
		tvError.setText("Username or Password can not be null");
	}
	private int checkExists(CustomerAccount customer) {
		// Implement code call service to check
		return 1;
	}	
}