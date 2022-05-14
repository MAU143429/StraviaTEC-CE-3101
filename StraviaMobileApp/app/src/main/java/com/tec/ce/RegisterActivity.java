package com.tec.ce;

import android.content.Intent;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.InputType;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class RegisterActivity extends AppCompatActivity {

    EditText registrarNombre, registrarApellido1, registrarApellido2, registrarTelefono,
            registrarCorreo, uniEditText, idUniEditText, registrarContrasena;
    CheckBox passwordCheckBox, studentCheckBox;
    Button registrarbtn;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        registrarNombre = findViewById(R.id.registrarNombre);
        registrarApellido1 = findViewById(R.id.registrarApellido1);
        registrarApellido2 = findViewById(R.id.registrarApellido2);
        registrarTelefono = findViewById(R.id.registrarTelefono);
        registrarCorreo = findViewById(R.id.registrarCorreo);
        registrarContrasena = findViewById(R.id.registrarContrasena);

        passwordCheckBox = findViewById(R.id.passwordCheckBox);
        passwordCheckBox.setOnClickListener(view -> {
            if (passwordCheckBox.isChecked()) {
                registrarContrasena.setInputType(InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD);
            } else {
                registrarContrasena.setInputType(InputType.TYPE_CLASS_TEXT
                        | InputType.TYPE_TEXT_VARIATION_PASSWORD);
                registrarContrasena.setTypeface(Typeface.SANS_SERIF);
            }
        });

        studentCheckBox = findViewById(R.id.studentCheckBox);
        uniEditText = findViewById(R.id.uniEditText);
        idUniEditText = findViewById(R.id.idUniEditText);

        studentCheckBox.setOnClickListener(view -> {
            if (studentCheckBox.isChecked()) {
                uniEditText.setVisibility(View.VISIBLE);
                idUniEditText.setVisibility(View.VISIBLE);
            } else {
                uniEditText.setVisibility(View.INVISIBLE);
                idUniEditText.setVisibility(View.INVISIBLE);
            }
        });

       /* registrarbtn = findViewById(R.id.registrarbtn);
        registrarbtn.setOnClickListener(view -> {
            DBRequest dbRequest = new DBRequest(RegisterActivity.this);
            long id = dbRequest.insertarUsuario(registrarNombre.getText().toString(),
                    registrarApellido1.getText().toString(),
                    registrarApellido2.getText().toString(),
                    registrarCorreo.getText().toString(),
                    registrarContrasena.getText().toString(),
                    Integer.parseInt(registrarTelefono.getText().toString()));
            if (id > 0) {
                Toast.makeText(RegisterActivity.this, "Registro guardado", Toast.LENGTH_LONG).show();
            }
            openMainMenu();
        });*/
    }

    public void openMainMenu() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}