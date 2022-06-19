using Library.Context;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private LibraryDBContext context = new LibraryDBContext();

        private GenericRepository<Student> studentRepository;
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Borrow> borrowRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }
        public GenericRepository<Book> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                }
                return bookRepository;
            }
        }
        public GenericRepository<Borrow> BorrowRepository
        {
            get
            {

                if (this.borrowRepository == null)
                {
                    this.borrowRepository = new GenericRepository<Borrow>(context);
                }
                return borrowRepository;
            }
        }
        //

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
