using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class GoalPublisher : UnityPublisher<MessageTypes.Std.String>
    {
        public string messageData;

        private MessageTypes.Std.String message;

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
            if (Input.GetKeyDown("w"))
            {
                print("w");
                message.data = "0,0.1,0,0,0,0,0,0,0,P";
                Publish(message);
            }
            else if (Input.GetKeyDown("s"))
            {
                print("s");
                message.data = "0,-0.1,0,0,0,0,0,0,0,P";
                Publish(message);
            }
            else if (Input.GetKeyDown("a"))
            {
                print("a");
                message.data = "-0.1,0,0,0,0,0,0,0,0,P";
                Publish(message);
            }
            else if (Input.GetKeyDown("d"))
            {
                print("d");
                message.data = "0.1,0,0,0,0,0,0,0,0,P";
                Publish(message);
            }
            else if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                print("zero");
                message.data = "0,0,0,0,0,0,0,0,0,P";
                Publish(message);
            }
        }
    }
}
