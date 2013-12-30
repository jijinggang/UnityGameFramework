//模块基类，通常模块是一个逻辑上独立的功能的
using System;
namespace core
{
    public abstract class IModule
    {
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Dispose() { }
        public bool Enable = true;
    }
}

