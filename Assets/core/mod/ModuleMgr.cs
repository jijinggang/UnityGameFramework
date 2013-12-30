//逻辑模块管理类，通过该类可以很方便的平行扩展功能模块

using System;
using System.Collections.Generic;
namespace core
{
	public sealed class ModuleMgr : IModule
    {
        private ModuleMgr()
        {
        }
		public static ModuleMgr Inst{
			get{
				if(_inst == null)
					_inst = new ModuleMgr();
				return _inst;
			}
		}
        public void AddModule(IModule mod)
        {
            mods.Add(mod);
        }
        public override void Start()
        {
            foreach (IModule mod in mods)
            {
                mod.Start();
            }
        }
        public override void Update()
        {
            foreach (IModule mod in mods)
            {
                if (mod.Enable)
                    mod.Update();
            }
        }
        public override void Dispose()
        {
            foreach (IModule mod in mods)
            {
                mod.Dispose();
            }
            mods.Clear();
        }
        private static ModuleMgr _inst = null;
        private List<IModule> mods = new List<IModule>();
    }
}