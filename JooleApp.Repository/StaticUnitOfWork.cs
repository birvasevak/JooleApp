using JooleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleApp.Repository
{
    class StaticUnitOfWork : IDisposable
    {
        private static JooleAppEntities context = null;

        private StaticUnitOfWork(){
            context = new JooleAppEntities();
        }

        public static JooleAppEntities getContext()
        {
            if(context == null)
            {
                context = new JooleAppEntities();
            }
            return context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();

        }
    }
}
