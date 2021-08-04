package com.example.dktkg.ddatest;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

/**
 * Created by dktkg on 2017-05-12.
 */

public class RegistActivity extends Activity {
    //선언
    private EditText etEmail;
    private EditText etPassword;
    private EditText etPasswordConfirm;
    private EditText etName, etAge;
    private Button btnDone;
    private Button btnCancel;
    private RadioGroup rbg_gender;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.registactivity);

        // 변수 연결
        etEmail = (EditText) findViewById(R.id.etEmail);
        etPassword = (EditText) findViewById(R.id.etPassword);
        etPasswordConfirm = (EditText) findViewById(R.id.etPasswordConfirm);
        etName = (EditText) findViewById(R.id.etName);
        etAge = (EditText) findViewById(R.id.etAge);
        rbg_gender = (RadioGroup) findViewById(R.id.rbg_gender);
        btnDone = (Button) findViewById(R.id.btnDone);
        btnCancel = (Button) findViewById(R.id.btnCancel);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);
        // 비밀번호 일치 검사
        etPasswordConfirm.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                String password = etPassword.getText().toString();
                String confirm = etPasswordConfirm.getText().toString();

                if (password.equals(confirm)) {
                    etPassword.setBackgroundColor(Color.GREEN);
                    etPasswordConfirm.setBackgroundColor(Color.GREEN);
                } else {
                    etPassword.setBackgroundColor(Color.RED);
                    etPasswordConfirm.setBackgroundColor(Color.RED);
                }
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

        btnDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // 이메일 입력 확인
                if (etEmail.getText().toString().length() == 0) {
                    Toast.makeText(RegistActivity.this, "Email을 입력하세요!", Toast.LENGTH_SHORT).show();
                    etEmail.requestFocus();
                    return;
                }

                // 비밀번호 입력 확인
                if (etPassword.getText().toString().length() == 0) {
                    Toast.makeText(RegistActivity.this, "비밀번호를 입력하세요!", Toast.LENGTH_SHORT).show();
                    etPassword.requestFocus();
                    return;
                }

                // 비밀번호 확인 입력 확인
                if (etPasswordConfirm.getText().toString().length() == 0) {
                    Toast.makeText(RegistActivity.this, "비밀번호 확인을 입력하세요!", Toast.LENGTH_SHORT).show();
                    etPasswordConfirm.requestFocus();
                    return;
                }
                // 이름 입력 확인
                if (etName.getText().toString().length() == 0) {
                    Toast.makeText(RegistActivity.this, "이름을 입력하세요!", Toast.LENGTH_SHORT).show();
                    etName.requestFocus();
                    return;
                }

                // 나이 입력 확인
                if (etAge.getText().toString().length() == 0) {
                    Toast.makeText(RegistActivity.this, "나이를 입력하세요!", Toast.LENGTH_SHORT).show();
                    etAge.requestFocus();
                    return;
                } else { //나이값이 숫자값인지 확인
                    try {
                        Integer.parseInt(etAge.getText().toString());
                    } catch (Exception e) {
                        Toast.makeText(RegistActivity.this, "숫자만 입력하세요!", Toast.LENGTH_SHORT).show();
                        etAge.requestFocus();
                        return;
                    }
                }

                //성별 선택 확인
                RadioButton rb = (RadioButton) findViewById(rbg_gender.getCheckedRadioButtonId());
                if (rb == null) {
                    Toast.makeText(RegistActivity.this, "성별을 선택하세요!", Toast.LENGTH_SHORT).show();
                    return;
                }

                // 비밀번호 일치 확인
                if (!etPassword.getText().toString().equals(etPasswordConfirm.getText().toString())) {
                    Toast.makeText(RegistActivity.this, "비밀번호가 일치하지 않습니다!", Toast.LENGTH_SHORT).show();
                    etPassword.setText("");
                    etPasswordConfirm.setText("");
                    etPassword.requestFocus();
                    return;
                }

                //회원가입 데이터 설정
                String id = etEmail.getText().toString();
                String pw = etPassword.getText().toString();
                String name = etName.getText().toString();
                String age = etAge.getText().toString();
                String gender = rb.getText().toString();

                Addmember addmember = (Addmember) new Addmember().execute(id, pw, name, age, gender);

            }
        });
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

    }

    public class Addmember extends AsyncTask<String, Void, String> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... params) {
            // 서버 호출
            Connect con = new Connect("AddMember");
            SoapObject request = new SoapObject(con.getNamespace(), con.getMethodname());
            request.addProperty("id", params[0]);
            request.addProperty("pw", params[1]);
            request.addProperty("name", params[2]);
            request.addProperty("age", params[3]);
            request.addProperty("gender", params[4]);

            //준비
            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
            envelope.setOutputSoapObject(request);
            envelope.dotNet = true;
            HttpTransportSE post = new HttpTransportSE(con.getUrl());

            //호출
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
            String checkaddmember = s;
            //성공 =1 , 아이디 중복 =2 , 실패 =3
            if (checkaddmember.equals("1")) {
                Intent result = new Intent();
                result.putExtra("email", etEmail.getText().toString());

                // 자신을 호출한 Activity로 데이터를 보낸다.
                setResult(RESULT_OK, result);
                finish();
            }
            if (checkaddmember.equals("2")) {
                Toast.makeText(RegistActivity.this, "이미 사용중인 ID 입니다!", Toast.LENGTH_SHORT).show();
                return;
            }
            if (checkaddmember.equals("3")) {
                Toast.makeText(RegistActivity.this, "회원가입 실패! 관리자에게 문의하세요!", Toast.LENGTH_SHORT).show();
                return;
            }

        }

    }
}