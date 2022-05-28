package com.tec.ce;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.os.Bundle;

import com.tec.ce.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        // starts in Training screen
        replaceFragment(new TrainingFragment());

        binding.bottomNavigationView.setOnItemSelectedListener(item ->{
            // Change screens on click on bottom navigation buttons
            switch (item.getItemId()){
                case R.id.train:
                    replaceFragment(new TrainingFragment());
                    break;
                case R.id.find:
                    replaceFragment(new FindFragment());
                    break;
                case R.id.saved:
                    replaceFragment(new SavedFragment());
                    break;
                case R.id.profile:
                    replaceFragment(new ProfileFragment());
                    break;

            }

            return true;
        });
    }

    /**
     * This method replace fragments when a button is clicked
     * @param fragment fragment to replace
     */
    private void replaceFragment(Fragment fragment){
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        fragmentTransaction.replace(R.id.frameLayout, fragment);
        fragmentTransaction.commit();
    }
}