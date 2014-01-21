using System;
namespace core
{
    public sealed class Defs
    {
        public delegate void Function();
        public delegate void Function<T1>(T1 t1);
        public delegate void Function<T1, T2>(T1 t1, T2 t2);
        public delegate void Function<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
        public delegate void Function<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
        public delegate void Function<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);

        public delegate R ReturnFunction<R>();
        public delegate R ReturnFunction<R, P1>(P1 p1);
        public delegate R ReturnFunction<R, P1, P2>(P1 p1, P2 p2);
        public delegate R ReturnFunction<R, P1, P2, P3>(P1 p1, P2 p2, P3 p3);
        public delegate R ReturnFunction<R, P1, P2, P3, P4>(P1 p1, P2 p2, P3 p3, P4 p4);
        public delegate R ReturnFunction<R, P1, P2, P3, P4, P5>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);

    }
}