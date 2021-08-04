package com.example.dktkg.ddatest;

import android.app.Activity;
import android.os.Bundle;
import android.view.WindowManager;

import static com.example.dktkg.ddatest.MainActivity.userid;

/**
 * Created by dktkg on 2017-05-12.
 */

public class MainPage extends Activity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
    }
}
