package com.example.se_car_rental;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

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
   // private FloatingActionButton fab;
    private TextView button;
    private ImageView image;
   // private ArrayList<Category> category_list = new ArrayList();
   //TODO: Remove dummy data and add methed for retrieving data
   //Category cat1 = new Category(1, "SUV", "All Terrain Vehical", "a_car", 25) ;
    // Category cat2 = new Category(1, "Economy", "All Terrain Vehical", "a_car", 25) ;
    private Category[] category_list;
    int currentPosition = 1;
    int currentActivity = 0;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private boolean isLoggedIn;

    @SuppressLint("RestrictedApi")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent i = getIntent();
        String myDepot = i.getStringExtra(getString(R.string.name));
        int loc_key = i.getIntExtra(getString(R.string.key), 0);

        //sharedPref = getParent().getPreferences(Context.MODE_PRIVATE);
        sharedPref = getSharedPreferences("Preference",MODE_PRIVATE);
        isLoggedIn = sharedPref.getBoolean(getString(R.string.isLoggedIn), false);

       // String url = "useCase/getCategoriesToLocationID/" + loc_key;
       // new CategoryTask().execute(url);

        //Set data from shared preferences
        String cat = sharedPref.getString(getString(R.string.categories), null);
        Gson gson = new Gson();
        category_list = gson.fromJson(cat, Category[].class);

        setContentView(R.layout.activity_depot);
        fragmentManager = getSupportFragmentManager();

        final TextView textView = this.findViewById(R.id.text_booking);
        textView.setText(myDepot);



        ImageView view = (ImageView) findViewById(R.id.closeView);
        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                Intent intent = new Intent(LocationActivity.this, MainActivity.class);
                startActivity(intent);// here u can start another activity or just call finish method to close the activity.
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
            // Create an instance of ExampleFragment
            Category_ListFragment firstFragment = new Category_ListFragment();
            // In case this activity was started with special instructions from an Intent,
            // pass the Intent's extras to the fragment as arguments and set Categories from view
          //  category_list = gson.fromJson(cat, Category[].class);
            firstFragment.setCategories(category_list);

            firstFragment.setArguments(getIntent().getExtras());

            // Add the fragment to the 'fragment_container' FrameLayout
            fragmentManager.beginTransaction()
                    .add(R.id.fragment_container, firstFragment).commit();
        }
    }

    @SuppressLint("RestrictedApi")
    @Override
    public void onCategorySelected(int position) {

        currentPosition = position;
        CheckAvailabilityFragment descFrag = (CheckAvailabilityFragment)
                fragmentManager.findFragmentById(R.id.description_fragment);
        TextView category = (TextView) this.findViewById(R.id.txt_category);
        //TextView description = (TextView) this.findViewById(R.id.txt_desc);


        if (descFrag != null) {
            // If article frag is available, we're in two-pane layout...

            //category.setText(category_list.get(position).getName());
            //description.setText(category_list.get(position).getLabel());
            category.setText(category_list[position].getName());
            descFrag.setCategories(category_list[currentPosition].getCategory_id());
           // description.setText(category_list[position].getLabel());
            // Call a method in the BookingFragment to update its content
            descFrag.updateBookingView(position);

        } else {

            // Create fragment and give it an argument for the selected category
            CheckAvailabilityFragment newFragment = new CheckAvailabilityFragment();
            image.setVisibility(View.VISIBLE);
            //category.setText(category_list.get(position).getName());
            //description.setText(category_list.get(position).getLabel());
            category.setText(category_list[position].getName());
            newFragment.setCategories(category_list[currentPosition].getCategory_id());
           //description.setText(category_list[position].getLabel());
            Bundle args = new Bundle();
            args.putInt(CheckAvailabilityFragment.ARG_POSITION, position);
            newFragment.setArguments(args);
            FragmentTransaction transaction = fragmentManager.beginTransaction();


            transaction.replace(R.id.fragment_container, newFragment);
            transaction.addToBackStack(null);
            //fab.setVisibility(View.VISIBLE);
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
            // If article frag is available, we're in two-pane layout...

            // Call a method in the ArticleFragment to update its content
            bookingFrag.updateBookingView(position);
            bookingFrag.setReservation(reservation);
            bookingFrag.setCategories(category_list[currentPosition].getCategory_id());
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
    public void onFabSelected(int currentActivity, Reservation reservation) {

        switch(currentActivity) {
            case 1:
                onBookingSelected(currentPosition, reservation);
                break;
            case 2:
                Intent intent=new Intent(LocationActivity.this, MainActivity.class);
                startActivity(intent);// here u can start another activity or just call finish method to close the activity.
                String toastMsg = "Reservation successful ";
                Toast toast=Toast.makeText(getApplicationContext(),toastMsg,Toast.LENGTH_LONG);
                toast.setMargin(100,100);
                toast.show();
                onStop();
                break;
        }
    }

    public class CategoryTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            return ApiUtil.getFromBackend(url, null);
        }

        @Override
        protected void onPostExecute(String s) {
            //Gson gson = new Gson();
            //Locations[] locations = gson.fromJson(s, Locations[].class);
            editor = sharedPref.edit();
            editor.putString(getString(R.string.categories), s);
            editor.commit();
        }
    }

    }



