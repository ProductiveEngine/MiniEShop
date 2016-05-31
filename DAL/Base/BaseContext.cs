using System.Data.Entity;

namespace DAL.Base
{
    public class BaseContext<TContext>
        : DbContext where TContext : DbContext
    {
        static BaseContext()
        {            
            Database.SetInitializer<TContext>(null);           
        }
        protected BaseContext()
            : base("name=MEDB")
        {            
            // base("Data Source=SERVER;Initial Catalog=TABLE;Persist Security Info=True;User ID=USERNAME;Password=PASSWORD;MultipleActiveResultSets=True")
        }
    }
}
