﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFramework.Message.Impl
{
    public class MockMessageConsumer : IMessageConsumer
    {
        public void Start()
        {
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }

        public decimal MessageCount
        {
            get { return 0; }
        }

        public void EnqueueMessage(object message)
        {
        }


        public void Stop()
        {
        }
    }
}
