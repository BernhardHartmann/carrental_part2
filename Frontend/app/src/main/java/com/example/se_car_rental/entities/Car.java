package com.example.se_car_rental.entities;


import java.time.LocalDateTime;

public class Car {
    private int carId ;
    private int categoryId ;
    private int locationId ;
    private String carDesc ;
    private String color   ;
    private String brand   ;
    private String model   ;
    private String engineNumber;
    private LocalDateTime purchaseDate ;
    private int kilometer ;
    private int petrolId   ;
    private int isAvailable;


    public Car(int carId , int categoryId , int locationId , String carDesc , String color   , String brand   , String model   , String engineNumber, LocalDateTime purchaseDate , int kilometer , int petrolId   , int isAvailable)
    {
        this.carId = 		carId;
        this.categoryId =	categoryId;
        this.locationId =	locationId;
        this.carDesc =		carDesc;
        this.color   =		color;
        this.brand   =		brand;
        this.model   =		model;
        this.engineNumber=	engineNumber;
        this.purchaseDate =	purchaseDate;
        this.kilometer =	kilometer;
        this.petrolId   =	petrolId;
        this.isAvailable=	isAvailable;
    }

    public int getCarId() {
        return carId;
    }

    public void setCarId(int carId) {
        this.carId = carId;
    }

    public int getCategoryId() {
        return categoryId;
    }

    public void setCategoryId(int categoryId) {
        this.categoryId = categoryId;
    }

    public int getLocationId() {
        return locationId;
    }

    public void setLocationId(int locationId) {
        this.locationId = locationId;
    }

    public String getCarDesc() {
        return carDesc;
    }

    public void setCarDesc(String carDesc) {
        this.carDesc = carDesc;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getEngineNumber() {
        return engineNumber;
    }

    public void setEngineNumber(String engineNumber) {
        this.engineNumber = engineNumber;
    }

    public LocalDateTime getPurchaseDate() {
        return purchaseDate;
    }

    public void setPurchaseDate(LocalDateTime purchaseDate) {
        this.purchaseDate = purchaseDate;
    }

    public int getKilometer() {
        return kilometer;
    }

    public void setKilometer(int kilometer) {
        this.kilometer = kilometer;
    }

    public int getPetrolId() {
        return petrolId;
    }

    public void setPetrolId(int petrolId) {
        this.petrolId = petrolId;
    }

    public int getIsAvailable() {
        return isAvailable;
    }

    public void setIsAvailable(int isAvailable) {
        this.isAvailable = isAvailable;
    }
}
