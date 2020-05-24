package com.example.se_car_rental.ui.reservation;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.ui.helpers.MyListAdapter;
import com.example.se_car_rental.ui.home.HomeFragment;

public class ReservationFragment extends Fragment {

    private ReservationViewModel reservationViewModel;
    private Reservation[] bookings;
    private MyListAdapter mAdapter;
    private ListView listView;
    private OnItemSelectedListener mCallback;
    private SharedPreferences sharedPref;
    private Reservation reservations[] = new Reservation[1];



    // The container Activity must implement this interface so the frag can deliver messages
    public interface OnItemSelectedListener {
        /** Called by HeadlinesFragment when a list item is selected */
        void onItemSelected(int position, Reservation reservation
        );
    }

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        reservationViewModel = ViewModelProviders.of(this).get(ReservationViewModel.class);

        sharedPref = getActivity().getSharedPreferences("Preference", Context.MODE_PRIVATE);

        View root = inflater.inflate(R.layout.fragment_reservation, container, false);

        try {
            mCallback = (ReservationFragment.OnItemSelectedListener) getActivity();
        } catch (ClassCastException e) {
            throw new ClassCastException(getActivity().toString()
                    + " must implement OnItemSelectedListener");
        }

        Reservation res = new Reservation(1);
        reservations[0] = res;

        listView =(ListView) root.findViewById(R.id.listview_reservation);
        mAdapter = new MyListAdapter(reservations, getActivity());
        listView.setAdapter(mAdapter);




        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

                mCallback.onItemSelected(position, reservations[position]);

            }
        });

        return root;
    }
}
