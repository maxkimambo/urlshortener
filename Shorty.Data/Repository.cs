using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Shorty.Data
{
    public interface IRepository
    {
        IEnumerable<UserUrl> GetAll(); 
        UserUrl GetById(int id);
        UserUrl SaveUrl(UserUrl userUrl);
        bool DeleteUrl(UserUrl userUrl);
        bool DeleteUrl(int id);
        IEnumerable<UserUrl> GetExpiredUrls(DateTime expiryDate);
        void Dispose(bool disposing);
        void Dispose();
    }

    public class Repository : IDisposable, IRepository
    {
        private readonly Context _context;

        public Repository(Context context )
        {
            _context = context;
            //_context.Database.CreateIfNotExists(); 
            
        }

        public IEnumerable<UserUrl> GetAll()
        {
            return _context.Urls; 
        }
        public UserUrl GetById(int id)
        {
            var result = _context.Urls.Find(id);

            return result; 
        }
        
        public UserUrl SaveUrl(UserUrl userUrl)
        {

            if (userUrl.Id == 0)
            {
                _context.Urls.Add(userUrl);
            }
            else
            {
                _context.Entry(userUrl).State = EntityState.Modified; 
            }
          
            var result = _context.SaveChanges();

            return userUrl; 
        }

        public bool DeleteUrl(UserUrl userUrl)
        {
            _context.Urls.Remove(userUrl);
            var operationResult = _context.SaveChanges();

            return operationResult > 0; 
        }

        public bool DeleteUrl(int id)
        {
          var result = _context.Urls.Find(id);
            return DeleteUrl(result); 
        }

        public IEnumerable<UserUrl> GetExpiredUrls(DateTime expiryDate)
        {
            var results = _context.Urls.Where(u => u.ExpiresOn < expiryDate).ToList();
            return results; 
        }

        private bool _disposed = false; 

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true; 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
