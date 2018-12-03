using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ministrare.Events;


[CreateAssetMenu(fileName = "NPCandLordHolder", menuName = "Ministrare/SingletonVars/NPCandLordHolder", order = 3)]

public class NPCandLordHolder : ScriptableObject {
    public enum ecStateofMind
    {
        NeedResources,
        Stable,
        Military
    }

    // Allies
    public IndustryLeader AllyFarmer;
    public IndustryLeader AllyGeneral;
    public IndustryLeader AllyScholar;
    public IndustryLeader AllyMerchant;
    public IndustryLeader AllyBuilder;
    // Enemy
    public IndustryLeader EnemyFarmer;
    public IndustryLeader EnemyGeneral;
    public IndustryLeader EnemyScholar;
    public IndustryLeader EnemyMerchant;
    public IndustryLeader EnemyBuilder;
    // our character (Lord)
    public Lord Lord;
    // leader of other city
    public Lord EnemyLord;
    // State of the enemy city
    public ecStateofMind EcStateofMind;
    //Resource Manager
    [SerializeField]
    public ResourceManager resourceManager;


    public void OnEnable()
   {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void Initialize()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        //Ally IndustryLeaders Initialization
        AllyFarmer = new IndustryLeader();
        AllyGeneral = new IndustryLeader();
        AllyScholar = new IndustryLeader();
        AllyMerchant = new IndustryLeader();
        AllyBuilder = new IndustryLeader();

        // our character Initialization
        Lord = new Lord();

        //Enemy IndustryLeaders Initialization
        EnemyFarmer = new IndustryLeader();
        EnemyGeneral = new IndustryLeader();
        EnemyScholar = new IndustryLeader();
        EnemyMerchant = new IndustryLeader();
        EnemyBuilder = new IndustryLeader();

        // enemy Leader Initialization
        EnemyLord = new Lord();

        //initialize enemy city state
        EcStateofMind = ecStateofMind.Stable;
        // add stable event to the eventrunner
        // find the timer
        GameObject GO = GameObject.Find("Timer");
        TimerRunner timerRunner = GO.GetComponent<TimerRunner>();
        // find the eventRunner and push an econ Event to it
        GameObject GO2 = GameObject.Find("MinistareEventRunner");
        MinistrareEventRunner ministrareEventRunner = GO2.GetComponent<MinistrareEventRunner>();
        int daysDuration = Random.Range(6, 8);
        StableMinistareEvent stable = new StableMinistareEvent(timerRunner.time, "StableEvent", daysDuration);
        ministrareEventRunner.AddEvent(stable);
    }

    public void doDailyworkEffeciency()
    {
        AllyBuilder.generateWorkEfficiency();
        AllyFarmer.generateWorkEfficiency();
        AllyGeneral.generateWorkEfficiency();
        AllyMerchant.generateWorkEfficiency();
        AllyScholar.generateWorkEfficiency();
        EnemyBuilder.generateWorkEfficiency();
        EnemyFarmer.generateWorkEfficiency();
        EnemyGeneral.generateWorkEfficiency();
        EnemyMerchant.generateWorkEfficiency();
        EnemyScholar.generateWorkEfficiency();
    }

    public void doDailyMoodChange()
    {
        AllyBuilder.dailyMoodChange();
        AllyFarmer.dailyMoodChange();
        AllyGeneral.dailyMoodChange();
        AllyMerchant.dailyMoodChange();
        AllyScholar.dailyMoodChange();
        EnemyBuilder.dailyMoodChange();
        EnemyFarmer.dailyMoodChange();
        EnemyGeneral.dailyMoodChange();
        EnemyMerchant.dailyMoodChange();
        EnemyScholar.dailyMoodChange();
    }

    public void doDailyinRellionCheck()
    {
        AllyBuilder.inRebellion();
        AllyFarmer.inRebellion();
        AllyGeneral.inRebellion();
        AllyMerchant.inRebellion();
        AllyScholar.inRebellion();
    }

    public void doDailyActions()
    {
        eIndustryLeaderInteraction();
        doDailyMoodChange();
        doDailyinRellionCheck();
        enemyIndustryCityHappinessModifiers();
        doDailyworkEffeciency();
        enemyLeadersConspiring();
        allyIndustryCityHappinessModifiers();
    }

    // determines the state that the enemy are in and add the event to the event runner
    public void stateOfMindRoll()
    {
        // check first to make sure that the enemy's military is on par with the players 

        // if it isn't, create an event so that enemy will make more military units 

        // if it is, spin the wheel to see if the city would be stable or need resources 
        int spinWheel = Random.Range(0, 100);

        if (spinWheel <= 33)
        {
            // Set the state machine
            EcStateofMind = ecStateofMind.NeedResources;
            // find the timer
            GameObject GO = GameObject.Find("Timer");
            TimerRunner timerRunner = GO.GetComponent<TimerRunner>();
            // find the eventRunner and push an econ Event to it
            GameObject GO2 = GameObject.Find("MinistareEventRunner");
            MinistrareEventRunner ministrareEventRunner = GO2.GetComponent<MinistrareEventRunner>();
            int daysDuration = Random.Range(6, 8);
            EconMinistareEvent econ = new EconMinistareEvent(timerRunner.time, "EconEvent", daysDuration);
            ministrareEventRunner.AddEvent(econ);
        }
        else if (spinWheel <= 66)
        {
            // Set the state machine
            EcStateofMind = ecStateofMind.Stable;
            // find the timer
            GameObject GO = GameObject.Find("Timer");
            TimerRunner timerRunner = GO.GetComponent<TimerRunner>();
            // find the eventRunner and push an econ Event to it
            GameObject GO2 = GameObject.Find("MinistareEventRunner");
            MinistrareEventRunner ministrareEventRunner = GO2.GetComponent<MinistrareEventRunner>();
            int daysDuration = Random.Range(6, 8);
            StableMinistareEvent stable = new StableMinistareEvent(timerRunner.time, "StableEvent", daysDuration);
            ministrareEventRunner.AddEvent(stable);
        }
        else
        {
            // Set the state machine
            EcStateofMind = ecStateofMind.Military;
            // find the timer
            GameObject GO = GameObject.Find("Timer");
            TimerRunner timerRunner = GO.GetComponent<TimerRunner>();
            // find the eventRunner and push an econ Event to it
            GameObject GO2 = GameObject.Find("MinistareEventRunner");
            MinistrareEventRunner ministrareEventRunner = GO2.GetComponent<MinistrareEventRunner>();
            int daysDuration = Random.Range(6, 8);
            MilitaryMinistareEvent military = new MilitaryMinistareEvent(timerRunner.time, "MilitaryEvent", daysDuration);
            ministrareEventRunner.AddEvent(military);
        }
    }

    // this will change the happiness of the enemy city industry leaders based on their state
    public void enemyIndustryCityHappinessModifiers()
    {
        if (EcStateofMind == ecStateofMind.NeedResources)
        {
            EnemyBuilder.Happiness = EnemyBuilder.Happiness - 2;
            EnemyFarmer.Happiness = EnemyFarmer.Happiness - 2;
            EnemyGeneral.Happiness = EnemyGeneral.Happiness - 2;
            EnemyMerchant.Happiness = EnemyMerchant.Happiness - 2;
            EnemyScholar.Happiness = EnemyScholar.Happiness - 2;
        }
        else if (EcStateofMind == ecStateofMind.Stable)
        {
            EnemyBuilder.Happiness = EnemyBuilder.Happiness + 2;
            EnemyFarmer.Happiness = EnemyFarmer.Happiness + 2;
            EnemyGeneral.Happiness = EnemyGeneral.Happiness + 2;
            EnemyMerchant.Happiness = EnemyMerchant.Happiness + 2;
            EnemyScholar.Happiness = EnemyScholar.Happiness + 2;
        }
    }

    // function of the enemy lord to try to change the alligence of the industry leaders
    public void enemyLeadersConspiring()
    {
        if (AllyBuilder.Happiness <= 20)
        {
            int chanceToflip = Random.Range(0, 100);
            if (chanceToflip <= 10)
            {
                AllyBuilder.WorkingWithEnemy = true;
            }
        }
        if (AllyScholar.Happiness <= 20)
        {
            int chanceToflip = Random.Range(0, 100);
            if (chanceToflip <= 10)
            {
                AllyScholar.WorkingWithEnemy = true;
            }
        }
        if (AllyMerchant.Happiness <= 20)
        {
            int chanceToflip = Random.Range(0, 100);
            if (chanceToflip <= 10)
            {
                AllyMerchant.WorkingWithEnemy = true;
            }
        }
        if (AllyGeneral.Happiness <= 20)
        {
            int chanceToflip = Random.Range(0, 100);
            if (chanceToflip <= 10)
            {
                AllyGeneral.WorkingWithEnemy = true;
            }
        }
        if (AllyFarmer.Happiness <= 20)
        {
            int chanceToflip = Random.Range(0, 100);
            if (chanceToflip <= 10)
            {
                AllyFarmer.WorkingWithEnemy = true;
            }
        }
    }

    // this will change the happiness of ally city industry leaders based on resources
    public void allyIndustryCityHappinessModifiers()
    {
        if(resourceManager.runtimeFoodStorage < 20)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness - 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness - 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness - 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness - 1;
            AllyScholar.Happiness = AllyScholar.Happiness - 1;
        }
        else if (resourceManager.runtimeFoodStorage > 80)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness + 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness + 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness + 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness + 1;
            AllyScholar.Happiness = AllyScholar.Happiness + 1;
        }
        if (resourceManager.runtimeGoldStorage < 20)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness - 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness - 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness - 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness - 1;
            AllyScholar.Happiness = AllyScholar.Happiness - 1;
        }
        else if (resourceManager.runtimeGoldStorage > 80)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness + 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness + 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness + 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness + 1;
            AllyScholar.Happiness = AllyScholar.Happiness + 1;
        }
        if (resourceManager.runtimeEGStorage < 20)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness - 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness - 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness - 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness - 1;
            AllyScholar.Happiness = AllyScholar.Happiness - 1;
        }
        else if (resourceManager.runtimeEGStorage > 80)
        {
            AllyBuilder.Happiness = AllyBuilder.Happiness + 1;
            AllyFarmer.Happiness = AllyFarmer.Happiness + 1;
            AllyGeneral.Happiness = AllyGeneral.Happiness + 1;
            AllyMerchant.Happiness = AllyMerchant.Happiness + 1;
            AllyScholar.Happiness = AllyScholar.Happiness + 1;
        }
    }
    
    // simulates the enemy lord interacting with his industry leaders
    public void eIndustryLeaderInteraction()
    {
        // run through the industry leaders
        for (int x = 0; x < 5; x++)
        {
            // Farmer
            if (x == 0)
            {
                //amount of interactions
                int interactions = Random.Range(0, 10);
                for (int y = 0; y < interactions; y++)
                {
                    // see if this interaction is pos or neg
                    int posNeg = 1;
                    if (Random.Range(0, 100) <= 50)
                    {
                        posNeg = -1;
                    }

                    // randomly see which mood they will change
                    int moodToChange = Random.Range(0, 6);
                    if (moodToChange == 0)
                    {
                        // happiness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Happiness += (change * posNeg);
                    }
                    else if (moodToChange == 1)
                    {
                        // angriness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Angriness += (change * posNeg);
                    }
                    else if (moodToChange == 2)
                    {
                        // greediness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Greediness += (change * posNeg);
                    }
                    else if (moodToChange == 3)
                    {
                        // fearfulness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Fearfulness += (change * posNeg);
                    }
                    else if (moodToChange == 4)
                    {
                        // sadness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Sadness += (change * posNeg);
                    }
                    else if (moodToChange == 5)
                    {
                        // boredom
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Boredom += (change * posNeg);
                    }
                    else if (moodToChange == 6)
                    {
                        // inspiration
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyFarmer.Inspiration += (change * posNeg);
                    }
                }
            }
            // General
            else if (x == 1)
            {
                //amount of interactions
                int interactions = Random.Range(0, 10);
                for (int y = 0; y < interactions; y++)
                {
                    // see if this interaction is pos or neg
                    int posNeg = 1;
                    if (Random.Range(0, 100) <= 50)
                    {
                        posNeg = -1;
                    }

                    // randomly see which mood they will change
                    int moodToChange = Random.Range(0, 6);
                    if (moodToChange == 0)
                    {
                        // happiness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Happiness += (change * posNeg);
                    }
                    else if (moodToChange == 1)
                    {
                        // angriness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Angriness += (change * posNeg);
                    }
                    else if (moodToChange == 2)
                    {
                        // greediness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Greediness += (change * posNeg);
                    }
                    else if (moodToChange == 3)
                    {
                        // fearfulness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Fearfulness += (change * posNeg);
                    }
                    else if (moodToChange == 4)
                    {
                        // sadness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Sadness += (change * posNeg);
                    }
                    else if (moodToChange == 5)
                    {
                        // boredom
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Boredom += (change * posNeg);
                    }
                    else if (moodToChange == 6)
                    {
                        // inspiration
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyGeneral.Inspiration += (change * posNeg);
                    }
                }
            }
            // Scholar
            else if (x == 2)
            {
                //amount of interactions
                int interactions = Random.Range(0, 10);
                for (int y = 0; y < interactions; y++)
                {
                    // see if this interaction is pos or neg
                    int posNeg = 1;
                    if (Random.Range(0, 100) <= 50)
                    {
                        posNeg = -1;
                    }

                    // randomly see which mood they will change
                    int moodToChange = Random.Range(0, 6);
                    if (moodToChange == 0)
                    {
                        // happiness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Happiness += (change * posNeg);
                    }
                    else if (moodToChange == 1)
                    {
                        // angriness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Angriness += (change * posNeg);
                    }
                    else if (moodToChange == 2)
                    {
                        // greediness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Greediness += (change * posNeg);
                    }
                    else if (moodToChange == 3)
                    {
                        // fearfulness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Fearfulness += (change * posNeg);
                    }
                    else if (moodToChange == 4)
                    {
                        // sadness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Sadness += (change * posNeg);
                    }
                    else if (moodToChange == 5)
                    {
                        // boredom
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Boredom += (change * posNeg);
                    }
                    else if (moodToChange == 6)
                    {
                        // inspiration
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyScholar.Inspiration += (change * posNeg);
                    }
                }
            }
            // Merchant
            else if (x == 3)
            {
                //amount of interactions
                int interactions = Random.Range(0, 10);
                for (int y = 0; y < interactions; y++)
                {
                    // see if this interaction is pos or neg
                    int posNeg = 1;
                    if (Random.Range(0, 100) <= 50)
                    {
                        posNeg = -1;
                    }

                    // randomly see which mood they will change
                    int moodToChange = Random.Range(0, 6);
                    if (moodToChange == 0)
                    {
                        // happiness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Happiness += (change * posNeg);
                    }
                    else if (moodToChange == 1)
                    {
                        // angriness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Angriness += (change * posNeg);
                    }
                    else if (moodToChange == 2)
                    {
                        // greediness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Greediness += (change * posNeg);
                    }
                    else if (moodToChange == 3)
                    {
                        // fearfulness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Fearfulness += (change * posNeg);
                    }
                    else if (moodToChange == 4)
                    {
                        // sadness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Sadness += (change * posNeg);
                    }
                    else if (moodToChange == 5)
                    {
                        // boredom
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Boredom += (change * posNeg);
                    }
                    else if (moodToChange == 6)
                    {
                        // inspiration
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyMerchant.Inspiration += (change * posNeg);
                    }
                }
            }
            // Builder
            else if (x == 4)
            {
                //amount of interactions
                int interactions = Random.Range(0, 10);
                for (int y = 0; y < interactions; y++)
                {
                    // see if this interaction is pos or neg
                    int posNeg = 1;
                    if (Random.Range(0, 100) <= 50)
                    {
                        posNeg = -1;
                    }

                    // randomly see which mood they will change
                    int moodToChange = Random.Range(0, 6);
                    if (moodToChange == 0)
                    {
                        // happiness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Happiness += (change * posNeg);
                    }
                    else if (moodToChange == 1)
                    {
                        // angriness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Angriness += (change * posNeg);
                    }
                    else if (moodToChange == 2)
                    {
                        // greediness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Greediness += (change * posNeg);
                    }
                    else if (moodToChange == 3)
                    {
                        // fearfulness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Fearfulness += (change * posNeg);
                    }
                    else if (moodToChange == 4)
                    {
                        // sadness
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Sadness += (change * posNeg);
                    }
                    else if (moodToChange == 5)
                    {
                        // boredom
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Boredom += (change * posNeg);
                    }
                    else if (moodToChange == 6)
                    {
                        // inspiration
                        // amount that the mood will change by
                        int change = Random.Range(1, 3);
                        // apply the change
                        EnemyBuilder.Inspiration += (change * posNeg);
                    }
                }
            }
        }
    }
}
