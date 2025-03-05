using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TraversalContext _context;
        private bool _disposed = false;

        public UnitOfWork(TraversalContext context)
        {
            _context = context;
        }

        public TraversalContext Context => _context;



        public void Save()
        {
            _context.SaveChanges();//veri tabanndaki tüm değişiklikleri kaydeder
        }

        // IDisposable implementasyonu
        public void Dispose()
        {
            Dispose(true);  // Dispose metodunu çağırırken true gönder
            GC.SuppressFinalize(this);  // Çöp toplayıcıya Dispose edilmesini bildirir
        }

        // Dispose işlemi
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Burada, yalnızca dispose edilmesi gereken managed kaynakları serbest bırak
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
