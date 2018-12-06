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
public class Unit : Targets
{
    //damage done with attacks
    public int attack;
    //damage prevented per battle
    public int shield;
    //amount of damage they can take before death
    public int health;
    public int healthMax;
    public bool dead;
    //location of unit
    public float xLoc;
    public float yLoc;

    //speed value for moving across map
    private int speed;

    public int IFF;

    public GameObject image;

    public bool inRange;

    public string name;

    //where they are trying to go/attack
    public Targets objective;
    public Targets secObjective;

    public GameObject GetImage()
    {
        return image;
    }

    //constructor
    public Unit(int a, int s, int h, float x, float y, Targets obj, int iff, GameObject im, GameObject parent)
    {
        attack = a;
        shield = s;
        health = h;
        healthMax = h;
        xLoc = parent.transform.position.x + x;
        yLoc = parent.transform.position.y + y;
        objective = obj;
        secObjective = null;
        speed = 10;
        IFF = iff;
        image = im;
        im.transform.position = new Vector3(xLoc, yLoc, 0);
        im.transform.parent = parent.transform;
        inRange = false;
        dead = false;
    }

    /// <summary>
    /// done when days roll over to move units
    /// </summary>
    public void Move()
    {
        if (objective != null)
        {
            xLoc = image.transform.position.x;
            yLoc = image.transform.position.y;

            float targetX = objective.GetImage().transform.position.x;
            float targetY = objective.GetImage().transform.position.y;

            float distanceX = Mathf.Abs(xLoc - targetX);
            float distanceY = Mathf.Abs(yLoc - targetY);

            if (distanceX < speed)
            {
                xLoc = targetX;
                inRange = true;
            }
            else
            {
                if (targetX < xLoc)
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
public class Location: Targets
{
    public GameObject image;

    // list to hold the units that are occupying this location
    public List<Unit> allyUnitsonLoc;
    public List<Unit> enemyUnitsonLoc;
    // position on the map
    public float xLoc;
    public float yLoc;
    public string name;

    public GameObject GetImage()
    {
        return image;
    }

    public int value;

    public Location(float xin, float yin, string namein, GameObject obj, GameObject parent)
    {
        xLoc = parent.transform.position.x + xin;
        yLoc = parent.transform.position.y + yin;
        allyUnitsonLoc = new List<Unit>();
        enemyUnitsonLoc = new List<Unit>();
        name = namein;
        image = obj;
        image.transform.position = new Vector3(xLoc, yLoc, 0);
        image.transform.parent = parent.transform;
    }

}
[CreateAssetMenu(fileName = "Military", menuName = "Ministrare/SingletonVars/Military", order = 9)]
public class Military : ScriptableObject
{

    //default values for attack sheild and health
    private int attack = 5;
    private int shield = 5;
    private int health = 10;
    private float xLoc = -794.7f;
    private float yLoc = -28;

    public GameObject unitImOne;

    public GameObject unitImTwo;

    public GameObject parent;

    public GameObject resourceLocation1;

    public ResourceManager resourceManager;

    private int enemyNumAmount;
    private int allyNumAmount;

    //private List<Unit> unitList = new List<Unit>();

    //list of all possible objectives
    //private List<Targets> masterList = new List<Targets>();

    //list of locations to defend
    //private List<Location> playerLocs = new List<Location>();

    // list of all units
    public List<Unit> allUnitsList = new List<Unit>();
    // list of possible resource locations 
    public List<Location> resourceLocs = new List<Location>();
    // list of current objectives chosen by the player
    public List<Targets> curObjList = new List<Targets>();
    // list of all objectives for enemy
    public List<Targets> enemyObjList = new List<Targets>();
    // list of avalible objectives that haven't been choosen by the player
    public List<Targets> unchosenObjList = new List<Targets>();

    Unit toChange;

    /// <summary>
    /// creates a unit and adds them to the list
    /// </summary>
    public void createUnit(int iff,float x, float y,GameObject image)
    {
        GameObject unitIm = Instantiate(image);
        if (iff == 0)
        {
            allyNumAmount++;
            unitIm.name = "AllyUnit#" + allyNumAmount;
        }
        else if (iff == 1)
        {
            enemyNumAmount++;
            unitIm.name = "EnemyUnit#" + enemyNumAmount;
        }

        Unit newUnit = new Unit(attack,shield,health,x,y, null, iff, unitIm, parent);
        if (newUnit.IFF == 0)
        {
            newUnit.name = "AllyUnit#" + allyNumAmount;
            allUnitsList.Add(newUnit);
            enemyObjList.Add(newUnit);
        } 
        else if(newUnit.IFF == 1)
        {
            newUnit.name = "EnemyUnit#" + enemyNumAmount;
            allUnitsList.Add(newUnit);
            unchosenObjList.Add(newUnit);
        }
    }

    /// <summary>
    /// Make a new location
    /// </summary>
    public void CreateALocation(float xin, float yin, string namein)
    {
        GameObject img = Instantiate(resourceLocation1);
        Location location = new Location(xin, yin, namein, img, parent);
        resourceLocs.Add(location);
        unchosenObjList.Add(location);
        enemyObjList.Add(location);
    }

    /// <summary>
    /// put selected objectives with names onto the list of used names
    /// </summary>
    public void placeSelectedObjinChosenList(string name)
    {
       Location removeLocation = null;
       Unit removeUnit = null;
       for(int x =0; x < unchosenObjList.Count; x++)
       {
         if (unchosenObjList[x].GetType() == typeof(Location))
            {
                Location location = (Location)unchosenObjList[x];
                if(location.name == name)
                {
                    curObjList.Add(location);
                    removeLocation = location;
                }
            }
         else if (unchosenObjList[x].GetType() == typeof(Unit))
            {
                Unit unit = (Unit)unchosenObjList[x];
                if (unit.name == name)
                {
                    curObjList.Add(unit);
                    removeUnit = unit;
                }
            }
       }
        if (removeUnit != null)
        {
            unchosenObjList.Remove(removeUnit);
        }
        else if (removeLocation != null)
        {
            unchosenObjList.Remove(removeLocation);
        }

    }

    /// <summary>
    /// put selected objectives with names onto the list of used names
    /// </summary>
    public void placeSelectedObjinUnchosenList(string name)
    {
        Location removeLocation = null;
        Unit removeUnit = null;
        for (int x = 0; x < curObjList.Count; x++)
        {
            if (curObjList[x].GetType() == typeof(Location))
            {
                Location location = (Location)curObjList[x];
                if (location.name == name)
                {
                    unchosenObjList.Add(location);
                    removeLocation = location;
                }
            }
            else if (curObjList[x].GetType() == typeof(Unit))
            {
                Unit unit = (Unit)curObjList[x];
                if (unit.name == name)
                {
                    unchosenObjList.Add(unit);
                    removeUnit = unit;
                }
            }
        }
        if (removeUnit != null)
        {
            curObjList.Remove(removeUnit);
        }
        else if (removeLocation != null)
        {
            curObjList.Remove(removeLocation);
        }

    }

    // set the parent game object 
    public void setParentObject()
    {
        parent = GameObject.Find("Map");
    }

    /// <summary>
    /// Creates a player unit
    /// </summary>
    public void CreateFriendlyUnit()
    {
        createUnit(0, -794.7f, -28, unitImOne);
        resourceManager.runtimeFoodStorage = resourceManager.runtimeFoodStorage - 10;
        resourceManager.runtimeGoldStorage = resourceManager.runtimeGoldStorage - 10;
        resourceManager.changeSpyMasterText();
    }


    /// <summary>
    /// Creates an enemy unit
    /// </summary>
    public void CreateEnemyUnit()
    {
        // 1700, 700
        createUnit(1, 754, 181, unitImTwo);

    }


    /// <summary>
    /// Calls move on all units, they move towards their objective
    /// </summary>
    public void MoveUnits()
    {
        foreach (Unit toMove in allUnitsList)
        {
            if (toMove.dead == false)
            {
                toMove.Move();
                if (toMove.inRange)
                {
                    Act(toMove, toMove.objective);
                }
            }
        }
        // get rid of the units and images if the unit is dead
        foreach(Location location in resourceLocs)
        {
            location.allyUnitsonLoc.RemoveAll(x => x.dead == true);
            location.enemyUnitsonLoc.RemoveAll(x => x.dead == true);
        }
        for (int x =0; x < allUnitsList.Count; x++)
        {
            if (allUnitsList[x].dead)
            {
                GameObject GO = GameObject.Find(allUnitsList[x].image.name);
                Destroy(GO);
            }
        }
        allUnitsList.RemoveAll(x => x.dead == true);
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
            // grab the location
            Location location = (Location)target;
            // add unit to respective list in the location
            if (unit.IFF == 0)
            {
                // add to ally list
                if (location.allyUnitsonLoc.Contains(unit) == false)
                {
                    location.allyUnitsonLoc.Add(unit);
                }
            }
            else if (unit.IFF == 1)
            {
                // add to the enemy list
                if (location.enemyUnitsonLoc.Contains(unit) == false)
                {
                    location.enemyUnitsonLoc.Add(unit);
                }
            }
        }
    }

    /// <summary>
    /// distributes units to each objective
    /// </summary>
    public void assignObj()
    {
        // ally objective counter
        int x = 0;
        // enemy objective counter
        int y = 0;
        for(int i = 0; i < allUnitsList.Count; i++)
        {
            // grab the unit
            Unit unit = allUnitsList[i];
            if (unit.objective == null)
            {
                // if the unit is friendly tell them to do friendly objectives 
                if (unit.IFF == 0 && curObjList.Count != 0)
                {
                    unit.objective = curObjList[x];
                    unit.inRange = false;
                    if (x < curObjList.Count - 1)
                    {
                        x++;

                    }
                    else
                    {
                        x = 0;
                    }
                }
                else if (unit.IFF == 1 && enemyObjList.Count != 0)
                {
                    unit.objective = enemyObjList[y];
                    unit.inRange = false;
                    if (y < enemyObjList.Count - 1)
                    {
                        y++;
                    }
                    else
                    {
                        y = 0;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Go to each location and assign enemies for units to fight in the location
    /// </summary>
    public void assignFightsinLocations()
    {
        foreach(Location location in resourceLocs)
        {
            //grab the ally and enemy list and assign jobs
            List<Unit> allyUnitTemp= location.allyUnitsonLoc;
            List<Unit> enemyUnitTemp = location.enemyUnitsonLoc;
            //ally
            int a = 0;
            if (enemyUnitTemp.Count > 0)
            {
                for (int x = 0; x < allyUnitTemp.Count; x++)
                {
                    Unit unit = allyUnitTemp[x];
                    unit.secObjective = unit.objective;
                    unit.objective = enemyUnitTemp[a];
                    unit.inRange = false;
                    if (a < enemyUnitTemp.Count - 1)
                    {
                        a++;
                    }
                    else
                    {
                        a = 0;
                    }
                }
            }


            int b = 0;
            if (allyUnitTemp.Count > 0)
            {
                for (int y = 0; y < enemyUnitTemp.Count; y++)
                {
                    Unit unit = enemyUnitTemp[y];
                    unit.secObjective = unit.objective;
                    unit.objective = allyUnitTemp[b];
                    unit.inRange = false;
                    if (b < allyUnitTemp.Count - 1)
                    {
                        b++;
                    }
                    else
                    {
                        b = 0;
                    }
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

        foreach (Unit toCheck in allUnitsList)
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
            // first list turn to attack
            if (randOne > 0)
            {
                indChoose = (int)Random.Range(0, randOne);
                attack = unitSetOne[indOne].attack + (int)Random.Range(-3, 3);
                target = unitSetTwo[indChoose];
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
                if (unitSetTwo[indChoose].health <= 0)
                {
                    unitSetTwo[indChoose].dead = true;
                    if (unitSetOne[indOne].secObjective != null)
                    {
                        unitSetOne[indOne].objective = unitSetOne[indOne].secObjective;
                    }
                    else
                    {
                        unitSetOne[indOne].objective = null;
                    }
                    unitSetTwo.RemoveAt(indChoose);
                    randTwo--;
                }
            }

            // second list turn to attack
            if (randTwo > 0)
            {
                indChoose = (int)Random.Range(0, randTwo);
                attack = unitSetTwo[indTwo].attack + (int)Random.Range(-3, 3);
                target = unitSetOne[indChoose];
                if (unitSetOne[indChoose].shield > 0)
                {
                    if (target.shield >= attack)
                    {
                        target.shield -= attack;
                    }
                    else
                    {
                        int over = attack - unitSetOne[indChoose].shield;
                        target.shield = 0;
                        target.health -= over;
                    }
                }
                else
                {
                    target.health -= attack;

                }
                if (unitSetOne[indChoose].health <= 0)
                {
                    unitSetOne[indChoose].dead = true;
                    if (unitSetTwo[indTwo].secObjective != null)
                    {
                        unitSetTwo[indTwo].objective = unitSetTwo[indTwo].secObjective;
                    }
                    else
                    {
                        unitSetTwo[indTwo].objective = null;
                    }
                    unitSetOne.RemoveAt(indChoose);
                    randOne--;
                }
            }

        }


    } 


}
