using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyMealBtn : MonoBehaviour {

    
    public Button buttonComponent;
    public Text nameLabel;
    public Text categoryLabel;
    public Text kcalLabel;
    public Text carbsLabel;
    public Text fatsLabel;
    public Text proteinsLabel;
    public Text gramsLabel;

    public Image icon;

    public GameObject dailyMealPanel;
    public GameObject mealPopup;
    
    private Component addMealPopup;

    private Meal meal;

    // fügt dem Button eine Click Funktion hinzu.
    void Start()
    {
        buttonComponent.onClick.AddListener(Handleclick);
        addMealPopup = mealPopup.GetComponentInChildren<AddMealPopup>();
    }

    // Erstellt Den Button mit den zugehörigen Informationen!
    public void Setup(Meal currentItem)
    {
        meal = currentItem;
        nameLabel.text = meal.Name;
        categoryLabel.text = meal.getCategory();
        // nutritionLabel.text = "Kcal = " + meal.getNutrition(0) + "    Carb = " + meal.getNutrition(1) + "   Protein = " + meal.getNutrition(2) + "   Fat = " + meal.getNutrition(3);
        kcalLabel.text = meal.getNutrition(0) + " Kcal";
        carbsLabel.text = "" + meal.getNutrition(1);
        proteinsLabel.text = "" + meal.getNutrition(2);
        fatsLabel.text = "" + meal.getNutrition(3);
        gramsLabel.text = meal.gram + " g";

        icon.sprite = Resources.Load<Sprite>(meal.iconName);
        //icon.sprite = meal.icon;
    }


    // Die funktion die beim Klick auf den Button Aufgeführt wird
    // Schaut welche Liste gerade aktiv ist und öffnet dann das MealPopup und führt die funktionen aus!
    public void Handleclick()
    {
        if (dailyMealPanel.activeSelf)
        {
            if (!addMealPopup.gameObject.activeSelf)
            {
                addMealPopup.gameObject.SetActive(true);
            }
            mealPopup.SetActive(true);
            ListHandler.currentMeal = meal;
            mealPopup.GetComponentInChildren<AddMealPopup>().GetMeal();
            mealPopup.GetComponentInChildren<AddMealPopup>().FillText();
            mealPopup.GetComponentInChildren<AddMealPopup>().gameObject.SetActive(false);
            mealPopup.GetComponentInChildren<RemoveMealScript>().SetMeal(meal);
            mealPopup.GetComponentInChildren<EditMealScript>().SetMeal(meal);

        }

        
    }
}
