package com.example.se_car_rental.ui.helpers;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Entity;

public class MyListAdapter extends BaseAdapter {
    private Entity[] mDataset;
    private Context myContext;
    private View listItem;

    public MyListAdapter(Entity[] myDataset, Context context) {
        mDataset = myDataset;
        myContext = context;
    }


    public static class MyViewHolderHome extends RecyclerView.ViewHolder {
        public TextView textView1;
        public TextView textView2;
        public View listItem;
        private Entity[] dataSet;
        private Context mContext;
        public MyViewHolderHome(View item, Entity[] dataset, Context context) {
            super(item);
            dataSet = dataset;
            mContext = context;
            listItem  = item;
            textView1 = item.findViewById(R.id.text1);
            textView2 = item.findViewById(R.id.text2);
        }
    }

    public static class MyViewHolderReservations extends RecyclerView.ViewHolder {
        public TextView textView1;
        public TextView textView2;
        public View listItem;
        private Entity[] dataSet;
        private Context mContext;
        public MyViewHolderReservations(View item, Entity[] dataset, Context context) {
            super(item);
            dataSet = dataset;
            mContext = context;
            listItem  = item;
            textView1 =  item.findViewById(R.id.text1);
            textView2 =  item.findViewById(R.id.text2);
        }
    }


    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        String className = null;
        if(mDataset != null){
            className = mDataset.getClass().getComponentType().getName();
        }

        if(className.equals("com.example.se_car_rental.entities.Reservation")){

            listItem =  LayoutInflater.from(myContext)
                    .inflate(R.layout.list_item_reservation, null);

            MyViewHolderReservations holder = new MyViewHolderReservations(listItem, mDataset, myContext);

            Entity entity = mDataset[position];
            holder.textView1.setText(entity.getName());
            holder.textView2.setText(entity.getLabel());
        }else{
            listItem = LayoutInflater.from(myContext)
                    .inflate(R.layout.list_item, null);

            MyViewHolderHome holder = new MyViewHolderHome(listItem, mDataset, myContext);
            ;
            Entity entity = mDataset[position];
            holder.textView1.setText(entity.getName());
            holder.textView2.setText(entity.getLabel());
        }

        return listItem;
    }

    @Override
    public int getCount() {
        return (mDataset != null ? mDataset.length : 0);
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }



}
