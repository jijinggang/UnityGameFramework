using System;
namespace core
{
    class Defs
    {
        public delegate void Handler();
        public delegate void Handler<T1>(T1 t1);
        public delegate void Handler<T1, T2>(T1 t1, T2 t2);
        public delegate void Handler<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
        public delegate void Handler<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
        public delegate void Handler<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    }
}