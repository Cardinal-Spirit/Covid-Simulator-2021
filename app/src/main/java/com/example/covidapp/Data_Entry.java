package com.example.covidapp;

import androidx.appcompat.app.AppCompatActivity;


import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;



public class Data_Entry extends AppCompatActivity {

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
    }
}

