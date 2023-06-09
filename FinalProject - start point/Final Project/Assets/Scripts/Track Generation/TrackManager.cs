﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {
    public Catmul[] splines;
    public GameObject splinePrefab;
    public GameObject[] swarmleaderPrefab;
    public string[][] maskNames;

	// Use this for initialization
	void Start () {
        maskNames = new string[5][];

        maskNames[0] = new string[] { "flock1", "flock2", "flock3", "flock4" };
        maskNames[1] = new string[] { "flock0", "flock2", "flock3", "flock4" };
        maskNames[2] = new string[] { "flock0", "flock1", "flock3", "flock4" };
        maskNames[3] = new string[] { "flock0", "flock1", "flock2", "flock4" };
        maskNames[4] = new string[] { "flock0", "flock1", "flock2", "flock3" };
        splines = new Catmul[5]; // TODO - change
        splines[0] = Instantiate(splinePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Catmul>();
        splines[1] = Instantiate(splinePrefab, new Vector3(-30, 0, -30), Quaternion.identity).GetComponent<Catmul>();
        splines[2] = Instantiate(splinePrefab, new Vector3(-30, 0, 30), Quaternion.identity).GetComponent<Catmul>();
        splines[3] = Instantiate(splinePrefab, new Vector3(30, 0, -30), Quaternion.identity).GetComponent<Catmul>();
        splines[4] = Instantiate(splinePrefab, new Vector3(30, 0, 30), Quaternion.identity).GetComponent<Catmul>();

        // TODO add code here

        for (int i = 0; i < splines.Length; i++) // TO DO - change code
        {
            splines[i].GenerateSpline();
        }
        // spawn the flocks on the tracks.  Track 0 is where the player begins.
        for (int i = 0; i < splines.Length; i++) // TO DO CHANGE CODE 
        {
            // TO DO - Spawn the swarm leader
            GameObject leader = Instantiate(swarmleaderPrefab[i], splines[i].sp[0].transform.position, Quaternion.identity);

            // TODO - Get the follow track script, and tell it about the track manager (so it can find more tracks), and the spline.
            Flock flock = leader.GetComponent<Flock>();
            flock.mask = maskNames[i];

            //Assign waypoints to the track
            FollowTrack followTrack = leader.GetComponent<FollowTrack>();
            followTrack.waypoints = splines[i].sp;
            followTrack.SetValue("TrackManager", this);
            followTrack.SetValue("TrackIndex", i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
