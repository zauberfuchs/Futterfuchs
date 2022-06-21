using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour {

    public Toggle maleToggle;
    public Toggle femaleToggle;
    public InputField ageInputField;
    public InputField heightInputField;
    public InputField weightInputField;
    public Dropdown goalDropdown;
    public GameObject infoPanel;
    public GameObject activityPanel;

    public InputField firstActivityInputField;
    public InputField secondActivityInputField;
    public InputField thirdActivityInputField;
    public InputField fourthActivityInputField;
    public InputField fifthActivityInputField;
    public InputField sixthActivityInputField;


    private bool checkPassed = true;


    private int dailyCalories;
    private int dailyProteins;
    private int dailyCarbohydrates;
    private int dailyFats;
    private int age;
    private int height;
    private int weight;
    


    void CheckSecondInput()
    {
        int sum = Convert.ToInt32(firstActivityInputField.text)
            + Convert.ToInt32(secondActivityInputField.text)
            + Convert.ToInt32(thirdActivityInputField.text)
            + Convert.ToInt32(fourthActivityInputField.text)
            + Convert.ToInt32(fourthActivityInputField.text)
            + Convert.ToInt32(sixthActivityInputField.text);
        checkPassed = true;
        if (Convert.ToInt32(firstActivityInputField.text) < 0 || Convert.ToInt32(firstActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if (Convert.ToInt32(secondActivityInputField.text) < 0 || Convert.ToInt32(secondActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if (Convert.ToInt32(thirdActivityInputField.text) < 0 || Convert.ToInt32(thirdActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if (Convert.ToInt32(fourthActivityInputField.text) < 0 || Convert.ToInt32(fourthActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if (Convert.ToInt32(fifthActivityInputField.text) < 0 || Convert.ToInt32(fifthActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if (Convert.ToInt32(sixthActivityInputField.text) < 0 || Convert.ToInt32(sixthActivityInputField.text) > 24)
        {
            checkPassed = false;
            Debug.Log("you are above 24 hour");
        }
        else if(sum != 24)
        {
            checkPassed = false;
            Debug.Log("your activity has to add up to 24");
        }
    }
    
    void SaveInputsIntoVariables()
    {
        age = Convert.ToInt32(ageInputField.text);
        height = Convert.ToInt32(heightInputField.text);
        weight = Convert.ToInt32(weightInputField.text);
    }
    void CalculateDailyCalories()
    {
        if (maleToggle.isOn)
        {
            dailyCalories = Convert.ToInt32(CalculatePalValue() * (66.47 + (13.7 * weight) + (5 * height) - (6.8 * age)));
            Debug.Log(dailyCalories);
        }

        else
        {
            dailyCalories = Convert.ToInt32(CalculatePalValue() * (655.1 + (9.6 * weight) + (1.8 * height) - (4.7 * age)));
        }
    }
    double CalculatePalValue()
    {
        double activityValue = 1;
        activityValue = (Convert.ToInt32(firstActivityInputField.text) * 0.95
            + Convert.ToInt32(secondActivityInputField.text) * 1.2
            + Convert.ToInt32(thirdActivityInputField.text) * 1.4
            + Convert.ToInt32(fourthActivityInputField.text) * 1.6
            + Convert.ToInt32(fifthActivityInputField.text) * 1.8
            + Convert.ToInt32(sixthActivityInputField.text) * 2) / 24;


        return activityValue;
    }

    void CalculateDailyMacros()
    {
        switch (goalDropdown.value)
        {
            case 0:
                dailyProteins = Convert.ToInt32(dailyCalories * 0.4 / 4.1);
                dailyCarbohydrates = Convert.ToInt32(dailyCalories * 0.2 / 4.1);
                dailyFats = Convert.ToInt32(dailyCalories * 0.4 / 9.3);
                break;
            case 1:
                dailyProteins = Convert.ToInt32(dailyCalories * 0.4 / 4.1);
                dailyCarbohydrates = Convert.ToInt32(dailyCalories * 0.4 / 4.1);
                dailyFats = Convert.ToInt32(dailyCalories * 0.2 / 9.3);
                break;
            case 2:
                dailyProteins = Convert.ToInt32(dailyCalories * 0.2 / 4.1);
                dailyCarbohydrates = Convert.ToInt32(dailyCalories * 0.5 / 4.1);
                dailyFats = Convert.ToInt32(dailyCalories * 0.3 / 9.3);
                break;
        }
    }

    void saveUserPreferences()
    {
        ListHandler.userPref = new UserPreferences(dailyCalories, dailyCarbohydrates, dailyProteins, dailyFats,
            Convert.ToInt32(firstActivityInputField.text), Convert.ToInt32(secondActivityInputField.text), Convert.ToInt32(thirdActivityInputField.text),
            Convert.ToInt32(fourthActivityInputField.text), Convert.ToInt32(fifthActivityInputField.text), Convert.ToInt32(sixthActivityInputField.text),
            age, weight, height, goalDropdown.value);
    }

    public void CheckFirstInput()
    {
        checkPassed = true;
        if (!maleToggle.isOn && !femaleToggle.isOn)
        {
            checkPassed = false;
            Debug.Log("You need to Select a Gender");
        }
        else if (Convert.ToInt32(ageInputField.text) < 16)
        {
            checkPassed = false;
            Debug.Log("You age is under 16!");
        }
        else if (Convert.ToInt32(heightInputField.text) < 140 || Convert.ToInt32(heightInputField.text) > 220)
        {
            checkPassed = false;
            Debug.Log("You are to small or to high");
        }
        else if (Convert.ToInt32(weightInputField.text) < 40 || Convert.ToInt32(weightInputField.text) > 200)
        {
            checkPassed = false;
            Debug.Log("You are to FAT or to skinny");
        }
    }
    public void SwitchToNextPanel()
    {
        if (checkPassed)
        {
            infoPanel.SetActive(false);
            activityPanel.SetActive(true);
        }
    }

    public void ButtonPressed()
    {
        if (checkPassed)
        {
            SaveInputsIntoVariables();
            CalculateDailyCalories();
            CalculateDailyMacros();
            saveUserPreferences();
            Debug.Log(dailyCalories + " " + dailyCarbohydrates + " " + dailyProteins + " " + dailyFats);
            SceneManager.LoadScene(1);
        }
    }
}
