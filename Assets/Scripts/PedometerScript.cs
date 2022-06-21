using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedometerScript : MonoBehaviour {

    private AndroidJavaClass plugin;
    public Text text;
    
    void Start ()
    {
#if UNITY_ANDROID
        plugin = new AndroidJavaClass("jp.kshoji.unity.sensor.UnitySensorPlugin").CallStatic<AndroidJavaClass>("getInstance");
        if (plugin != null)
        {
            plugin.Call("startSensorListening", "stepcounter");
        }
        text.text = "Stepcounter geladen!";
        InvokeRepeating("CheckSensor", 1.0f, 0.001f);
#endif
    }
	
    void OnApplicationQuit()
    {
#if UNITY_ANDROID
        if (plugin != null)
        {
            plugin.Call("terminate");
            plugin = null;
        }
#endif
    }

    void CheckSensor()
    {
#if UNITY_ANDROID
        if (plugin != null)
        {
            float[] sensorValue = plugin.Call<float[]>("getSensorValues", "stepcounter");
            if (sensorValue != null)
            {
                Debug.Log("sensorValue:" + string.Join(",", new List<float>(sensorValue).ConvertAll(i => i.ToString()).ToArray()));
                text.text = string.Join(",", new List<float>(sensorValue).ConvertAll(i => i.ToString()).ToArray());
            }
        }
#endif
    }

}
