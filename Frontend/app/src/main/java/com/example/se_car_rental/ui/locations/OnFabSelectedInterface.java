package com.example.se_car_rental.ui.locations;

import com.example.se_car_rental.entities.Reservation;

public interface OnFabSelectedInterface {

    /** Called by HeadlinesFragment when a list item is selected */
    //TODO: change the FAB method so that it returns an object to the location activity
    void onFabSelected(int fragment, Reservation reservation, String msg);

}
