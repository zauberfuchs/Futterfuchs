using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CalendarDateItem : MonoBehaviour, IDeselectHandler
{
   
    public string date;
    public List<Meal> DailyMealList = null;
    public DailyMealScrollList DMSL;
    public Text dateText;
    public UnityEvent onDeselect;

    public ListHandler listHandler;
    
    // Funktiom um die Button Farbe auf Blau zu ändern
    //public void changeBTNColor()
    //{
    //    this.GetComponent<Image>().color = Color.cyan;
    //}

    // Funktion um Die Button Color auf Rot zu ändern falls eine liste an dem tag existiert!
    //* Anmerkung eventuel überarbieten eine globale BTN COLOR funktion mit swap cases erstellen ?
    public void gotList()
    {
        this.GetComponent<Image>().color = Color.red;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(1, 1, 1, 255);
    }
    // 
    //public void OnDateItemClick()
    //{
    //    CalendarController.calendarInstance.OnDateItemClick();
    //    this.GetComponent<Image>().color = Color.gray;

    //    if (ListHandler.dailyMealList.Count > 0)
    //    {
    //        listHandler.StoreInList(ListHandler.currentDate);
    //    }

    //    ListHandler.currentDate = date;
    //    listHandler.LoadFromList(ListHandler.currentDate);
    //    ShowDateInHeader();


    //    DMSL.RefreshDisplay();

    //}

    public void OnDateItemClick()
    {
        if (ListHandler.dailyMealList.Count > 0)
        {
            listHandler.StoreInList(ListHandler.currentDate);
        }

        ListHandler.currentDate = date;
        listHandler.LoadFromList(ListHandler.currentDate);
        // this.GetComponent<Image>().color = Color.red;
        //ShowDateInHeader();
    }

    public void OnAcceptButtonClick()
    {
        CalendarController.calendarInstance.OnDateItemClick();
        ShowDateInHeader(ListHandler.currentDate);
        DMSL.RefreshDisplay();
    }

    public void ShowDateInHeader(string date)
    {
        dateText.text = date;
    }
}
