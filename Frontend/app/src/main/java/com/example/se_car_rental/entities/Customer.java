package com.example.se_car_rental.entities;

public class Customer {
    public Integer  customerId;
    public String firstname;
    public String lastname;
    public String password;
    public String email;
    public String drivingLicenseNumber;
    public String mobile;
    public String state;
    public String city;
    public String country;
    public String zipCode;
    public String phone;
    public Integer currency;

    public Customer(Integer customerId, String firstname, String lastname, String password, String email, String drivingLicenseNumber, String mobile, String state, String city, String country, String zipCode, String phone, Integer currency) {
        this.customerId = customerId;
        this.firstname = firstname;
        this.lastname = lastname;
        this.password = password;
        this.email = email;
        this.drivingLicenseNumber = drivingLicenseNumber;
        this.mobile = mobile;
        this.state = state;
        this.city = city;
        this.country = country;
        this.zipCode = zipCode;
        this.phone = phone;
        this.currency = currency;
    }

    public Integer getCustomerId() {
        return customerId;
    }

    public void setCustomerId(Integer customerId) {
        this.customerId = customerId;
    }

    public String getFirstName() {
        return firstname;
    }

    public void setFirstName(String firstName) {
        this.firstname = firstName;
    }

    public String getLastName() {
        return lastname;
    }

    public void setLastName(String lastName) {
        this.lastname = lastName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getDrivingLicenseNumber() {
        return drivingLicenseNumber;
    }

    public void setDrivingLicenseNumber(String drivingLicenseNumber) {
        this.drivingLicenseNumber = drivingLicenseNumber;
    }

    public String getMobile() {
        return mobile;
    }

    public void setMobile(String mobile) {
        this.mobile = mobile;
    }

    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getZipCode() {
        return zipCode;
    }

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public Integer getCurrency() {
        return currency;
    }

    public void setCurrency(Integer currency) {
        this.currency = currency;
    }
}

