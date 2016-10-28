using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class TransactionProcessor
    {
        private Func<TransactionRequest, bool> check;
        private Func<TransactionRequest, Transaction> register;
        private Action<Transaction> save;

        public TransactionProcessor(Func<TransactionRequest, bool> check, Func<TransactionRequest, Transaction> register, Action<Transaction> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }

        public Transaction Process(TransactionRequest request)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request);
            save(result);
            return result;
        }
    }
}
