package com.example.dktkg.ddatest;

/**
 * Created by dktkg on 2017-05-12.
 */

public class Foodimg {
    private String id;
    private byte[] img;

    public Foodimg(String id, byte[] img) {
        this.id = id;
        this.img = img;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public byte[] getImg() {
        return img;
    }

}
