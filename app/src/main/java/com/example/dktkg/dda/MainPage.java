package com.example.dktkg.dda;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;
import static com.example.dktkg.dda.MainActivity.userid;

/**
 * Created by dktkg on 2017-03-23.
 */


public class MainPage extends Activity {

    String id = userid;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

    }


}
