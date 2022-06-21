using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMealScript : MonoBehaviour {


    private Meal meal;
    public DailyMealScrollList dMSL;
    public ExampleMealScrollList aMSL;

    // Holt sich die Mahlzeit vom Button indem die Mahlzeit drin gespeichert ist.
    public void SetMeal(Meal meal)
    {
        this.meal = meal;
    }

    // Diese Funktion unterscheidet erst in welcher Liste wir uns Befinden, und sucht sich dann erst den Index raus um dann an dieser stelle das Mahlzeit Objekt zu löschen
    public void RemoveMeal()
    {
        if (aMSL.isActiveAndEnabled)
        {
            ListHandler.exampleMealList.RemoveAt(ListHandler.exampleMealList.FindIndex(x => x.Equals(meal)));
            aMSL.RefreshDisplay();
        }
        else
        {
            ListHandler.dailyMealList.RemoveAt(ListHandler.dailyMealList.FindIndex(x => x.Equals(meal)));
            dMSL.RefreshDisplay();
        }
    }
}
