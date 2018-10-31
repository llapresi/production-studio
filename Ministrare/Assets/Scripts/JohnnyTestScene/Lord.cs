using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lord {

    //Stats
    private int militaryLeadership;
    private int communication;
    private int subterfuge;
    private int presence;
    private int intelligence;
    private int luck;

	// Use this for initialization
	public Lord() {
        militaryLeadership = Random.Range(1, 10);
        communication = Random.Range(1, 10);
        subterfuge = Random.Range(1, 10);
        presence = Random.Range(1, 10);
        intelligence = Random.Range(1, 10);
        Luck = Random.Range(1, 10);
	}

    // setters and getters

    public int MilitaryLeadership
    {
        get
        {
            return militaryLeadership;
        }
        set
        {
            militaryLeadership = value;
        }
    }
    public int Communication
    {
        get
        {
            return communication;
        }
        set
        {
            communication = value;
        }
    }
    public int Subterfuge
    {
        get
        {
            return subterfuge;
        }
        set
        {
            subterfuge = value;
        }
    }
    public int Presence
    {
        get
        {
            return presence;
        }
        set
        {
            presence = value;
        }
    }
    public int Intelligence
    {
        get
        {
            return intelligence;
        }
        set
        {
            intelligence = value;
        }
    }
    public int Luck
    {
        get
        {
            return luck;
        }
        set
        {
            luck = value;
        }
    }
}
