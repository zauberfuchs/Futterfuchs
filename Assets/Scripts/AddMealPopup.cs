using UnityEngine;
using UnityEngine.UI;

public class AddMealPopup : MonoBehaviour
{
    
    public  ExampleMealScrollList scrollList;

    public  Text kCal;
    public  Text protein;
    public  Text fat;
    public  Text carbs;
    public  Text mealName;

    public  Dropdown dD;
    public  InputField gram;
    public  Button showExampleMealsBtn;

    public  Meal sampleMeal;
    public  Meal meal;
    
    public  GameObject exampleMealPanel;
    public  GameObject dailyMealPanel;
    public  GameObject calendarBtn;

    private void Start()
    {
       // calendarBtn = GameObject.Find("AppCanvas").transform.Find("CalendarBtn").gameObject;
       // exampleMealPanel = GameObject.Find("AppCanvas").transform.Find("ExampleMealPanel").gameObject;
       // dailyMealPanel = GameObject.Find("AppCanvas").transform.Find("DailyMealPanel").gameObject;
    }

    // zählt die Nährwärte und berücksicht dabei immer die 100g basis
    public void CountNutritions()
    {
        float nutrition;
        for(int i = 0; i < meal.nutritions.Length; i++)
        {
            nutrition = sampleMeal.getNutrition(i); 
            nutrition = Mathf.Round(nutrition * (float.Parse(gram.text) / sampleMeal.gram));
            meal.nutritions[i] = nutrition;
        }
    }
    // Befüllt das PopupFenster mit daten
    public void FillText()
    {
        CheckTextIfNull();
        CountNutritions();
        kCal.text = "kCal: " + meal.getNutrition(0).ToString();
        carbs.text = "carbs: " + meal.getNutrition(1).ToString();
        protein.text = "protein: " + meal.getNutrition(2).ToString();
        fat.text = "fat: " + meal.getNutrition(3).ToString();
        mealName.text = "Name: " + meal.name;
    }

    // schaut ob der text im "gram" eingabefeld 0 ist
    public void CheckTextIfNull()
    {
        if(gram.text.Equals(""))
        {
            gram.text = "0";
        }
    }

    // Legt ein SampleMeal fest damit man in der CountNutritions Funktion ein Ausgangspunkt hat um die Nährwerte immer richtig zu berechnen!
    // dann legt es ein neues Mahlzeitenobjekt an mit dem später gearbeitet wird und das wenn alles gut geht in die Zugehörige Liste eingefügt wird!
    public void SetMeal(Meal meal)
    {
        sampleMeal = meal;
        
        this.meal = new Meal(meal.category, meal.Name, meal.getNutrition(0), meal.getNutrition(1), meal.getNutrition(2), meal.getNutrition(0),meal.Gram, meal.iconName);
        //this.meal = new Meal(ListHandler.currentMeal.category, ListHandler.currentMeal.Name, ListHandler.currentMeal.getNutrition(0), ListHandler.currentMeal.getNutrition(1), ListHandler.currentMeal.getNutrition(2), ListHandler.currentMeal.getNutrition(0), ListHandler.currentMeal.Gram);
        gram.text = this.meal.gram + "g";
    }

    // Nach dem Bearbeiten // Verschieben des Objekt werden die letzten Daten genommen
    public void UpdateMeal()
    {
        meal.category = dD.GetComponent<DropdownHandler>().GetSelectedCategory();
        meal.gram = System.Convert.ToInt32(gram.text);
    }

    // AddMeal funktion auskoppeln ?? in ein neues Skript wie removemeal / edit meal ??
    public void AddMeal()
    {
        dailyMealPanel.SetActive(true);
        UpdateMeal();
        scrollList.TryTransferItemToDay(meal);
        exampleMealPanel.SetActive(false);
        showExampleMealsBtn.gameObject.SetActive(true);
        calendarBtn.SetActive(true);
    }
    // Liefert die Mahlzeit Zurück die gerade im Meal Popup bearbeitet wird!
    public Meal GetMeal()
    {
        return meal;
    }
}
