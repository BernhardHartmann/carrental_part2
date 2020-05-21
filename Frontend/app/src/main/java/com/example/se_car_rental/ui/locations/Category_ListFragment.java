package com.example.se_car_rental.ui.locations;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;

import androidx.fragment.app.ListFragment;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Category;
import com.example.se_car_rental.ui.helpers.MyListAdapter;


public class Category_ListFragment extends ListFragment {
    OnCategorySelectedListener mCallback;
    private MyListAdapter mAdapter;
    //private ArrayList<Category> dummy_list = new ArrayList<Category>();
    private Category[] dummy_list;


    // The container Activity must implement this interface so the frag can deliver messages
    public interface OnCategorySelectedListener {
        /** Called by HeadlinesFragment when a list item is selected */
        void onCategorySelected(int position);
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //Parceble doesn't seem to work
            //dummy_list.add((Category) getArguments().getParcelable("cat1"));
            //dummy_list.add((Category) getArguments().getParcelable("cat2"));


        mAdapter = new MyListAdapter(dummy_list, getActivity());
        setListAdapter(mAdapter);

    }


    @Override
    public void onStart() {
        super.onStart();


        try {
            mCallback = (OnCategorySelectedListener) getActivity();
        } catch (ClassCastException e) {
            throw new ClassCastException(getActivity().toString()
                    + " must implement OnHeadlineSelectedListener");
        }


        if (getFragmentManager().findFragmentById(R.id.category_fragment) != null) {
            getListView().setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }


    @Override
    public void onListItemClick(ListView l, View v, int position, long id) {
        // Notify the parent activity of selected item
        mCallback.onCategorySelected(position);

        // Set the item as checked to be highlighted when in two-pane layout
        getListView().setItemChecked(position, true);
    }

    //public void setCategories(ArrayList<Category> list){
   //     dummy_list = list;
   // }

    public void setCategories(Category[] list){
        dummy_list = list;
    }

}
