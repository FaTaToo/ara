package uit.aep06.phuctung.ara;

import org.json.JSONException;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;
import uit.aep06.phuctung.ara.CommonClass.CustomerAccount;
import uit.aep06.phuctung.ara.Service.CustomerAccountService;

public class RegisterActivity extends Activity implements OnClickListener {
	Button btnRegister;
	EditText etUser, etFirstName, etLastName, etEmail, etPass, etRetype, etAddress, etBirthday, etPhone;
	RadioButton radioMale;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_register);

		btnRegister = (Button) findViewById(R.id.btnRegister);
		btnRegister.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		if (v.getId() == R.id.btnRegister) {
			etFirstName = (EditText) findViewById(R.id.etFirstName);
			etLastName = (EditText) findViewById(R.id.etLastName);
			radioMale = (RadioButton) findViewById(R.id.radioMale);
			etBirthday = (EditText) findViewById(R.id.etBirthday);
			etAddress = (EditText) findViewById(R.id.etAddress);
			etEmail = (EditText) findViewById(R.id.etEmail);
			etPhone = (EditText) findViewById(R.id.etPhone);
			etUser = (EditText) findViewById(R.id.etUsername);
			etPass = (EditText) findViewById(R.id.etPassword);
			etRetype = (EditText) findViewById(R.id.etRetypePassword);
			if (etFirstName.getText().toString().isEmpty() || etLastName.getText().toString().isEmpty()
					|| etBirthday.getText().toString().isEmpty() || etAddress.getText().toString().isEmpty()
					|| etEmail.getText().toString().isEmpty() || etPhone.getText().toString().isEmpty()
					|| etUser.getText().toString().isEmpty() || etPass.getText().toString().isEmpty()
					|| etRetype.getText().toString().isEmpty())
				Toast.makeText(getApplicationContext(), "Alert ! Can not be" + " empty.", Toast.LENGTH_LONG).show();
			return;
		}
		if (!etPass.getText().toString().equals(etRetype.getText().toString())) {
			etPass.setText("");
			etRetype.setText("");
			etPass.setFocusable(true);
			etPass.setHighlightColor(new Color().RED);
			etPass.setHint("Passwords do not match");
		} else {
			CustomerAccount customerAccount = new CustomerAccount();
			customerAccount.setFirstName(etFirstName.getText().toString());
			customerAccount.setLastName(etLastName.getText().toString());
			customerAccount.setBirthDay(etBirthday.getText().toString());
			customerAccount.setAddress(etAddress.getText().toString());
			customerAccount.setEmail(etEmail.getText().toString());
			customerAccount.setPhone(etPhone.getText().toString());
			customerAccount.setUsername(etUser.getText().toString());
			customerAccount.setPass(etPass.getText().toString());
			if (radioMale.isChecked()) {
				customerAccount.setSex("Male");
			} else {
				customerAccount.setSex("Female");
			}
			
			try {
				SignUp task = new SignUp();
				int result = task.execute(customerAccount).get();

				if (result == 0) {
					etUser.setText("fatatoo");
					etUser.setFocusable(true);
					etUser.setHighlightColor(new Color().RED);
					etUser.setHint("This username or email or phone is exists.");
					return;
				} else {
					Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
					startActivity(intent);
				}
			} catch (Exception e) {
				Log.e("Register", "fail...");
			}
		}
	}

	private class SignUp extends AsyncTask<CustomerAccount, Void, Integer> {

		@Override
		protected Integer doInBackground(CustomerAccount... params) {
			CustomerAccountService service = new CustomerAccountService();
			int result = 0;
			try {
				result = service.addNewCustomerAccount(params[0]);
				return result;
			} catch (JSONException e) {
				// TODO Auto-generated catch block
				Log.e("Sign Up", e.toString());
			}
			return result;
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
			intent = new Intent(getApplicationContext(), AboutActivity.class);
			startActivity(intent);
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}
}
