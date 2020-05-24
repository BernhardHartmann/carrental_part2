package com.example.se_car_rental.entities;


import android.content.Context;
import android.content.SharedPreferences;
import android.icu.text.SimpleDateFormat;

import android.util.Log;

import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.google.gson.JsonSerializer;
import com.google.gson.reflect.TypeToken;


import org.json.JSONException;


import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.Reader;
import java.lang.reflect.Array;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ApiUtil {
    private ApiUtil() {
    }

    //public static final String BASE_API_URL = "http://34.230.15.8/fh.campuswien.rest/services/rest/v1/";
    public static final String BASE_API_URL = "http://10.0.2.2:5001/services/rest/v1/";

    public static String getFromBackend(String urlPath, String jwtToken)  {

        HttpURLConnection con = null;
        StringBuilder result = new StringBuilder();
        JsonParser parser = new JsonParser();


        try {

            URL url = new URL(BASE_API_URL + urlPath);

            con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("Content-Type", "application/json; utf-8");
            con.setRequestProperty("Accept", "application/json");
            if(jwtToken != null){
                con.setRequestProperty("authorization", "Bearer " + jwtToken);
            }
            con.setDoOutput(false);

            int status = con.getResponseCode();
            InputStream in = null;

            if (status > 299) {
                in = new BufferedInputStream(con.getErrorStream());
            } else {
                in = new BufferedInputStream(con.getInputStream());
            }

            BufferedReader reader = new BufferedReader(new InputStreamReader(in));

            String line;
            while ((line = reader.readLine()) != null) {
                result.append(line);
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            con.disconnect();
        }

        JsonElement json = parser.parse(String.valueOf(result));
        return json.getAsString();

    }


    public static String getFromBackend(String urlPath, String jwtToken, Integer id) {


        HttpURLConnection con = null;
        StringBuilder result = new StringBuilder();
        JsonParser parser = new JsonParser();

        try {

            URL url = new URL(BASE_API_URL + urlPath + id.toString());

            con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("GET");
            con.setRequestProperty("Content-Type", "application/json; utf-8");
            con.setRequestProperty("Accept", "application/json");
            if(jwtToken != null){
                con.setRequestProperty("authorization", "Bearer " + jwtToken);
            }
            con.setDoOutput(false);

            int status = con.getResponseCode();
            InputStream in = null;

            if (status > 299) {
                in = new BufferedInputStream(con.getErrorStream());
            } else {
                in = new BufferedInputStream(con.getInputStream());
            }

            BufferedReader reader = new BufferedReader(new InputStreamReader(in));

            String line;
            while ((line = reader.readLine()) != null) {
                result.append(line);
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            con.disconnect();
        }

        JsonElement json = parser.parse(String.valueOf(result));
        return json.getAsString();
    }

    public static String postToBackend(String urlPath, String jwtToken, Object object) throws IOException {

        HttpURLConnection con = null;
        JsonParser parser = new JsonParser();
        StringBuilder response = new StringBuilder();

        try {
            URL url = new URL(BASE_API_URL + urlPath);
            Gson gson = new Gson();

            con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("POST");
            con.setRequestProperty("Content-Type", "application/json; utf-8");
            con.setRequestProperty("Accept", "application/json");
            if(jwtToken != null){
                con.setRequestProperty("authorization", "Bearer " + jwtToken);
            }
            con.setDoOutput(true);

            String jsonInputString = gson.toJson(object); //gson.tojson() converts your pojo to json

            OutputStream os = con.getOutputStream();
            byte[] input = jsonInputString.getBytes("utf-8");
            os.write(input, 0, input.length);

            int status = con.getResponseCode();
            Reader streamReader = null;

            if (status > 299) {
                streamReader = new InputStreamReader(con.getErrorStream(), "utf-8");
            } else {
                streamReader = new InputStreamReader(con.getInputStream(), "utf-8");
            }

            BufferedReader br = new BufferedReader(streamReader);

            String responseLine = null;

            while ((responseLine = br.readLine()) != null) {
                response.append(responseLine.trim());
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            con.disconnect();
        }

        JsonElement json = parser.parse(String.valueOf(response));
        return json.getAsString();

    }

    public static String putToBackend(String urlPath, String jwtToken, Object object) throws IOException {

        HttpURLConnection con = null;
        JsonParser parser = new JsonParser();
        StringBuilder response = new StringBuilder();

        try {
            URL url = new URL(BASE_API_URL + urlPath);
            Gson gson = new Gson();

            con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("PUT");
            con.setRequestProperty("Content-Type", "application/json; utf-8");
            con.setRequestProperty("Accept", "application/json");
            if(jwtToken != null){
                con.setRequestProperty("authorization", "Bearer " + jwtToken);
            }
            con.setDoOutput(true);

            String jsonInputString = gson.toJson(object); //gson.tojson() converts your pojo to json

            OutputStream os = con.getOutputStream();
            byte[] input = jsonInputString.getBytes("utf-8");
            os.write(input, 0, input.length);

            int status = con.getResponseCode();
            Reader streamReader = null;

            if (status > 299) {
                streamReader = new InputStreamReader(con.getErrorStream(), "utf-8");
            } else {
                streamReader = new InputStreamReader(con.getInputStream(), "utf-8");
            }

            BufferedReader br = new BufferedReader(streamReader);

            String responseLine = null;

            while ((responseLine = br.readLine()) != null) {
                response.append(responseLine.trim());
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            con.disconnect();
        }

        JsonElement json = parser.parse(String.valueOf(response));
        return json.getAsString();

    }

}