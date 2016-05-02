package com.piwi.taskhorseapp.Logging;

import android.util.Log;

/**
 * Created by Vivi on 2016/05/02.
 */
public class AndroidLogger implements ILogger {
    @Override
    public void Debug(String tag, String message) {
        Log.d("QuestBoard: " + tag, message);
    }

    @Override
    public void Error(String tag, Exception ex) {
        Log.e("QuestBoard: " + tag, ex.getClass().toString());
        Log.e("QuestBoard: " + tag, ex.getMessage());
        for(StackTraceElement el :  ex.getStackTrace())
        {
            Log.e("QuestBoard: " + tag, el.toString());
        }
    }
}
