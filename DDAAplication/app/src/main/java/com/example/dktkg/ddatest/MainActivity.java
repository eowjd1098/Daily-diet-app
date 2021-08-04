package com.example.dktkg.ddatest;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

public class MainActivity extends Activity {

    private Button btnRegist;
    private Button btnLogin;
    private EditText etEmail;
    private EditText etPassword;
    public static String userid;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.loginactivity);
        startActivity(new Intent(this, SplashActivity.class));

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);
        initializeGood();

        etEmail = (EditText) findViewById(R.id.etEmail);
        btnRegist = (Button) findViewById(R.id.btnRegist);
        btnLogin = (Button) findViewById(R.id.btnLogin);
        etPassword = (EditText) findViewById(R.id.etPassword);

        // 회원가입 버튼이벤트
        btnRegist.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), RegistActivity.class);
                intent.setFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
                startActivityForResult(intent, 1000);

            }
        });

        //로그인 버튼이벤트
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                userid = etEmail.getText().toString();
                String id = etEmail.getText().toString();
                String pw = etPassword.getText().toString();
                LoginMember loginMember = (LoginMember) new LoginMember().execute(id, pw);
            }
        });

    }

    public class LoginMember extends AsyncTask<String, Void, String> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... params) {
            Connect con = new Connect("Login");
            SoapObject request = new SoapObject(con.getNamespace(), con.getMethodname());
            request.addProperty("id", params[0]);
            request.addProperty("pw", params[1]);

            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
            envelope.setOutputSoapObject(request);
            envelope.dotNet = true;
            HttpTransportSE post = new HttpTransportSE(con.getUrl());

            String result = "";
            try {
                post.call(con.getSaopaction(), envelope);
                result = envelope.getResponse().toString();
            } catch (Exception e) {
                result = e.toString();
            }
            return result;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            String checklogin = s;
            if (checklogin.equals("1")) {
                Intent intent = new Intent(getApplicationContext(), MainButton.class);
                startActivity(intent);
            }
            if (checklogin.equals("0")) {
                Toast.makeText(MainActivity.this, "로그인 실패! 관리자에게 문의하세요!", Toast.LENGTH_SHORT).show();
                return;
            }
            if (checklogin.equals("2")) {
                Toast.makeText(MainActivity.this, "PW가 틀렷습니다. PW를 확인해주세요", Toast.LENGTH_SHORT).show();
                return;
            }
            if (checklogin.equals("3")) {
                Toast.makeText(MainActivity.this, "없는 ID 입니다 ID를 확인해주세요", Toast.LENGTH_SHORT).show();
                return;
            }

        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        Log.d("RESULT", requestCode + "");
        Log.d("RESULT", resultCode + "");
        Log.d("RESULT", data + "");

        if (requestCode == 1000 && resultCode == RESULT_OK) {
            Toast.makeText(MainActivity.this, "회원가입을 완료했습니다!", Toast.LENGTH_SHORT).show();
            etEmail.setText(data.getStringExtra("email"));
        }
    }
    private void initializeGood() 	{
        InitializationRunnable init = new InitializationRunnable();
        new Thread(init).start();
    }

    /**
     * 초기화 작업 처리
     */
    class InitializationRunnable implements Runnable {
        public void run() {
        }
    }
}