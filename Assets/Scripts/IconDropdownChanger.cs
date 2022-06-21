using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDropdownChanger : MonoBehaviour {


    public Sprite mealIcon;
    public Sprite drinkIcon;
    public Sprite snackIcon;
    public Dropdown iconDropdown;

    public void ChangeSpriteByValue()
    {
        switch (iconDropdown.value)
        {
            case 0:
                GetComponent<Image>().sprite = mealIcon;
                break;
            case 1:
                GetComponent<Image>().sprite = drinkIcon;
                break;
            case 2:
                GetComponent<Image>().sprite = snackIcon;
                break;
        }
    }
}
