using System;
using System.Collections.Generic;

namespace core
{
	public class EventManager
	{
        public void AddEventListener<T>(string type, Defs.Function<T> onEvent)
        {
        }
        public void RemoveEventListener<T>(string type, Defs.Function<T> onEvent)
        {
        }
        public void DispatchEvent<T>(Event evt, Defs.Function<T> onEvent = null){

        }
	}

    public class Event
    {
        public string type;
        public object args;
        public Event(string type, object args = null){
            this.type = type;
            this.args = args;
        }
    }
}
