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
    public Unit(int a, int s, int h, int x, int y)
    {
        attack = a;
        shield = s;
        health = h;
        xLoc = x;
        yLoc = y;
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

    private List<GameObjject> locList = new List<GameObject>();

    /// <summary>
    /// creates a unit and adds them to the list
    /// </summary>
    public void createUnit()
    {
        Unit newUnit = new Unit(attack,shield,health,xLoc,yLoc);
        unitList.Add(newUnit);
    }

    /// <summary>
    /// distributes units to each objective
    /// </summary>
    public void assignObj()
    {
        int x = 0;
        foreach (Unit toAssign in unitList)
        {
            toAssign.objective = locList(x);
            if(x < locList.length)
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
        Random rand = new Random();
        int randTwo = unitSetOne.length;
        int randOne = unitSetTwo.length;

        //starts index for loop
        int indOne = 0;
        int indTwo = 0;
        int indChoose = 0;


        //loops until one side is dead
        while(randOne > 0 && randTwo > 0)
        {
            indChoose = rand.Next(randOne);
            if(unitSetTwo[indChoose].shield > 0)
            {
                if(unitSetTwo[indChoose].shield >= unitSetOne[indOne].attack)
                {
                    unitSetTwo[indChoose].shield -= unitSetOne[indOne].attack;
                }
                else
                {
                    int over = unitSetOne[indOne].attack - unitSetTwo[indChoose].shield;
                    unitSetTwo[indChoose].shield = 0;
                    unitSetTwo[indChoose].health -= over;
                }
            }
            else
            {
                unitSetTwo[indChoose].health -= unitSetOne[indOne].attack;
                if(unitSetTwo[indChoose].health <= 0)
                {
                    unitSetTwo.RemoveAt(indChoose);
                    randOne--;
                }
            }

            indChoose = rand.Next(randTwo);
            if (unitSetOne[indChoose].shield > 0)
            {
                if (unitSetOne[indChoose].shield >= unitSetTwo[indTwo].attack)
                {
                    unitSetOne[indChoose].shield -= unitSetTwo[indTwo].attack;
                }
                else
                {
                    int over = unitSetTwo[indTwo].attack - unitSetOne[indChoose].shield;
                    unitSetOne[indChoose].shield = 0;
                    unitSetOne[indChoose].health -= over;
                }
            }
            else
            {
                unitSetOne[indChoose].health -= unitSetTwo[indTwo].attack;
                if (unitSetOne[indChoose].health <= 0)
                {
                    unitSetOne.RemoveAt(indChoose);
                    randTwo--;
                }
            }

        }


    } 


}
