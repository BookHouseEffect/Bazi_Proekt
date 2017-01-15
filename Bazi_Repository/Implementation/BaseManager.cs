using System;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class BaseManager
    {
        protected Db201617zVaProektRnabDataContext Context;

        protected BaseManager()
        {
            Context = new Db201617zVaProektRnabDataContext();
        }
    }
}
