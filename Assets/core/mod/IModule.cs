//模块基类，通常模块是一个逻辑上独立的功能的
using System;
namespace core
{
    public interface IModule
    {
        void Start();
        void Update();
        void Dispose();
        bool IsEnable();
    }
}

