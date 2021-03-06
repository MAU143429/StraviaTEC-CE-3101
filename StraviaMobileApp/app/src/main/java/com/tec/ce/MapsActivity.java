package com.tec.ce;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.SystemClock;
import android.widget.Button;
import android.widget.Chronometer;
import android.widget.Toast;
import android.widget.ToggleButton;

import androidx.annotation.NonNull;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.FragmentActivity;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;

public class MapsActivity extends FragmentActivity implements OnMapReadyCallback {

    GoogleMap map;
    private Chronometer chronometer;
    private long PauseOffSet = 0;
    private long raceTime;
    private boolean isPlaying = false;
    private ToggleButton toggleButton;
    private Button reset_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);

        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);

        //Chronometer and play, pause, stop buttons
        chronometer = findViewById(R.id.chronometer);
        toggleButton = findViewById(R.id.Toggle);
        reset_btn = findViewById(R.id.reset_btn);
        // now we need to customize our toggle button
        toggleButton.setText(null);
        toggleButton.setTextOn(null);
        toggleButton.setTextOff(null);
        //the event listener will automatically generated by android studio
        toggleButton.setOnCheckedChangeListener((compoundButton, buttonState) -> {
            //now let's code our stopwatch
            //buttonState is the state of our button, it will be true if we pressed the button otherwise it will be false
            changeState(buttonState);
        });

        //now we need to add the reset function of our button
        // we should check if the chronometre is actually workin to be able to reset otherwise we can't
        reset_btn.setOnClickListener(view -> {
            if(isPlaying){
                changeState(false);
            }
            chronometer.setBase(SystemClock.elapsedRealtime());
            raceTime = PauseOffSet;
            Toast.makeText(this, String.valueOf(raceTime), Toast.LENGTH_SHORT).show();
            PauseOffSet = 0;
            toggleButton.setChecked(false);
            displayTraining();
        });
    }

    public void changeState(boolean buttonState) {
        if(buttonState){
            chronometer.setBase(SystemClock.elapsedRealtime() - PauseOffSet);
            chronometer.start();
            isPlaying = true;
        }else{
            chronometer.stop();
            PauseOffSet = SystemClock.elapsedRealtime()- chronometer.getBase();
            isPlaying = false;
        }
    }

    @Override
    public void onMapReady(@NonNull GoogleMap googleMap) {
        map = googleMap;
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // TODO: Consider calling
            //    ActivityCompat#requestPermissions
            // here to request the missing permissions, and then overriding
            //   public void onRequestPermissionsResult(int requestCode, String[] permissions,
            //                                          int[] grantResults)
            // to handle the case where the user grants the permission. See the documentation
            // for ActivityCompat#requestPermissions for more details.
            return;
        }
        map.setMyLocationEnabled(true);
    }

    public void displayTraining() {
        Intent intent = new Intent();
        intent.setClass(this, TrainingFragment.class);
        this.startActivity(intent);
    }
}