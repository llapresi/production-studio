using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    //location of unit on map off screen
    public float xLocOffScreen;
    public float yLocOffScreen;
    public bool offmap;

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
    public Unit(int a, int s, int h, float x, float y, float Mapx, float Mapy, Targets obj, int iff)
    {
        attack = a;
        shield = s;
        health = h;
        healthMax = h;
        xLoc = x;
        yLoc = y;
        objective = obj;
        secObjective = null;
        speed = 50;
        IFF = iff;
        //image = im;
        //im.transform.position = new Vector3(xLoc, yLoc, 0);
        //im.transform.parent = parent.transform;
        inRange = false;
        dead = false;
        offmap = false;
    }

    /// <summary>
    /// done when days roll over to move units
    /// </summary>
    public void Move()
    {
        if (objective != null && dead == false)
        {
            if (image != null)
            {
                xLoc = image.transform.position.x;
                yLoc = image.transform.position.y;

            }
            else
            {
            }

            float targetX = 0; 
            float targetY = 0;

            if (objective.GetImage() != null)
            {
                targetX = objective.GetImage().transform.position.x;
                targetY = objective.GetImage().transform.position.y;
            }
            else
            {
                if (objective.GetType() == typeof(Location))
                {
                    Location location = (Location)objective;
                    targetX = location.xLocOffScreen;
                    targetY = location.yLocOffScreen;
                }
                else if (objective.GetType() == typeof(Unit))
                {
                    Unit unit = (Unit)objective;
                    targetX = unit.xLoc;
                    targetY = unit.yLoc;
                }
            }

            float distanceX = Mathf.Abs(xLoc - targetX);
            float distanceY = Mathf.Abs(yLoc - targetY);

            if (distanceX < speed && distanceY < speed)
            {
                inRange = true;
            }
            if (distanceX < speed)
            {
                xLoc = targetX;
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
            if (image != null)
            {
                image.transform.position = new Vector3(xLoc, yLoc, 0);
            }
        }
        else if (image != null)
        {
            xLoc = image.transform.position.x;
            yLoc = image.transform.position.y;
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
    // position after game objects dissaper
    public float xLocOffScreen;
    public float yLocOffScreen;

    public GameObject GetImage()
    {
        return image;
    }

    public int value;

    public Location(float xin, float yin, float Mapxin, float Mapyin, string namein)
    {
        xLoc = xin;
        yLoc = yin;
        allyUnitsonLoc = new List<Unit>();
        enemyUnitsonLoc = new List<Unit>();
        name = namein;
        //image = obj;
        //image.transform.position = new Vector3(xLoc, yLoc, 0);
        //image.transform.parent = parent.transform;
    }

    public void ControlObjective()
    {
        GameObject GO = GameObject.Find("GameManager");
        GameManager GM = GO.GetComponent<GameManager>();
        ResourceManager resourceManager = GM.resourceManager;
        if (allyUnitsonLoc.Count > 0 && enemyUnitsonLoc.Count == 0 && name == "Mines")
        {
            resourceManager.runtimeGoldMiliaryGained = 15;
        }
        if (allyUnitsonLoc.Count > 0 && enemyUnitsonLoc.Count == 0 && name == "Hunting Grounds")
        {
            resourceManager.runtimeFoodMiliaryGained = 15;
        }
        if (allyUnitsonLoc.Count == 0 && enemyUnitsonLoc.Count == 0 && name == "Ruins")
        {
            resourceManager.runtimeEGMiliaryGained = 15;
        }
        if (allyUnitsonLoc.Count == 0 && enemyUnitsonLoc.Count > 0 && name == "Mines")
        {
            resourceManager.runtimeGoldMiliaryGained = 0;
        }
        if (allyUnitsonLoc.Count == 0 && enemyUnitsonLoc.Count > 0 && name == "Hunting Grounds")
        {
            resourceManager.runtimeFoodMiliaryGained = 0;
        }
        if (allyUnitsonLoc.Count == 0 && enemyUnitsonLoc.Count > 0 && name == "Ruins")
        {
            resourceManager.runtimeEGMiliaryGained = 0;
        }
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
    // Map coordinates
    public float Mapx;
    public float Mapy;

    public GameObject unitImOne;

    public GameObject unitImTwo;

    public GameObject parent;

    public GameObject Mines;
    public GameObject Ruins;
    public GameObject HuntingGrounds;
    public GameObject EnemyCity;

    public ResourceManager resourceManager;
    public NPCandLordHolder nPCandLordHolder;

    private int enemyNumAmount;
    private int allyNumAmount;
    private int rebelNumAmount;

    //display the Military button
    public bool displayCanvas = false;

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
    public void createUnit(int iff,float x, float y,GameObject image, string industryleaderName)
    {
        //GameObject unitIm = Instantiate(image);
        if (iff == 0)
        {
            allyNumAmount++;
            //unitIm.name = "AllyUnit#" + allyNumAmount;
        }
        else if (iff == 1)
        {
            enemyNumAmount++;
            //unitIm.name = "EnemyUnit#" + enemyNumAmount;
        }

        Unit newUnit = new Unit(attack,shield,health,x,y,Mapx,Mapy, null, iff);
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
        else if (newUnit.IFF == 2)
        {
            newUnit.name = "RebelUnit " + industryleaderName;
            newUnit.attack = 1;
            newUnit.health = 3;
            newUnit.shield = 0;
            allUnitsList.Add(newUnit);
            unchosenObjList.Add(newUnit);
        }
    }

    /// <summary>
    /// Make a new location
    /// </summary>
    public void CreateALocation(float xin, float yin, string namein)
    {
        Location location = new Location(xin, yin, Mapx, Mapy, namein);
        resourceLocs.Add(location);
        unchosenObjList.Add(location);
        if (namein != "Enemy City")
        {
            enemyObjList.Add(location);
        }
    }

    // changes canvas boolean between true and false
    public void SwitchCanvas()
    {
        displayCanvas = !displayCanvas;
    }

    // returns the canvas boolean
    public bool DisplayCanvas()
    {
        return displayCanvas;
    }

    public void Reset()
    {
        allUnitsList = new List<Unit>();
        curObjList = new List<Targets>();
        enemyObjList = new List<Targets>();
        unchosenObjList = new List<Targets>();
        for(int x =0; x < resourceLocs.Count;x++)
        {
            unchosenObjList.Add(resourceLocs[x]);
            resourceLocs[x].allyUnitsonLoc = new List<Unit>();
            resourceLocs[x].enemyUnitsonLoc = new List<Unit>();
        }
        displayCanvas = false;
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
        Mapx = parent.transform.position.x;
        Mapy = parent.transform.position.y;
    }

    /// <summary>
    /// Creates a player unit
    /// </summary>
    public void CreateFriendlyUnit()
    {
        //-792, -79
        createUnit(0, -792f, -79, unitImOne, null);
        resourceManager.runtimeFoodStorage = resourceManager.runtimeFoodStorage - 10;
        resourceManager.runtimeGoldStorage = resourceManager.runtimeGoldStorage - 10;
        resourceManager.runtimeFoodUpkeep = resourceManager.runtimeFoodUpkeep + 5;
        resourceManager.runtimeGoldUpkeep = resourceManager.runtimeGoldUpkeep + 5;
        resourceManager.changeSpyMasterText();
        // Change Dialog text to notifiy that a unit has been created
        GameObject GODialogText = GameObject.Find("DialogText");
        TextMeshProUGUI textMesh = GODialogText.GetComponent<TextMeshProUGUI>();
        textMesh.SetText("Military Leader: A Unit has been created, my Leige");
    }


    /// <summary>
    /// Creates an enemy unit
    /// </summary>
    public void CreateEnemyUnit()
    {
        // 792, 166
        createUnit(1, 792, 166, unitImTwo, null);
    }

    public void CreateRebelUnit(string industryLeadersName)
    {
        if (industryLeadersName == "Farmer")
        {
            createUnit(2, -775.6f, -596f, unitImTwo, "Farmer");
        }
        else if (industryLeadersName == "Merchant")
        {
            createUnit(2, -459.6f, -249.1f, unitImTwo, "Merchant");
        }
        else if (industryLeadersName == "Smith")
        {
            createUnit(2, -784.5f, -414f, unitImTwo, "Smith");
        }
        else if (industryLeadersName == "Scholar")
        {
            createUnit(2, -414.3f, 139.6f, unitImTwo, "Scholar");
        }
        else if (industryLeadersName == "General")
        {
            createUnit(2, -863.4f, -82.9f, unitImTwo, "General");
        }
    }
   
    /// <summary>
    /// When called, it will save the position of the objects off screen in case we are not on map on movement
    /// </summary>
    public void saveOffScreenPos()
    {
        //all units 
        for(int x =0; x < allUnitsList.Count; x++)
        {
            Unit unit = allUnitsList[x];
            GameObject GO = GameObject.Find(unit.name);
            if (GO != null)
            {
                unit.xLoc = GO.transform.localPosition.x;
                unit.yLoc = GO.transform.localPosition.y;
                unit.offmap = true;
            }
        }
        // all locations
        for(int y =0; y < resourceLocs.Count; y++)
        {
            Location loc = resourceLocs[y];
            GameObject GO = GameObject.Find(loc.name);
            loc.xLocOffScreen = GO.transform.localPosition.x;
            loc.yLocOffScreen = GO.transform.localPosition.y;
        }
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
                if (allUnitsList[x].image != null)
                {
                    GameObject GO = GameObject.Find(allUnitsList[x].image.name);
                    Destroy(GO);
                }
                
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
            if (location.name != "Enemy City")
            {
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
    /// The grand battle to end them all
    /// </summary>
    public bool GrandBattle()
    {
        List<Unit> allyUnits = new List<Unit>();
        List<Unit> enemyUnits = new List<Unit>();
        for(int j =0; j < allUnitsList.Count; j++)
        {
            Unit unit = allUnitsList[j];
            if (unit.IFF == 0)
            {
                allyUnits.Add(unit);
            }
            else if (unit.IFF == 1)
            {
                enemyUnits.Add(unit);
            }
        }
        battle(allyUnits, enemyUnits);
        if (allyUnits.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
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
            // first list turn to attack
            if (randOne > 0 && randTwo > 0)
            {
                indChoose = (int)Random.Range(0, randOne-1);
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
                    unitSetOne[indOne].inRange = false;
                    if (unitSetOne[indOne].secObjective != null)
                    {
                        unitSetOne[indOne].objective = unitSetOne[indOne].secObjective;
                    }
                    else
                    {
                        unitSetOne[indOne].objective = null;
                    }
                    if (unitSetTwo[indChoose].name.Contains("Rebel"))
                    {
                        string name = unitSetTwo[indChoose].name.Replace("RebelUnit ", "");
                        if (name == "Farmer")
                        {
                            nPCandLordHolder.AllyFarmer.Rebelling = false;
                        }
                        else if (name == "Smith")
                        {
                            nPCandLordHolder.AllyBuilder.Rebelling = false;
                        }
                        else if (name == "Scholar")
                        {
                            nPCandLordHolder.AllyScholar.Rebelling = false;
                        }
                        else if (name == "General")
                        {
                            nPCandLordHolder.AllyGeneral.Rebelling = false;
                        }
                        else if (name == "Merchant")
                        {
                            nPCandLordHolder.AllyMerchant.Rebelling = false;
                        }
                    }
                    //Grab the name of dead unit
                    string deadname = unitSetTwo[indChoose].name;
                    for (int x = 0; x < curObjList.Count; x++)
                    {
                        if (curObjList[x].GetType() == typeof(Unit))
                        {
                            Unit unit = (Unit)curObjList[x];
                            if (unit.name == deadname)
                            {
                                curObjList.RemoveAt(x);
                            }
                        }
                    }
                    for (int x = 0; x < enemyObjList.Count; x++)
                    {
                        if (enemyObjList[x].GetType() == typeof(Unit))
                        {
                            Unit unit = (Unit)enemyObjList[x];
                            if (unit.name == deadname)
                            {
                                enemyObjList.RemoveAt(x);
                            }
                        }
                    }
                    unitSetTwo.RemoveAt(indChoose);
                    randOne--;
                }
            }

            // second list turn to attack
            if (randTwo > 0 && randOne > 0)
            {
                indChoose = (int)Random.Range(0, randTwo-1);
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
                    unitSetTwo[indTwo].inRange = false;
                    if (unitSetTwo[indTwo].secObjective != null)
                    {
                        unitSetTwo[indTwo].objective = unitSetTwo[indTwo].secObjective;
                    }
                    else
                    {
                        unitSetTwo[indTwo].objective = null;
                    }
                    if(unitSetOne[indChoose].name.Contains("Rebel"))
                    {
                        string name = unitSetOne[indChoose].name.Replace("RebelUnit ", "");
                        if (name == "Farmer")
                        {
                            nPCandLordHolder.AllyFarmer.Rebelling = false;
                        }
                        else if (name == "Smith")
                        {
                            nPCandLordHolder.AllyBuilder.Rebelling = false;
                        }
                        else if(name == "Scholar")
                        {
                            nPCandLordHolder.AllyScholar.Rebelling = false;
                        }
                        else if(name == "General")
                        {
                            nPCandLordHolder.AllyGeneral.Rebelling = false;
                        }
                        else if(name == "Merchant")
                        {
                            nPCandLordHolder.AllyMerchant.Rebelling = false;
                        }
                    }
                    //Grab the name of dead unit
                    string deadname = unitSetOne[indChoose].name;
                    for(int x =0; x < curObjList.Count; x++)
                    {
                       if (curObjList[x].GetType() == typeof(Unit))
                        {
                            Unit unit = (Unit)curObjList[x];
                            if(unit.name == deadname)
                            {
                                curObjList.RemoveAt(x);
                            }
                        }
                    }
                    for (int x = 0; x < enemyObjList.Count; x++)
                    {
                        if (enemyObjList[x].GetType() == typeof(Unit))
                        {
                            Unit unit = (Unit)enemyObjList[x];
                            if (unit.name == deadname)
                            {
                                enemyObjList.RemoveAt(x);
                            }
                        }
                    }
                    unitSetOne.RemoveAt(indChoose);
                    randTwo--;
                }
            }

        }


    } 


}
