package com.tec.ce.api;

import java.io.Serializable;

public class LoginResponse implements Serializable {

    private String username;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
