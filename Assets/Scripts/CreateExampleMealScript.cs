using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;

public class CreateExampleMealScript : MonoBehaviour
{

    public InputField inputName;
    public InputField inputKcal;
    public InputField inputProtein;
    public InputField inputFat;
    public InputField inputCarbs;

    public ExampleMealScrollList aMSL;
        
    public Dropdown dDCategory;
    public Image icon;

    private Meal meal;

    public void AddMeal()
    {
        if (!inputName.text.Equals("") && !inputKcal.text.Equals("") && !inputProtein.text.Equals("") && !inputFat.text.Equals("") && !inputCarbs.text.Equals(""))
        {
            meal = new Meal(0, inputName.text, float.Parse(inputKcal.text), float.Parse(inputCarbs.text), float.Parse(inputProtein.text), float.Parse(inputFat.text), 100, icon.sprite.name);
            ListHandler.exampleMealList.Add(meal);
            aMSL.RefreshDisplay();
        }
        else
        {
            Debug.Log("Fehlerhafte Eingabe");
        }
    }


}
