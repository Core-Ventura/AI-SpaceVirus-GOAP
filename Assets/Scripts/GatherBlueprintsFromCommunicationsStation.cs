﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherBlueprintsFromCommunicationsStation : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // seconds
    public Inventory communicationsStationInventory;
    
    public GatherBlueprintsFromCommunicationsStation()
    {
        addPrecondition("communicationsStationHasBlueprints", true);
        addEffect("hasBlueprints", true);
        name = "GatherBlueprintsFromCommunicationStation";
    }

    public override void reset()
    {
        completed = false;
        startTime = 0;
    }

    public override bool isDone()
    {
        return completed;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool perform(GameObject agent)
    {
        if (startTime == 0)
        {
            Debug.Log("Starting: " + name);
            startTime = Time.time;
        }

        if (Time.time - startTime > workDuration)
        {
            Debug.Log("Finished: " + name);
            communicationsStationInventory.blueprints--;
            completed = true;
        }
        return true;
    }
}
