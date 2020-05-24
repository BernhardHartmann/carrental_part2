package com.example.se_car_rental.ui.locations;

import com.example.se_car_rental.entities.Reservation;

public interface OnFabSelectedInterface {

    /** Called by HeadlinesFragment when a list item is selected */
    void onFabSelected(int fragment, Reservation reservation, String msg);

}
