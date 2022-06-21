using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UserPreferences
{
    private int dailyCalories;
    private int[] dailyMacros = new int[3];
    private int[] palValues = new int[6];
    private int age;
    private int weight;
    private int height;
    private int goalValue;

    public UserPreferences(int dailyCalories, int dailyCarbohydrates, int dailyProteins, int dailyFats,
        int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, int sixthValue,
        int age, int weight, int height, int goalValue)
    {
        this.dailyCalories = dailyCalories;
        this.dailyMacros[0] = dailyCarbohydrates;
        this.dailyMacros[1] = dailyProteins;
        this.dailyMacros[2] = dailyFats;
        this.palValues[0] = firstValue;
        this.palValues[1] = secondValue;
        this.palValues[2] = thirdValue;
        this.palValues[3] = fourthValue;
        this.palValues[4] = fifthValue;
        this.palValues[5] = sixthValue;
        this.age = age;
        this.weight = weight;
        this.height = height;
        this.goalValue = goalValue;
    }
    public UserPreferences()
    {

    }

    public int DailyCalories
    {
        get
        {
            return dailyCalories;
        }

        set
        {
            dailyCalories = value;
        }
    }

    public int[] DailyMacros
    {
        get
        {
            return dailyMacros;
        }

        set
        {
            dailyMacros = value;
        }
    }

    public int[] PalValues
    {
        get
        {
            return palValues;
        }

        set
        {
            palValues = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            age = value;
        }
    }

    public int Weight
    {
        get
        {
            return weight;
        }

        set
        {
            weight = value;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

    public int GoalValue
    {
        get
        {
            return goalValue;
        }

        set
        {
            goalValue = value;
        }
    }
}
