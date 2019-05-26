using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class GameboardException : Exception
    {
        public GameboardException(string msg) : base(msg)
        {

        }
    }
}
