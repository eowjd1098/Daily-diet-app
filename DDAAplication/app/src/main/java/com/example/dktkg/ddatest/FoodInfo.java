package com.example.dktkg.ddatest;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.TextView;

import static com.example.dktkg.ddatest.TableFood.transportClass;

/**
 * Created by dktkg on 2017-05-22.
 */


public class FoodInfo extends Activity {
    private FoodNutrient foodNutrient;
    private TextView textView;
    private ImageView imageView;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.foodinfo);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);


        foodNutrient = transportClass.getFoodNutrient();
        textView = (TextView) findViewById(R.id.tv);

        Bitmap thumbnail = byteArrayToBitmap(foodNutrient.getImg());
        imageView = (ImageView) findViewById(R.id.foodimage);
        imageView.setImageBitmap(thumbnail);


        String result = "\n\n\n음식이름 ..................................................  " + foodNutrient.getName() + "\n\n열량 .................................................. " + foodNutrient.getKcal() +
                "/2500kcal" + "\n\n탄수화물 .................................................. " + foodNutrient.getCho() + "/400g" +
                "\n\n단백질 .................................................. " + foodNutrient.getProtein() + "/100g" + "\n\n지방 ................................................. " + foodNutrient.getFat() +
                "/45g" + "\n\n나트륨 .................................................  " + foodNutrient.getNa() + "/2000mg";
        textView.setText(result);
    }

    public Bitmap byteArrayToBitmap(byte[] $byteArray) {
        Bitmap bitmap = BitmapFactory.decodeByteArray($byteArray, 0, $byteArray.length);
        return bitmap;
    }

}
