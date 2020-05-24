package com.example.se_car_rental;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Category;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.ui.locations.Category_ListFragment;
import com.example.se_car_rental.ui.locations.CheckAvailabilityFragment;
import com.example.se_car_rental.ui.locations.ConfirmBookingFragment;
import com.example.se_car_rental.ui.locations.OnFabSelectedInterface;
import com.google.gson.Gson;

public class LocationActivity extends FragmentActivity implements Category_ListFragment.OnCategorySelectedListener, OnFabSelectedInterface {
    private static FragmentManager fragmentManager;
    private TextView button;
    private ImageView image;
    private Category[] category_list;
    int currentPosition = 1;
    int currentActivity = 0;
    private String myDepot = "";
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private boolean isLoggedIn;

    @SuppressLint("RestrictedApi")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent i = getIntent();
        myDepot = i.getStringExtra(getString(R.string.name));
        int loc_key = i.getIntExtra(getString(R.string.key), 0);

        //Need to call SharedPreferences by name
        sharedPref = getSharedPreferences("Preference", MODE_PRIVATE);
        isLoggedIn = sharedPref.getBoolean(getString(R.string.isLoggedIn), false);

        //Set data from shared preferences
        String cat = sharedPref.getString(getString(R.string.categories), null);
        Gson gson = new Gson();
        category_list = gson.fromJson(cat, Category[].class);

        setContentView(R.layout.activity_depot);
        final View fragView = findViewById(R.id.fragment_container);
        fragmentManager = getSupportFragmentManager();

        final TextView textView = this.findViewById(R.id.text_booking);
        textView.setText(myDepot);


        ImageView view = findViewById(R.id.closeView);
        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                Intent intent = new Intent(LocationActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });


        button = findViewById(R.id.button);
        button.setVisibility(button.GONE);
        image = findViewById(R.id.catIcon);
        image.setVisibility(image.GONE);


        // the fragment_container FrameLayout. If so, we must add the first fragment
        if (findViewById(R.id.fragment_container) != null) {

            if (savedInstanceState != null) {
                return;
            }
            // Create an instance of Category List Fragment
            Category_ListFragment firstFragment = new Category_ListFragment();
            firstFragment.setCategories(category_list);

            firstFragment.setArguments(getIntent().getExtras());


            // Add the fragment to the 'fragment_container' FrameLayout
            fragmentManager.beginTransaction()
                    .add(R.id.fragment_container, firstFragment, "LIST").commit();

            //Hides button and reset View

            fragView.setFocusableInTouchMode(true);
            fragView.requestFocus();
            fragView.setOnKeyListener(new View.OnKeyListener() {
                @Override
                public boolean onKey(View v, int keyCode, KeyEvent event) {
                    if (keyCode == KeyEvent.KEYCODE_BACK) {
                        if (currentActivity == 1) {
                            button.setVisibility(button.GONE);
                            image.setVisibility(image.GONE);
                            textView.setText(myDepot);
                        }
                        //TODO: Fixed some issues. Button will still appear if moving back from Confirm Reservation fragment
                    }
                    return false;
                }
            });

        }
    }

    @SuppressLint("RestrictedApi")
    @Override
    public void onCategorySelected(int position) {

        //TODO: Check if logged in.
        currentPosition = position;
        CheckAvailabilityFragment descFrag = (CheckAvailabilityFragment)
                fragmentManager.findFragmentById(R.id.description_fragment);
        TextView category = this.findViewById(R.id.txt_category);
        ImageView catImage = this.findViewById(R.id.catIcon);


        if (descFrag != null) {
            category.setText(category_list[position].getName());
            descFrag.setCategories(category_list[currentPosition].getCategoryId());
            // description.setText(category_list[position].getLabel());
            descFrag.updateBookingView(position);
            currentActivity = 1;

        } else {

            CheckAvailabilityFragment newFragment = new CheckAvailabilityFragment();
            image.setVisibility(View.VISIBLE);
            String catName = category_list[position].getName();
            category.setText(catName);
            switch (catName) {
                case ("City Car"):
                    catImage.setImageResource(R.mipmap.city_foreground);
                    break;
                case ("Economy Car"):
                    catImage.setImageResource(R.mipmap.economy_foreground);
                    break;
                case ("Compact Car"):
                    catImage.setImageResource(R.mipmap.compact_foreground);
                    break;
                case ("Family Car"):
                    catImage.setImageResource(R.mipmap.family_foreground);
                    break;
                case ("Luxury Car"):
                    catImage.setImageResource(R.mipmap.luxury_foreground);
                    break;
                default:
                    catImage.setImageResource(R.mipmap.old_foreground);
            }
            newFragment.setCategories(category_list[currentPosition].getCategoryId());
            //description.setText(category_list[position].getLabel());
            Bundle args = new Bundle();
            args.putInt(CheckAvailabilityFragment.ARG_POSITION, position);
            newFragment.setArguments(args);
            FragmentTransaction transaction = fragmentManager.beginTransaction();


            transaction.replace(R.id.fragment_container, newFragment);
            transaction.addToBackStack(null);
            button.setVisibility(View.VISIBLE);
            button.setText("Reserve Car from Category");
            currentActivity = 1;

            transaction.commit();

        }
    }

    public void onBookingSelected(int position, Reservation reservation) {

        ConfirmBookingFragment bookingFrag = (ConfirmBookingFragment)
                fragmentManager.findFragmentById(R.id.booking_fragment);

        if (bookingFrag != null) {

            // Call a method in the BookingFragment to update its content
            bookingFrag.updateBookingView(position);
            bookingFrag.setReservation(reservation);
            bookingFrag.setCategories(category_list[currentPosition].getCategoryId());
            currentActivity = 2;

        } else {

            // Create fragment and give it an argument for the selected category
            ConfirmBookingFragment newFragment = new ConfirmBookingFragment();
            newFragment.setReservation(reservation);
            Bundle args = new Bundle();
            newFragment.setArguments(args);
            FragmentTransaction transaction = fragmentManager.beginTransaction();

            button.setText("Confirm Reservation");

            transaction.replace(R.id.fragment_container, newFragment);
            transaction.addToBackStack(null);


            transaction.commit();
            currentActivity = 2;

        }
    }

    @Override
    public void onFabSelected(int currentActivity, Reservation reservation, String msg) {

        switch (currentActivity) {
            case 1:
                onBookingSelected(currentPosition, reservation);
                break;
            case 2:
                Intent intent = new Intent(LocationActivity.this, MainActivity.class);
                startActivity(intent);// here u can start another activity or just call finish method to close the activity.
                Toast toast = Toast.makeText(getApplicationContext(), msg, Toast.LENGTH_LONG);
                toast.setMargin(100, 100);
                toast.show();
                onStop();
                break;
        }
    }


}



