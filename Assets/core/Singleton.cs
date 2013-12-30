namespace core
{
	public class Singleton<T> where T : new() 
	{
		protected Singleton() 
		{
		}
		private static T _inst;
		public static T Inst
		{
			get
			{
				if(_inst == null)
					_inst = new T();
				return _inst;
			}
		}
	}
}
