package com.example.se_car_rental.ui.profile;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.se_car_rental.entities.Customer;

import java.util.Date;

public class ProfileViewModel extends ViewModel {

    private Customer customer;

    public ProfileViewModel() {
        //customer = new Customer("Franz", "Gruber", "test", "franz.gruber@stud.fh-campuswien.ac.at", "1234", "076727272", "Wien", "Wien", "AT", "1120", "1234", new Date(), 1);
    }

    public Customer getCustomer() {
        return customer;
    }


}