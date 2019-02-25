using System;

namespace Contingenciamento.Exceptions
{
    public class ItemAlreadyExists : Exception
    {
        public ItemAlreadyExists()
        {

        }

        public ItemAlreadyExists(string message) : base(message)
        {

        }
    }
}
