using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarController : MonoBehaviour {

    public GameObject calendarPanel;
    public Text yearNumText;
    public Text monthNumText;

    public GameObject item;
    public List<GameObject> dateItems = new List<GameObject>();
    const int totalDateNum = 42;

    private DateTime dateTime;
    public static CalendarController calendarInstance;
    public ListHandler listHandler;

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
            day.transform.localPosition = new Vector3((i % 7) * 34 + startPos.x, startPos.y - (i / 7) * 35, startPos.z);
            dateItems.Add(day);
        }
        
        CreateCalendar();

        calendarPanel.SetActive(false);

    }

    void CreateCalendar()
    {
        DateTime firstDay = dateTime.AddDays(-(dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < totalDateNum; i++)
        {
            Text label = dateItems[i].GetComponentInChildren<Text>();
            dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    dateItems[i].SetActive(true);
                    dateItems[i].GetComponent<CalendarDateItem>().date = date + 1 + "." + dateTime.Month + "." + dateTime.Year;
                    dateItems[i].GetComponent<CalendarDateItem>().DailyMealList = listHandler.LoadFromList(dateItems[i].GetComponent<CalendarDateItem>().DailyMealList, date + 1 + "." + dateTime.Month + "." + dateTime.Year);
                    if (dateItems[i].GetComponent<CalendarDateItem>().DailyMealList.Count > 0)
                    {
                        dateItems[i].GetComponent<CalendarDateItem>().gotList = true;
                    }


                    label.text = (date + 1).ToString();
                    if ((date + 1) == dateTime.Day)
                    {
                        dateItems[i].GetComponent<Image>().color = Color.cyan;
                        //var colors = dateItems[i].GetComponent<Button>().colors;
                        //colors.normalColor = Color.red;
                        //dateItems[i].GetComponent<Button>().colors = colors;
                    }
                    date++;
                }
            }
        }
        yearNumText.text = dateTime.Year.ToString();
        //monthNumText.text = dateTime.Month.ToString();
        monthNumText.text = GetMonth(dateTime.Month);
    }
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
    public void YearPrev()
    {
        dateTime = dateTime.AddYears(-1);
        CreateCalendar();
    }
    void HighlightPresentDay()
    {

    }

    public void YearNext()
    {
        dateTime = dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        dateTime = dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        dateTime = dateTime.AddMonths(1);
        CreateCalendar();
    }

    //public void ShowCalendar(Text target)
    public void ShowCalendar()
    {
        if (calendarPanel.activeSelf)
        {
            calendarPanel.SetActive(false);
        }
        else
        {
            calendarPanel.SetActive(true);
        }
       // _target = target;
       // calendarPanel.transform.position = new Vector3(965, 475, 0);//Input.mousePosition-new Vector3(0,120,0);
    }

  //  Text _target;
    //public void OnDateItemClick(string day)
    public void OnDateItemClick()
    {
     //   _target.text = yearNumText.text + "Year" + monthNumText.text + "Month" + day + "Day";
        calendarPanel.SetActive(false);
    }
}
