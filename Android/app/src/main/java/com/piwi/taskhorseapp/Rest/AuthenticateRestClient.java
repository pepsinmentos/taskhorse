package com.piwi.taskhorseapp.Rest;

import com.piwi.taskhorseapp.Logging.ILogger;
import com.piwi.taskhorseapp.Models.AuthenticationRequest;
import com.piwi.taskhorseapp.Models.Board;
import com.piwi.taskhorseapp.Models.SignUp;
import com.piwi.taskhorseapp.Models.TokenResult;

import java.lang.reflect.Field;
import java.util.Hashtable;

/**
 * Created by Vivi on 2016/05/01.
 */
public class AuthenticateRestClient extends RestClient implements IAuthenticateRest {
    protected String _baseUrl;
    public AuthenticateRestClient(ILogger logger, String baseUrl)
    {
        super(logger);
        _baseUrl = baseUrl;
    }

    @Override
    public boolean signUp(SignUp signUp) {
        setMethod("POST");
        setReturnType(String.class);
        setRequestUrl(_baseUrl + "/signup");
        setInputObject(signUp);

        RestResponse r = doCall();
        if(r.statusCode >= 200 && r.statusCode < 300)
            return true;
        return false;
    }

    @Override
    public TokenResult authenticate(AuthenticationRequest authenticateRequest) {

        setMethod("POST");
        setReturnType(TokenResult.class);
        setRequestUrl(_baseUrl);
        setInputObject(authenticateRequest);

        RestResponse r = doCall();
        if(r.statusCode >= 200 && r.statusCode < 300)
            return (TokenResult)r.response;

        return new TokenResult();
    }
}
