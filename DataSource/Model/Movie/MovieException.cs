using System;

namespace SFF.Datasource.Model
{
    [Serializable]
    public class ExceedingMaxRentCapReachedException : Exception
    {
        public ExceedingMaxRentCapReachedException()
        {
        }

        public ExceedingMaxRentCapReachedException(string message) : base(message)
        {
        }

        public ExceedingMaxRentCapReachedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}