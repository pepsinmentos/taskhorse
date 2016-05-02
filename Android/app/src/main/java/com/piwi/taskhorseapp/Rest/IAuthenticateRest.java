package com.piwi.taskhorseapp.Rest;

import com.piwi.taskhorseapp.Models.AuthenticationRequest;
import com.piwi.taskhorseapp.Models.SignUp;
import com.piwi.taskhorseapp.Models.TokenResult;

/**
 * Created by Vivi on 2016/05/01.
 */
public interface IAuthenticateRest {
    boolean signUp(SignUp signUp);
    TokenResult authenticate(AuthenticationRequest authenticateRequest);
}
