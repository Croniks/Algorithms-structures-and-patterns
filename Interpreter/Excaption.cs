using System;
using System.Runtime.Serialization;

namespace Interpreter
{
    [Serializable]
    internal class Excaption : Exception
    {
        public Excaption()
        {
        }

        public Excaption(string message) : base(message)
        {
        }

        public Excaption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Excaption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}