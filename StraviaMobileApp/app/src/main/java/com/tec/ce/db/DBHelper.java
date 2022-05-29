package com.tec.ce.db;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class DBHelper extends SQLiteOpenHelper {
    /**
     * Atributos de nombre y version de la base de datos
     */
    public static final String DATABASE = "StraviaTEC.db";
    private static final int DATABASE_VERSION = 1;

    /**
     * Atributos para la creacion de tablas de la base de datos
     */
    //Tabla Challenge
    public static final String TABLE_CHALLENGE = "Challenge";
    public static final String NO_CHALLENGE = "no_challenge";
    public static final String C_NAME = "c_name";
    public static final String FINAL_DATE = "final_date";

    //Tabla Race
    public static final String TABLE_RACE = "Race";
    public static final String NO_RACE = "no_race";
    public static final String R_CATEGORY = "category";
    public static final String R_NAME = "r_name";
    public static final String PRICE = "price";

    //Tabla User
    public static final String TABLE_USER = "User";
    public static final String U_USERNAME = "u_username";
    public static final String CATEGORY = "category";
    public static final String NAME = "name";
    public static final String LAST_NAME = "last_name";
    public static final String BIRTHDATE = "birthdate";
    public static final String NATIONALITY = "nationality";
    public static final String U_PASSWORD = "u_password";
    public static final String IMAGE = "image";

    //Tabla Participation
    public static final String TABLE_PARTICIPATION = "Participation";

    //Tabla Inscription
    public static final String TABLE_INSCRIPTION = "Inscription";
    public static final String NO_INSCRIPTION = "no_inscription";
    public static final String VOUCHER = "voucher";
    public static final String IS_ACCEPTED = "is_accepted";

    //Tabla Activity
    public static final String TABLE_ACTIVITY = "Activity";
    public static final String NO_ACTIVITY = "no_activity";
    public static final String SPORT = "sport";
    public static final String O_USERNAME = "o_username";
    public static final String ROUTE = "route";
    public static final String LENGTH = "Length";
    public static final String A_DATE = "a_date";

    //Tabla Result
    public static final String TABLE_RESULT = "Result";
    public static final String NO_RESULT = "no_result";
    public static final String DURATION = "duration";

    /**
     * Constructor de la clase
     * @param context
     */
    public DBHelper(@Nullable Context context) {
        super(context, DATABASE, null, DATABASE_VERSION);
    }

    /**
     * En esta funcion se crean las tablas a partir de los atributos definidos
     * @param sqLiteDatabase
     */
    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        //Tabla Challenge
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_CHALLENGE + "(" +
                NO_CHALLENGE + " INTEGER PRIMARY KEY NOT NULL, " +
                C_NAME + " TEXT NOT NULL, " +
                FINAL_DATE + " TEXT NOT NULL)");

        //Tabla Race
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_RACE + "(" +
                NO_RACE + " INTEGER PRIMARY KEY NOT NULL, " +
                R_CATEGORY + " TEXT NOT NULL, " +
                R_NAME + " TEXT NOT NULL, " +
                PRICE + " INTEGER NOT NULL)");

        //Tabla User
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_USER + "(" +
                U_USERNAME + " TEXT PRIMARY KEY NOT NULL, " +
                CATEGORY + " TEXT NOT NULL, " +
                NAME + " TEXT NOT NULL, " +
                LAST_NAME + " TEXT NOT NULL, " +
                BIRTHDATE + " TEXT NOT NULL, " +
                NATIONALITY + " TEXT NOT NULL, " +
                U_PASSWORD + " TEXT NOT NULL, " +
                IMAGE + " TEXT NOT NULL)");

        //Tabla Participation
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_PARTICIPATION + "(" +
                U_USERNAME + " TEXT REFERENCES " + TABLE_USER + "(" + U_USERNAME + "), " +
                NO_CHALLENGE + " INTEGER REFERENCES " + TABLE_CHALLENGE + "(" + NO_CHALLENGE + "))");

        //Tabla Inscription
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_INSCRIPTION + "(" +
                NO_INSCRIPTION + " INTEGER PRIMARY KEY NOT NULL, " +
                VOUCHER + " TEXT NOT NULL, " +
                IS_ACCEPTED + " INTEGER NOT NULL, " +
                NO_RACE + " INTEGER REFERENCES " + TABLE_RACE + "(" + NO_RACE + "), " +
                U_USERNAME + " TEXT REFERENCES " + TABLE_USER + "(" + U_USERNAME + "))");

        //Tabla Activity
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_ACTIVITY + "(" +
                NO_ACTIVITY + " INTEGER PRIMARY KEY NOT NULL, " +
                ROUTE + " TEXT NOT NULL, " +
                LENGTH + " INTEGER NOT NULL, " +
                A_DATE + " TEXT NOT NULL, " +
                SPORT + " TEXT NOT NULL, " +
                O_USERNAME + " TEXT NOT NULL, " +
                NO_RACE + " INTEGER REFERENCES " + TABLE_RACE + "(" + NO_RACE + "), " +
                NO_CHALLENGE + " INTEGER REFERENCES " + TABLE_CHALLENGE + "(" + NO_CHALLENGE + "))");

        //Tabla Result
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_RESULT + "(" +
                NO_RESULT + " INTEGER PRIMARY KEY NOT NULL, " +
                DURATION + " TEXT NOT NULL, " +
                NO_ACTIVITY + " INTEGER REFERENCES " + TABLE_ACTIVITY + "(" + NO_ACTIVITY + "), " +
                U_USERNAME + "TEXT REFERENCES " + TABLE_USER + "(" + U_USERNAME + "))");
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_CHALLENGE);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_RACE);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_USER);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_PARTICIPATION);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_INSCRIPTION);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_ACTIVITY);
        sqLiteDatabase.execSQL("DROP TABLE " + TABLE_RESULT);
        onCreate(sqLiteDatabase);
    }
}
