package com.example.dktkg.ddatest;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.CalendarView;
import android.widget.EditText;
import android.widget.TextView;


/**
 * Created by dktkg on 2017-05-12.
 */

public class TableKcal extends Activity {
    private EditText mHeightText;
    private EditText mWeightText;
    private TextView mResultView;
    private Button okButton;
    private float BMI;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tableone);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        mHeightText = (EditText) findViewById(R.id.val_height);
        mWeightText = (EditText) findViewById(R.id.val_weight);
        mResultView = (TextView) findViewById(R.id.rst_text);
        okButton = (Button) findViewById(R.id.ok);

        okButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                float cm = Integer.parseInt(mHeightText.getText().toString());
                cm = cm / 100;
                float kg = Integer.parseInt(mWeightText.getText().toString());
                BMI = (kg / (cm * cm));
                Log.d("TableKcalClass", "BMI:" + String.format("%f", BMI) + "/" + "cm:" + cm + "/" + "kg:" + kg);
                String str_result;
                if (BMI >= 30.0) {
                    str_result = "2단계 비만";
                } else if ((BMI <= 29.9) && (BMI >= 25.0)) {
                    str_result = "1단계 비만";
                } else if ((BMI > 18.5) && (BMI <= 24.9)) {
                    str_result = "정상";
                } else {
                    str_result = "저체중";
                }
                str_result = String.format("%.2f", BMI) + "%" + str_result;
                mResultView.setText(str_result);
            }
        });
        final CalendarView calendar = (CalendarView) findViewById(R.id.calendarView);
        calendar.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            public void onSelectedDayChange(CalendarView view, int year,
                                            int month, int dayOfMonth) {
                String date;
                if (month < 9) {
                    if (dayOfMonth < 10) {
                        date = year + "0" + (month + 1) + "0" + dayOfMonth;
                    } else {
                        date = year + "0" + (month + 1) + dayOfMonth;
                    }
                } else {
                    if (dayOfMonth < 10) {
                        date = String.valueOf(year) + (month + 1) + "0" + dayOfMonth;
                    } else {
                        date = String.valueOf(year) + (month + 1) + dayOfMonth;
                    }
                }


                Intent intent = new Intent(TableKcal.this, CalenderData.class);
                intent.putExtra("date", date);

                startActivity(intent);

            }
        });
    }
}