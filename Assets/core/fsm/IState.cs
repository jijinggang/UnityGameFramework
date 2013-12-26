using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    interface IState
    {
        void Enter();
        void Leave();
        IState Update();
    }
}
