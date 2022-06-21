using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{

    public Transform carbLoadingBar;
    public Transform proteinLoadingBar;
    public Transform fatLoadingBar;
    public Slider caloriesSlider;

    public Text carbProgressText;
    public Text proteinProgressText;
    public Text fatProgressText;
    public Text caloriesProgressText;

    public Text eatenCalories;
    public Text earnedCarbs;
    public Text earnedProteins;
    public Text earnedFat;
    //public Transform stepLoadingBar;

    private const double carbohydrate = 4.1;
    private const double protein = 4.1;
    private const double fat = 9.3;

    private int maximumDailyCalories = ListHandler.userPref.DailyCalories;
    private double minimumDailyProteins = ListHandler.userPref.DailyMacros[1];
    private double minimumDailyCarbs = ListHandler.userPref.DailyMacros[0];
    private double minimumDailyFats = ListHandler.userPref.DailyMacros[2];

    //public int minimumDailySteps;
    private float currentCalories;
    private float currentProteins;
    private float currentCarbs;
    private float currentFats;

    

    public void UpdateLoadingbar()
    {
        currentCalories = ListHandler.calories;
        currentProteins = ListHandler.proteins;
        currentCarbs = ListHandler.carbs;
        currentFats = ListHandler.fats;

        Debug.Log("zu oft Refresh??");

        carbLoadingBar.GetComponent<Image>().fillAmount = (float)(currentCarbs / minimumDailyCarbs);
        //carbProgressText.text = Mathf.Round((float)(minimumDailyCarbs - System.Convert.ToInt32(currentCarbs))) + " g";
        carbProgressText.text = Mathf.Round((float)(minimumDailyCarbs - System.Convert.ToInt32(currentCarbs))) + " /" + minimumDailyCarbs;
        earnedCarbs.text = "" + currentCarbs + "g of carbs consumed";
        //if (currentCarbs > minimumDailyCarbs)
        //{
        //    carbProgressText.text = "Goal Reached!";
        //}

        proteinLoadingBar.GetComponent<Image>().fillAmount = (float)(currentProteins / minimumDailyProteins) ;
        proteinProgressText.text = Mathf.Round((float)(minimumDailyProteins - System.Convert.ToInt32(currentProteins))) + " g";
        earnedProteins.text = currentProteins + "g of proteins consumed";
        if (currentProteins > minimumDailyProteins)
        {
            proteinProgressText.text = "Goal Reached!";

        }

        fatLoadingBar.GetComponent<Image>().fillAmount = (float)(currentFats / minimumDailyFats);
        fatProgressText.text =  Mathf.Round((float)(minimumDailyFats - System.Convert.ToInt32(currentFats))) + " g";
        earnedFat.text = currentFats + "g of fats consumed";
        if (currentFats > minimumDailyFats)
        {
            fatProgressText.text = "Goal Reached!";
        }

        //caloriesSlider.GetComponent<Image>().fillAmount = currentCalories / maximumDailyCalories;
        caloriesSlider.value = currentCalories / maximumDailyCalories;
        //caloriesProgressText.text = "" + (maximumDailyCalories - System.Convert.ToInt32(currentCalories));
        caloriesProgressText.text =  currentCalories + " / " + maximumDailyCalories;
        eatenCalories.text = "" + currentCalories + " calories eaten";
        if (currentCalories > maximumDailyCalories)
        {
            caloriesProgressText.text = "Goal Reached!";
        }

    }
}
