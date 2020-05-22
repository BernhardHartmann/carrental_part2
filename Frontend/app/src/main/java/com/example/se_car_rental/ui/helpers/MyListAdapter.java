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

    //private ArrayList<Entity> mDataset;
    private Entity[] mDataset;
    private Context myContext;


    public static class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView textView1;
        public TextView textView2;
        public View listItem;
        //private ArrayList<Entity> dataSet;
        private Entity[] dataSet;
        private Context mContext;
        //public MyViewHolder(View item, ArrayList<Entity> dataset, Context context) {
        public MyViewHolder(View item, Entity[] dataset, Context context) {
            super(item);
            dataSet = dataset;
            mContext = context;
            listItem  = item;
            textView1 = (TextView) item.findViewById(R.id.text1);
            textView2 = (TextView) item.findViewById(R.id.text2);
        }

    }

//    public MyListAdapter(ArrayList myDataset, Context context) {
//        mDataset = myDataset;
//        myContext = context;
//    }

        public MyListAdapter(Entity[] myDataset, Context context) {
        mDataset = myDataset;
        myContext = context;
    }


    @Override
    public int getCount() {
        //return (null != mDataset ? mDataset.size() : 0);
        return mDataset.length;
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        View listItem = (LinearLayout) LayoutInflater.from(myContext)
                .inflate(R.layout.list_item, null);

        MyViewHolder holder = new MyViewHolder(listItem, mDataset, myContext);

        //Entity entity =  mDataset.get(position);
        Entity entity = mDataset[position];
        holder.textView1.setText(entity.getName());
        holder.textView2.setText(entity.getLabel());

        return listItem;
    }

}
