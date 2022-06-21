using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ListHandler : MonoBehaviour {

    public static List<Meal> exampleMealList = new List<Meal>();
    public static List<Meal> dailyMealList = new List<Meal>();
    // int Calories????
    public static float calories;
    public static float proteins;
    public static float carbs;
    public static float fats;
    public static bool addingMeals = true;
    public static bool saved = false;
    public static UserPreferences userPref = new UserPreferences();
    public static List<String> SavedDatesAndPlaces = new List<String>();
    public static List<List<Meal>> savedMealLists = new List<List<Meal>>();
    public static DateTime presentDate = DateTime.Now;
    public static String currentDate = presentDate.Day + "." + presentDate.Month + "." + presentDate.Year;
    public static Meal currentMeal;

    // Speicher Funktion
    public void Save()
    {
        saved = true;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/MealsLists.dat", FileMode.Create);
        ListData data = new ListData();
        StoreInList(currentDate);
        data.exampleMealList = exampleMealList;
        data.savedDatesAndPlaces = SavedDatesAndPlaces;
        data.savedMealLists = savedMealLists;
        data.saved = saved;
        data.userPref = userPref;
        bf.Serialize(file, data);
        file.Close();
    }

    // Lade Funktion
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MealsLists.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/MealsLists.dat", FileMode.Open);
            ListData data = (ListData)bf.Deserialize(file);
            file.Close();
            saved = data.saved;
            exampleMealList = data.exampleMealList;
            SavedDatesAndPlaces = data.savedDatesAndPlaces;
            savedMealLists = data.savedMealLists;
            userPref = data.userPref;
            LoadFromList(presentDate.Day + "." + presentDate.Month + "." + presentDate.Year);
        }
        //Debug.Log(SavedMealLists.Count + " " + SavedDatesAndPlaces.Count);
    }


    //* Anmerkung: eventuel ein backup einrichten falls das mal schiefläuft da sonst alles weg ist!
    //* Eine Zweite Datei die nur dann gespeichert wird wenn alles funktioniert
    //* eventuel eine Datei die nur gespeichert wird wenn speicherung und ladevorgang funktioniert ?

    // Funktion um Die Mahlzeiten in einer "Tages Mahlzeiten Datenbank zu speichern"
    public void StoreInList(String date)
    {
        if (!SavedDatesAndPlaces.Contains(date) && (dailyMealList.Count > 0))
        {
            savedMealLists.Add(dailyMealList);
            SavedDatesAndPlaces.Add(date);
            SavedDatesAndPlaces.Add("" + (savedMealLists.Count - 1));
        }
        else if(dailyMealList.Count > 0)
        {
            int i = System.Convert.ToInt32(SavedDatesAndPlaces[SavedDatesAndPlaces.IndexOf(date) + 1]);
            savedMealLists[i] = dailyMealList;
        }
    }

    // Funktion zum Laden aus der Datenbank in der die Mahlzeiten nach Tagen Gespeichert werden
    public void LoadFromList(String date)
    {
        int place = 0;
        for (int i = 0; i < SavedDatesAndPlaces.Count; i += 2)
        {
            if (SavedDatesAndPlaces[i].Contains(date))
            {
                place = System.Convert.ToInt32(SavedDatesAndPlaces[SavedDatesAndPlaces.IndexOf(date) + 1]);
                dailyMealList = savedMealLists[place];
                break;
            }
            else
            {
                dailyMealList = new List<Meal>();
            }
        }
    }

    // Speichert wenn man die App schließt
    public void OnApplicationQuit()
    {
        Save();
    }

    public void OnApplicationPause(bool pause)
    {
        Save();
    }

    // befüllt die Liste falls die App zum ersten mal gestartet wird
    public void Awake()
    {
        //File.Delete(Application.persistentDataPath + "/MealsLists.dat");
        LoadFromList(presentDate.Day + "." + presentDate.Month + "." + presentDate.Year);
        //Load();
        UpdateUserPref();
        //if (!saved)
        //{
        //    exampleMealList.Add(new Meal(3, "Shake", 109f, 5, 30, 0, 100));
        //    exampleMealList.Add(new Meal(0, "Haferflocken", 330f, 30, 16, 0, 100));
        //}
    }

    void UpdateUserPref()
    {
        calories = userPref.DailyCalories;
        carbs = userPref.DailyMacros[0];
        proteins = userPref.DailyMacros[1];
        fats = userPref.DailyMacros[2];
    }
    
}


// Die Classe der Datei die abgespeichert wird!
[Serializable]
class ListData
{
    public List<Meal> exampleMealList; 
    public List<List<Meal>> savedMealLists;
    public List<String> savedDatesAndPlaces;
    public bool saved;
    public UserPreferences userPref;
}