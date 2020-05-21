package com.example.se_car_rental.ui.locations;


import android.app.DatePickerDialog;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.ApiUtil;
import com.example.se_car_rental.entities.Car;
import com.example.se_car_rental.entities.Reservation;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class CheckAvailabilityFragment extends Fragment {
    public static final String ARG_POSITION = "position";
    public static final int BOOK_FRAG = 1;
    private static final String START = "start";
    private static final String END = "end";
    int mCurrentPosition = -1;
    private String testString = "";
    private OnFabSelectedInterface mCallback;
    private Bundle args;
    //TODO: change booking_msg to a Reservation object and edit object instead
    private Reservation reservation;
    public static String booking_msg = "";
    static SharedPreferences sharedPref;
    static SharedPreferences.Editor editor;
    private static int category_id;


    public static class MyOnClickListener implements View.OnClickListener {

        private TextView dateView;
        private Context myContext;
        private String myTime;
        private CheckAvailabilityFragment book;

        public MyOnClickListener(Context context, TextView view, String time, CheckAvailabilityFragment b) {
            dateView = view;
            myContext = context;
            myTime = time;
            book = b;
        }

        @Override
        public void onClick(final View view) {
            // Create a new OnDateSetListener instance. This listener will be invoked when user click ok button in DatePickerDialog.
            DatePickerDialog.OnDateSetListener onDateSetListener = new DatePickerDialog.OnDateSetListener() {
                @Override
                public void onDateSet(DatePicker datePicker, int year, int month, int dayOfMonth) {
                    StringBuffer strBuf = new StringBuffer();
                    strBuf.append(year);
                    strBuf.append("-");
                    strBuf.append(month+1);
                    strBuf.append("-");
                    strBuf.append(dayOfMonth);
                    Calendar cal = new GregorianCalendar(year, month, dayOfMonth);
                    Date date = cal.getTime();
                    book.setReservation(date, myTime);
                    dateView.setText(strBuf.toString());


                }
            };

            // Get current year, month and day.
            Calendar now = Calendar.getInstance();
            int year = now.get(java.util.Calendar.YEAR);
            int month = now.get(java.util.Calendar.MONTH);
            int day = now.get(java.util.Calendar.DAY_OF_MONTH);

            // Create the new DatePickerDialog instance.
            DatePickerDialog datePickerDialog = new DatePickerDialog(myContext, onDateSetListener, year, month, day);

            // Set dialog icon and title.
            datePickerDialog.setTitle("Please select date.");

            // Popup the dialog.
            datePickerDialog.show();

        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        if (savedInstanceState != null) {
            mCurrentPosition = savedInstanceState.getInt(ARG_POSITION);
            //testString = savedInstanceState.getString("test");
        }

        sharedPref = getActivity().getPreferences(Context.MODE_PRIVATE);
        String currency = sharedPref.getString(getString(R.string.currencies), null);

        //getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE | WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);

        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.description_view, container, false);
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

        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_VISIBLE | WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);
        TextView description = (TextView) getActivity().findViewById(R.id.text_booking);
        args = getArguments();
       // testString = args.getString("test");
        description.setText(testString);
        reservation = new Reservation(1);
        this.showDatePickerDialog();
//        FloatingActionButton fab = (FloatingActionButton) getActivity().findViewById(R.id.fab3);
//        fab.setOnClickListener(new View.OnClickListener() {
        TextView button = (TextView) getActivity().findViewById(R.id.button);
        button.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {
                if(reservation.getDate_from() != null && reservation.getDate_to() != null) {
                    TextInputLayout mEdit  = (TextInputLayout) getActivity().findViewById(R.id.comments);
                    String note = String.valueOf(mEdit.getEditText().getText());
                   // assignCar();
                    reservation.setRes_note(note);
                    mCallback.onFabSelected(BOOK_FRAG, reservation);
                }else{
                    Toast toast=Toast.makeText(getActivity(),"Please enter at least one date",Toast.LENGTH_LONG);
                    toast.setMargin(50,50);
                    toast.show();
                }
//                if(booking_msg != "") {
//                    mCallback.onFabSelected(BOOK_FRAG, booking_msg);
//                    booking_msg = "";
//                }else{
//                    Toast toast=Toast.makeText(getActivity(),"Please enter at least one date",Toast.LENGTH_LONG);
//                    toast.setMargin(50,50);
//                    toast.show();
//                }
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

    // Create and show a DatePickerDialog when click button.
    private void showDatePickerDialog()
    {

        // Get open DatePickerDialog button.
        TextView datePickerDialogButton = (TextView) getActivity().findViewById(R.id.datePickerDialogButton);
        TextView datePickerDialogButton2 = (TextView) getActivity().findViewById(R.id.datePickerDialogButton2);
        datePickerDialogButton.setOnClickListener(new CheckAvailabilityFragment.MyOnClickListener(getActivity(), datePickerDialogButton, START, this));
        datePickerDialogButton2.setOnClickListener(new CheckAvailabilityFragment.MyOnClickListener(getActivity(), datePickerDialogButton2, END,this));
    }


    public void setReservation(Date date, String time) {

        switch (time) {
            case START:
                reservation.setDate_from(date);
                break;
            case END:
                reservation.setDate_to(date);
                break;
        }

        if(reservation.getDate_from() != null && reservation.getDate_to() != null) {
          //  try{
            //String url = "useCase/getCarByDate/" + 2 + "/" + reservation.getDate_from() +  "/" + reservation.getDate_to();
          //      String url = "car/getRandomCarByCategoryID/" + category_id;
          //  new CheckAvaibilityTask(getActivity()).execute(url);}
           //    catch (Exception e) {
            //        Log.d("error", e.getMessage());
         //       }
        }
    }

    public void assignCar(){
        String getCar =  sharedPref.getString(getString(R.string.car), null);
        Gson gson = new Gson();
        Car car = gson.fromJson( getCar , Car.class);
        reservation.setCar_id(car.getCarId());
    }

    public void setCategories(int catID){
        category_id = catID;
    }

    public class CheckAvaibilityTask extends AsyncTask<String, Void, String> {
        FragmentActivity context;

        CheckAvaibilityTask(FragmentActivity view) {
            context = view;
        }

        @Override
        protected String doInBackground(String... strings) {
            String url = strings[0];

            return ApiUtil.getFromBackend(url, null);
        }

        @Override
        protected void onPostExecute(String s) {
            //Gson gson = new Gson();
            //Locations[] locations = gson.fromJson(s, Locations[].class);
            TextView text = (TextView) context.findViewById(R.id.info);
            if (s != null) {
                text.setText(s);
                editor = sharedPref.edit();
                editor.putString(getString(R.string.car), s);
                editor.commit();
            }
        }

    }
}

