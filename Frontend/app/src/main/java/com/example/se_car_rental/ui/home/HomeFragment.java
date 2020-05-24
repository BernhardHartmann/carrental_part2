package com.example.se_car_rental.ui.home;

import android.Manifest;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProviders;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Locations;
import com.example.se_car_rental.ui.helpers.MyListAdapter;
import com.example.se_car_rental.ui.helpers.PermissionUtils;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapView;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.gson.Gson;

import static android.content.Context.MODE_PRIVATE;


public class HomeFragment extends Fragment implements OnMapReadyCallback {

    private static final int LOCATION_PERMISSION_REQUEST_CODE=100;
    private MapView mapView;
    private GoogleMap map;
    private OnItemSelectedListener mCallback;
    private SharedPreferences sharedPref;
    private MyListAdapter mAdapter;
    private ListView listView;

    private Locations locations[];

    // The container Activity must implement this interface so the frag can deliver messages
    public interface OnItemSelectedListener {
        void onItemSelected(int position, Locations location);
    }

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        View root = inflater.inflate(R.layout.fragment_home, container, false);


        try {
            mCallback = (OnItemSelectedListener) getActivity();
        } catch (ClassCastException e) {
            throw new ClassCastException(getActivity().toString()
                    + " must implement OnItemSelectedListener");
        }

        //sharedPref = getActivity().getPreferences(Context.MODE_PRIVATE);
        sharedPref = getActivity().getSharedPreferences("Preference",MODE_PRIVATE);
        String location = sharedPref.getString(getString(R.string.locations), null);
        Gson gson = new Gson();
        locations = gson.fromJson(location, Locations[].class);

        //MapView should be created even if locations cannot be loaded from the API.
        mapView = (MapView) root.findViewById(R.id.mapView);
        mapView.onCreate(savedInstanceState);
        mapView.getMapAsync(this);


        if(location != null) {
            listView = (ListView) root.findViewById(R.id.listview_home);
            mAdapter = new MyListAdapter(locations, getActivity());
            listView.setAdapter(mAdapter);

            listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                @Override
                public void onItemClick(AdapterView<?> parent, View view,
                                        int position, long id) {

                    mCallback.onItemSelected(position, locations[position]);
                }
            });
        }
        return root;
    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        map = googleMap;
        map.getUiSettings().setZoomControlsEnabled(true);
        map.getUiSettings().setZoomGesturesEnabled(true);
        map.getUiSettings().setCompassEnabled(true);

        LatLng branch0 = new LatLng(48.2082,16.3738);
        if(locations != null ){
        for (int i=0; i<this.locations.length; i++)
        {
            branch0 = new LatLng(Double.parseDouble(this.locations[i].getLatitude()), Double.parseDouble(this.locations[i].getLongitude()));
            map.addMarker(new MarkerOptions().position(branch0).title(this.locations[i].getName()));
        }
        }
        map.moveCamera(CameraUpdateFactory.newLatLngZoom(branch0, 10));
        MarkerOptions markerOptions = new MarkerOptions();
        markerOptions.position(branch0);
        LocationManager locationManager = (LocationManager)
                getActivity().getSystemService(getActivity().LOCATION_SERVICE);
        String provider = locationManager.getBestProvider(new Criteria(), true);
        if (ActivityCompat.checkSelfPermission(getActivity(),
                Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED &&
                ActivityCompat.checkSelfPermission(getActivity(), Manifest.permission.ACCESS_COARSE_LOCATION)
                        != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        Location locations = locationManager.getLastKnownLocation(provider);
        markerOptions.icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_BLUE));
        //mMap.addMarker(markerOptions);
        //mMap.moveCamera(CameraUpdateFactory.newLatLng(latLng));
        //map.animateCamera(CameraUpdateFactory.zoomTo(20));
    }

    @Override
    public void onResume() {
        if(mapView != null) {
            mapView.onResume();
        }
        super.onResume();
    }

    @Override
    public void onPause() {
        mapView.onPause();
        super.onPause();
    }

    @Override
    public void onDestroy() {
        mapView.onDestroy();
        super.onDestroy();
    }

    @Override
    public void onLowMemory() {
        mapView.onLowMemory();
        super.onLowMemory();
    }
}
