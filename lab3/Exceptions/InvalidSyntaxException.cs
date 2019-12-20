using System;

namespace lab3.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        public override string Message {
            get { return "Invalid Syntax Exception"; }
        }
    }
}