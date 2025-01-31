package com.example.se_car_rental.ui.helpers;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
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
        public ImageView imageView;
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
            imageView = item.findViewById(R.id.iView);
        }
    }

    public static class MyViewHolderReservations extends RecyclerView.ViewHolder {
        public TextView textView1;
        public TextView textView2;
        public TextView textView3;
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
            textView3 =  item.findViewById(R.id.text3);
        }
    }


    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        String className = null;
        if(mDataset != null){
            className = mDataset.getClass().getComponentType().getName();
        }

        if(className.equals("com.example.se_car_rental.entities.ReservationOverview")){

            listItem =  LayoutInflater.from(myContext)
                    .inflate(R.layout.list_item_reservation, null);

            MyViewHolderReservations holder = new MyViewHolderReservations(listItem, mDataset, myContext);

            Entity entity = mDataset[position];
            holder.textView1.setText(entity.getName());
            holder.textView2.setText(entity.getLabel());
            holder.textView3.setText(entity.getLabel2());

        }else{
            listItem = LayoutInflater.from(myContext)
                    .inflate(R.layout.list_item, null);

            MyViewHolderHome holder = new MyViewHolderHome(listItem, mDataset, myContext);
            ;
            Entity entity = mDataset[position];
            holder.textView1.setText(entity.getName());
            holder.textView2.setText(entity.getLabel());
            if(className.equals("com.example.se_car_rental.entities.Category")){
                String catName = entity.getName();
                switch(catName) {
                    case("City Car"):
                        holder.imageView.setImageResource(R.mipmap.city_foreground);
                        break;
                    case("Economy Car"):
                        holder.imageView.setImageResource(R.mipmap.economy_foreground);
                        break;
                    case("Compact Car"):
                        holder.imageView.setImageResource(R.mipmap.compact_foreground);
                        break;
                    case("Family Car"):
                        holder.imageView.setImageResource(R.mipmap.family_foreground);
                        break;
                    case("Luxury Car"):
                        holder.imageView.setImageResource(R.mipmap.luxury_foreground);
                        break;
                    default:
                        holder.imageView.setImageResource(R.mipmap.old_foreground);
                }
                }
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
