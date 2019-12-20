using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Model;
using DAL.Interfaces;

namespace BLL
{
    public class DBDataOperation: IDbCrud
    {
        public IDbRepos db;
        public Service.OutService serOut;
        public Service.ChitatelService serSt;
        

        public DBDataOperation(IDbRepos repos)
        {
            db = repos;
            serOut = new Service.OutService();
        }

        public List<Model.Out> Find(int st, int book)
        {
            List<Model.Out> tmp = GetAllOut();
            return serOut.Find(st, book, tmp);
        }

        public List<Model.Out> Find(List<Model.Out> list)
        {
            return serOut.Find(list);
        }

        public List<Model.Book> GetAllBook()
        {
            return db.Book.GetList().Select(i => new Model.Book(i,db.Izdatelstvo.GetItem(i.Izdatelstvo_id),db.Book_status.GetItem(i.Status_id),db.Rubrika.GetItem(i.Rubrika_id))).ToList();
        }

        public IEnumerable<IGrouping<string, Model.Book>> GetAllBookGroup()
        {
            return db.Book.GetList().Select(i => new Model.Book(i, db.Izdatelstvo.GetItem(i.Izdatelstvo_id), db.Book_status.GetItem(i.Status_id), db.Rubrika.GetItem(i.Rubrika_id))).ToList().GroupBy(i => (i.Name+i.Rubrika_id+i.Autor+i.Annot+i.Izdatelstvo_id));
        }

        public List<Model.Out> GetAllOut()                 
        {
            //return null;
            return db.Out.GetList().Select(i => new Model.Out(i, db.Book.GetItem(i.Id_book), db.Chitatel.GetItem(i.Id_chit), db.Outtype.GetItem(i.Outtype_id))).ToList();
        }

        public Model.Book GetBook(int BookId)
        {
           
            DAL.Book tmp= db.Book.GetItem(BookId);
            return new Model.Book(tmp, db.Izdatelstvo.GetItem(tmp.Izdatelstvo_id), db.Book_status.GetItem(tmp.Status_id), db.Rubrika.GetItem(tmp.Rubrika_id));
        }

        public void CreateBook(Model.Book p)
        {
            db.Book.Create(new DAL.Book { Name = p.Name, Autor = p.Autor,Annot=p.Annot, Status_id=p.Status_id,Rubrika_id=p.Rubrika_id,God=p.God,Izdatelstvo_id=p.Izdatelstvo_id });
            
        }

        public void CreateChitatel(Model.Chitatel p)
        {
            db.Chitatel.Create(new DAL.Chitatel { Nomer_chit=p.Nomer_chit, FIO=p.FIO,Telephone=p.Telephone,Adress=p.Adress,Status_id=p.Status_id  });
            
        }

        public void CreateOut(Model.Out p)
        {
            db.Out.Create(new DAL.Out { Id_book= p.Id_book, Id_chit = p.Id_chit, Date = DateTime.Now,Outtype_id=p.Outtype_id });
            Book_status_change(GetBook(p.Id_book), p.Outtype_id);

        }

        public void Book_status_change(Model.Book p, int stat_id)
        {
            DAL.Book tmp = db.Book.GetItem(p.Id);
            tmp.Status_id = stat_id;
            db.Book.Update(tmp);
            Save();
        }

        public void UpdateBook(Model.Book p)
        {
            DAL.Book tmp = db.Book.GetItem(p.Id);
            tmp.Status_id = 1;
            db.Book.Update(tmp);
            Save();
        }

        public void UpdateChit(Model.Chitatel p)
        {
            DAL.Chitatel tmp= db.Chitatel.GetItem(p.Id);
            tmp.Nomer_chit = p.Nomer_chit;
            tmp.FIO = p.FIO;
            tmp.Status_id = p.Status_id;
            tmp.Telephone = p.Telephone;
            tmp.Adress = p.Adress;
            db.Chitatel.Update(tmp);
            Save();
            //db.Chitatel.Update(new DAL.Chitatel {Id=p.Id,FIO=p.FIO,Nomer_chit=p.Nomer_chit,Adress=p.Adress,Telephone=p.Telephone,Status_id=p.Status_id });
        }
        public bool Save()
        {
            if (db.Save() > 0) return true; else return false;
        }
        public void DeleteBook(int id)
        {
            db.Book.Delete(id);
        }

        public Model.Out GetOut(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOut(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Chitatel> GetAllChit()
        {
            return db.Chitatel.GetList().Select(i => new Model.Chitatel(i,db.Chitatel_status.GetItem(i.Status_id), Find(i.Nomer_chit,-1),Find(Find(i.Nomer_chit, -1)).Select(j=>new Model.Book(db.Book.GetItem(j.Id_book),db.Izdatelstvo.GetItem(db.Book.GetItem(j.Id_book).Izdatelstvo_id),db.Book_status.GetItem(db.Book.GetItem(j.Id_book).Status_id),db.Rubrika.GetItem(db.Book.GetItem(j.Id_book).Rubrika_id))).ToList())).ToList();
        }
        public void Create_stat_book(Model.Book_status bs)
        {
            db.Book_status.Create(new DAL.Book_status {  Name = bs.Name });
        }

        public void Create_stat_chit(Model.Chitatel_status chs)
        {
            db.Chitatel_status.Create(new DAL.Chitatel_status { Name = chs.Name });
        }

        public void Create_izdat(Model.Izdatelstvo iz)
        {
            db.Izdatelstvo.Create(new DAL.Izdatelstvo { Name=iz.Name }) ;
        }
        public void Create_rubrika(Model.Rubrika r)
        {
            db.Rubrika.Create(new DAL.Rubrika { Name=r.Name,Head_id=r.Head_id }) ;
        }
        public Model.Chitatel GetChitatel(int id)
        {
            throw new NotImplementedException();
        }
        public void Create_Outtype(Model.Outtype o)
        {
            db.Outtype.Create(new DAL.Outtype { Name = o.Name });
        }
        public List<Model.Rubrika> GetAllRubrikas()
        {
            return db.Rubrika.GetList().Select(i => new Model.Rubrika(i.Id, i.Name, i.Head_id)).ToList();
        }

        public List<Model.Izdatelstvo> GetAllIzdatelstvs()
        {
            return db.Izdatelstvo.GetList().Select(i => new Model.Izdatelstvo(i.Id, i.Name)).ToList();
        }

        public List<Model.Chitatel_status> GetAllChitatelStatus()
        {
            return db.Chitatel_status.GetList().Select(i => new Model.Chitatel_status { Id = i.Id, Name = i.Name }).ToList();
        }
    }
}
