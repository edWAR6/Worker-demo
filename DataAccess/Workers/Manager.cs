using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Workers
{
    public class Manager
    {
        protected DataAccessContext context = new DataAccessContext();

        public virtual bool Create()
        {
            throw new NotImplementedException();
        }

        public virtual bool Update()
        {
            throw new NotImplementedException();
        }

        public virtual bool Detele()
        {
            throw new NotImplementedException();
        }

        public virtual Manager Get(int ID)
        {
            throw new NotImplementedException();
        }

        public virtual List<Manager> List()
        {
            throw new NotImplementedException();
        }

        protected void Dispose()
        {
            context.Dispose();
        }
    }
}