using System;

namespace Meteo_Lib
{
    public class ResolveException : Exception
    {
        public ResolveException() { }
        public ResolveException(string message) { }
        public ResolveException(string message, System.Exception inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client.
        protected ResolveException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
