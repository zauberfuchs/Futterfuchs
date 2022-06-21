using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton2 : MonoBehaviour {

    // Use this for initialization
    //public Button AddMealButton;
    //public GameObject AddMealPanel;
    //public GameObject DailyMealPanel;
    public Button buttonComponent;
    public Text nameLabel;
    public Text categoryLabel;
    public Text nutritionLabel;
    private GameObject AddMealPanel;
    private GameObject DailyMealPanel;
    private GameObject AddMealButton;

    private Meal meal;
    private AddMealScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        AddMealPanel = GameObject.Find("AppCanvas").transform.Find("AddMealPanel").gameObject;
        DailyMealPanel = GameObject.Find("AppCanvas").transform.Find("DailyMealPanel").gameObject;
        AddMealButton = GameObject.Find("AppCanvas").transform.Find("AddMealButton").gameObject;
        buttonComponent.onClick.AddListener(Handleclick);
    }

    public void Setup(Meal currentItem)
    {
        meal = currentItem;
        nameLabel.text = meal.Name;
        categoryLabel.text = meal.getCategory();
        nutritionLabel.text = "Kcal = " + meal.getNutrition(0) + "    Carb = " + meal.getNutrition(1) + "   Protein = " + meal.getNutrition(2) + "   Fat = " + meal.getNutrition(3);
    }

    public void Handleclick()
    {

        if (AddMealPanel.activeSelf)
        {
            DailyMealPanel.SetActive(true);
            AddMealPanel.SetActive(false);
            AddMealButton.gameObject.SetActive(true);
        }
        else
        {
            //scrolllist.trytransferitemtoday(meal);
            //DailyMealPanel.SetActive(false);
            //addmealpanel.setactive(true);
        }
    }
    //private bool canFade = true;
    //private Color alphaColor;
    //private float timeToFade = 1.0f;


    //void Update()
    //{
    //    if (canFade)
    //    {
    //        buttonComponent.GetComponent<Button>().colors = Color.Lerp(buttonComponent.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
    //    }
    //}
}
