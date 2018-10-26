using System.Collections;
using System.Collections.Generic;
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

    //Conversation only stats
    private int attention;
    private int relationshipValue;

    //Personality Traits
    private int openness;
    private int conscientiousness;
    private int extraversion;
    private int agreeableness;
    private int neuroticism;

	// Use this for initialization
	public IndustryLeader () {
        // Mood value initialization
        happiness = Random.Range(0, 100);
        angriness = Random.Range(0, 100);
        greediness = Random.Range(0, 100);
        fearfulness = Random.Range(0, 100);
        sadness = Random.Range(0, 100);
        boredom = Random.Range(0, 100);
        inspiration = Random.Range(0, 100);
        // Conversation only stats
        attention = 100;
        relationshipValue = Random.Range(50, 100);
        // Personality Traits
        openness = Random.Range(1, 5);
        conscientiousness = Random.Range(1, 5);
        extraversion = Random.Range(1, 5);
        agreeableness = Random.Range(1, 5);
        neuroticism = Random.Range(1, 5);
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
