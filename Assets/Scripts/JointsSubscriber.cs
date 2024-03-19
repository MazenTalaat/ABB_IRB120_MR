using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class JointsSubscriber : UnitySubscriber<MessageTypes.Std.String>
    {
        public string messageData;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Std.String message)
        {
            messageData = message.data;
        }
    }
}