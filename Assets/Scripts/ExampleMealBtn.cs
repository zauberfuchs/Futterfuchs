using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExampleMealBtn : MonoBehaviour {
    
    public Button buttonComponent;
    public Text nameLabel;
    [SerializeField]
    public Image icon;

    public GameObject mealPopup;
    public GameObject exampleMealPanel;


    private Component addMealPopup;
    private Meal meal;

    // fügt dem Button eine Click Funktion hinzu.
    void Start()
    {
        buttonComponent.onClick.AddListener(Handleclick);
        addMealPopup = mealPopup.GetComponentInChildren<AddMealPopup>();
    }

    // Erstellt Den Button mit den zugehörigen Informationen!
    public void Setup(Meal currentItem, ExampleMealScrollList AddMealscrollList)
    {
        meal = currentItem;
        nameLabel.text = meal.Name;
        //categoryLabel.text = meal.getCategory();
        //nutritionLabel.text = "Kcal = " + meal.getNutrition(0) + "    Carb = " + meal.getNutrition(1) + "   Protein = " + meal.getNutrition(2) + "   Fat = " + meal.getNutrition(3);

        icon.sprite = Resources.Load<Sprite>(meal.iconName);
        //icon.sprite = meal.icon;
    }

    // Die funktion die beim Klick auf den Button Aufgeführt wird
    // Schaut welche Liste gerade aktiv ist und öffnet dann das MealPopup und führt die funktionen aus!
    public void Handleclick()
    {
        if (exampleMealPanel.activeSelf)
        {
            if (!addMealPopup.gameObject.activeSelf)
            {
                addMealPopup.gameObject.SetActive(true);
            }
            mealPopup.SetActive(true);
            mealPopup.GetComponentInChildren<AddMealPopup>().SetMeal(meal);
            mealPopup.GetComponentInChildren<AddMealPopup>().FillText();
            mealPopup.GetComponentInChildren<AddMealPopup>().gameObject.SetActive(true);
            mealPopup.GetComponentInChildren<RemoveMealScript>().SetMeal(meal);
            mealPopup.GetComponentInChildren<EditMealScript>().SetMeal(meal);
        }
    }
}
