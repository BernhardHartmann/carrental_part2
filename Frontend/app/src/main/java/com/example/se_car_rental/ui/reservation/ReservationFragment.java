package com.example.se_car_rental.ui.reservation;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Currency;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.entities.ReservationOverview;
import com.example.se_car_rental.ui.helpers.MyListAdapter;
import com.example.se_car_rental.ui.home.HomeFragment;
import com.google.gson.Gson;

import java.util.Arrays;
import java.util.List;

public class ReservationFragment extends Fragment {

    private MyListAdapter mAdapter;
    private ListView listView;
    private OnItemSelectedListener mCallback;
    private SharedPreferences sharedPref;
    private ReservationOverview[] reservationArray;
    private List<ReservationOverview> reservationList;

    // The container Activity must implement this interface so the frag can deliver messages
    public interface OnItemSelectedListener {
        /** Called by HeadlinesFragment when a list item is selected */
        void onItemSelected(int position, ReservationOverview reservation
        );
    }

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);

        View root = inflater.inflate(R.layout.fragment_reservation, container, false);

        try {
            mCallback = (ReservationFragment.OnItemSelectedListener) getActivity();
        } catch (ClassCastException e) {
            throw new ClassCastException(getActivity().toString()
                    + " must implement OnItemSelectedListener");
        }

        Gson gson = new Gson();

        String reservations = sharedPref.getString(getString(R.string.reservations), null);
        reservationArray = gson.fromJson(reservations, ReservationOverview[].class);

        listView = root.findViewById(R.id.listview_reservation);
        mAdapter = new MyListAdapter(reservationArray, getActivity());
        listView.setAdapter(mAdapter);



        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    final int position, long id) {

                mCallback.onItemSelected(position, reservationArray[position]);

            }
        });

        return root;
    }
}
