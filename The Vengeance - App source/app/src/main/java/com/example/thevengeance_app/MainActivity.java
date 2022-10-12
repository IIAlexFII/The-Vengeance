package com.example.thevengeance_app;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Editable;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity {

    //deactivate this activity to be able to use the rest of the app
    EditText Username;
    EditText Password;
    EditText IP;
    Button Login;

    JSONArray playerid = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Username = findViewById(R.id.editTextUsername);
        Password = findViewById(R.id.editTextPassword);
        IP = findViewById(R.id.editTextIP);
        Login = findViewById(R.id.Loginbutton);

    }

    public void Login(View view) {
        Editable username;
        Editable password;

        username = Username.getText();
        password = Password.getText();

        Map<String, String> postData = new HashMap<>();
        postData.put("username ", username.toString());
        postData.put("password", password.toString());

        Players task = new Players(postData);

        try {
            JSONArray jsonObject = task.execute("http://" + IP.getText().toString() + ":3434/players/getid").get(); // line gives and error
            playerid = jsonObject.getJSONArray(Integer.parseInt("Players")); // line gives and error

            if(Username.getText().toString().equals(playerid.getJSONObject(0).getString("username")) && Password.getText().toString().equals(playerid.getJSONObject(0).getString("password"))) {
                String ip = IP.getText().toString();


                Intent intent = new Intent(MainActivity.this, MapsActivity.class);
                intent.putExtra("Id", playerid.getJSONObject(0).getInt("id"));
                intent.putExtra("Ip", ip);
                startActivity(intent);
            }
        }
        catch (Exception e){
            Log.i("ERROR", e.getMessage());
        }

    }

    // Doesn't work
    /*public void Onclick(View view) {
        String username = Username.getText().toString();
        String password = Password.getText().toString();

        if (username.isEmpty() || password.isEmpty() || IP.getText().toString().isEmpty()) {
            Toast emptyUsername = Toast.makeText(this, "Please fill the empty fields", Toast.LENGTH_LONG);
            emptyUsername.show();
        }
        else {
            try {
                // -------------> POST DATA
                Map<String, String> postData = new HashMap<>();
                postData.put("username ", username);
                postData.put("password", password);

                Players task = new Players(postData);

                task.execute(IP.getText().toString() + ":3434/getid");

                JSONObject aux = new JSONObject(playerid.get(0).toString());
                Log.e("username and password", "are in the db");

            } catch (Exception e) {
                e.printStackTrace();
                playerid = null;
            }

            String ip = IP.getText().toString();
            Integer id = Integer.parseInt(playerid.toString()); //

            Log.e("id", id + "this is the id");

            Intent intent = new Intent(MainActivity.this, MapsActivity.class);
            intent.putExtra("Id", id);
            intent.putExtra("Ip", ip);
            startActivity(intent);

        }
    }*/
}