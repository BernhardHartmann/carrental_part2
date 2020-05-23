package com.example.se_car_rental;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;
import androidx.viewpager.widget.ViewPager;

import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.ui.helpers.LocationListener;
import com.example.se_car_rental.ui.home.HomeFragment;
import com.example.se_car_rental.ui.profile.LoginFragment;
import com.example.se_car_rental.ui.profile.ProfileFragment;
import com.example.se_car_rental.ui.profile.RegisterFragment;
import com.example.se_car_rental.ui.reservation.ReservationFragment;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.gson.Gson;

import java.util.ArrayList;


public class MainActivity extends AppCompatActivity implements BottomNavigationView.OnNavigationItemSelectedListener, HomeFragment.OnItemSelectedListener, ReservationFragment.OnItemSelectedListener, LocationListener {

    private BottomNavigationView navView;
    private ViewPager viewPager;
    private MainPagerAdapter pagerAdapter;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private boolean isLoggedIn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        sharedPref = getSharedPreferences("Preference", MODE_PRIVATE);
        new LocationTask(this).execute("utilities/locations");
        new CurrencyTask().execute("utilities/currencies");
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
        TextView txtView= findViewById(R.id.warning);
        txtView.setText("App unable to connect to API. Please check your internet connection and try again.");
    }

    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {

        switch (menuItem.getItemId()) {
            case R.id.navigation_home:
                viewPager.setCurrentItem(0);
                break;
            case R.id.navigation_dashboard:
                viewPager.setCurrentItem(1);
                break;
            case R.id.navigation_profile:
                isLoggedIn = sharedPref.getBoolean(getString(R.string.isLoggedIn), false);
                if(isLoggedIn){
                    viewPager.setCurrentItem(2);
                }else{
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
        startActivity(intent);
        onStop();
    }

    public void onItemSelected(int position, Reservation reservation) {

    }


    public class LocationTask extends AsyncTask<String, Void, String> {
        private LocationListener callback;

        LocationTask(LocationListener loclist){
            callback = loclist;
        }

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];
            return ApiUtil.getFromBackend(url, null);
        }

        @Override
        protected void onPostExecute(String s) {
            if(s != null) {
                editor = sharedPref.edit();
                editor.putString(getString(R.string.locations), s);
                editor.commit();
                callback.onLocationsRetrieved();
            }else{
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



    public class MainPagerAdapter extends FragmentPagerAdapter {
        private ArrayList<Fragment> fragmentList = new ArrayList<>();

        public MainPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int i) {
            return fragmentList.get(i);
        }

        @Override
        public int getCount() {
            return fragmentList.size();
        }

        void addFragmet(Fragment fragment) {
            fragmentList.add(fragment);
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
            editor = sharedPref.edit();
            editor.putString(getString(R.string.categories), s);
            editor.commit();
        }
    }

}

