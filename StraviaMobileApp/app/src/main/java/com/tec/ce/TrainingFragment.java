package com.tec.ce;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.Toast;

import androidx.fragment.app.Fragment;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link TrainingFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class TrainingFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public TrainingFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment TrainingFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static TrainingFragment newInstance(String param1, String param2) {
        TrainingFragment fragment = new TrainingFragment();
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
        ImageButton runButton = v.findViewById(R.id.imageButtonRun);
        runButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Run button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });

        ImageButton cyclingButton = v.findViewById(R.id.imageButtonCycling);
        cyclingButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Cycling button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });

        ImageButton kayakingButton = v.findViewById(R.id.imageButtonKayaking);
        kayakingButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Kayaking button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });

        ImageButton swimmingButton = v.findViewById(R.id.imageButtonSwimming);
        swimmingButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Swimming button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });

        ImageButton hikingButton = v.findViewById(R.id.imageButtonHiking);
        hikingButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Hiking button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });

        ImageButton walkingButton = v.findViewById(R.id.imageButtonWalking);
        walkingButton.setOnClickListener(view -> {
            displayMap();
            Toast.makeText(getContext(), "Walking button clicked", Toast.LENGTH_SHORT).show();
            // Go to next activity
        });



        // Inflate the layout for this fragment
        return v;
    }
    public void displayMap() {
        Intent intent = new Intent();
        intent.setClass(getActivity(), MapsActivity.class);
        this.startActivity(intent);
    }
}