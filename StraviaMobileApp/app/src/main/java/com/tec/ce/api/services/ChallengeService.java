package com.tec.ce.api.services;

import com.tec.ce.api.models.UserResponse;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ChallengeService {
    @GET("User/{username}")
    Call<List<UserResponse>> getAllChallenges();
}
