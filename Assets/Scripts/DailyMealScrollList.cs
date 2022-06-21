using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyMealScrollList : MonoBehaviour {
    
    public Transform contentPanel;
    //public Text myCaloriesDisplay;
    public SimpleObjectPool buttonObjectPool;
    public ProgressBarScript pBS;

    void Start()
    {
        RefreshDisplay();
    }

    // Hier wird das Display Neu angezeigt und die Daten geupdatet.
    public void RefreshDisplay()
    {
        CountCalories();
        CountProteins();
        CountCarbs();
        CountFats();
       // myCaloriesDisplay.text = "Calories: " + ListHandler.calories.ToString();
        pBS.UpdateLoadingbar();
        RemoveButtons();
        StartCoroutine(DelayInstantation());
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
    private void AddButtons(int i)
    {


        Meal meal = ListHandler.dailyMealList[i];
        GameObject newButton = buttonObjectPool.GetObject();

        newButton.transform.SetParent(contentPanel);
        


        DailyMealBtn sampleButton = newButton.GetComponent<DailyMealBtn>();
        sampleButton.Setup(meal);

    }
    // Hier wird die Erstellung jedes einzelnen Buttons um 0,5 Sekunden verzögert
    IEnumerator DelayInstantation()
    {

        for (int i = 0; i < ListHandler.dailyMealList.Count; i++)
        {
            AddButtons(i);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Hier werden die Calorien der Liste gezählt!
    private void CountCalories()
    {
        ListHandler.calories = 0;
        for (int i = 0; i < ListHandler.dailyMealList.Count; i++)
        {

            ListHandler.calories += ListHandler.dailyMealList[i].getNutrition(0);
        }
    }
    private void CountProteins()
    {
        ListHandler.proteins = 0;
        for (int i = 0; i < ListHandler.dailyMealList.Count; i++)
        {

            ListHandler.proteins += ListHandler.dailyMealList[i].getNutrition(2);
        }
    }
    private void CountCarbs()
    {
        ListHandler.carbs = 0;
        for (int i = 0; i < ListHandler.dailyMealList.Count; i++)
        {

            ListHandler.carbs += ListHandler.dailyMealList[i].getNutrition(1);
        }
    }
    private void CountFats()
    {
        ListHandler.fats = 0;
        for (int i = 0; i < ListHandler.dailyMealList.Count; i++)
        {
            ListHandler.fats += ListHandler.dailyMealList[i].getNutrition(3);
        }
    }
}
