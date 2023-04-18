using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
    public GameObject boidPrefab;
    public string[] mask;
    public int numberOfBoids = 20;
    public int numberOfObstacles = 10;
    public List<GameObject> boids;
    public float spawnRadius = 3.0f;
    public float speed = 1.0f;
    public float turnspeed = 30.0f;
    public float FOV = 60; // degrees
    public float NeighborDistanceSquared = 64.0f; // avoid sqrt
    public float cohesionWeight = 1.0f;
    public float alignmentWeight = 0.0f;
    public float avoidanceWeight = 1.0f;
    public float noise = 0.1f;
    public float AvoidMininum = 3.0f;
    public GameObject target;
    public List<GameObject> deadBoids;
    public GameObject boom;
    public bool player;
    // Use this for initialization
    void Start () {
        target = gameObject;
        boids = new List<GameObject>();
        deadBoids = new List<GameObject>();

        //Gets layermask from the string array
        LayerMask Layermask = LayerMask.GetMask(mask);

        for (int i = 0; i < numberOfBoids; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
            pos.y = 0.0f;
            Quaternion rot = Quaternion.Euler(0, Random.Range(0,360), 0);
            boids.Add(Instantiate(boidPrefab, pos,rot));
            boids[i].GetComponent<Boid>().flock = this;

          //  BUG HERE ????? FIX????? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
          //  BUG HERE ????? FIX????? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Shooting ShootTree = boids[i].GetComponent<Shooting>();
            //Sets value of the layer mask in the blackboard
            ShootTree.SetValue("Mask", Layermask);


           // ShootTree.SetValue("Mask", Layermask);
          //  BUG HERE ????? FIX????? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
          //  BUG HERE ????? FIX????? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            // TODO - Configure the combat AI on the boid we just built.
            // get the tree, and set any blackbaord variables it may need, such as the mask, the object hit (which will be null to start), the shooting range
        }
    }
	
    public void removeBoid(GameObject b)
    {
        deadBoids.Add(b);
    }
	// Update is called once per frame
	void Update () {
		if (deadBoids.Count != 0)
        {
            foreach (GameObject g in deadBoids)
            {
                boids.Remove(g);
                // TODO - create a boom where the boid was
                GameObject.Instantiate(boom, g.transform.position, Quaternion.identity);
                // TODO - destroy the boid
                Destroy(g);
            }
            deadBoids.Clear();
            if (boids.Count == 0)
            {
                // TODO - destroy this swarm leader
                if (player)
                {
#if UNITY_EDITOR

                    UnityEditor.EditorApplication.isPlaying = false;
#else

                    Application.Quit();
#endif
                }
                else
                {
                    Destroy(gameObject);
                }
                // unless it's the player, and if it's the player, stop the game.
            }
        }
	}
}
