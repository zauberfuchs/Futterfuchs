using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    
	void Awake ()
    {

        //File.Delete(Application.persistentDataPath + "/MealsLists.dat");
        Load();
        if (ListHandler.saved)
        {
            SceneManager.LoadScene(1);
        }
	}

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MealsLists.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/MealsLists.dat", FileMode.Open);
            ListData data = (ListData)bf.Deserialize(file);
            file.Close();
            ListHandler.saved = data.saved;
            ListHandler.exampleMealList = data.exampleMealList;
            ListHandler.SavedDatesAndPlaces = data.savedDatesAndPlaces;
            ListHandler.savedMealLists = data.savedMealLists;
            ListHandler.userPref = data.userPref;
        }
        //Debug.Log(SavedMealLists.Count + " " + SavedDatesAndPlaces.Count);
    }

}
