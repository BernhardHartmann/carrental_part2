package com.example.se_car_rental.entities;

import java.util.Date;
import java.time.LocalDateTime;
import java.time.ZoneId;

public class Reservation implements Entity {

    Integer categoryID;
    Integer locationID;
    Integer petrolID;
    Integer reservation_id;
    Integer car_id;
    Integer currency_id;
    LocalDateTime date_from;
    LocalDateTime date_to;
    Integer res_status;
    String car_status;
    String res_note;
    double reservation_price;
    double kilometer_spent;
    LocalDateTime return_time;


    public Reservation(Integer reservation_id, Integer car_id, Integer currency_id, LocalDateTime date_from, LocalDateTime date_to, Integer res_status, String car_status, String res_note, double reservation_price, double kilometer_spent, LocalDateTime return_time) {
        this.reservation_id = reservation_id;
        this.car_id = car_id;
        this.currency_id = currency_id;
        this.date_from = date_from;
        this.date_to = date_to;
        this.res_status = res_status;
        this.car_status = car_status;
        this.res_note = res_note;
        this.reservation_price = reservation_price;
        this.kilometer_spent = kilometer_spent;
        this.return_time = return_time;
    }

    //Create empty Reservation for editing
    public Reservation(Integer id) {
        this.reservation_id = id;
    }

    public Integer getReservation_id() {
        return reservation_id;
    }

    public void setReservation_id(Integer reservation_id) {
        this.reservation_id = reservation_id;
    }

    public Integer getCar_id() {
        return car_id;
    }

    public void setCar_id(Integer car_id) {
        this.car_id = car_id;
    }

    public Integer getCurrency_id() {
        return currency_id;
    }

    public void setCurrency_id(Integer currency_id) {
        this.currency_id = currency_id;
    }

    public double getKilometer_spent() {
        return kilometer_spent;
    }

    public void setKilometer_spent(double kilometer_spent) {
        this.kilometer_spent = kilometer_spent;
    }

    public LocalDateTime getReturn_time() {
        return return_time;
    }

    public void setReturn_time(LocalDateTime return_time) {
        this.return_time = return_time;
    }

    public double getReservation_price() {
        return reservation_price;
    }

    public void setReservation_price(double reservation_price) {
        this.reservation_price = reservation_price;
    }

    public String getRes_note() {
        return res_note;
    }

    public void setRes_note(String res_note) {
        this.res_note = res_note;
    }

    public String getCar_status() {
        return car_status;
    }

    public void setCar_status(String car_status) {
        this.car_status = car_status;
    }

    public LocalDateTime getDate_from() {
        return date_from;
    }

    public void setDate_from(Date date_from) {

        LocalDateTime date = date_from.toInstant()
                .atZone(ZoneId.systemDefault())
                .toLocalDateTime();
        this.date_from = date;
    }

    public LocalDateTime getDate_to() {
        return date_to;
    }


    public void setDate_to(Date date_to) {
        LocalDateTime date = date_to.toInstant()
                .atZone(ZoneId.systemDefault())
                .toLocalDateTime();
        this.date_to = date;
    }

    public Integer getRes_status() {
        return res_status;
    }

    public void setRes_status(Integer res_status) {
        this.res_status = res_status;
    }

    @Override
    public String getName() {
        return Integer.toString(reservation_id);
    }

    @Override
    public String getLabel() {
        return "this is a test reservation";
    }
}