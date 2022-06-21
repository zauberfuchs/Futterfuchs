//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class Meal
//{
//    public int category;
//    private string[] categorys = { "Frühstück", "Mittag", "Abend", "Postworkout" };
//    public string name;
//    private float[] nutritions = new float[4263];

//    public Meal()
//    {

//    }

//    public Meal(int category, string name, float kCal, float carbohydrates, float protein, float fat)
//    {
//        this.Name = name;
//        this.category = category;
//        this.nutritions[0] = kCal;
//        this.nutritions[1] = carbohydrates;
//        this.nutritions[2] = protein;
//        this.nutritions[3] = fat;
//    }

//    public int Category
//    {
//        get { return category; }
//        set { category = value; }
//    }
   
//    public string Name
//    {
//        get { return name; }
//        set { name = value; }
//    }

//    public string getCategory()
//    {
//        return categorys[this.category];
//    }

//    public float getNutrition(int nutrition)
//    {
//        return this.nutritions[nutrition];
//    }

//    public void changeNutritions(int nutrition, float value)
//    {
//        this.nutritions[nutrition] = value;
//    }
//}
