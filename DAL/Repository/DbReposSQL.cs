using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private Context db;
        private BookRepositorySQL bookRepository;
        private Book_statusRepositorySQL book_statusRepository;
        private OutRepositorySQL outRepository;
        private OuttypeRepositorySQL outtypeRepository;
        private ChitatelRepositorySQL chitatelRepository;
        private Chitatel_statusRepositorySQL chitatel_statusRepository;
        private IzdatelstvoRepositorySQL izdatelstvoRepository;
        private RubrikaRepositorySQL rubrikaRepository;

        public DbReposSQL()
        {
            db = new Context();
        }

        public IRepository<Book> Book
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepositorySQL(db);
                return bookRepository;
            }
        }

        public IRepository<Book_status> Book_status
        {
            get
            {
                if (book_statusRepository == null)
                    book_statusRepository = new Book_statusRepositorySQL(db);
                return book_statusRepository;
            }
        }

        public IRepository<Out> Out
        {
            get
            {
                if (outRepository == null)
                    outRepository = new OutRepositorySQL(db);
                return outRepository;
            }
        }

        public IRepository<Outtype> Outtype
        {
            get
            {
                if (outtypeRepository == null)
                    outtypeRepository = new OuttypeRepositorySQL(db);
                return outtypeRepository;
            }
        }

        public IRepository<Izdatelstvo> Izdatelstvo
        {
            get
            {
                if (izdatelstvoRepository == null)
                    izdatelstvoRepository = new IzdatelstvoRepositorySQL(db);
                return izdatelstvoRepository;
            }
        }

        public IRepository<Rubrika> Rubrika
        {
            get
            {
                if (rubrikaRepository == null)
                    rubrikaRepository = new RubrikaRepositorySQL(db);
                return rubrikaRepository;
            }
        }

        public IRepository<Chitatel> Chitatel
        {
            get
            {
                if (chitatelRepository == null)
                    chitatelRepository = new ChitatelRepositorySQL(db);
                return chitatelRepository;
            }
        }

        public IRepository<Chitatel_status> Chitatel_status
        {
            get
            {
                if (chitatel_statusRepository == null)
                    chitatel_statusRepository = new Chitatel_statusRepositorySQL(db);
                return chitatel_statusRepository;
            }
        }


        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
