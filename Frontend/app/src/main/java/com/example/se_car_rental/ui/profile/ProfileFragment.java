package com.example.se_car_rental.ui.profile;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;
import androidx.viewpager.widget.ViewPager;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Currency;
import com.example.se_car_rental.entities.Customer;
import com.example.se_car_rental.entities.Register;
import com.example.se_car_rental.entities.User;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.gson.Gson;

import java.io.IOException;


public class ProfileFragment extends Fragment {

    private ProfileViewModel profileViewModel;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    User user;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        profileViewModel = ViewModelProviders.of(this).get(ProfileViewModel.class);
        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);

        View root = inflater.inflate(R.layout.fragment_profile, container, false);



        Button logoutButton = root.findViewById(R.id.logout);
        logoutButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {

                editor = sharedPref.edit();
                editor.putBoolean(getString(R.string.isLoggedIn), false);
                editor.commit();


                //Change menu to home
                BottomNavigationView mBottomNavigationView = getActivity().findViewById(R.id.nav_view);
                mBottomNavigationView.getMenu().findItem(R.id.navigation_home).setChecked(true);

                //Load home tab
                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(0);

                Toast.makeText(getContext(), "You logged out successfully." ,Toast.LENGTH_SHORT).show();
            }
        });

        Button changeDataButton = root.findViewById(R.id.changeData);
        changeDataButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {

                //Send request to change profile data to backend
                Integer userId = user.getId();
                String url = "customer/profile";

                //Send register request to backend and wait for response
                try {
                    new ProfileTask().execute(url, userId);
                }
                catch (Exception e) {
                    Log.d("error", e.getMessage());
                }

                //Load register tab
                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(3);
            }
        });

        return root;
    }

    private class ProfileTask extends AsyncTask<Object, Void, String> {

        @Override
        protected String doInBackground(Object... objects) {
            String url = (String) objects[0];
            Object object = objects[1];

            String userData = sharedPref.getString(getString(R.string.user), null);
            Gson gson = new Gson();
            user = gson.fromJson(userData, User.class);

            try {
                return ApiUtil.postToBackend(url, user.getToken(), object);
            } catch (IOException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(String string) {


            if(string != null){

                //Change menu to home
                BottomNavigationView mBottomNavigationView = getActivity().findViewById(R.id.nav_view);
                mBottomNavigationView.getMenu().findItem(R.id.navigation_home).setChecked(true);

                //Load home tab
                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(0);

                Toast.makeText(getContext(), "Your logged in successfully." ,Toast.LENGTH_SHORT).show();

            }else{
                Toast.makeText(getContext(), "Your email or password is invalid." ,Toast.LENGTH_SHORT).show();
            }

        }
    }
}
