using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public FollowTrack parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets movement for W A and D
        if (Input.GetKey(KeyCode.W))
        {
            parent.SetValue("TurnRequested", Turning.STRAIGHT);
            Debug.Log("W key pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            parent.SetValue("TurnRequested", Turning.LEFT);
            Debug.Log("A key pressed");
        }
        if (Input.GetKey(KeyCode.D))
        {
            parent.SetValue("TurnRequested", Turning.RIGHT);
            Debug.Log("D key pressed");
        }
    }
}
