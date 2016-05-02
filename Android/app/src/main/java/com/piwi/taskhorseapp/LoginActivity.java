package com.piwi.taskhorseapp;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.auth.api.Auth;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.auth.api.signin.GoogleSignInResult;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.piwi.taskhorseapp.Logging.AndroidLogger;
import com.piwi.taskhorseapp.Logging.ConsoleLogger;
import com.piwi.taskhorseapp.Models.AuthenticationRequest;
import com.piwi.taskhorseapp.Models.SignUp;
import com.piwi.taskhorseapp.Models.TokenResult;
import com.piwi.taskhorseapp.Rest.AuthenticateRestClient;
import com.piwi.taskhorseapp.Services.AuthenticateService;

import java.util.concurrent.ExecutionException;

public class LoginActivity extends AppCompatActivity implements GoogleApiClient.OnConnectionFailedListener, View.OnClickListener {

    private static final int RC_SIGN_IN = 9001;
    AuthenticateService authenticateService;

    //private GoogleApiClient mGoogleApiClient;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        authenticateService = new AuthenticateService(new AuthenticateRestClient(new AndroidLogger(), "http://10.0.2.2:8086/api/authentication"));

        findViewById(R.id.google_sign_in_button).setOnClickListener(this);
        findViewById(R.id.login_button).setOnClickListener(this);
        findViewById(R.id.signup_load_form_button).setOnClickListener(this);
        findViewById(R.id.signup_button).setOnClickListener(this);
    }

    @Override
    public void onConnectionFailed(ConnectionResult connectionResult) {

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.google_sign_in_button:
                googleSignIn();
                break;
            case R.id.login_button:
                loginQuestBoard();
                break;
            case R.id.signup_load_form_button:
                loadSignUpForm();
                break;
            case R.id.signup_button:
                signUp();
                break;
        }
    }

    private void loadSignUpForm() {
        ((LinearLayout)findViewById(R.id.login_form)).setVisibility(View.INVISIBLE);
        ((LinearLayout)findViewById(R.id.signup_form)).setVisibility(View.VISIBLE);
    }

    private void signUp() {
        // Get email
        // Get password
        // Get username
        SignUp signUp = new SignUp();
        signUp.Email = ((EditText)findViewById(R.id.signup_email)).getText().toString();
        signUp.Password = ((EditText)findViewById(R.id.signup_password)).getText().toString();
        signUp.Username = ((EditText)findViewById(R.id.signup_username)).getText().toString();

        AsyncTask<SignUp, Void, Boolean> atask = new AsyncTask<SignUp, Void, Boolean>() {
            @Override
            protected Boolean doInBackground(SignUp... params) {

                return authenticateService.signUp(params[0]);
            }

            @Override
            protected void onPostExecute(Boolean aBoolean) {
                super.onPostExecute(aBoolean);
                if(aBoolean){
                    Intent i = new Intent(LoginActivity.this, CreateGroupActivity.class);
                    startActivity(i);
                }
                else{
                    Toast.makeText(LoginActivity.this, "Sign up failed. Please try again", Toast.LENGTH_LONG);
                }
            }
        }.execute(signUp);



    }

    private void loginQuestBoard() {
        // get email + password
        // send to authentication service
        // if success, continue to questboard screen
        String email = ((EditText)findViewById(R.id.login_email)).getText().toString();
        String password = ((EditText)findViewById(R.id.login_password)).getText().toString();
        AuthenticationRequest authRequest = new AuthenticationRequest();
        authRequest.Email = email;
        authRequest.Password = password;

        AsyncTask<AuthenticationRequest, Void, TokenResult> authenticateTask = new AsyncTask<AuthenticationRequest, Void, TokenResult>() {
            @Override
            protected TokenResult doInBackground(AuthenticationRequest... authRequest) {
                return authenticateService.authenticate(authRequest[0]);
            }

            @Override
            protected void onPostExecute(TokenResult tokenResult) {
                super.onPostExecute(tokenResult);
                // if success continue to quest board
                // else toast unsuccessful attempt

                if(tokenResult.Token == null || "".equals(tokenResult.Token)){
                    Toast.makeText(LoginActivity.this, "Authentication was unsuccessful. Please try again", Toast.LENGTH_LONG).show();
                }
                else{
                    Intent i = new Intent(LoginActivity.this, CreateGroupActivity.class);
                    startActivity(i);
                }

            }
        }.execute(authRequest);
    }


    private void googleSignIn() {
        GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN).requestEmail().build();
        GoogleApiClient mGoogleApiClient = new GoogleApiClient.Builder(this).enableAutoManage(this, this).addApi(Auth.GOOGLE_SIGN_IN_API, gso).build();
        Intent signInIntent = Auth.GoogleSignInApi.getSignInIntent(mGoogleApiClient);
        startActivityForResult(signInIntent, RC_SIGN_IN);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // Result returned from launching the Intent from GoogleSignInApi.getSignInIntent(...);
        if (requestCode == RC_SIGN_IN) {
            GoogleSignInResult result = Auth.GoogleSignInApi.getSignInResultFromIntent(data);
            handleSignInResult(result);
        }
    }

    private void handleSignInResult(GoogleSignInResult result) {
        Log.d("PR", "handleSignInResult:" + result.isSuccess());
        if (result.isSuccess()) {
            // Signed in successfully, show authenticated UI.
            GoogleSignInAccount acct = result.getSignInAccount();
            //((TextView) findViewById(R.id.status_text_view)).setText(getString(R.string.signed_in_fmt, acct.getDisplayName()));
            updateUI(true);
        } else {
            // Signed out, show unauthenticated UI.
            updateUI(false);
        }
    }

    private void updateUI(boolean signedIn) {
        if (signedIn) {
            findViewById(R.id.google_sign_in_button).setVisibility(View.GONE);
            //findViewById(R.id.sign_out_and_disconnect).setVisibility(View.VISIBLE);
        } else {
           // mStatusTextView.setText(R.string.signed_out);

            findViewById(R.id.google_sign_in_button).setVisibility(View.VISIBLE);
            //findViewById(R.id.sign_out_and_disconnect).setVisibility(View.GONE);
        }
    }
}
