using System;

namespace core
{
	public abstract class AbstractModule : IModule
	{
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Dispose() { }
        public bool IsEnable() { return _enable; }
        protected void setEnable(bool enable) { _enable = enable; }
        private bool _enable = true;
	}
}
