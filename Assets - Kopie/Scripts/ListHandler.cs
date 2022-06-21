using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ListHandler : MonoBehaviour {

    public static List<Meal> AddMealList = new List<Meal>();
    public static List<Meal> DailyMealList = new List<Meal>();
    public static float calories;
    public static bool addingMeals = true;
    public static bool saved = false;
    public static List<String> SavedDatesAndPlaces = new List<String>();
    private List<List<Meal>> SavedMealLists = new List<List<Meal>>();
    public static DateTime presentDate = DateTime.Now;
    public static String currentDate = presentDate.Day + "." + presentDate.Month + "." + presentDate.Year;

    public void Save()
    {
        saved = true;
        BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "MealsLists.dat");
        FileStream file = new FileStream(Application.persistentDataPath + "/MealsLists.dat", FileMode.Create);
        ListData data = new ListData();
        StoreInList(DailyMealList, currentDate);
        data.AddMealList = AddMealList;
        data.SavedDatesAndPlaces = SavedDatesAndPlaces;
       // data.DailyMealList = DailyMealList;
        data.SavedMealLists = SavedMealLists;
        data.saved = saved;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MealsLists.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            // filestream file = file.open(application.persistentdatapath + "meallists.dat", filemode.open);
            FileStream file = new FileStream(Application.persistentDataPath + "/MealsLists.dat", FileMode.Open);
            ListData data = (ListData)bf.Deserialize(file);
            file.Close();
            saved = data.saved;
            AddMealList = data.AddMealList;
            SavedDatesAndPlaces = data.SavedDatesAndPlaces;
           //DailyMealList = data.DailyMealList;
            SavedMealLists = data.SavedMealLists;
            DailyMealList = LoadFromList(DailyMealList, presentDate.Day + "." + presentDate.Month + "." + presentDate.Year);
            CountCalories();
        }

    }

    public void StoreInList(List<Meal> DailyMealList, String date)
    {
        //DateTime date = presentDate;
        //if (!SavedDatesAndPlaces.Contains(date.Day + "." + date.Month + "." + date.Year))
        //{
        //    SavedMealLists.Add(DailyMealList);
        //    SavedDatesAndPlaces.Add(date.Day + "." + date.Month + "." + date.Year);
        //    SavedDatesAndPlaces.Add("" + (SavedDatesAndPlaces.Count + 1));
        //}
        //else
        //{
        //    SavedMealLists[SavedDatesAndPlaces.IndexOf(date.Day + "." + date.Month + "." + date.Year) + 1] = DailyMealList;
        //}

        if (!SavedDatesAndPlaces.Contains(date))
        {
            SavedMealLists.Add(DailyMealList);
            SavedDatesAndPlaces.Add(date);
            SavedDatesAndPlaces.Add("" + (SavedMealLists.Count - 1));
        }
        else
        {
            int i = System.Convert.ToInt32(SavedDatesAndPlaces[SavedDatesAndPlaces.IndexOf(date) + 1]);
            SavedMealLists[i] = DailyMealList;
        }

    }

    public List<Meal> LoadFromList(List<Meal> dailyMealList, String date)
    {

        int place = 0;
        for (int i = 0; i < SavedDatesAndPlaces.Count; i += 2)
        {
            if (SavedDatesAndPlaces[i].Contains(date))
            {
               // place = i++;
                place = SavedDatesAndPlaces.IndexOf(date)+1;
                dailyMealList = SavedMealLists[place];
            }
        }
        return dailyMealList;
    }
    public void OnApplicationQuit()
    {
        Save();
    }
    public void Awake()
    {
        File.Delete(Application.persistentDataPath + "/MealsLists.dat");
        Load();

        if (!saved)
        {
            AddMealList.Add(new Meal(3, "Shake", 109f, 5, 30, 0));
            AddMealList.Add(new Meal(0, "Haferflocken", 330f, 30, 16, 0));
        }

        // LoadFromList(DailyMealList, presentDate.Day + "." + presentDate.Month + "." + presentDate.Year);
    }
    
    private void CountCalories()
    {
        for (int i = 0; i < DailyMealList.Count; i++)
        {
            calories += DailyMealList[i].getNutrition(0);
        }
    }
}

[Serializable]
class ListData
{
    public List<Meal> AddMealList; 
    public List<List<Meal>> SavedMealLists;
    public List<String> SavedDatesAndPlaces;
    public bool saved;
}