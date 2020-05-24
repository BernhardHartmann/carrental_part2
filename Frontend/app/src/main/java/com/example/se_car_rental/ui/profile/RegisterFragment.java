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
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;
import androidx.viewpager.widget.ViewPager;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Currency;
import com.example.se_car_rental.entities.Customer;
import com.example.se_car_rental.entities.Register;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;


import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;

public class RegisterFragment extends Fragment implements AdapterView.OnItemSelectedListener {

    SharedPreferences sharedPref;
    Currency[] currencies;
    ArrayList<String> spinnerCurrencies = new ArrayList<>();
    Currency selectedCurrency;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);
        String currency = sharedPref.getString(getString(R.string.currencies), null);
        Gson gson = new Gson();
        currencies = gson.fromJson(currency, Currency[].class);

        for (Currency item: currencies) {
            spinnerCurrencies.add(item.getCurrency_name());
        }


        // Inflate the layout for this fragment
        View root = inflater.inflate(R.layout.fragment_register, container, false);


        final TextInputLayout firstName = root.findViewById(R.id.firstName);
        final TextInputLayout  lastName = root.findViewById(R.id.lastName);
        final TextInputLayout  mail = root.findViewById(R.id.mail);
        final TextInputLayout  password = root.findViewById(R.id.password);


        Spinner spin = root.findViewById(R.id.spinner_currency_register);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_item, spinnerCurrencies);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spin.setAdapter(adapter);
        spin.setOnItemSelectedListener(this);


        Button registerButton = root.findViewById(R.id.register);
        registerButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {

                //Send request to register new user to backend

                String url = "customer/register";

                Register register = new Register(firstName.getEditText().getText().toString(), lastName.getEditText().getText().toString(), mail.getEditText().getText().toString(), password.getEditText().getText().toString(), selectedCurrency.getCurrency_id());
                //Send register request to backend and wait for response
                try {
                    new RegisterTask().execute(url, register);
                }
                catch (Exception e) {
                    Log.d("error", e.getMessage());
                }


            }
        });

        Button loginButton = root.findViewById(R.id.login);
        loginButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {

                //Load pogin tab

                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(3);
            }
        });


        return root;
    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        //Toast.makeText(getContext(), "Selected User: "+currency[position] ,Toast.LENGTH_SHORT).show();
        selectedCurrency = currencies[position];
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    private class RegisterTask extends AsyncTask<Object, Void, String> {

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
            String response = string;

            if(response != null){
                //Load login view
                ViewPager viewPager = getActivity().findViewById(R.id.viewPager);
                viewPager.setCurrentItem(3);

                Toast.makeText(getContext(), "You registered successfully." ,Toast.LENGTH_SHORT).show();
            }

        }
    }
}