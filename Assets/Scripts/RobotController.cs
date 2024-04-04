using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // The whole robot
    public GameObject robot;
    // Get all the joints of the robot gameobjects
    public List<GameObject> jointsList = new List<GameObject>();
    // Get a ref. to the JointsSubscriber to access the data
    //public JointsSubscriber jointsSubscriber;
    // Angles received
    float[] jointsAngles = new float[6];
    // Hands
    public List<GameObject> hands = new List<GameObject>();
    private Vector3[] newHandsPositionRotation = new Vector3[4];
    private Vector3[] oldHandsPositionRotation = new Vector3[4];
    public static Vector3[] deltaHandsPositionRotation = new Vector3[4];
    // Grabbed flag to prevent controlling the robot while moving
    public bool grabbed = false;
    void Update()
    {
        newHandsPositionRotation[0] = hands[0].transform.position;
        newHandsPositionRotation[1] = hands[0].transform.eulerAngles;
        newHandsPositionRotation[2] = hands[1].transform.position;
        newHandsPositionRotation[3] = hands[1].transform.eulerAngles;
        try
        {
            // Check if message > 10 to prevent errors in splitting
            if (JointsSubscriber.messageData.Length > 10)
            {
                string[] splitNumbers = JointsSubscriber.messageData.Split(',');
                //Parse each angle rad->deg
                for (int i = 0; i < splitNumbers.Length; i++)
                {
                    jointsAngles[i] = float.Parse(splitNumbers[i]) * 180 / Mathf.PI;
                }
                // Rotate each gameobject
                jointsList[0].transform.localEulerAngles = new Vector3(0, -jointsAngles[0], 0);
                jointsList[1].transform.localEulerAngles = new Vector3(jointsAngles[1], 0, 0);
                jointsList[2].transform.localEulerAngles = new Vector3(jointsAngles[2], 0, 0);
                jointsList[3].transform.localEulerAngles = new Vector3(0, 0, -jointsAngles[3]);
                jointsList[4].transform.localEulerAngles = new Vector3(jointsAngles[4], 0, 0);
                jointsList[5].transform.localEulerAngles = new Vector3(0, 0, -jointsAngles[5]);
            }
        }
        catch (System.Exception)
        {
            throw;
        }

        //Fix the robot rotation
        robot.transform.localEulerAngles = new Vector3(0, robot.transform.localEulerAngles.y, 0);

        //get the delta position and rotation 
        deltaHandsPositionRotation[0] = newHandsPositionRotation[0] - newHandsPositionRotation[0];
        deltaHandsPositionRotation[1] = oldHandsPositionRotation[1] - newHandsPositionRotation[1];
        deltaHandsPositionRotation[2] = newHandsPositionRotation[2] - newHandsPositionRotation[2];
        deltaHandsPositionRotation[3] = oldHandsPositionRotation[3] - newHandsPositionRotation[3];

        //update with old with new value
        oldHandsPositionRotation[0] = newHandsPositionRotation[0];
        oldHandsPositionRotation[1] = newHandsPositionRotation[1];
        oldHandsPositionRotation[2] = newHandsPositionRotation[2];
        oldHandsPositionRotation[3] = newHandsPositionRotation[3];
    }

    void Start()
    {
        oldHandsPositionRotation[0] = hands[0].transform.position;
        oldHandsPositionRotation[1] = hands[0].transform.eulerAngles;
        oldHandsPositionRotation[2] = hands[1].transform.position;
        oldHandsPositionRotation[3] = hands[1].transform.eulerAngles;
    }

    public void setGrabbed(bool b)
    {
        grabbed = b;
    }
}
