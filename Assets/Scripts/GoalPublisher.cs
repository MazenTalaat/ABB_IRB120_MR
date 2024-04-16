using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class GoalPublisher : UnityPublisher<MessageTypes.Std.String>
    {
        // Message body
        public string messageData;
        // Message to be sent
        private MessageTypes.Std.String message;
        // Flag to send the position data
        private bool sendPosData = false;
        // Flag to send the rotation data
        private bool sendRotData = false;

        public RobotController robotController;

        private int delay = 0;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Std.String
            {
                data = messageData
            };
        }

        private void Update()
        {
            if(delay < 24)
            {
                delay++;
                return;
            }
            else
            {
                if (sendPosData)
                {
                    var leftHandPos = robotController.deltaHandsPositionRotation[0];
                    message.data = string.Format("{0},{1},{2},0,0,0,0,0,0,P", -leftHandPos.z * 100, -leftHandPos.x * 100, -leftHandPos.y * 100);
                    Publish(message);
                }
                else if (sendRotData)
                {
                    var leftHandRot = robotController.deltaHandsPositionRotation[1];
                    //                                   0 ,1, 2 , 3 ,4,5
                    message.data = string.Format("0,0,0,{1},0,{0},{2},0,0,R", -((int)leftHandRot.z  + robotController.jointsAngles[2]), ((int)leftHandRot.y + robotController.jointsAngles[0]), ((int)leftHandRot.x + robotController.jointsAngles[3]));
                    print((int)leftHandRot.x);
                    
                    Publish(message);
                }
                else
                {
                    message.data = string.Format("0,0,0,0,0,0,0,0,0,P");
                    Publish(message);
                }

                //if (Input.GetKeyDown("w"))
                //{
                //    print("w");
                //    message.data = string.Format("0,0,0,{0},{1},{2},{3},{4},{5},R", (1 + robotController.jointsAngles[0]), robotController.jointsAngles[1], robotController.jointsAngles[2], robotController.jointsAngles[3], robotController.jointsAngles[4], robotController.jointsAngles[5]);

                //    Publish(message);
                //}
                //else if (Input.GetKeyDown("s"))
                //{
                //    print("s");
                //    message.data = string.Format("0,0,0,{0},{1},{2},{3},{4},{5},R", (robotController.jointsAngles[0] - 1), robotController.jointsAngles[1], robotController.jointsAngles[2], robotController.jointsAngles[3], robotController.jointsAngles[4], robotController.jointsAngles[5]);
                //    Publish(message);
                //}
                delay = 0;
            }
            //message.data = messageData;
            //Publish(message);
            //if (Input.GetKeyDown("w"))
            //{
            //    print("w");
            //    message.data = "0,0.1,0,0,0,0,0,0,0,P";
            //    Publish(message);
            //}
            //else if (Input.GetKeyDown("s"))
            //{
            //    print("s");
            //    message.data = "0,-0.1,0,0,0,0,0,0,0,P";
            //    Publish(message);
            //}
            //else if (Input.GetKeyDown("a"))
            //{
            //    print("a");
            //    message.data = "-0.1,0,0,0,0,0,0,0,0,P";
            //    Publish(message);
            //}
            //else if (Input.GetKeyDown("d"))
            //{
            //    print("d");
            //    message.data = "0.1,0,0,0,0,0,0,0,0,P";
            //    Publish(message);
            //}
            //else if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            //{
            //    print("zero");
            //    message.data = "0,0,0,0,0,0,0,0,0,P";
            //    Publish(message);
            //}

            

        }

        public void setSendPosData(bool b)
        {
            print("Index forward");
            sendPosData = b;
        }

        public void setRotPosData(bool b)
        {
            print("Index forward");
            sendRotData = b;
        }
    }
}
