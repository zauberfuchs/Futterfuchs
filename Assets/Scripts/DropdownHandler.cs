using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour {

    public Dropdown dropdown;
    
	void Start ()
    {
        dropdown.ClearOptions();
        populateList();
    }
	
	void populateList()
    {
        dropdown.AddOptions(Meal.categorys);
    }

    public int GetSelectedCategory()
    {
        //return dropdown.itemText.ToString();
        return dropdown.value;
    }
}
