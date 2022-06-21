using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Meal
{

    // Mahlzeiten Object um meine Mahlzeiten in einem Objekt abzubilden.
    public int category;
    public static List<string> categorys = new List<string>() { "Frühstück", "Mittag", "Abend", "Postworkout" };
    public string name;
    public float[] nutritions = new float[4];
    public int gram;
    public string iconName;
    //public Sprite icon;
    // eventuel nur ein name ? und den dann laden lassen!
    public Meal()
    {

    }

    public Meal(int category, string name, float kCal, float carbohydrates, float protein, float fat, int gram, String iconName)
    {
        this.Name = name;
        this.category = category;
        this.nutritions[0] = kCal;
        this.nutritions[1] = carbohydrates;
        this.nutritions[2] = protein;
        this.nutritions[3] = fat;
        this.gram = gram;
        this.iconName = iconName;
        //this.icon = icon;
    }

    public int Category
    {
        get { return category; }
        set { category = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Gram
    {
        get { return gram; }
        set { gram = value; }
    }

    public string getCategory()
    {
        return categorys[this.category];
    }

    public float getNutrition(int nutrition)
    {
        return this.nutritions[nutrition];
    }

    public void changeNutritions(int nutrition, float value)
    {
        this.nutritions[nutrition] = value;
    }
}
