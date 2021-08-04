package com.example.dktkg.ddatest;

import android.app.Activity;
import android.graphics.drawable.AnimationDrawable;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.view.WindowManager;
import android.widget.ImageView;

/**
 * Created by dktkg on 2017-05-12.
 */

public class SplashActivity extends Activity {

    private ImageView img;
    private AnimationDrawable ani;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.splash_main);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        initialize();
    }

    private void initialize() {
        Handler handler = new Handler() {
            @Override
            public void handleMessage(Message msg) {
                finish();    	// 액티비티 종료
            }
        };
        handler.sendEmptyMessageDelayed(0, 2200);	// ms, 3초후 종료시킴

        img=(ImageView)findViewById(R.id.img);
        ani=(AnimationDrawable)img.getDrawable();

        new Thread(new Runnable() {
            @Override
            public void run() {
                Handler handler = new Handler(Looper.getMainLooper());
                handler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        img.setImageResource(R.drawable.main_list);
                        ani=(AnimationDrawable)img.getDrawable();
                        ani.start();
                    }
                }, 0);
            }
        }).start();

    }
}
