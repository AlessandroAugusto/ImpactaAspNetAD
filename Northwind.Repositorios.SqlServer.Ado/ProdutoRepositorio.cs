using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Repositorios.SqlServer.Ado
{
    public class ProdutoRepositorio : RepositorioBase
    {
        //Todo: refatorar para usar o base.selecionar
        public DataTable SelecionarPorCategoria(int categoriaId)
        {
            var instrucao = $@"SELECT [ProductID]
                                  ,[ProductName]
                                  ,[UnitPrice]
                                  ,[UnitsInStock]
                                FROM [Northwind].[dbo].[Products]
                                WHERE CategoryID = @CategoryID";

            return Selecionar(instrucao, new SqlParameter("@CategoryID", categoriaId));
        }

        public DataTable SelecionarPorFornecedor(int fornecedorId)
        {

            var instrucao = $@"SELECT [ProductID]
                                  ,[ProductName]
                                  ,[UnitPrice]
                                  ,[UnitsInStock]
                                FROM [Northwind].[dbo].[Products]
                                WHERE SupplierID = @SupplierID";

            return Selecionar(instrucao, new SqlParameter("@SupplierID", fornecedorId));
        }

    }
}
