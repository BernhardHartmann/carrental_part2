package com.example.se_car_rental.ui.filter;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Reservation;
import com.example.se_car_rental.ui.helpers.MyListAdapter;

import java.util.ArrayList;

public class FilterFragment extends Fragment {

    private FilterViewModel filterViewModel;
    private Reservation[] bookings;
    private MyListAdapter mAdapter;
    private ListView listView;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        filterViewModel =
                ViewModelProviders.of(this).get(FilterViewModel.class);
        View root = inflater.inflate(R.layout.fragment_filter, container, false);


        listView =(ListView) root.findViewById(R.id.listview);
      //mAdapter = new MyListAdapter(bookings, getActivity());
       // listView.setAdapter(mAdapter);

        return root;
    }
}
