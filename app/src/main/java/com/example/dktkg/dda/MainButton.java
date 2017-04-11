package com.example.dktkg.dda;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

/**
 * Created by dktkg on 2017-03-26.
 */

public class MainButton extends Activity implements View.OnClickListener{

    private Button button1;
    private Button button2;
    private Button button3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        button1 = (Button) findViewById(R.id.button1);
        button1.setOnClickListener(this);
        button2 = (Button) findViewById(R.id.button2);
        button2.setOnClickListener(this);
        button3 = (Button) findViewById(R.id.button3);
        button3.setOnClickListener(this);

    }

    @Override
    public void onClick(View v) {
        switch (v.getId())
        {
            case R.id.button1:
                startActivity(new Intent(getApplicationContext(),TableKcal.class));break;
            case R.id.button2:startActivity(new Intent(getApplicationContext(),TableFood.class));break;
            case R.id.button3:startActivity(new Intent(getApplicationContext(),TableExersice.class));break;
        }
    }
}

