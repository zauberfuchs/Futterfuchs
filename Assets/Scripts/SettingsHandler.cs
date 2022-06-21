using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsHandler : MonoBehaviour {

    public InputField calInputfield;
    public Dropdown goalDropdown;
    public void setUserPreferences()
    {
        calInputfield.text = "" + ListHandler.userPref.DailyCalories;
        goalDropdown.value = ListHandler.userPref.GoalValue;
    }

    public void UpdateUserPreferences()
    {
        ListHandler.userPref.DailyCalories = System.Convert.ToInt32(calInputfield.text);
        ListHandler.userPref.GoalValue = goalDropdown.value;
    }
}
