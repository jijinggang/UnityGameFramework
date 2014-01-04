using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    public sealed class StateMachine
    {
        private IState _currState;
        private IState _prevState;
        public void ChangeState(IState state)
        {
            if (state == _currState)
                return;
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
        public IState GetState() { return _currState; }
    }
}
