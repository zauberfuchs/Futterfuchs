using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtenPressScript : MonoBehaviour {
    private Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        btn.onClick.AddListener(addMealToDay);
	}

    void addMealToDay()
    {
    }
}
