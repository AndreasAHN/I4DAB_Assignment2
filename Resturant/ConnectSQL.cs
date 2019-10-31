using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Resturant
{
    class ConnectSQL : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=84.238.88.212;uid=I4DAB_HandIn2;pwd=I4DaB1234;database=I4DAB_HandIn2");
        }
    }
}
