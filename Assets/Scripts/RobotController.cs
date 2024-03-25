using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Get all the joints gameobejects
    public List<GameObject> jointsList = new List<GameObject>();
    // Get a ref. to the JointsSubscriber to access the data
    public JointsSubscriber jointsSubscriber;
    // Angles received
    float[] jointsAngles = new float[6];

    void Update()
    {
        try
        {
            // Check if message > 10 to prevent errors in splitting
            if (jointsSubscriber.messageData.Length > 10)
            {
                string[] splitNumbers = jointsSubscriber.messageData.Split(',');
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

        //OculusHand_L for position and rotation

    }
}
