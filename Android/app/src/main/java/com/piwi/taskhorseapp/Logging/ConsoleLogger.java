package com.piwi.taskhorseapp.Logging;

/**
 * Created by Vivi on 2016/05/01.
 */
public class ConsoleLogger implements ILogger {
    @Override
    public void Debug(String tag, String message) {
        System.out.print(tag + ": " + message);
    }

    @Override
    public void Error(String tag, Exception ex) {
        System.out.print(tag + ": " + ex.getMessage());
        for(StackTraceElement el :  ex.getStackTrace())
        {
            System.out.print(tag + ": " + el.toString());
        }
    }
}
