package com.piwi.taskhorseapp.Rest;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.piwi.taskhorseapp.Logging.ILogger;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;
import java.util.Dictionary;
import java.util.Hashtable;
import java.util.Iterator;

/**
 * Created by Vivi on 2016/05/01.
 */
public class RestClient {
    protected ILogger _logger;
    public RestClient(ILogger logger){
        _logger = logger;
    }

    private String method;
    private String requestUrl = "";
    private Hashtable<String, String> headers;
    private Type returnType;

    public Object getInputObject() {
        return inputObject;
    }

    public void setInputObject(Object inputObject) {
        this.inputObject = inputObject;
    }

    private Object inputObject;

    public Hashtable<String, String> getInputParameters() {
        return inputParameters;
    }

    public void setInputParameters(Hashtable<String, String> inputParameters) {
        this.inputParameters = inputParameters;
    }

    private Hashtable<String, String> inputParameters;

    public String getMethod() {
        return method;
    }

    public void setMethod(String method) {
        this.method = method;
    }

    public String getRequestUrl() {
        return requestUrl;
    }

    public void setRequestUrl(String requestUrl) {
        this.requestUrl = requestUrl;
    }

    public Hashtable<String, String> getHeaders() {
        return headers;
    }

    public void setHeaders(Hashtable<String, String> headers) {
        this.headers = headers;
    }

    public Type getReturnType() {
        return returnType;
    }

    public void setReturnType(Type returnType) {
        this.returnType = returnType;
    }

    public RestResponse doCall()
    {

        RestResponse restResponse = new RestResponse();
        HttpURLConnection connection = null;


        try {
            URL url = new URL(requestUrl);
            Gson g = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
            connection = (HttpURLConnection) url.openConnection();
            connection.setConnectTimeout(10000);
            connection.setReadTimeout(10000);
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setRequestProperty("Accept", "application/json");
            //connection.setRequestProperty("User-Agent","Mozilla/5.0 ( compatible ) ");
            //connection.setRequestProperty("Authorization","Bearer 45e29fb5-bf85-4e79-b087-dd5e0648f0ba");
            if(headers != null && !headers.isEmpty())
            {
                for(String key : headers.keySet())
                {
                    connection.setRequestProperty(key, headers.get(key));
                }
            }
            connection.setRequestMethod(method);

            if (inputObject != null) {
                connection.setDoOutput(true);
                connection.setDoInput(true);
                OutputStream out = connection.getOutputStream();
                Writer writer = new OutputStreamWriter(out, "UTF-8");

                writer.write(g.toJson(inputObject));
                /*
               for(String k : inputParameters.keySet()) {
                    writer.write(k);
                    writer.write("=");
                    writer.write(URLEncoder.encode(inputParameters.get(k), "UTF-8"));
                    writer.write("&");
                }
                */
                writer.close();
                out.close();
            }

            BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            String inputLine;
            StringBuffer response = new StringBuffer();
            while ((inputLine = in.readLine()) != null) {
                response.append(inputLine);
            }
            in.close();


            if(returnType == String.class)
                restResponse.response = response.toString();
            else
                restResponse.response = g.fromJson(response.toString(), returnType);

            restResponse.statusCode = connection.getResponseCode();
            restResponse.headers = connection.getHeaderFields();

        }
        catch(Exception ex)
        {
            _logger.Error("RestClient", ex);
        }
        finally {
            if(connection != null)
                connection.disconnect();
        }

        return restResponse;

    }
    public RestResponse get()
    {
        method = "GET";

        return doCall();
    }

}
