package com.example.se_car_rental.ui.home;

import androidx.lifecycle.ViewModel;

import com.example.se_car_rental.MainActivity;
import com.example.se_car_rental.entities.Depot;
import com.example.se_car_rental.entities.Locations;

import java.util.ArrayList;

public class HomeViewModel extends ViewModel {
    private ArrayList<Depot> depots = new ArrayList();
    private Locations[] locations;
    MainActivity.LocationTask locationsTask;


    public HomeViewModel() {



        //locations = locationsTask.getLocations();

    }

    public Locations[] getLocations() {
        if (locations == null) {
            // locations = locationsTask.getLocations();
        }
        return locations;
    }

}
        //Create Dummy Data
        /*
        Depot depot1 = new Depot(0, "CarsForYou", "201 Test Street", new Locations(48.222, 16.001));
        Depot depot2 = new Depot(1, "RentACar", "201 Test Street", new Locations(49.000, 16.982));
        Depot depot3 = new Depot(2, "RentACar", "201 Test Street", new Locations(49.000, 16.982));
        depots.add(depot1);
        depots.add(depot2);
        depots.add(depot3);

    }

    public ArrayList<Depot> getDepots(){return depots;}

         */