using core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq; 
namespace UnitTest
{
    
    
    /// <summary>
    ///这是 StateMachineTest 的测试类，旨在
    ///包含所有 StateMachineTest 单元测试
    ///</summary>
    [TestClass()]
    public class StateMachineTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        abstract class StateBase : IState
        {
            protected string _str = String.Empty;
            public override string ToString() { return _str; }
            public void Enter() { _str += "Enter"; }
            public void Leave() { _str = _str.Substring(0, _str.Length - "Enter".Length); }
            public virtual IState Update() { return null; }
        }
        class State1 : StateBase
        {
            public State1() { _str = "S1"; }
            public override IState Update() { return new State2(); }
        }
        class State2 : StateBase
        {
            public State2() { _str = "S2"; }
            public override IState Update() { return new State1(); }
        }
        /// <summary>
        ///ChangeState 的测试
        ///</summary>
        [TestMethod()]
        public void ChangeStateTest()
        {
            StateMachine sm = new StateMachine(); // TODO: 初始化为适当的值
            Assert.IsNull(sm.GetState());
            var state1 = new State1();

            //测试基本changestate
            sm.ChangeState(state1);
            Assert.AreSame(state1, sm.GetState());
            Assert.AreEqual(state1.ToString(), "S1Enter");
            
            //测试对同一个state设置
            sm.ChangeState(state1);
            Assert.AreSame(state1, sm.GetState());
            Assert.AreEqual(state1.ToString(), "S1Enter");

            sm.Update();
            

            var state2 = sm.GetState();
            Assert.AreNotSame(state1, state2);
            Assert.AreEqual(state1.ToString(), "S1");
            Assert.AreEqual(state2.ToString(), "S2Enter");
        }
    }
}
