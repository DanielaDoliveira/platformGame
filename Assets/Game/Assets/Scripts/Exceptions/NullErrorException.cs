using System;


namespace Game.Assets.Scripts.Exceptions
{
    public class NullErrorException: Exception
    {
        public NullErrorException(string message):base(message)
        {
        }
       
    }
}