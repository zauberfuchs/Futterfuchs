using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIHandler : MonoBehaviour {
    

    public void ButtonChangeColor()
    {
        Text text = GameObject.Find("AddMealButtonText").GetComponent<Text>();
        text.color = new Color32(153, 225, 223, 255);
    }

    public void ButtonChangeColorback()
    {
        Text text = GameObject.Find("AddMealButtonText").GetComponent<Text>();
        text.color = new Color32(51, 41, 47, 255);
    }

    public void showMealList()
    {
        //List<Meal> meals;
        //meals = GameObject.Find("AddMealContent").GetComponent<MealScrollList>().MealList;
        //Debug.Log(meals.Count);
        StopAllCoroutines();
    }
}
