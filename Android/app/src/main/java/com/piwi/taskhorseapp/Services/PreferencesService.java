package com.piwi.taskhorseapp.Services;

import android.content.Context;
import android.content.SharedPreferences;

import com.piwi.taskhorseapp.Constants.KeyValueConstants;

/**
 * Created by Vivi on 2016/05/01.
 */
public class PreferencesService {

    public String addPreference(Context context, String key, String pref)
    {
        context.getSharedPreferences(KeyValueConstants.SharedPreferencesName, context.MODE_PRIVATE ).edit().putString(key, pref).commit();
        return pref;
    }
}
