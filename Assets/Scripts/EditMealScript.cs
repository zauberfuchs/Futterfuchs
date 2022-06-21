using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMealScript : MonoBehaviour {

    private Meal meal;
    public DailyMealScrollList dMSL;
    public ExampleMealScrollList aMSL;
    public AddMealPopup aMP;

    // Holt sich die Mahlzeit vom Button indem die Mahlzeit drin gespeichert ist.
    public void SetMeal(Meal meal)
    {
        this.meal = meal;
    }

    // Editiert die Mahlzeit indem es 
    // Am anfang holt er sich den Index wo die "uneditierte" Mahlzeit war
    // danach speichert er die neuen werte auf die Mahlzeit.
    // Dann holt er sich die neue "editierte" Mahlzeit
    // und am ende Speichert er die "editierte Mahlzeit auf den index der "uneditierten"
    public void EditMeal()
    {
        int i = 0;
        if (aMSL.isActiveAndEnabled)
        {
            i = ListHandler.exampleMealList.FindIndex(x => x.Equals(meal));
            aMP.UpdateMeal();
            meal = aMP.GetMeal();
            ListHandler.exampleMealList[i] = meal;
            aMSL.RefreshDisplay();
        }
        else
        {
            i = ListHandler.dailyMealList.FindIndex(x => x.Equals(meal));
            aMP.UpdateMeal();
            meal = aMP.GetMeal();
            ListHandler.dailyMealList[i] = meal;
            dMSL.RefreshDisplay();
        }
    }
}
