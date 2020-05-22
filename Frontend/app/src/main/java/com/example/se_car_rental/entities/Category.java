package com.example.se_car_rental.entities;

import android.os.Parcel;
import android.os.Parcelable;

public class Category implements Entity, Parcelable {
    private int category_id;
    private float categoryPrice;
    private String categoryDescription;
    private String categoryImage;
    private int amountAvailable;
    private int amountNotAvailable;
    private boolean success;


    public Category(int category_id, long price, String category_desc, String category_image, int amtav, int amtnav, boolean suc) {
        this.category_id = category_id;;
        this.categoryDescription = category_desc;
        this.categoryImage = category_image;
        this.categoryPrice = price;
        this.amountAvailable = amtav;
        this.amountNotAvailable = amtnav;
        this.success = suc;
    }

    protected Category(Parcel in) {
        this.category_id = in.readInt();
        this.categoryImage = in.readString();
        this.categoryPrice = in.readInt();
    }

    public static final Creator<Category> CREATOR = new Creator<Category>() {
        @Override
        public Category createFromParcel(Parcel in) {
            return new Category(in);
        }

        @Override
        public Category[] newArray(int size) {
            return new Category[size];
        }
    };

    public int getCategory_id() {
        return category_id;
    }

    public void setCategory_id(int category_id) {
        this.category_id = category_id;
    }


    public String getCategory_desc() {
        return categoryDescription;
    }

    public void setCategory_desc(String category_desc) {
        this.categoryDescription = category_desc;
    }

    public String getCategory_image() {
        return categoryImage;
    }

    public void setCategory_image(String category_image) {
        this.categoryImage = category_image;
    }

    public float getPrice() {
        return categoryPrice;
    }

    public void setPrice(long price) {
        this.categoryPrice = price;
    }

    @Override
    public String getName() {
        String car;
        switch(category_id){
            case 1:
                car =  "City Car";
                break;
            case 2:
                car = "Economy Car";
                break;
            case 3:
                car =  "Compact Car";
                break;
            case 4:
                car = "Family Car";
                break;
            default:
                car =  "A car";
                break;
        }
        return car;
    }

    @Override
    public String getLabel() {
        return categoryDescription;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeInt(category_id);
        parcel.writeString(categoryImage);
    }
}
