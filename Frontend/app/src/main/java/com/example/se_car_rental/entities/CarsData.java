package com.example.se_car_rental.entities;

import android.icu.util.LocaleData;

import java.text.DecimalFormat;
import java.time.LocalDateTime;

public class CarsData {
    public CarsData(){}
    // Cars
    int carId ;
    int categoryId ;
    int locationId ;
    String carDesc ;
    String color   ;
    String brand   ;
    String model   ;
    String engineNumber;
    LocaleData purchaseDate ;
    Integer kilometer ;
    Integer petrolId   ;
    Integer isAvailable;
    // CAtegories
    Integer category_id;
    Integer price;
    String category_image;
    String category_desc;

    String currency_symbol;
    // Customers
    Integer  customer_id 			;
    String first_name				;
    String last_name				    ;
    String password					;
    String email					    ;
    String driving_license_number	;
    String mobile					;
    String state					    ;
    String city						;
    String country					;
    String zipcode					;
    String phone					    ;
    LocalDateTime registration_date	;
    Integer preferred_currency		;
    //Reservation
    Integer reservation_id;
    Integer car_id;
    Integer currency_id;
    LocaleData date_from;
    LocaleData date_to;
    Integer res_status;
    String car_status;
    String res_note;
    double  reservation_price;
    double kilometer_spent;
    LocaleData return_time;



}
