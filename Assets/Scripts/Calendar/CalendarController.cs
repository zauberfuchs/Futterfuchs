using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CalendarController : MonoBehaviour {

    public GameObject calendarPanel;
    public GameObject calendarBg;
    public Text yearNumText;
    public Text monthNumText;

    private EventSystem m_EventSystem;

    public GameObject item;
    public List<GameObject> dateItems = new List<GameObject>();
    const int totalDateNum = 42;
    // Erinnerung dateTime überprüfen ob es sich ändern wenn ein neuer tag beginnt! *Anmerkung, selbst Windows hat solch eine funktion nicht!
    private DateTime dateTime;
    public static CalendarController calendarInstance;
    public ListHandler listHandler;

    private GameObject currentDay;
    private GameObject highlightedDay;

    // Erst wird der Kalender bestückt mit allen Tagen
    // dannach wird er mit der CreateCalendar erstellt (zb: mit welchem Tag beginnt der jetzige Monat ? oder wieviele Tage hat dieser.)
    // und setzt ihn erstmal auf "unsichtbar"
    void Start ()
    {
        calendarInstance = this;
        Vector3 startPos = item.transform.localPosition;
        dateItems.Clear();
        dateItems.Add(item);

        dateTime = DateTime.Now;


        for (int i = 1; i < totalDateNum; i++)
        {
            GameObject day = GameObject.Instantiate(item) as GameObject;
            day.name = "Item" + (i + 1).ToString();
            day.transform.SetParent(item.transform.parent);
            day.transform.localScale = Vector3.one;
            day.transform.localRotation = Quaternion.identity;
            day.transform.localPosition = new Vector3((i % 7) * 80 + startPos.x, startPos.y - (i / 7) * 80, startPos.z);
            dateItems.Add(day);
        }
        
        CreateCalendar();

        calendarPanel.SetActive(false);

    }

    // Baut den Kalender stück für stück auf
    public void CreateCalendar()
    {
        // Speichert den ersten Tag des Aktuellen Monats in ein DateTime Object (-1) weil der Monat bei 1 Startet und nicht bei 0
        DateTime firstDay = dateTime.AddDays(-(dateTime.Day - 1));
        // Holt sich die Nummer zum ersten Tag damit der Kalendar weiß wo er startet!

        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < totalDateNum; i++)
        {
            //Holt sich das Textfeld für Die Tag Nummer
            Text label = dateItems[i].GetComponentInChildren<Text>();
            //setzt den Tag erst einmal auf inaktiv (könnte ja sein das er sich außerhalb des Monats Befinden
            dateItems[i].SetActive(false);

            // Falls die dateItems kleiner sind als der Anfangstag werden sie nicht befüllt!
            if (i >= index)
            {
                // Holt sich den Tag der in der For schleife durchlaufen wird
                DateTime thatDay = firstDay.AddDays(date);

                // kein plan
                if (thatDay.Month == firstDay.Month)
                {
                    //Setzt den Tag auf Aktiv und gibt ihm sein Datum und seinen Text
                    dateItems[i].SetActive(true);
                    dateItems[i].GetComponent<CalendarDateItem>().date = date + 1 + "." + dateTime.Month + "." + dateTime.Year;

                    label.text = (date + 1).ToString();
                    //Falls der gerade erstellte Tag noch zusätzlich der Aktuelle Tag ist wird er blau gefärbt 
                    // wenn nicht wird es weiß gefärbt
                    //* Eventuel eigene funktion??
                    ChangeColorOfPresentDay(date, i);
                    date++;
                }
            }
        }
        yearNumText.text = dateTime.Year.ToString();
        monthNumText.text = GetMonth(dateTime.Month);
    }

    public void SetCurrentDay()
    {
        currentDay = highlightedDay;
    }

    public void SetHightlightedDay(GameObject gO)
    {
        highlightedDay = gO;
    }

    private void SelectCurrentDay()
    {
        currentDay.GetComponent<Button>().Select();
        //m_EventSystem.SetSelectedGameObject(presentDay);
    }

    // ändert die Farbe vom Aktuellen tag (eventuel überarbeiten)
    void ChangeColorOfPresentDay(int date, int i)
    {
        if ((date + 1) == ListHandler.presentDate.Day && dateTime.Month == DateTime.Now.Month && dateTime.Year == DateTime.Now.Year)
        {
            //ateItems[i].GetComponent<Image>().color = new Color(0.1215f, 0.1372f, 0.1686f, 255);
            dateItems[i].GetComponentInChildren<Text>().color = Color.red;
            currentDay = dateItems[i];
        }
        else
        {
            //dateItems[i].GetComponent<Image>().color = new Color(0.3372f, 0.3372f, 0.3372f, 255);
            dateItems[i].GetComponent<Image>().color = new Color(1, 1, 1, 255);
            if (ListHandler.SavedDatesAndPlaces.Contains(dateItems[i].GetComponent<CalendarDateItem>().date))
            {
                dateItems[i].GetComponent<CalendarDateItem>().gotList();
            }
        }
    }

    // Gibt den Tagen eine Nummer zu damit der Kalender weiß wo er anfangen muss
    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 0;
            case DayOfWeek.Tuesday: return 1;
            case DayOfWeek.Wednesday: return 2;
            case DayOfWeek.Thursday: return 3;
            case DayOfWeek.Friday: return 4;
            case DayOfWeek.Saturday: return 5;
            case DayOfWeek.Sunday: return 6;
        }

        return 0;
    }

    // Gibt den gewünschten Monat zurück
    string GetMonth(int month)
    {
        switch (month)
        {
            case 1: return "January";
            case 2: return "February";
            case 3: return "March";
            case 4: return "April";
            case 5: return "May";
            case 6: return "June";
            case 7: return "July";
            case 8: return "August";
            case 9: return "September";
            case 10: return "October";
            case 11: return "November";
            case 12: return "December";
        }
        return "";
    }

   

    // Springt ein Jahr nach hinten
    public void YearPrev()
    {
        dateTime = dateTime.AddYears(-1);
        CreateCalendar();
    }

    // Springt ein Jahr nach vorne
    public void YearNext()
    {
        dateTime = dateTime.AddYears(1);
        CreateCalendar();
    }

    // Springt einen Monat nach hinten
    public void MonthPrev()
    {
        dateTime = dateTime.AddMonths(-1);
        CreateCalendar();
    }

    // Springt einen Monat nach vorne
    public void MonthNext()
    {
        dateTime = dateTime.AddMonths(1);
        CreateCalendar();
    }
    
    // Blendet den Kalendar ein aber nur wenn er nicht schon eingeblendet ist!
    public void ShowCalendar()
    {
        if (calendarPanel.activeSelf)
        {
            calendarBg.SetActive(false);
            calendarPanel.SetActive(false);
        }
        else
        {
            calendarBg.SetActive(true);
            calendarPanel.SetActive(true);
            SelectCurrentDay();
        }
    }
    
    
    // Blendet den Calendar aus wenn man ein Datum ausgewählt hat
    public void OnDateItemClick()
    {
        calendarBg.SetActive(false);
        calendarPanel.SetActive(false);
    }
}
