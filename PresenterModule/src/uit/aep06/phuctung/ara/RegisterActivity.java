package uit.aep06.phuctung.ara;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;
import uit.aep06.phuctung.ara.Service.CustomerAccountService;

public class RegisterActivity extends Activity implements OnClickListener {
	Button btnRegister;
	EditText etUser, etFullname, etEmail, etPass, etRetype;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_register);
		
		btnRegister = (Button)findViewById(R.id.btnRegister);
		btnRegister.setOnClickListener(this);
	}
	@Override
	public void onClick(View v) {
		if(v.getId() == R.id.btnRegister) {
			etUser = (EditText)findViewById(R.id.etUsername);
			etFullname = (EditText)findViewById(R.id.etFullname);
			etEmail = (EditText)findViewById(R.id.etEmail);
			etPass = (EditText)findViewById(R.id.etPassword);
			etRetype = (EditText)findViewById(R.id.etRetypePassword);
			
			if (etUser.getText().toString().isEmpty() || etFullname.getText().toString().isEmpty() ||
					etEmail.getText().toString().isEmpty() || etPass.getText().toString().isEmpty()){				
				Toast.makeText(getApplicationContext(), "Alert ! Can not be empty.", Toast.LENGTH_LONG).show();
				return;
			}
			if (!etPass.getText().toString().equals(etRetype.getText().toString()))
			{
				etPass.setText("");
				etRetype.setText("");
				etPass.setFocusable(true);
				etPass.setHighlightColor(new Color().RED);
				etPass.setHint("Passwords do not match");
			}else{
				CustomerAccount customerAccount = new CustomerAccount();
				customerAccount.setUsername(etUser.getText().toString());
				customerAccount.setPass(etPass.getText().toString());
				customerAccount.setEmail(etEmail.getText().toString());
				customerAccount.setFullname(etFullname.getText().toString());
				CustomerAccountService service = new CustomerAccountService();
				try {
					int result = 0;//service.AddNewCustomerAccount(customerAccount);
					if (result == 0){
						etUser.setText("");
						etUser.setFocusable(true);
						etUser.setHighlightColor(new Color().RED);
						etUser.setHint("This username is exists.");
						return;
					}else{
						Intent intent = new Intent (getApplicationContext(),LoginActivity.class);
						startActivity(intent);
					}
				} catch (Exception e) {
					Log.e("Register", "fail...");
				}
			}			
		}
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		Intent intent;
	    // Handle item selection
	    switch (item.getItemId()) {	    	
	        case R.id.about:
	        	intent = new Intent(getApplicationContext(),AboutActivity.class);
	    		startActivity(intent);
	            return true;
	        default:
	            return super.onOptionsItemSelected(item);
	    }
	}
}
