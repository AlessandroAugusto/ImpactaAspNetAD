using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class CategoriaRepositorio:RepositorioBase
    {
        public DataTable Selecionar()
        {
            var instrucao = @"SELECT [CategoryID]
                                    ,[CategoryName]
                                    FROM [Northwind].[dbo].[Categories]";

            return Selecionar(instrucao);
        }

    }
}
