package com.example.se_car_rental.entities;

import java.time.LocalDateTime;
import java.util.Date;

public class ReservationOverview implements Entity {
     Integer reservation_id;
     String date_from;
    String date_to;
     String location;

    public ReservationOverview(Integer reservation_id, String date_from, String date_to, String location) {
        this.reservation_id = reservation_id;
        this.date_from = date_from;
        this.date_to = date_to;
        this.location = location;
    }

    public Integer getReservation_id() {
        return reservation_id;
    }

    public void setReservation_id(Integer reservation_id) {
        this.reservation_id = reservation_id;
    }

    public String getDate_from() {
        return date_from;
    }

    public void setDate_from(String date_from) {
        this.date_from = date_from;
    }

    public String getDate_to() {
        return date_to;
    }

    public void setDate_to(String date_to) {
        this.date_to = date_to;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    @Override
    public String getName() {
        return "Reservation " + reservation_id;
    }

    @Override
    public String getLabel() { return location; }

    @Override
    public String getLabel2() { return date_from + " to " + date_to; }
}
