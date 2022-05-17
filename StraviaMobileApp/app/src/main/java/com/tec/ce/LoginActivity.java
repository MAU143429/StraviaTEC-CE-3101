package com.tec.ce;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class LoginActivity extends AppCompatActivity {

    private static final String TAG = "LoginActivity";
    private String user;
    //private DBRequest dbRequest;
    EditText userEditText, passwordEditText;
    TextView registerTextView;
    Button loginbtn;
    ImageView logo;
    static String BASE_URL = "http://192.168.100.40:7038";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        userEditText = findViewById(R.id.userEditText);
        passwordEditText = findViewById(R.id.passwordEditText);

        //registerTextView = findViewById(R.id.registerTextView);
        //registerTextView.setOnClickListener(view -> register());

        /*dbRequest = new DBRequest(LoginActivity.this);
        DBSync dbSync = new DBSync();
        dbSync.SyncUsuario(LoginActivity.this);*/

        Button loginbtn = (Button) findViewById(R.id.loginbtn);
        loginbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //dbRequest = new DBRequest(LoginActivity.this);
                String usuario = userEditText.getText().toString();
                String password = passwordEditText.getText().toString();
                if (userEditText.getText().toString().equals("admin") && passwordEditText.getText().toString().equals("test")) {
                    user = userEditText.getText().toString();
                    login();
                }
                /*else if(dbRequest.verificarUsuario(usuario,password)){
                    user = userEditText.getText().toString();
                    login();
                }*/
                else if(userEditText.getText ().toString().equals ("") ||  passwordEditText.getText().toString().equals ("")) {
                    login();
                    //Toast.makeText(LoginActivity.this, "Debe ingresar ambos datos", Toast.LENGTH_SHORT).show();
                }else {
                    Toast.makeText(LoginActivity.this, "Fallo de inicio de sesión, verifique los datos", Toast.LENGTH_SHORT).show();
                }
            }
        });

        logo = findViewById(R.id.logo);
        /*logo.setOnClickListener(view -> {
            DBHelper dataBase = new DBHelper(LoginActivity.this);
            SQLiteDatabase db = dataBase.getWritableDatabase();
            if (db != null) {
                Toast.makeText(LoginActivity.this, "Base de datos creada", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(LoginActivity.this, "Error al crear base de datos", Toast.LENGTH_LONG).show();
            }
        });*/
    }

    public void register() {
        Intent intent = new Intent(this, RegisterActivity.class);
        startActivity(intent);
    }

    public void login() {
        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtra("user", user);
        startActivity(intent);
    }

}