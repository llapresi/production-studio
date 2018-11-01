using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class IndustryLeader {

    //Moods
    private int happiness;
    private int angriness;
    private int greediness;
    private int fearfulness;
    private int sadness;
    private int boredom;
    private int inspiration;
    private double workEffectiveness;
    //Conversation only stats
    private int attention;
    private int relationshipValue;

    //Personality Traits
    private int openness;
    private int conscientiousness;
    private int extraversion;
    private int agreeableness;
    private int neuroticism;

    //Arrays
    private string[] Moods = new string[] {"H","A","G","F","S","B","I"};
    private string[] Traits = new string[] { "O","C", "E", "A", "N"};
    private int[] traitsValue;

    //PersonalityData
    PersonalityValues personalityValues;

	// Use this for initialization
	public IndustryLeader () {
        // Conversation only stats
        attention = 100;
        relationshipValue = UnityEngine.Random.Range(50, 100);
        // Personality Traits
        openness = UnityEngine.Random.Range(1, 5);
        conscientiousness = UnityEngine.Random.Range(1, 5);
        extraversion = UnityEngine.Random.Range(1, 5);
        agreeableness = UnityEngine.Random.Range(1, 5);
        neuroticism = UnityEngine.Random.Range(1, 5);
        traitsValue = new int[] { openness, conscientiousness, extraversion, agreeableness, neuroticism };
        personalityValues = new PersonalityValues();
        generateStartingMoods();
    }

    public void generateStartingMoods()
    {
        for (int x = 0; x < Moods.Length; x++)
        {
            int sum = 0;
            string moodLetter = Moods[x];
            for (int y = 0; y < Traits.Length; y++)
            {
                string traitsLetter = Traits[y];
                string personalityVar = moodLetter + traitsLetter + traitsValue[y].ToString();
                Type type = personalityValues.GetType();
                FieldInfo fieldInfo = type.GetField(personalityVar);
                object value = fieldInfo.GetValue(personalityValues);
                int personalityValueInput = (int)value;
                sum = sum + personalityValueInput;
            }
            if (x == 0)
            {
                happiness = sum * 5 + 50;
            } else if (x == 1)
            {
                agreeableness = sum * 5 + 50;
            } else if (x == 2) {
                greediness = sum * 5 + 50;
            } else if (x == 3) {
                fearfulness = sum * 5 + 50;
            } else if (x == 4) {
                sadness = sum * 5 + 50;
            } else if (x == 5) {
                boredom = sum * 5 + 50;
            } else if(x == 6) {
                inspiration = sum * 5 + 50;
            }
        }
    }

    //setters and getters
    #region Mood Setters and getters
    public int Happiness
    {
        get
        {
            return happiness;
        }
        set
        {
            happiness = value;
        }
    }

    public int Angriness
    {
        get
        {
            return angriness;
        }
        set
        {
            angriness = value;
        }
    }

    public int Greediness
    {
        get
        {
            return greediness;
        }
        set
        {
            greediness = value;
        }
    }
    public int Fearfulness
    {
        get
        {
            return fearfulness;
        }
        set
        {
            fearfulness = value;
        }
    }
    public int Sadness
    {
        get
        {
            return sadness;
        }
        set
        {
            sadness = value;
        }
    }
    public int Boredom
    {
        get
        {
            return boredom;
        }
        set
        {
            boredom = value;
        }
    }
    public int Inspiration
    {
        get
        {
            return inspiration;
        }
        set
        {
            inspiration = value;
        }
    }

    public double WorkEffectiveness
    {
        get
        {
            return workEffectiveness;
        }
        set
        {
            workEffectiveness = value;
        }

    }
    #endregion
    #region Conversation only Setters and Getters
    public int Attention
    {
        get
        {
            return attention;
        }
        set
        {
            attention = value;
        }
    }
    public int RelationshipValue
    {
        get
        {
            return relationshipValue;
        }
        set
        {
            relationshipValue = value;
        }
    }
    #endregion
    #region Personality Setters and Getters 
    public int Openess
    {
        get
        {
            return openness;
        }
        set
        {
            openness = value;
        }
    }
    public int Conscientiousness
    {
        get
        {
            return conscientiousness;
        }
        set
        {
            conscientiousness = value;
        }
    }
    public int Extraversion
    {
        get
        {
            return extraversion;
        }
        set
        {
            extraversion = value;
        }
    }
    public int Agreeableness
    {
        get
        {
            return agreeableness;
        }
        set
        {
            agreeableness = value;
        }
    }
    public int Neuroticism
    {
        get
        {
            return neuroticism;
        }
        set
        {
            neuroticism = value;
        }
    }
    #endregion
}
