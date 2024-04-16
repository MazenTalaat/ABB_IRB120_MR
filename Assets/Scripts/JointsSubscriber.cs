using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class JointsSubscriber : UnitySubscriber<MessageTypes.Std.String>
    {
        // Received messageData
        public string messageData;
        protected override void Start()
        {
            base.Start();
        }

        // Received messageData callback
        protected override void ReceiveMessage(MessageTypes.Std.String message)
        {
            messageData = message.data;
        }
    }
}