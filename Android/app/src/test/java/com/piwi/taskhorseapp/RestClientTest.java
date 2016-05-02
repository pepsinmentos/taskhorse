package com.piwi.taskhorseapp;

/**
 * Created by Vivi on 2016/05/01.
 */

import com.piwi.taskhorseapp.Logging.ConsoleLogger;
import com.piwi.taskhorseapp.Models.AuthenticationRequest;
import com.piwi.taskhorseapp.Models.Board;
import com.piwi.taskhorseapp.Models.SignUp;
import com.piwi.taskhorseapp.Rest.AuthenticateRestClient;
import com.piwi.taskhorseapp.Rest.RestClient;
import com.piwi.taskhorseapp.Rest.RestResponse;

import org.junit.Test;

import java.util.Dictionary;
import java.util.Hashtable;
import java.util.Map;

import static org.junit.Assert.*;

public class RestClientTest {
    @Test
    public void rest_call_get() throws Exception{
        RestClient client = new RestClient(new ConsoleLogger());
        Hashtable<String,String> s = new Hashtable<String,String>();
        s.put("Authorization", "Bearer 45e29fb5-bf85-4e79-b087-dd5e0648f0ba");
        client.setHeaders(s);
        client.setRequestUrl("http://localhost:4362/api/board/1e8b82c1-3124-4d05-812d-9250c6069cd4");
        client.setReturnType(Board.class);

        RestResponse result = client.get();
        assertEquals(result.statusCode, 200);
        assertNotNull(result.response);
    }

    @Test
    public void rest_signup() throws Exception{
        AuthenticateRestClient r = new AuthenticateRestClient(new ConsoleLogger(), "http://localhost:4362/api/authentication");
        SignUp s = new SignUp();
        s.Email = "pieterroodt@gmail.com";
        s.Username = "pepsinmentos";
        s.Password = "chucke";
        s.Source = "questboard";

        assertTrue(r.signUp(s));
    }

    @Test
    public void rest_authenticate() throws Exception{
        AuthenticateRestClient r = new AuthenticateRestClient(new ConsoleLogger(), "http://localhost:4362/api/authentication");
        AuthenticationRequest s = new AuthenticationRequest();
        s.Email = "pieterroodt@gmail.com";
        s.Password = "chucke";
        assertTrue(r.authenticate(s).Token != "");
        s.Password = "lol";
        assertFalse(r.authenticate(s).Token != "");
    }

    @Test
    public void addition_isCorrect() throws Exception {
        assertEquals(4, 2 + 2);
    }
}
