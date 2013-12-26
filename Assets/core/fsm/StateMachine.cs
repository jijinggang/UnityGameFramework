using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    class StateMachine
    {
        private IState _currState;
        private IState _prevState;
        public void ChangeState(IState state)
        {
            _prevState = _currState;
            _currState = state;
            if (_prevState != null)
                _prevState.Leave();
            if (_currState != null)
                _currState.Enter();
        }
        public void Update()
        {
            if (_currState != null)
            {
                IState nextState = _currState.Update();
                if (nextState != null)
                {
                    ChangeState(nextState);
                }
            }
        }
    }
}
