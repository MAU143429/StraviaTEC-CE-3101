package com.tec.ce;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.tec.ce.api.ApiClient;
import com.tec.ce.api.models.UserModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link FindFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class FindFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public FindFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment FindFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static FindFragment newInstance(String param1, String param2) {
        FindFragment fragment = new FindFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_training, container, false);

        getAllChallenges();
        getAllRaces();

        // Inflate the layout for this fragment
        return v;
    }

    public void getAllChallenges(){

        Call<List<UserModel>> userlist = ApiClient.getChallengeService().getAllChallenges();

        userlist.enqueue(new Callback<List<UserModel>>() {
            @Override
            public void onResponse(Call<List<UserModel>> call, Response<List<UserModel>> response) {

                if(response.isSuccessful()){
                    Log.e("Successful connection", response.body().toString());

                }

            }

            @Override
            public void onFailure(Call<List<UserModel>> call, Throwable t) {
                Log.e("failure",t.getLocalizedMessage());

            }
        });
    }

    public void getAllRaces(){

        Call<List<UserModel>> userlist = ApiClient.getRaceService().getAllRaces();

        userlist.enqueue(new Callback<List<UserModel>>() {
            @Override
            public void onResponse(Call<List<UserModel>> call, Response<List<UserModel>> response) {

                if(response.isSuccessful()){
                    Log.e("Successful connection", response.body().toString());

                }

            }

            @Override
            public void onFailure(Call<List<UserModel>> call, Throwable t) {
                Log.e("failure",t.getLocalizedMessage());

            }
        });
    }
}