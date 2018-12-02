using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The military units, along with their info
/// </summary>
public struct Unit
{
    //damage done with attacks
    public int attack;
    //damage prevented per battle
    public int shield;
    //amount of damage they can take before death
    public int health;

    //location of unit
    public int xLoc;
    public int yLoc;

    //where they are trying to go/attack
    public GameObject objective;

    //constructor
    public Unit(int a, int s, int h, int x, int y, GameObject obj)
    {
        attack = a;
        shield = s;
        health = h;
        xLoc = x;
        yLoc = y;
        objective = obj;
    }
}

public class Military : MonoBehaviour
{

    //default values for attack sheild and health
    private int attack = 5;
    private int shield = 5;
    private int health = 10;
    private int xLoc = 10;
    private int yLoc = 10;


    private List<Unit> unitList = new List<Unit>();

    private List<GameObject> locList = new List<GameObject>();

    Unit toChange;

    /// <summary>
    /// creates a unit and adds them to the list
    /// </summary>
    public void createUnit()
    {
        Unit newUnit = new Unit(attack,shield,health,xLoc,yLoc, gameObject);
        unitList.Add(newUnit);
    }

    

    /// <summary>
    /// distributes units to each objective
    /// </summary>
    public void assignObj()
    {
        int x = 0;
        for(int i = 0; i < locList.Count; i++)
        {
            toChange = unitList[i];
            toChange.objective = locList[x];
            unitList[i] = toChange;
            if(x < locList.Count)
            {
                x++;
                
            }
            else
            {
                x = 0;
            }
        }
    }

    /// <summary>
    /// maes two groups of units fight until one side is destroyed
    /// </summary>
    /// <param name="unitSetOne"></param>
    /// <param name="unitSetTwo"></param>
    public void battle(List<Unit> unitSetOne, List<Unit> unitSetTwo)
    {
        //creates random and gets max number of targets on each side
        float randTwo = unitSetOne.Count;
        float randOne = unitSetTwo.Count;

        //starts index for loop
        int indOne = 0;
        int indTwo = 0;
        int indChoose = 0;

        int attack = 0;
        Unit target;

        //loops until one side is dead
        while(randOne > 0 && randTwo > 0)
        {
            indChoose = (int)Random.Range(0,randOne);
            attack = unitSetOne[indOne].attack + (int)Random.Range(-3, 3);
            target = unitSetTwo[indChoose];
            if(unitSetTwo[indChoose].shield > 0)
            {
                if(target.shield >= attack)
                {
                    target.shield -= attack;
                }
                else
                {
                    int over = attack - unitSetTwo[indChoose].shield;
                    target.shield = 0;
                    target.health -= over;
                }
            }
            else
            {
                target.health -= attack;
              
            }
            unitSetTwo[indChoose] = target;
            if (unitSetTwo[indChoose].health <= 0)
            {
                unitSetTwo.RemoveAt(indChoose);
                randOne--;
            }

            indChoose = (int)Random.Range(0,randTwo);
            attack = unitSetTwo[indTwo].attack + (int)Random.Range(-3, 3);
            target = unitSetOne[indChoose];
            if (unitSetTwo[indChoose].shield > 0)
            {
                if (target.shield >= attack)
                {
                    target.shield -= attack;
                }
                else
                {
                    int over = attack - unitSetTwo[indChoose].shield;
                    target.shield = 0;
                    target.health -= over;
                }
            }
            else
            {
                target.health -= attack;

            }
            unitSetTwo[indChoose] = target;
            if (unitSetTwo[indChoose].health <= 0)
            {
                unitSetOne.RemoveAt(indChoose);
                randOne--;
            }

        }


    } 


}
