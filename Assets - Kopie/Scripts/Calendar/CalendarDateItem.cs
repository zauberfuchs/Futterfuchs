using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour
{
   
    public string date;
    public List<Meal> DailyMealList = null;
    public bool gotList = false;
    public DailyMealScrollList DMSL;

    public ListHandler listHandler;

    public void changeBTNColor()
    {
        this.GetComponent<Image>().color = Color.cyan;
    }
    public void OnDateItemClick()
    {
        CalendarController.calendarInstance.OnDateItemClick();
        this.GetComponent<Image>().color = Color.gray;
        // CalendarController.calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
        if (ListHandler.DailyMealList.Count > 0)
        {
            listHandler.StoreInList(ListHandler.DailyMealList, ListHandler.currentDate);
        }

        if (gotList)
        {
            ListHandler.DailyMealList = DailyMealList;

        }
        else
        {
            ListHandler.DailyMealList = DailyMealList;
        }
        DMSL.RefreshDisplay();
        ListHandler.currentDate = date;

    }
}
