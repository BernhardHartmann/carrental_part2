package com.example.se_car_rental.ui.reservation;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.se_car_rental.entities.Reservation;

import java.util.ArrayList;

public class ReservationViewModel extends ViewModel {

    private MutableLiveData<String> mText;
    private ArrayList<Reservation> bookings = new ArrayList();

    public ReservationViewModel() {
        bookings.add(new Reservation(2));
        bookings.add(new Reservation(3));
    }

    public ArrayList<Reservation> getBookings(){return bookings;}

    //public LiveData<String> getText() {
     //   return mText;
   // }
}