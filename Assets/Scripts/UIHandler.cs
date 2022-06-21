using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIHandler : MonoBehaviour
{

    // Wird beim ShowExampleMealsBtn ausgeführt um beim klick die Farbe im Button zu ändern!
    public void ButtonChangeColor()
    {
        Text text = GameObject.Find("AddMealButtonText").GetComponent<Text>();
        text.color = new Color32(153, 225, 223, 255);
    }

    public void ButtonChangeColorback()
    {
        Text text = GameObject.Find("AddMealButtonText").GetComponent<Text>();
        text.color = new Color32(255, 255, 255, 255);
    }

    //public void ShowMealList()
    //{
    //    StopAllCoroutines();
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
    