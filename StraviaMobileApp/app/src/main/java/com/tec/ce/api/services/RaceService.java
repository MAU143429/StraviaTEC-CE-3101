package com.tec.ce.api.services;

import com.tec.ce.api.models.UserModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface RaceService {
    @GET("User")
    Call<List<UserModel>> getAllRaces();
}
