package com.example.se_car_rental.entities;

public class Locations implements Entity {

    private Integer location_id;
    private String branchname;
    private String street;
    private String street_no;
    private String city;
    private String zip_code;
    private String state;
    private String country;
    private String latitude;
    private String longitude;

    public Locations(Integer location_id, String branchname, String street, String street_no, String city, String zip_code, String state, String country, String latitude, String longitude) {
        this.location_id = location_id;
        this.branchname = branchname;
        this.street = street;
        this.street_no = street_no;
        this.city = city;
        this.zip_code = zip_code;
        this.state = state;
        this.country = country;
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public Integer getLocation_id() {
        return location_id;
    }

    public void setLocation_id(Integer location_id) {
        this.location_id = location_id;
    }

    public String getBranchname() {
        return branchname;
    }

    public void setBranchname(String branchname) {
        this.branchname = branchname;
    }

    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public String getStreet_no() {
        return street_no;
    }

    public void setStreet_no(String street_no) {
        this.street_no = street_no;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getZip_code() {
        return zip_code;
    }

    public void setZip_code(String zip_code) {
        this.zip_code = zip_code;
    }

    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getLatitude() {
        return latitude;
    }

    public void setLatitude(String latitude) {
        this.latitude = latitude;
    }

    public String getLongitude() {
        return longitude;
    }

    public void setLongitude(String longitude) {
        this.longitude = longitude;
    }

    @Override
    public String getName() {
        return branchname;
    }

    @Override
    public String getLabel() {
        return street + " " + street_no + "\n" + zip_code + " " + city + ", " + " country";
    }

    @Override
    public String getLabel2() {
        return null;
    }
}