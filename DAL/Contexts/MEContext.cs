using System.Data.Entity;
using DAL.Base;
using DomainClasses.Models;

namespace DAL.Contexts
{
    public interface IMEContext : IContext
    {
        IDbSet<Cart> Carts { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Member> Members { get; set; }        
        IDbSet<Product> Products { get; set; }
        IDbSet<Rating> Ratings { get; set; }
        IDbSet<Transaction> Transactions { get; set; }

    }

    public class MEContext : BaseContext<MEContext>, IMEContext
    {
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Member> Members { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Rating> Ratings { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}
