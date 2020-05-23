package com.example.se_car_rental.entities;

public class User {
    private Integer id;
    private String token;
    private boolean isLoginSuccessful;

    public User(Integer id, String token, boolean isLoginSuccessful) {
        this.id = id;
        this.token = token;
        this.isLoginSuccessful = isLoginSuccessful;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public boolean isLoginSuccessful() { return isLoginSuccessful; }

    public void setLoginSuccessful(boolean loginSuccessful) { this.isLoginSuccessful = loginSuccessful; }
}
