using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public List<GameObject> jointsList = new List<GameObject>();
    public JointsSubscriber jointsSubscriber;
    // Start is called before the first frame update
    void Start()
    {
        // TODO Know each link angle to rotate
        jointsList[0].transform.Rotate(10, 0, 0);
        jointsList[1].transform.eulerAngles = new Vector3(0, 0, 30);
        jointsList[2].transform.eulerAngles = new Vector3(0, 20, 0);
        jointsList[3].transform.eulerAngles = new Vector3(0, 0, 0);
        jointsList[4].transform.eulerAngles = new Vector3(40, 0, 0);
        jointsList[5].transform.eulerAngles = new Vector3(0, 50, 0);

        print("working");
    }

    // TODO Delay the start of the update function
    void Update()
    {
        //string[] splitNumbers = jointsSubscriber.messageData.Split(',');

        //// Convert the string array to a float array
        //float[] floatNumbers = new float[splitNumbers.Length];
        //for (int i = 0; i < splitNumbers.Length; i++)
        //{
        //    floatNumbers[i] = float.Parse(splitNumbers[i]);
        //    //print(floatNumbers[i]);
        //}

        //// Now, floatNumbers contains the float numbers
        //jointsList[0].transform.Rotate(10, 0, 0);
        //jointsList[1].transform.eulerAngles = new Vector3(0, 0, 30);
        //jointsList[2].transform.eulerAngles = new Vector3(0, 20, 0);
        //jointsList[3].transform.eulerAngles = new Vector3(0, 0, 0);
        //jointsList[4].transform.eulerAngles = new Vector3(40, 0, 0);
        //jointsList[5].transform.eulerAngles = new Vector3(0, 50, 0);

        //print("working");
    }
}
