package com.example.se_car_rental.ui.profile;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
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
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.io.IOException;
import java.util.ArrayList;


public class ProfileFragment extends Fragment implements AdapterView.OnItemSelectedListener {

    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    User user;
    Customer customer;
    Currency[] currencies;
    ArrayList<String> spinnerCurrencies = new ArrayList<>();
    Currency selectedCurrency;
    TextInputLayout firstName;
    TextInputLayout lastName;
    TextInputLayout  mail;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);
        Gson gson = new Gson();

        String currency = sharedPref.getString(getString(R.string.currencies), null);
        currencies = gson.fromJson(currency, Currency[].class);
        for (Currency item: currencies) {
            spinnerCurrencies.add(item.getCurrency_name());
        }

        String customerString = sharedPref.getString(getString(R.string.customerData), null);
        customer = gson.fromJson(customerString, Customer.class);

        View root = inflater.inflate(R.layout.fragment_profile, container, false);

        Spinner spin = root.findViewById(R.id.spinner_currency_profile);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_item, spinnerCurrencies);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter(adapter);
        spin.setOnItemSelectedListener(this);

        if(customer != null){
            spin.setSelection(customer.getCurrency()-1);

            firstName = root.findViewById(R.id.firstName_profile);
            lastName = root.findViewById(R.id.lastName_profile);
            mail = root.findViewById(R.id.email_profile);

            firstName.getEditText().setText(customer.getFirstName());
            lastName.getEditText().setText(customer.getLastName());
            mail.getEditText().setText(customer.getEmail());
        }


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

                //Send put request to change profile data to backend
                String url = "customer/update";

                customer.setFirstName(firstName.getEditText().getText().toString());
                customer.setLastName(lastName.getEditText().getText().toString());
                customer.setEmail(mail.getEditText().getText().toString());
                customer.setCurrency(selectedCurrency.getCurrency_id());

                try {
                    new ProfileTask().execute(url, customer);
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

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        selectedCurrency = currencies[position];
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

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
                    Toast.makeText(getContext(), "An error occurred during processing your request.", Toast.LENGTH_SHORT).show();
                } else {
                    //Change menu to home
                    BottomNavigationView mBottomNavigationView = getActivity().findViewById(R.id.nav_view);
                    mBottomNavigationView.getMenu().findItem(R.id.navigation_home).setChecked(true);

                    //Load home tab
                    ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                    viewPager.setCurrentItem(0);

                    Toast.makeText(getContext(), "Your successfully updated your profile data.", Toast.LENGTH_SHORT).show();
                }
            }
        }

    }
}
