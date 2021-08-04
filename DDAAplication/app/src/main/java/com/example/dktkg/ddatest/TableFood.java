package com.example.dktkg.ddatest;

import android.app.Activity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;

import android.provider.MediaStore;
import android.util.Log;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;


import java.io.ByteArrayOutputStream;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.MarshalBase64;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import static com.example.dktkg.ddatest.MainActivity.userid;

/**
 * Created by dktkg on 2017-05-12.
 */

public class TableFood extends Activity {


    private int TAKE_CAMERA = 1; // 카메라 리턴 코드값 설정
    private int TAKE_GALLERY = 2; // 앨범선택에 대한 리턴 코드값 설정

    private Button sendButton;
    static  TransportClass transportClass;
    private String id = userid;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tabletwo);
        Button btncamera = (Button) findViewById(R.id.btn_ca);
        Button btnlist = (Button) findViewById(R.id.btn_ga);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        btncamera.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setAction(MediaStore.ACTION_IMAGE_CAPTURE);
                startActivityForResult(intent, TAKE_CAMERA);
            }
        });
        btnlist.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setAction(Intent.ACTION_GET_CONTENT);
                intent.setType("image/*");
                startActivityForResult(intent, TAKE_GALLERY);
            }
        });

        sendButton = (Button) findViewById(R.id.analysisbutton);
        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                BitmapDrawable img = (BitmapDrawable) ((ImageView) findViewById(R.id.image)).getDrawable();
                Bitmap imgBitmap = img.getBitmap();

                Foodimg sending = new Foodimg(id, bitmapToByteArray(imgBitmap));
                SendingImg sendingIMG = (SendingImg) new SendingImg().execute(sending);
            }
        });

    }

    public class SendingImg extends AsyncTask<Foodimg, Void, FoodNutrient> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected FoodNutrient doInBackground(Foodimg... params) {
            Connect con = new Connect("ImageAnalysis");
            SoapObject request = new SoapObject(con.getNamespace(), con.getMethodname());
            request.addProperty("id", params[0].getId());
            request.addProperty("img", params[0].getImg());

            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
            envelope.setOutputSoapObject(request);
            envelope.dotNet = true;
            new MarshalBase64().register(envelope);
            HttpTransportSE post = new HttpTransportSE(con.getUrl());

            FoodNutrient foodNutrient = null;


            try {
                post.call(con.getSaopaction(), envelope);
                SoapObject result = (SoapObject) envelope.getResponse();
                String name = result.getProperty("name").toString();
                int kcal = Integer.parseInt(result.getProperty("kcal").toString());
                double cho = Double.parseDouble(result.getProperty("cho").toString());
                double fat = Double.parseDouble(result.getProperty("fat").toString());
                double protein = Double.parseDouble(result.getProperty("protein").toString());
                double na = Double.parseDouble(result.getProperty("na").toString());


                foodNutrient = new FoodNutrient(name, params[0].getImg(), kcal, cho, fat, protein, na);

            } catch (Exception e) {
                Log.e("ERROR", "this is error", e);
            }
            return foodNutrient;

        }

        FoodNutrient result;

        @Override
        protected void onPostExecute(FoodNutrient foodNutrient) {
            super.onPostExecute(foodNutrient);
            result = foodNutrient;
            Intent intent = new Intent(TableFood.this, FoodInfo.class);
            transportClass = new TransportClass(result);

            startActivity(intent);
        }
    }


    // 이미지 변환 메소드
    public byte[] bitmapToByteArray(Bitmap $bitmap) {
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        $bitmap.compress(Bitmap.CompressFormat.PNG, 50, stream);
        byte[] byteArray = stream.toByteArray();
        return byteArray;
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode == RESULT_OK) {
            if (requestCode == TAKE_CAMERA) {
                if (data != null) {
                    Log.e("Test", "result = " + data);
                    Bitmap thumbnail = (Bitmap) data.getExtras().get("data");
                    if (thumbnail != null) {
                        ImageView Imageview = (ImageView) findViewById(R.id.image);
                        Imageview.setImageBitmap(thumbnail);
                    }
                }

            } else if (requestCode == TAKE_GALLERY) {
                if (data != null) {
                    Log.e("Test", "result = " + data);

                    Uri thumbnail = data.getData();
                    if (thumbnail != null) {
                        ImageView Imageview = (ImageView) findViewById(R.id.image);
                        Imageview.setImageURI(thumbnail);
                    }
                }
            }
        }
    }


}