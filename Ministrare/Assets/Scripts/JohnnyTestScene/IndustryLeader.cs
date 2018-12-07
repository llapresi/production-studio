using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
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
    private double workEfficiency;
    //Conversation only stats
    private int attention;
    private int relationshipValue;

    //Personality Traits
    private int openness;
    private int conscientiousness;
    private int extraversion;
    private int agreeableness;
    private int neuroticism;

    //Working with enemy bool
    private bool workingWithEnemy;

    //Rebellion value
    private bool rebelling;

    //name value
    public string leaderName;

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
        workingWithEnemy = false;
        //openness = 4;
        //conscientiousness = 4;
        //extraversion = 1;
        //agreeableness = 3;
        //neuroticism = 2;
        traitsValue = new int[] { openness, conscientiousness, extraversion, agreeableness, neuroticism };
        personalityValues = new PersonalityValues();
        generateStartingMoods();
        generateWorkEfficiency();
        Rebelling = false;
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
                if(x == 0 && y == 4)
                {
                    personalityValueInput = personalityValueInput * -1;
                }
                sum = sum + personalityValueInput;
            }
            if (x == 0)
            {
                happiness = sum * 5 + 50;
            } else if (x == 1)
            {
                angriness = sum * 5 + 50;
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

    public void generateWorkEfficiency()
    {
        int numSum = angriness + greediness + fearfulness + sadness + (100 - inspiration) + boredom;
        double avg = (double)numSum / 6;
        if (workingWithEnemy == true)
        {
            workEfficiency = happiness - avg - 5;
        }
        else
        {
            workEfficiency = happiness - avg;
        }
    }

    public void dailyMoodChange()
    {
        int thirdRandom = UnityEngine.Random.Range(1, 10);
        for (int x = 0; x < Moods.Length; x++)
        {
            // Looks to see if they are affected by daily change in the first place
            int firstRandom = UnityEngine.Random.Range(1, 100);
            int NCompare = neuroticism * 20;
            if (firstRandom > NCompare)
            {
                // if the random is bigger then the nueroticism times 5, no change in Mood
            }
            else if (firstRandom <= NCompare)
            {
                // See if the change will be negative or positive
                int secondRandom = UnityEngine.Random.Range(1, 100);
                int change;
                if (secondRandom <= 50)
                {
                    change = 1;
                }
                else
                {
                    change = -1;
                }
                string moodLetter = Moods[x];
                int sum = 0;
                // see if we are adding all the personality values to the mood or just the neuroticism value
                if (thirdRandom - 1 == x)
                {
                    // run through all the personality values to find the sum of change
                    for (int y =0; y < Traits.Length; y++)
                    {
                        string traitLetter = Traits[y];
                        int traitValue = traitsValue[y];
                        string personalityVar = moodLetter + traitLetter + traitValue.ToString();
                        Type type = personalityValues.GetType();
                        FieldInfo fieldInfo = type.GetField(personalityVar);
                        object value = fieldInfo.GetValue(personalityValues);
                        int personalityValueInput = (int)value;
                        if (x == 0 && y == 4)
                        {
                            personalityValueInput = personalityValueInput * -1;
                        }
                        sum = sum + personalityValueInput;
                    }
                    sum = sum * change;
                } else
                {
                    // just get the neuroticism value
                    int traitValue = traitsValue[4];
                    string personalityVar = moodLetter + "N" + traitValue.ToString();
                    Type type = personalityValues.GetType();
                    FieldInfo fieldInfo = type.GetField(personalityVar);
                    object value = fieldInfo.GetValue(personalityValues);
                    int personalityValueInput = (int)value;
                    if (x == 0)
                    {
                        personalityValueInput = personalityValueInput * -1;
                    }
                    sum = personalityValueInput * change;
                }
                if (x == 0)
                {
                    happiness = happiness + sum;
                    // make sure the value does not go above 100 or below 0
                    if (happiness > 100)
                    {
                        happiness = 100;
                    } else if (happiness < 0)
                    {
                        happiness = 0;
                    }
                }
                else if (x == 1)
                {
                    angriness = angriness + sum;
                    // make sure the value does not go above 100 or below 0
                    if (angriness > 100)
                    {
                        angriness = 100;
                    } else if(angriness < 0)
                    {
                        angriness = 0;
                    }
                }
                else if (x == 2)
                {
                    greediness = greediness + sum;
                    // make sure the value does not go above 100 or below 0
                    if (greediness > 100)
                    {
                        greediness = 100;
                    } else if (greediness < 0)
                    {
                        greediness = 0;
                    }
                }
                else if (x == 3)
                {
                    fearfulness = fearfulness + sum;
                    // make sure the value does not go above 100 or below 0
                    if (fearfulness > 100)
                    {
                        fearfulness = 100;
                    } else if (fearfulness < 0)
                    {
                        fearfulness = 0;
                    }
                }
                else if (x == 4)
                {
                    sadness = sadness + sum;
                    // make sure the value does not go above 100 or below 0
                    if (sadness > 100)
                    {
                        sadness = 100;
                    } else if(sadness < 0)
                    {
                        sadness = 0;
                    }
                }
                else if (x == 5)
                {
                    boredom = boredom + sum;
                    // make sure the value does not go above 100 or below 0
                    if (boredom > 100)
                    {
                        boredom = 100;
                    } else if (boredom < 0)
                    {
                        boredom = 0;
                    }
                }
                else if (x == 6)
                {
                    inspiration = inspiration + sum;
                    // make sure the value does not go above 100 or below 0
                    if (inspiration > 100)
                    {
                        inspiration = 100;
                    } else if (inspiration < 0)
                    {
                        inspiration = 0;
                    }
                }

            }
        }
    }

    // see if the person is in open rebellion or not
    public void inRebellion()
    {
        if (happiness <= 25 && fearfulness <= 25)
        {
            if (UnityEngine.Random.Range(0,100) <= 10)
            {
                if (rebelling == false && leaderName != null)
                {
                    rebelling = true;
                    Military military = (Military)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/Military.asset", typeof(Military));
                    military.CreateRebelUnit(leaderName);
                }
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

    public double WorkEfficiency
    {
        get
        {
            return workEfficiency;
        }
        set
        {
            workEfficiency = value;
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
    #region Working with Enemy Bool and rebelling bool
    public bool WorkingWithEnemy
    {
        get
        {
            return workingWithEnemy;
        }
        set
        {
            workingWithEnemy = value;
        }
    }

    public bool Rebelling
    {
        get
        {
            return rebelling;
        }
        set
        {
            rebelling = value;
        }
    }
#endregion
}
