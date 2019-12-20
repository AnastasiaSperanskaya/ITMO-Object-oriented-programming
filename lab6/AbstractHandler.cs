using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public abstract class AbstractHandler : IHandler
    {
        protected IHandler NextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this.NextHandler = handler;

            return handler;
        }

        public virtual object Handle(object request)
        {
            return NextHandler?.Handle(request);
        }
    }
}