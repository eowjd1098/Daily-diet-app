package com.example.dktkg.ddatest;

/**
 * Created by dktkg on 2017-05-12.
 */

public class Connect {
    public Connect(String _methodname) {
        methodname = _methodname;
        saopaction = saopaction + _methodname;
    }

    private String url = "http://dda01.iptime.org:10200/Service";
    private String namespace = "http://tempuri.org/";
    private String saopaction = "http://tempuri.org/IService/";
    private String methodname;

    public String getUrl() {
        return url;
    }

    public String getNamespace() {
        return namespace;
    }

    public String getSaopaction() {
        return saopaction;
    }

    public String getMethodname() {
        return methodname;
    }

}