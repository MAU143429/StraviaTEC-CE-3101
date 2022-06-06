package com.tec.ce;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.tec.ce.api.models.ChallengeResponse;
/*
public class EventsAdapter extends RecyclerView.Adapter<EventsAdapter.UserAdapterVH> {

    private List<ChallengeResponse> challengeResponseList;
    private Context context;
    private ClickedItem clickedItem;

    public EventsAdapter(ClickedItem clickedItem) {
        this.clickedItem = clickedItem;
    }

    public void setData(List<ChallengeResponse> challengeResponseList) {
        this.challengeResponseList = challengeResponseList;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public UserAdapterVH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        context = parent.getContext();
        return new EventsAdapter.UserAdapterVH(LayoutInflater.from(context).inflate(R.layout.row_users,parent,false));
    }

    @Override
    public void onBindViewHolder(@NonNull UserAdapterVH holder, int position) {

        ChallengeResponse challengeResponse = challengeResponseList.get(position);

        String username = challengeResponse.getcName();
        String prefix;*/
        /*if(challengeResponse.isIs_active()){
            prefix = "A";
        }else{
            prefix = "D";
        }

        holder.prefix.setText(prefix);
        holder.username.setText(username);
        holder.imageMore.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clickedItem.ClickedUser(ChallengeResponse);
            }
        });

    }

    public interface ClickedItem{
        public void ClickedUser(ChallengeResponse challengeResponse);
    }

    @Override
    public int getItemCount() {
        return challengeResponseList.size();
    }

    public class UserAdapterVH extends RecyclerView.ViewHolder {

        TextView username;
        TextView prefix;
        ImageView imageMore;

        public UserAdapterVH(@NonNull View itemView) {
            super(itemView);
            username = itemView.findViewById(R.id.username);
            prefix = itemView.findViewById(R.id.prefix);
            imageMore = itemView.findViewById(R.id.imageMore);
        }
    }
}*/
