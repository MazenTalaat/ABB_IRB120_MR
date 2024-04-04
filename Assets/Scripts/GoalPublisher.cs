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
        private bool sendData = false;
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
            if (sendData)
            {
                print("Index forward");
                var leftHandPos = RobotController.deltaHandsPositionRotation[0];
                print(RobotController.deltaHandsPositionRotation[0]);
                // TODO add more controls
                message.data = string.Format("{0},{1},{2},0,0,0,0,0,0,P", leftHandPos.x, leftHandPos.y, leftHandPos.z); 
                Publish(message);
            }
        }

        public void setSendData(bool b)
        {
            print("Index forward");
            sendData = b;
        }
    }
}
