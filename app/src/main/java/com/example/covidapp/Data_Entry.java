package com.example.covidapp;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;


import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.google.android.material.navigation.NavigationView;


public class Data_Entry extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {


    DrawerLayout drawerLayout;
    NavigationView navigationView;
    Toolbar toolbar;
    private Button button;
    private EditText numpersons, nummasks, numsanitized, len;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_data__entry);


        numpersons = findViewById(R.id.persons);

        nummasks = findViewById(R.id.masks);

        numsanitized = findViewById(R.id.sanitized);

        len = findViewById(R.id.socialdlen);

        button = findViewById(R.id.submitButton);


        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String userpersons = numpersons.getText().toString();
                String usermasks = nummasks.getText().toString();
                String usersanitized = numsanitized.getText().toString();
                String userlen = len.getText().toString();

                Intent intent = new Intent(Data_Entry.this, MainActivity.class);
                intent.putExtra("keypersons",userpersons);
                intent.putExtra("keymasks",usermasks);
                intent.putExtra("keysanitized",usersanitized);
                intent.putExtra("keyken",userlen);
                startActivity(intent);
            }
        });

        drawerLayout = findViewById(R.id.drawer_layout);
        navigationView = findViewById(R.id.nav_menu);
        toolbar = findViewById(R.id.toolbar);

        setSupportActionBar(toolbar);

        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, R.string.open_nav, R.string.close_nav);
        drawerLayout.addDrawerListener(toggle);
        toggle.syncState();

        navigationView.setNavigationItemSelectedListener(this);
        navigationView.setCheckedItem(R.id.supDataMenu);

    }

    @Override
    public void onBackPressed() {
        if(drawerLayout.isDrawerOpen(GravityCompat.START)){
            drawerLayout.closeDrawer(GravityCompat.START);
        }
        else {
            super.onBackPressed();
        }
    }


    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.mainMenu:
                startActivity(new Intent(Data_Entry.this, MainActivity.class));
                break;

            case R.id.simSettingsMenu:
                startActivity(new Intent(Data_Entry.this, Simulation_Settings.class));
                break;

            case R.id.locationMenu:
                startActivity(new Intent(Data_Entry.this, Location_List.class));
                break;

            case R.id.supDataMenu:
                break;

            case R.id.settingsMenu:
                startActivity(new Intent(Data_Entry.this, App_Settings.class));
                break;
        }

        drawerLayout.closeDrawer(GravityCompat.START);
        return true;
    }
}

