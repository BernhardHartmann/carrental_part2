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
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.ViewModelProviders;
import androidx.viewpager.widget.ViewPager;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Currency;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.entities.Login;
import com.example.se_car_rental.entities.User;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.io.IOException;

import static android.view.View.*;

public class LoginFragment extends Fragment {

    private ProfileViewModel profileViewModel;
    private User user;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        profileViewModel = ViewModelProviders.of(this).get(ProfileViewModel.class);

        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);

        // Inflate the layout for this fragment
        View root = inflater.inflate(R.layout.fragment_login, container, false);

        final TextInputLayout email = root.findViewById(R.id.email);
        final TextInputLayout  password = root.findViewById(R.id.password);


        Button loginButton = root.findViewById(R.id.login);
        loginButton.setOnClickListener(new OnClickListener()
        {
            @Override
            public void onClick(View v)
            {

            //Send login request to backend and wait for response

            String url = "customer/login";
            Login login = new Login(email.getEditText().getText().toString(), password.getEditText().getText().toString());

            try {
                new LoginTask().execute(url, login);
            }
            catch (Exception e) {
                Log.d("error", e.getMessage());
            }


            }
        });

        Button registerButton = root.findViewById(R.id.register);
        registerButton.setOnClickListener(new OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                //Load register tab
                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(4);
            }
        });


        return root;

    }


    private class LoginTask extends AsyncTask<Object, Void, String> {

        @Override
        protected String doInBackground(Object... objects) {
            String url = (String) objects[0];
            Object object = objects[1];

            try {
                return ApiUtil.postToBackend(url, null, object);
            } catch (IOException e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(String string) {


            if(string != null){

                Gson gson = new Gson();
                user = gson.fromJson(string, User.class);

                if(user.isLoginSuccessful()){
                    editor = sharedPref.edit();
                    editor.putString(getString(R.string.user), string);
                    editor.putBoolean(getString(R.string.isLoggedIn), true);
                    editor.commit();

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


            }else{
                Toast.makeText(getContext(), "An error occurred during processing your request." ,Toast.LENGTH_SHORT).show();
            }

        }
    }

}
