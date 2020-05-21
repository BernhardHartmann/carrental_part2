package com.example.se_car_rental.entities;

import android.os.Parcel;
import android.os.Parcelable;

import java.util.ArrayList;

public class Depot implements Entity, Parcelable {
    private int id;
    private String depot_name;
    private String address;
    private Locations depot_location;
    private ArrayList<Category> car_list = new ArrayList();


    public Depot(int id, String name, String address, Locations location){
        this.id = id;
        this.depot_name = name;
        this.address = address;
        this.depot_location = location;
    }

    protected Depot(Parcel in) {
        this.id = in.readInt();
        this.depot_name = in.readString();
        this.address = in.readString();
    }

    public static final Creator<Depot> CREATOR = new Creator<Depot>() {
        @Override
        public Depot createFromParcel(Parcel in) {
            return new Depot(in);
        }

        @Override
        public Depot[] newArray(int size) {
            return new Depot[size];
        }
    };

    public void addCar(Category car){
        car_list.add(car);
    }

    public Category getCar(int id){
        return car_list.get(id);
    }

    public ArrayList<Category> getCar_list(){
        return car_list;
    }

    //TODO: Delete Car_Category??

    public String getName(){
        return depot_name;
    }

    private void setDepot_name(String name){
        this.depot_name = name;
    }

    public String getLabel(){
        return address;
    }

    private void setAddress(String address){
        this.address = address;
    }

    public Locations getDepot_Location(){
        return depot_location;
    }

    private void setDepot_location(Locations location){
        this.depot_location = location;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeInt(id);
        parcel.writeString(depot_name);
        parcel.writeString(address);
    }

}


