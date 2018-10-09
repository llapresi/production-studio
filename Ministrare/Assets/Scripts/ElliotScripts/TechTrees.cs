using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTrees : MonoBehaviour {

    List<Technology> scienceTreeResearched, productionTreeResearched, militaryTreeResearched;
	// Use this for initialization
	void Start () {
        scienceTreeResearched = new List<Technology>();
        productionTreeResearched = new List<Technology>();
        militaryTreeResearched = new List<Technology>();

        ScienceTree scienceTech = new ScienceTree();
        ProductionTree productionTech = new ProductionTree();
        MilitaryTree militaryTech = new MilitaryTree();

        scienceTreeResearched.Add(scienceTech.firstTech);
        productionTreeResearched.Add(productionTech.firstTech);
        militaryTreeResearched.Add(militaryTech.firstTech);

	}
	
	// Update is called once per frame
	void Update () {
        Researchable(scienceTreeResearched);
        Researchable(productionTreeResearched);
        Researchable(militaryTreeResearched);
	}

    // goes through and checks which techs should be available
    void Researchable(List<Technology> techTree)
    {
        // logic for determining level of tech able to be researched
        /*
		if()
        {
            // display these techs
            techTree[techTree.Count - 1].nextTech1;
            techTree[techTree.Count - 1].nextTech2;
        }
        else if()
        {

        }
        else if()
        {

        }
        else
        {

        }
        */
    }
}
