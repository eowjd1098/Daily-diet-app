package com.example.dktkg.ddatest;

import java.io.Serializable;

/**
 * Created by dktkg on 2017-05-22.
 */

public class FoodNutrient implements Serializable {
    private String name;    //이름
    private byte[] img;     //사진
    private int kcal;       //열량
    private double cho;     //탄수화물
    private double fat;     //지방
    private double protein; //단백질
    private double na;      //나트륨



    public FoodNutrient(String name, byte[] img, int kcal, double cho, double fat, double protein, double na) {
        this.name = name;
        this.img = img;
        this.kcal = kcal;
        this.cho = cho;
        this.fat = fat;
        this.protein = protein;
        this.na = na;

    }

    public FoodNutrient(int kcal, double cho, double fat, double protein, double na) {

        this.kcal = kcal;
        this.cho = cho;
        this.fat = fat;
        this.protein = protein;
        this.na = na;

    }

    public String getName() {
        return name;
    }

    public byte[] getImg() {
        return img;
    }

    public int getKcal() {
        return kcal;
    }

    public double getCho() {
        return cho;
    }

    public double getFat() {
        return fat;
    }

    public double getProtein() {
        return protein;
    }

    public double getNa() {
        return na;
    }

    public void setName(String name) {
        this.name = name;
    }

}
