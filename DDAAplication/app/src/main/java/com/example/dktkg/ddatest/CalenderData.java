package com.example.dktkg.ddatest;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.WindowManager;
import android.widget.TextView;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.MarshalBase64;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import static com.example.dktkg.ddatest.MainActivity.userid;

/**
 * Created by dktkg on 2017-05-30.
 */

public class CalenderData extends Activity {
    private TextView textView;
    private FoodNutrient result;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.datasave);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        Intent intent = getIntent();

        textView = (TextView) findViewById(R.id.test);
        String date = intent.getStringExtra("date");
        String id = userid;
        LoadFoodData loadFoodData = (LoadFoodData) new LoadFoodData().execute(id, date);
    }

    public class LoadFoodData extends AsyncTask<String, Void, FoodNutrient> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected FoodNutrient doInBackground(String... params) {
            Connect con = new Connect("LoadEatFood");
            SoapObject request = new SoapObject(con.getNamespace(), con.getMethodname());
            request.addProperty("id", params[0]);
            request.addProperty("date", params[1]);

            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
            envelope.setOutputSoapObject(request);
            envelope.dotNet = true;
            new MarshalBase64().register(envelope);
            HttpTransportSE post = new HttpTransportSE(con.getUrl());

            FoodNutrient foodNutrient = null;

            try {
                post.call(con.getSaopaction(), envelope);
                SoapObject result = (SoapObject) envelope.getResponse();

                int kcal = Integer.parseInt(result.getProperty("kcal").toString());
                double cho = Double.parseDouble(result.getProperty("cho").toString());
                double fat = Double.parseDouble(result.getProperty("fat").toString());
                double protein = Double.parseDouble(result.getProperty("protein").toString());
                double na = Double.parseDouble(result.getProperty("na").toString());
                foodNutrient = new FoodNutrient(kcal, cho, fat, protein, na);

            } catch (Exception e) {
                Log.e("ERROR", "this is error", e);
            }
            return foodNutrient;
        }

        @Override
        protected void onPostExecute(FoodNutrient foodNutrient) {
            super.onPostExecute(foodNutrient);
            result = foodNutrient;

            String result_Kcal = "칼로리" + compare(foodNutrient.getKcal(), 2500);
            String result_cho = "탄수화물" + compare(foodNutrient.getCho(), 400);
            String result_protein = "단백질" + compare(foodNutrient.getProtein(), 100);
            String result_fat = "지방" + compare(foodNutrient.getFat(), 45);
            String result_na = "나트륨" + compare(foodNutrient.getNa(), 2000);

            String re = "\n\n\n\n열량 ...................................... " + foodNutrient.getKcal() +                 "/2500kcal          " + result_Kcal + "\n\n\n탄수화물 ...................................... " + foodNutrient.getCho() + "/400g     " + result_cho +
                    "\n\n\n단백질 ...................................... " + foodNutrient.getProtein() + "/100g              " + result_protein + "\n\n\n지방 ....................................... " + foodNutrient.getFat() +
                    "/45g                  " + result_fat + "\n\n\n나트륨 .......................................  " + foodNutrient.getNa() + "/2000mg  " + result_na;
            textView.setText(re);
        }

        protected String compare(double server, double max) {
            String resultString;

            if (server / max < 0.9) {
                resultString = "부족";
            } else if ((server / max > 1.1) && (server / max > 1.3)) {
                resultString = "만족";
            } else {
                resultString = "초과";
            }
            return resultString;
        }
    }

}
