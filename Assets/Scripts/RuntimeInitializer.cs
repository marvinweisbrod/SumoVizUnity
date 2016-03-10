﻿using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RuntimeInitializer : MonoBehaviour {

	/*[Header("load trajectories at editing time:")] // false means to load them at runtime
	[SerializeField]
	public bool trajAtEditingTime = true;*/
	[HideInInspector]
	public GeometryLoader geometryLoader;
	public string relativeTrajFilePath; // TODO more floors

	void Start () { // = Play button was pressed in unity
		//TrajectoryLoader tl = new TrajectoryLoader (trajectoryFilePath, false); // for mobile: load using TextAsset
		TrajectoryLoader tl = new TrajectoryLoader (relativeTrajFilePath, true); // NOT working on mobile: load using stream reader
		tl.loadTrajectories ();
	}

}
