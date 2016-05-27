using System;

namespace Delegates.Classes
{
    public class Processor
    {
        public T Process<T, TRequest>(TRequest request,
            Func<TRequest, bool> checkFunc,
            Func<TRequest, T> registerFunc,
            Action<T> saveAction)
        {
            if (!checkFunc(request))
            {
                throw new ArgumentException();
            }

            var result = registerFunc(request);
            saveAction(result);
            return result;
        }
    }

    public class TransactionRequest
    {
        public override string ToString()
        {
            return "This is TransactionRequest";
        }
    }

    public class Transaction
    {
        public override string ToString()
        {
            return "This is Transaction";
        }
    }

    public class OrderRequest
    {
        public override string ToString()
        {
            return "This is OrderRequest";
        }
    }

    public class Order
    {
        public override string ToString()
        {
            return "This is Order";
        }
    }
}