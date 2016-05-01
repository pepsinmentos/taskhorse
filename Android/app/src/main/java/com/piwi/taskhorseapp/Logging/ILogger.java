package com.piwi.taskhorseapp.Logging;

/**
 * Created by Vivi on 2016/05/01.
 */
public interface ILogger {
    void Debug(String tag, String message);
    void Error(String tag, Exception ex);
}
