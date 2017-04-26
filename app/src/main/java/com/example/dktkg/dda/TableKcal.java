package com.example.dktkg.dda;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

/**
 * Created by dktkg on 2017-03-23.
 */

public class TableKcal extends Activity {
    private EditText mHeightText;
    private EditText mWeightText;
    private TextView mResultView;
    private Button okButton;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tableone);

        mHeightText = (EditText)findViewById(R.id.val_height);
        mWeightText = (EditText)findViewById(R.id.val_weight);
        mResultView = (TextView)findViewById(R.id.rst_text);
        okButton = (Button)findViewById(R.id.ok);

        okButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v) {
                float cm = Integer.parseInt(mHeightText.getText().toString());
                cm = cm/100;
                float kg = Integer.parseInt(mWeightText.getText().toString());
                float BMI = (kg / (cm * cm));
                Log.d("TableKcalClass","BMI:"+String.format("%f",BMI)+"/"+"cm:"+cm+"/"+"kg:"+kg);
                String str_result;
                if(BMI >=30.0)
                {
                    str_result="2단계 비만";
                }
                else if((BMI<=29.9) && (BMI>=25.0))
                {
                    str_result = "1단계 비만";
                }
                else if((BMI>18.5) && (BMI<=24.9))
                {
                    str_result="정상";
                }
                else
                {
                    str_result="저체중";
                }
                str_result = String.format("%.2f",BMI) + "%" + str_result;
                mResultView.setText(str_result);
            }
        });
    }
}