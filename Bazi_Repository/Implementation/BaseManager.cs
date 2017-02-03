using System;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public abstract class BaseManager
    {
        protected Db201617zVaProektRnabDataContext Context;

        protected BaseManager()
        {
            this.Context = new Db201617zVaProektRnabDataContext();
        }

        protected BaseManager(Db201617zVaProektRnabDataContext existingContext)
        {
            this.Context = existingContext;
        }
    }
}
