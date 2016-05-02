package com.piwi.taskhorseapp.Rest;

import java.util.Dictionary;
import java.util.List;
import java.util.Map;

/**
 * Created by Vivi on 2016/05/01.
 */
public class RestResponse<T> {
    public T response;
    public int statusCode;
    public Map<String, List<String>> headers;

}
