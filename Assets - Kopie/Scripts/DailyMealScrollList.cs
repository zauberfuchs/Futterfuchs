using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DailyMealScrollList : MonoBehaviour {

    //public List<Meal> MealList;
    public Transform contentPanel;
    public Text myCaloriesDisplay;
    public SimpleObjectPool buttonObjectPool;
    public float calories = 0f;


    void Start()
    {
        RefreshDisplay();
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


        Meal meal = ListHandler.DailyMealList[i];
        GameObject newButton = buttonObjectPool.GetObject();
        newButton.transform.SetParent(contentPanel);
        


        SampleButton2 sampleButton = newButton.GetComponent<SampleButton2>();
        sampleButton.Setup(meal);

    }

    IEnumerator DelayInstantation()
    {

        for (int i = 0; i < ListHandler.DailyMealList.Count; i++)
        {
            AddButtons(i);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
