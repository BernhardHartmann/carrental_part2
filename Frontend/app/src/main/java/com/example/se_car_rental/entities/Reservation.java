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
    LocalDateTime dateFrom;
    LocalDateTime dateTo;
    Integer resStatus;
    String carStatus;
    String reservationNote;
    double price;
    double kilometerSpent;
    LocalDateTime returnTime;


    public Reservation(Integer reservation_id, Integer car_id, Integer currency_id, LocalDateTime dateFrom, LocalDateTime date_to, Integer res_status, String car_status, String res_note, double reservation_price, double kilometer_spent, LocalDateTime return_time) {
        this.reservation_id = reservation_id;
        this.car_id = car_id;
        this.currency_id = currency_id;
        this.dateFrom = dateFrom;
        this.dateTo = date_to;
        this.resStatus = res_status;
        this.carStatus = car_status;
        this.reservationNote = res_note;
        this.price = reservation_price;
        this.kilometerSpent = kilometer_spent;
        this.returnTime = return_time;
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

    public double getKilometerSpent() {
        return kilometerSpent;
    }

    public void setKilometerSpent(double kilometerSpent) {
        this.kilometerSpent = kilometerSpent;
    }

    public LocalDateTime getReturnTime() {
        return returnTime;
    }

    public void setReturnTime(LocalDateTime returnTime) {
        this.returnTime = returnTime;
    }

    public double getReservation_price() {
        return price;
    }

    public void setReservation_price(double reservation_price) {
        this.price = reservation_price;
    }

    public String getReservationNote() {
        return reservationNote;
    }

    public void setReservationNote(String reservationNote) {
        this.reservationNote = reservationNote;
    }

    public String getCarStatus() {
        return carStatus;
    }

    public void setCarStatus(String carStatus) {
        this.carStatus = carStatus;
    }

    public LocalDateTime getDateFrom() {
        return dateFrom;
    }

    public void setDateFrom(Date dateFrom) {

        LocalDateTime date = dateFrom.toInstant()
                .atZone(ZoneId.systemDefault())
                .toLocalDateTime();
        this.dateFrom = date;
    }

    public LocalDateTime getDateTo() {
        return dateTo;
    }


    public void setDateTo(Date dateTo) {
        LocalDateTime date = dateTo.toInstant()
                .atZone(ZoneId.systemDefault())
                .toLocalDateTime();
        this.dateTo = date;
    }

    public Integer getResStatus() {
        return resStatus;
    }

    public void setResStatus(Integer resStatus) {
        this.resStatus = resStatus;
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