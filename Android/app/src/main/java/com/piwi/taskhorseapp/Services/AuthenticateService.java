package com.piwi.taskhorseapp.Services;

import com.piwi.taskhorseapp.Models.AuthenticationRequest;
import com.piwi.taskhorseapp.Models.SignUp;
import com.piwi.taskhorseapp.Models.TokenResult;
import com.piwi.taskhorseapp.Rest.IAuthenticateRest;

import java.util.Date;

/**
 * Created by Vivi on 2016/05/01.
 */
public class AuthenticateService {

    private IAuthenticateRest _authenticateRestClient;
    private TokenResult storedToken = null;
    private Date tokenExpiry;

    public AuthenticateService(IAuthenticateRest authenticateRestClient)
    {
        _authenticateRestClient = authenticateRestClient;
    }

    public boolean signUp(SignUp model)
    {
        return _authenticateRestClient.signUp(model);
    }

    public TokenResult authenticate(AuthenticationRequest authenticationRequest)
    {
        if(storedToken == null || tokenExpiry.before(new Date())) {
            storedToken = _authenticateRestClient.authenticate(authenticationRequest);
            tokenExpiry = new Date( System.currentTimeMillis() + storedToken.ExpiresIn * 1000);
        }

        return storedToken;
    }
}
