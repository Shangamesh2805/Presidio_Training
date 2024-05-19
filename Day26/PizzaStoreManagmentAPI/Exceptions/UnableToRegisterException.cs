﻿using System.Runtime.Serialization;

namespace PizzaStoreManagmentAPI.Exceptions
{
    [Serializable]
    internal class UnableToRegisterException : Exception
    {
            string message;

        public UnableToRegisterException(string data)
        {
            message = data;
        }

        public override string Message => message;
    }

        
        
    }
