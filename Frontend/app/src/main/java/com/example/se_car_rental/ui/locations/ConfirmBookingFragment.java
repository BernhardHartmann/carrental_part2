package com.example.se_car_rental.ui.locations;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Category;
import com.example.se_car_rental.entities.Reservation;

import java.io.IOException;
import java.util.ArrayList;

public class ConfirmBookingFragment extends Fragment {
    public static final String ARG_POSITION = "position";
    public static final int DESC_FRAG = 2;
    int mCurrentPosition = -1;
    private OnFabSelectedInterface mCallback;
    private ArrayList<Category> category_list = new ArrayList();
    private Bundle args;
    private Reservation reservationToConfirm;
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private boolean isLoggedIn;
    int category_id;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        sharedPref = getActivity().getPreferences(Context.MODE_PRIVATE);
        String currency = sharedPref.getString(getString(R.string.currencies), null);

        // If activity recreated (such as from screen rotate), restore
        // the previous article selection set by onSaveInstanceState().
        // This is primarily necessary when in the two-pane layout.
        if (savedInstanceState != null) {
            mCurrentPosition = savedInstanceState.getInt(ARG_POSITION);
        }

        return inflater.inflate(R.layout.booking_view, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();

        try {
            mCallback = (OnFabSelectedInterface) getActivity();
        } catch (ClassCastException e) {
            throw new ClassCastException(getActivity().toString()
                    + " must implement OnFabSelectedListener");
        }

        args = getArguments();
        if (args != null) {
            // Set article based on argument passed in Category_ListFragment
            updateBookingView(args.getInt(ARG_POSITION));
        } else if (mCurrentPosition != -1) {
            updateBookingView(mCurrentPosition);
        }

        //Set text
        TextView reservationID = (TextView) getActivity().findViewById(R.id.res_id);
        TextView reservation_start = (TextView) getActivity().findViewById(R.id.res_start);
        TextView reservation_end = (TextView) getActivity().findViewById(R.id.res_end);
        TextView reservation_cost = (TextView) getActivity().findViewById(R.id.res_currency);
        TextView reservation_msg = (TextView) getActivity().findViewById(R.id.res_comment);

        reservationID.setText("Reservation ID: " + reservationToConfirm.getReservation_id());
        reservation_start.setText("Reservation start: " + reservationToConfirm.getDate_from());
        reservation_end.setText("Reservation end: " + reservationToConfirm.getDate_to());
        reservation_cost.setText("Reservation amount: " + 132);
        reservation_msg.setText("Additional comments: " + reservationToConfirm.getRes_note());


        TextView button = (TextView) getActivity().findViewById(R.id.button);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                //String url = "useCase/bookCarToCategory/" + category_id;
                String url = "useCase/bookCarToCategory/";
                try {
                    new ReservationTask().execute(url, reservationToConfirm);
                } catch (Exception e) {
                    Log.d("error", e.getMessage());
                }

                mCallback.onFabSelected(DESC_FRAG, reservationToConfirm);
            }
        });


    }

    public void updateBookingView(int position) {
        TextView description = (TextView) getActivity().findViewById(R.id.text_booking);
        ;
        mCurrentPosition = position;
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);

        // Save the current article selection in case we need to recreate the fragment
        outState.putInt(ARG_POSITION, mCurrentPosition);
    }

    public void setCategories(int catID) {
        category_id = catID;
    }

    public void setReservation(Reservation reservation) {
        reservationToConfirm = reservation;
    }

    private class ReservationTask extends AsyncTask<Object, Void, String> {

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
            String responseCode = string;
            System.out.println(responseCode);
        }
    }

}
