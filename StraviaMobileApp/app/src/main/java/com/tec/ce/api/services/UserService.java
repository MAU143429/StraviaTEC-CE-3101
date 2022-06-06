package com.tec.ce.api.services;

import com.tec.ce.api.models.LoginRequest;
import com.tec.ce.api.models.LoginResponse;
import com.tec.ce.api.models.UserResponse;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface UserService {

    @GET("User")
    Call<List<UserResponse>> getAllUsers();

    @POST("User/login")
    Call<LoginResponse> loginUser(@Body LoginRequest loginRequest);

}


