package com.example.se_car_rental.ui.helpers;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.se_car_rental.LocationActivity;
import com.example.se_car_rental.R;
import com.example.se_car_rental.entities.Entity;

import java.util.ArrayList;

public class ViewAdapter extends RecyclerView.Adapter<ViewAdapter.MyViewHolder> {

private ArrayList<Entity> mDataset;
private Context myContext;

   // public static class MyViewHolder extends RecyclerView.ViewHolder {
   public static class MyViewHolder extends RecyclerView.ViewHolder {
        // each data item is just a string in this case
        public TextView textView1;
        public TextView textView2;
        public View listItem;
        private ArrayList<Entity> dataSet;
        private Context mContext;
        public MyViewHolder(View item, ArrayList<Entity> dataset, Context context) {
            super(item);
            dataSet = dataset;
            mContext = context;
            item.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View item) {
                    int itemPosition = getLayoutPosition();
                    Intent intent = new Intent(mContext, LocationActivity.class);
                    Entity entity= dataSet.get(itemPosition);
                    intent.putExtra("key", entity.getName());
                    mContext.startActivity(intent);
                }
            });
            listItem  = item;
            textView1 = (TextView) item.findViewById(R.id.text1);
            textView2 = (TextView) item.findViewById(R.id.text2);
        }

    }

    public ViewAdapter(ArrayList myDataset, Context context) {
        mDataset = myDataset;
        myContext = context;
    }

    @Override
    public ViewAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent,
                                                     int viewType) {

        View listItem = (LinearLayout) LayoutInflater.from(parent.getContext())
                .inflate(R.layout.list_item, parent, false);

        MyViewHolder vh = new MyViewHolder(listItem, mDataset, myContext);
        return vh;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewAdapter.MyViewHolder holder, int position) {
        Entity entity =  mDataset.get(position);
        holder.textView1.setText(entity.getName());
        holder.textView2.setText(entity.getLabel());
    }

    // Return the size of your dataset (invoked by the layout manager)
    @Override
    public int getItemCount() {
        return (null != mDataset ? mDataset.size() : 0);
    }

}
