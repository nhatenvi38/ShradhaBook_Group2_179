using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShradhaBook.DataAccess.DbInitializer
{
    // Interface for defining database initializer classes
    public interface IDbInitializer
    {
        // Method to initialize the database
        void Initialize();
    }
}
