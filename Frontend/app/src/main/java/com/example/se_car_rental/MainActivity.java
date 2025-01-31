package com.example.se_car_rental;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.WindowManager;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.fragment.app.FragmentStatePagerAdapter;
import androidx.viewpager.widget.ViewPager;

import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Category;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.entities.ReservationOverview;
import com.example.se_car_rental.entities.User;
import com.example.se_car_rental.ui.helpers.LocationListener;
import com.example.se_car_rental.ui.home.HomeFragment;
import com.example.se_car_rental.ui.profile.LoginFragment;
import com.example.se_car_rental.ui.profile.ProfileFragment;
import com.example.se_car_rental.ui.profile.RegisterFragment;
import com.example.se_car_rental.ui.reservation.ReservationFragment;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.gson.Gson;

import java.io.IOException;
import java.util.ArrayList;


public class MainActivity extends AppCompatActivity implements BottomNavigationView.OnNavigationItemSelectedListener, HomeFragment.OnItemSelectedListener, ReservationFragment.OnItemSelectedListener, LocationListener {

    private BottomNavigationView navView;
    private ViewPager viewPager;
    private MainPagerAdapter pagerAdapter;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private boolean isLoggedIn;

    /*
    public MainActivity(){
        sharedPref = getSharedPreferences("Preference", MODE_PRIVATE);
        editor = sharedPref.edit();
        editor.putBoolean(getString(R.string.isLoggedIn), false);
        editor.commit();
    }
     */

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        sharedPref = getSharedPreferences("Preference", MODE_PRIVATE);

        new LocationTask(this).execute("utilities/locations");
        new CurrencyTask().execute("utilities/currencies");
    }

    public class MainPagerAdapter extends FragmentStatePagerAdapter {
        private ArrayList<Fragment> fragmentList = new ArrayList<>();

        public MainPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int i) {
            return fragmentList.get(i);
        }

        @Override
        public int getItemPosition(Object object){
            return POSITION_NONE;
        }

        @Override
        public int getCount() {
            return fragmentList.size();
        }

        void addFragmet(Fragment fragment) {
            fragmentList.add(fragment);
        }
    }

    @Override
    public void onLocationsRetrieved() {
        //Initialize Views only if App can be started. Prevents app from starting before essential data can be loaded.
        navView = findViewById(R.id.nav_view);
        navView.setOnNavigationItemSelectedListener(this);

        viewPager = findViewById(R.id.viewPager);

        pagerAdapter = new MainPagerAdapter(getSupportFragmentManager());
        pagerAdapter.addFragmet(new HomeFragment());
        pagerAdapter.addFragmet(new ReservationFragment());
        pagerAdapter.addFragmet(new ProfileFragment());
        pagerAdapter.addFragmet(new LoginFragment());
        pagerAdapter.addFragmet(new RegisterFragment());
        viewPager.setAdapter(pagerAdapter);

    }

    @Override
    public void onLocationsFailed() {
        TextView txtView = findViewById(R.id.warning);
        txtView.setText("App unable to connect to API. Please check your internet connection and try again.");
    }

    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {

        switch (menuItem.getItemId()) {
            case R.id.navigation_home:
                viewPager.setCurrentItem(0);
                break;
            case R.id.navigation_dashboard:
                isLoggedIn = sharedPref.getBoolean(getString(R.string.isLoggedIn), false);
                if (isLoggedIn) {
                    String url = "reservation/customer/overview/";
                    new ReservationTask().execute(url);
                    viewPager.setCurrentItem(1);
                } else {
                    Toast.makeText(this, "You need to be logged in to access your bookings.", Toast.LENGTH_LONG).show();
                }
                break;
            case R.id.navigation_profile:
                isLoggedIn = sharedPref.getBoolean(getString(R.string.isLoggedIn), false);
                if (isLoggedIn) {
                    String url = "customer/profile/";
                    new ProfileTask().execute(url);
                    viewPager.setCurrentItem(2);
                } else {
                    viewPager.setCurrentItem(3);
                }
                break;
        }
        return true;
    }

    public void onItemSelected(int position, Locations location) {
        Intent intent = new Intent(this, LocationActivity.class);
        String url = "useCase/getCategoriesToLocationID/" + location.getLocation_id();
        new CategoryTask().execute(url);
        intent.putExtra(getString(R.string.key), location.getLocation_id());
        intent.putExtra(getString(R.string.name), location.getName());
        intent.putExtra(getString(R.string.locationAddr), location.getLabel());
        startActivity(intent);
        onStop();
    }

    public void onItemSelected(int position, ReservationOverview reservation) {
        String url = "reservation/customer/cancel";
        new CancelReservationTask().execute(url, reservation);
    }


    public class LocationTask extends AsyncTask<String, Void, String> {
        private LocationListener callback;

        LocationTask(LocationListener loclist) {
            callback = loclist;
        }

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];
            return ApiUtil.getFromBackend(url, null);
        }

        @Override
        protected void onPostExecute(String s) {
            if (s != null) {
                editor = sharedPref.edit();
                editor.putString(getString(R.string.locations), s);
                editor.commit();
                callback.onLocationsRetrieved();
            } else {
                callback.onLocationsFailed();
            }
        }
    }

    public class CurrencyTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            return ApiUtil.getFromBackend(url, null);

        }

        @Override
        protected void onPostExecute(String s) {
            editor = sharedPref.edit();
            editor.putString(getString(R.string.currencies), s);
            editor.commit();
        }
    }

    public class CategoryTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            User user = getUserDataFromSharedPreferences();

            return ApiUtil.getFromBackend(url, user.getToken());
        }

        @Override
        protected void onPostExecute(String s) {

            editor = sharedPref.edit();
            editor.putString(getString(R.string.categories), s);
            editor.commit();
        }
    }

    public class ProfileTask extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            User user = getUserDataFromSharedPreferences();

            return ApiUtil.getFromBackend(url, user.getToken(), user.getId());
        }

        @Override
        protected void onPostExecute(String s) {
            editor = sharedPref.edit();
            editor.putString(getString(R.string.customerData), s);
            editor.commit();
            pagerAdapter.notifyDataSetChanged();
        }
    }

    private class ReservationTask extends AsyncTask<String, Void, String> {
        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            User user = getUserDataFromSharedPreferences();

            return ApiUtil.getFromBackend(url, user.getToken(), user.getId());
        }

        @Override
        protected void onPostExecute(String s) {
            editor = sharedPref.edit();
            editor.putString(getString(R.string.reservations), s);
            editor.commit();
            pagerAdapter.notifyDataSetChanged();
        }
    }

    private User getUserDataFromSharedPreferences() {
        String userData = sharedPref.getString(getString(R.string.user), null);
        Gson gson = new Gson();
        User user = gson.fromJson(userData, User.class);

        return user;
    }

    private class CancelReservationTask extends AsyncTask<Object, Void, String> {
        @Override
        protected String doInBackground(Object... objects) {
            String url = (String) objects[0];
            Object object = objects[1];

            User user = getUserDataFromSharedPreferences();

            try {
                return ApiUtil.putToBackend(url, user.getToken(), object);
            } catch (IOException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(String string) {

            if(string != null) {

                if (string.contains("exception")) {
                    Toast.makeText(MainActivity.this, "An error occurred during processing your request.", Toast.LENGTH_SHORT).show();
                    pagerAdapter.notifyDataSetChanged();
                } else {
                    Toast.makeText(MainActivity.this, "Your successfully canceled your booking.", Toast.LENGTH_SHORT).show();
                }
            }
        }

    }

}


