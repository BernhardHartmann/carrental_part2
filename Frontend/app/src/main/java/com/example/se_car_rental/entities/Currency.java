package com.example.se_car_rental.entities;

public class Currency {

    private int currency_id;
    private String currency_name;
    private String currency_symbol;
    private String currency_code;

    public Currency(int currency_id, String currency_name, String currency_symbol, String currency_code) {
        this.currency_id = currency_id;
        this.currency_name = currency_name;
        this.currency_symbol = currency_symbol;
        this.currency_code = currency_code;
    }

    public int getCurrency_id() {
        return currency_id;
    }

    public void setCurrency_id(int currency_id) {
        this.currency_id = currency_id;
    }

    public String getCurrency_name() {
        return currency_name;
    }

    public void setCurrency_name(String currency_name) {
        this.currency_name = currency_name;
    }

    public String getCurrency_symbol() {
        return currency_symbol;
    }

    public void setCurrency_symbol(String currency_symbol) {
        this.currency_symbol = currency_symbol;
    }

    public String getCurrency_code() {
        return currency_code;
    }

    public void setCurrency_code(String currency_code) {
        this.currency_code = currency_code;
    }
}
