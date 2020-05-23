package com.example.se_car_rental.entities;

import android.os.Parcel;
import android.os.Parcelable;

public class Category implements Entity, Parcelable {
    private int categoryID;
    private float categoryPrice;
    private String categoryDescription;
    private String categoryImage;
    private int amountAvailable;
    private int amountNotAvailable;
    private boolean success;


    public Category(int categoryID, long price, String category_desc, String category_image, int amtav, int amtnav, boolean suc) {
        this.categoryID = categoryID;
        this.categoryDescription = category_desc;
        this.categoryImage = category_image;
        this.categoryPrice = price;
        this.amountAvailable = amtav;
        this.amountNotAvailable = amtnav;
        this.success = suc;
    }

    protected Category(Parcel in) {
        this.categoryID = in.readInt();
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

    public int getCategoryId() {
        return categoryID;
    }

    public void setCategoryId(int categoryId) {
        this.categoryID = categoryId;
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

        switch (categoryID) {
            case 1:
                car = "City Car";
                break;
            case 2:
                car = "Economy Car";
                break;
            case 3:
                car = "Compact Car";
                break;
            case 4:
                car = "Family Car";
                break;
            case 5:
                car = "Luxury Car";
                break;
            default:
                car = "A car";
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
        parcel.writeInt(categoryID);
        parcel.writeString(categoryImage);
    }
}
