using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Targets
{
     GameObject GetImage();

}


/// <summary>
/// The military units, along with their info
/// </summary>
public struct Unit : Targets
{
    //damage done with attacks
    public int attack;
    //damage prevented per battle
    public int shield;
    //amount of damage they can take before death
    public int health;
    public int healthMax;

    //location of unit
    public float xLoc;
    public float yLoc;

    //speed value for moving across map
    private int speed;

    public int IFF;

    public GameObject image;

    public bool inRange;


    //where they are trying to go/attack
    public GameObject objective;

    public GameObject GetImage()
    {
        return image;
    }

    //constructor
    public Unit(int a, int s, int h, float x, float y, GameObject obj, int iff, GameObject im, GameObject parent)
    {
        attack = a;
        shield = s;
        health = h;
        healthMax = h;
        xLoc = x;
        yLoc = y;
        objective = obj;
        speed = 10;
        IFF = iff;
        image = im;
        im.transform.position = new Vector3(xLoc, yLoc, 0);
        im.transform.parent = parent.transform;
        inRange = false;
    }

    /// <summary>
    /// done when days roll over to move units
    /// </summary>
    public void Move()
    {

        float targetX = objective.transform.position.x;
        float targetY = objective.transform.position.y;

        float distanceX = Mathf.Abs(xLoc - targetX);
        float distanceY = Mathf.Abs(yLoc - targetY);

        if(distanceX < speed)
        {
            xLoc = targetX;
            inRange = true;
        }
        else
        {
            if(targetX < xLoc)
            {
                xLoc -= speed;
            }
            else
            {
                xLoc += speed;
            }
        }
        if (distanceY < speed)
        {
            yLoc = targetY;
        }
        else
        {
            if (targetY < yLoc)
            {
                yLoc -= speed;
            }
            else
            {
                yLoc += speed;
            }
        }
        image.transform.position = new Vector3(xLoc, yLoc, 0);

    }


    /// <summary>
    /// Heals units if theyve taken damage in combat
    /// </summary>
    public void Rest()
    {
        if(health < healthMax)
        {
            health += 1;
        }
    }
}


/// <summary>
/// Struct for location objects
/// </summary>
public struct Location: Targets
{
    public GameObject image;

    public GameObject GetImage()
    {
        return image;
    }

    public int value;

}

public class Military : MonoBehaviour
{

    //default values for attack sheild and health
    private int attack = 5;
    private int shield = 5;
    private int health = 10;
    private float xLoc = 500;
    private float yLoc = 500;

    public GameObject unitImOne;

    public GameObject unitImTwo;

    public GameObject parent;

    private List<Unit> unitList = new List<Unit>();

    private List<Location> placeList = new List<Location>();

    private List<Targets> locList = new List<Targets>();

    Unit toChange;

    /// <summary>
    /// creates a unit and adds them to the list
    /// </summary>
    public void createUnit(int iff,float x, float y,GameObject image)
    {
        GameObject unitIm = Instantiate(image);
        unitIm.name = "Unit";
        Unit newUnit = new Unit(attack,shield,health,x,y, gameObject, iff, unitIm, parent);
        unitList.Add(newUnit);
    }


    /// <summary>
    /// Creates a player unit
    /// </summary>
    public void CreateFriendlyUnit()
    {
        createUnit(0, xLoc, yLoc, unitImOne);
    }


    /// <summary>
    /// Creates an enemy unit
    /// </summary>
    public void EnemyUnit()
    {
        createUnit(1, 1700, 700, unitImTwo);
    }


    /// <summary>
    /// Calls move on all units, they move towards their objective
    /// </summary>
    public void MoveUnits()
    {
        foreach (Unit toMove in unitList)
        {
            toMove.Move();
        }
    }


    /// <summary>
    /// Unit interacts with target if close enough
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="target"></param>
    public void Act(Unit unit, Targets target)
    {
        if(target.GetType() == typeof(Unit))
        {
            startBattle(unit, (Unit)target);
        }
        else if(target.GetType() == typeof(Location))
        {

        }
    }

    /// <summary>
    /// distributes units to each objective
    /// </summary>
    public void assignObj()
    {
        int x = 0;
        for(int i = 0; i < locList.Count; i++)
        {
            if (unitList[i].IFF == 0)
            {
                toChange = unitList[i];
                toChange.objective = locList[x].GetImage();
                toChange.inRange = false;
                unitList[i] = toChange;
                if (x < locList.Count)
                {
                    x++;

                }
                else
                {
                    x = 0;
                }
            }
        }
    }


    /// <summary>
    /// if units fight, checks for nearby units to jpoin the battle, then launches battle
    /// </summary>
    /// <param name="agressor"></param>
    /// <param name="defender"></param>
   public void startBattle(Unit agressor, Unit defender)
    {
        List<Unit> liOne = new List<Unit>();
        List<Unit> liTwo = new List<Unit>();
        float distCheck = 100;

        foreach (Unit toCheck in unitList)
        {
            float distance = Vector3.Distance((new Vector3(agressor.xLoc, agressor.yLoc, 0)), (new Vector3(toCheck.xLoc, toCheck.yLoc, 0)));
            if(distance < distCheck)
            {
                if(agressor.IFF == toCheck.IFF)
                {
                    liOne.Add(toCheck);
                }
                else if(defender.IFF == toCheck.IFF)
                {
                    liTwo.Add(toCheck);
                }
            }
        }

        battle(liOne, liTwo);
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
