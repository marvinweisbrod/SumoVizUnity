﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class PedestrianLoader : MonoBehaviour {

    Dictionary<int, List<PedestrianPosition>> pedestrianPositions = new Dictionary<int, List<PedestrianPosition>>();
    PlaybackControl pc;
    GameObject parent;

    public List<Pedestrian> pedestrians = new List<Pedestrian>();
    public int[] population;

    private void Awake()
    {
        pc = GameObject.Find("PlaybackControl").GetComponent<PlaybackControl>();
        parent = GameObject.Find("SimulationObjects");
    }

    /// <summary>
    /// Adds a position to the internal dictionary of positions belonging to pedestrians.
    /// </summary>
    /// <param name="position"></param>
    public void addPedestrianPosition(PedestrianPosition position) {
        List<PedestrianPosition> currentPosList;
        if (pedestrianPositions.TryGetValue(position.getID(), out currentPosList))
        {
            currentPosList.Add(position);
        }
        else
        {
            currentPosList = new List<PedestrianPosition>();
            currentPosList.Add(position);
            pedestrianPositions.Add(position.getID(), currentPosList);
        }
        if (position.getTime() > pc.total_time) pc.total_time = position.getTime();
    }

    public void createPedestrians() {
        foreach (var pedestrianEntry in pedestrianPositions) {
            GameObject pedestrian = (GameObject)Instantiate(Resources.Load("Pedestrian2"));
            pedestrian.transform.parent = parent.transform;
            Pedestrian pedComponent = pedestrian.GetComponent<Pedestrian>();
            pedComponent.setPositions(pedestrianEntry.Value);
            pedComponent.setID(pedestrianEntry.Key);
            pedestrians.Add(pedComponent);
        }
    }
}
