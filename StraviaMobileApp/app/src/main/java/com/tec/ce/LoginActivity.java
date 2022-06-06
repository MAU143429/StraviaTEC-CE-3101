package com.tec.ce;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.tec.ce.api.ApiClient;
import com.tec.ce.api.models.LoginRequest;
import com.tec.ce.api.models.LoginResponse;
import com.tec.ce.db.DBHelper;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

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
                String username = userEditText.getText().toString();
                String password = passwordEditText.getText().toString();

                if(TextUtils.isEmpty(username) || TextUtils.isEmpty(password) ) {
                    String message = "All inputs required to login";
                    Toast.makeText(LoginActivity.this,message,Toast.LENGTH_LONG).show();
                }else{
                    LoginRequest loginRequest = new LoginRequest();
                    loginRequest.setUsername(username);
                    loginRequest.setPassword(password);

                    loginUser(loginRequest);
                }
            }
        });

        // Create Database
        logo = findViewById(R.id.logo);
        /**
         * Metodo que al hacer click en la imagen del logo permite
         * crear la base de datos en SQL lite
         */
        logo.setOnClickListener(view -> {
            DBHelper dataBase = new DBHelper(LoginActivity.this);
            SQLiteDatabase db = dataBase.getWritableDatabase();
            if (db != null) {
                Toast.makeText(LoginActivity.this, "Base de datos creada", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(LoginActivity.this, "Error al crear base de datos", Toast.LENGTH_LONG).show();
            }
        });
    }

    /**
     * Metodo que se encarga de obtener la respuesta del API para verificar contrasena y nombre de
     * usuario para hacer login en la aplicacion
     * @param loginRequest Objeto que guarda el nombre de usuario y contrasena
     */
    public void loginUser(LoginRequest loginRequest){
        Call<LoginResponse> loginResponseCall = ApiClient.getUserService().loginUser(loginRequest);
        loginResponseCall.enqueue(new Callback<LoginResponse>() {
            @Override
            public void onResponse(Call<LoginResponse> call, Response<LoginResponse> response) {
                if(response.isSuccessful()){
                    LoginResponse loginResponse = response.body();
                    Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                    intent.putExtra("usernameData", loginResponse);
                    startActivity(intent);

                    //startActivity(new Intent(LoginActivity.this,TrainingFragment.class).putExtra("data",loginResponse));
                    finish();


                }else{
                    String message = "Incorrect username or password";
                    Toast.makeText(LoginActivity.this,message,Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<LoginResponse> call, Throwable t) {

                String message = t.getLocalizedMessage();
                Toast.makeText(LoginActivity.this,message,Toast.LENGTH_LONG).show();
            }
        });
    }

    public void login() {
        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtra("user", user);
        startActivity(intent);
    }

    /**
     * Metodo que inicia la actividad de registro de usuario
     */
    public void register() {
        Intent intent = new Intent(this, RegisterActivity.class);
        startActivity(intent);
    }

}