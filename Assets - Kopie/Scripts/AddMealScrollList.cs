using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

[Serializable]
public class Meal
{
    public int category;
    private string[] categorys = { "Frühstück", "Mittag", "Abend", "Postworkout" };
    public string name;
    public float[] nutritions = new float[4];

    public Meal()
    {

    }

    public Meal(int category, string name, float kCal, float carbohydrates, float protein, float fat)
    {
        this.Name = name;
        this.category = category;
        this.nutritions[0] = kCal;
        this.nutritions[1] = carbohydrates;
        this.nutritions[2] = protein;
        this.nutritions[3] = fat;
    }

    public int Category
    {
        get { return category; }
        set { category = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string getCategory()
    {
        return categorys[this.category];
    }

    public float getNutrition(int nutrition)
    {
        return this.nutritions[nutrition];
    }

    public void changeNutritions(int nutrition, float value)
    {
        this.nutritions[nutrition] = value;
    }
}
public class AddMealScrollList : MonoBehaviour
{



    public Transform contentPanel;
    public Text myCaloriesDisplay;
    public SimpleObjectPool buttonObjectPool;
    public DailyMealScrollList otherList;
    public float calories = 0f;


    void Awake()
    {
        //if (!ListHandler.saved)
        //{ 
        //ListHandler.AddMealList.Add(new Meal(3, "Shake", 109f, 5, 30, 0));
        //ListHandler.AddMealList.Add(new Meal(0, "Haferflocken", 330f, 30, 16, 0));
        //}
    }

    public void RefreshDisplay()
    {
        myCaloriesDisplay.text = "Calories: " + ListHandler.calories.ToString();
        RemoveButtons();
        StartCoroutine(DelayInstantation());
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons(int i)
    {

        Meal meal = ListHandler.AddMealList[i];
        GameObject newButton = buttonObjectPool.GetObject();

        newButton.transform.SetParent(contentPanel);


        SampleButton sampleButton = newButton.GetComponent<SampleButton>();
        sampleButton.Setup(meal, this);

    }

    IEnumerator DelayInstantation()
    {

        for (int i = 0; i < ListHandler.AddMealList.Count; i++)
        {
            AddButtons(i);
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void TryTransferItemToDay(Meal meal)
    {
        ListHandler.DailyMealList.Add(meal);
        //AddMeal(meal, otherList);
        ListHandler.calories += meal.getNutrition(0);
        //otherList.calories += calories;


        RefreshDisplay();
        otherList.RefreshDisplay();

    }
    

    

    void AddMeal(Meal itemToAdd)
    {
        ListHandler.DailyMealList.Add(itemToAdd);
    }

    private void RemoveMeal(Meal itemToRemove)
    {
        for (int i = ListHandler.AddMealList.Count - 1; i >= 0; i--)
        {
            if (ListHandler.AddMealList[i] == itemToRemove)
            {
                ListHandler.AddMealList.RemoveAt(i);
            }
        }
    }
}
