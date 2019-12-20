using System;

namespace lab3.Exceptions
{
    public class InvalidNamingException : Exception
    {
        public override string Message {
            get { return "Invalid Naming Exception"; }
        }
    }
}