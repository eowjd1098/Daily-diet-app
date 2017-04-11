package com.example.dktkg.dda;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.widget.Toast;

/**
 * Created by dktkg on 2017-03-23.
 */

public class SplashActivity extends Activity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.splash_main);
        Toast.makeText(this,"Daliy Diet AI",Toast.LENGTH_SHORT).show();
        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                finish();       // 3 초후 이미지를 닫아버림
            }
        }, 3000);
    }
}

