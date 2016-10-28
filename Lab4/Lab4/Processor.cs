using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Processor<TRequest, TResult>
    {
        private Func<TRequest, bool> check;
        private Func<TRequest, TResult> register;
        private Action<TResult> save;

        public Processor(Func<TRequest, bool> check, Func<TRequest, TResult> register, Action<TResult> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }

        public TResult Process(TRequest request)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request);
            save(result);
            return result;
        }
    }
}
