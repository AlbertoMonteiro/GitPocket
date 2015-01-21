using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GitPocket.Business.Test.Mocks
{
    public interface IMock<T>
    {
        MockBuilder<TRet> MockSome<TRet>(Expression<Func<T, TRet>> m);
    }

    public class Mock<T> : IMock<T>
        where T : class
    {
        protected Dictionary<string, object> methods;

        public Mock()
        {
            methods = new Dictionary<string, object>();
        }

        public MockBuilder<TRet> MockSome<TRet>(Expression<Func<T, TRet>> m)
        {
            var a = (m.Body as MethodCallExpression);
            var mb = new MockBuilder<TRet>();
            methods.Add(a.Method.Name, mb);
            return mb;
        }
    }

    public class MockBuilder<TRet>
    {
        public Func<TRet> Execution { get; set; }

        public void Returns(Func<TRet> returnsFunc)
        {
            Execution = returnsFunc;
        }
    }
}