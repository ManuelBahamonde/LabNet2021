using System;
using Tp2.Exceptions;

namespace Tp2
{
    public class Logic
    {
        public void ThrowException()
        {
            throw new Exception("Esta es una exception");
        }

        public void ThrowCustomException()
        {
            throw new CustomException("Esta es una exception personalizada.");
        }
    }
}
