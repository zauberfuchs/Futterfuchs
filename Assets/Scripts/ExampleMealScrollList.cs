using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;


public class ExampleMealScrollList : MonoBehaviour
{



    public Transform contentPanel;
    //ganze Calorien funktion woanders speichern(listHandler);
    //public Text myCaloriesDisplay;
    public SimpleObjectPool buttonObjectPool;
    public DailyMealScrollList otherList;
    public ProgressBarScript pBS;

    public Sprite snackIcon;
    public Sprite drinkIcon;
    public Sprite mealIcon;


    private void Awake()
    {
        if (!ListHandler.saved)
        {
            //ListHandler.exampleMealList.Add(new Meal(3, "Shake", 389f, 7.8f, 74.9f, 6.6f, 100, drinkIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Haferflocken", 339f, 55, 10.3f, 6.5f, 100, mealIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Paranüsse", 660f, 12, 14, 66, 100, snackIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Magerquark", 73f, 4, 13.5f, 0.3f, 100, mealIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Magerjoghurt", 41f, 5.4f, 4.6f, 0.1f, 100, snackIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Thunfisch", 111f, 0, 25.5f, 1, 100, mealIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Kaffee mit Milch", 30f, 2, 1.5f, 0.5f, 100, drinkIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Apfel", 52f, 11.4f, 0.3f, 0.4f, 100, snackIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Brötchen", 310f, 52, 6, 6, 100, mealIcon));
            //ListHandler.exampleMealList.Add(new Meal(0, "Reis", 130f, 28, 7.5f, 0.3f, 100, mealIcon));

            ListHandler.exampleMealList.Add(new Meal(3, "Shake", 389f, 7.8f, 74.9f, 6.6f, 100, "drink-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Haferflocken", 339f, 55, 10.3f, 6.5f, 100, "eat-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Paranüsse", 660f, 12, 14, 66, 100, "snack-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Magerquark", 73f, 4, 13.5f, 0.3f, 100, "eat-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Magerjoghurt", 41f, 5.4f, 4.6f, 0.1f, 100, "snack-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Thunfisch", 111f, 0, 25.5f, 1, 100, "eat-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Kaffee mit Milch", 30f, 2, 1.5f, 0.5f, 100, "drink-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Apfel", 52f, 11.4f, 0.3f, 0.4f, 100, "snack-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Brötchen", 310f, 52, 6, 6, 100, "eat-icon"));
            ListHandler.exampleMealList.Add(new Meal(0, "Reis", 130f, 28, 7.5f, 0.3f, 100, "eat-icon"));
        }
    }

    // Hier wird das Display Neu angezeigt und die Daten geupdatet.
    public void RefreshDisplay()
    {
        //myCaloriesDisplay.text = "Calories: " + ListHandler.calories.ToString();
        pBS.UpdateLoadingbar();
        RemoveButtons();
        AddButtons();
        //StartCoroutine(DelayInstantation());
    }

    // Funktion um alle Buttons aus der Liste einmal zu löschen
    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    //Funktion um die Buttons der Liste Hinzuzufügen
    private void AddButtons()
    {
        for (int i = 0; i < ListHandler.exampleMealList.Count; i++)
        {
            Meal meal = ListHandler.exampleMealList[i];
            GameObject newButton = buttonObjectPool.GetObject();

            newButton.transform.SetParent(contentPanel);


            ExampleMealBtn sampleButton = newButton.GetComponent<ExampleMealBtn>();
            sampleButton.Setup(meal, this);
        }
    }

    // Hier wird die Erstellung jedes einzelnen Buttons um 0,5 Sekunden verzögert
    //IEnumerator DelayInstantation()
    //{

    //    for (int i = 0; i < ListHandler.exampleMealList.Count; i++)
    //    {
    //        AddButtons(i);
    //        yield return new WaitForSeconds(0.0f);
    //    }
    //}

    // Funktion um Die Beispiel Mahlzeit zu den Täglichen Mahlzeiten hinzuzufügen
    public void TryTransferItemToDay(Meal meal)
    {
        ListHandler.dailyMealList.Add(meal);
        
        RefreshDisplay();
        otherList.RefreshDisplay();
    }
    
    //private void RemoveMeal(Meal itemToRemove)
    //{
    //    for (int i = ListHandler.exampleMealList.Count - 1; i >= 0; i--)
    //    {
    //        if (ListHandler.exampleMealList[i] == itemToRemove)
    //        {
    //            ListHandler.exampleMealList.RemoveAt(i);
    //        }
    //    }
    //}
}
