using Northwind.Dominio;
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
    public class TransportadoraRepositorio : RepositorioListBase
    {
        private String _stringConexao =
            ConfigurationManager
                .ConnectionStrings["NorthwindConnectionString"]
                .ConnectionString;

        public List<Transportadora> Selecionar()
        {
            return ExecuteReader("TransportadoraSelecionar", Mapear);
        }

        public Transportadora Selecionar(Int32 id)
        {
            return ExecuteReader(
                "TransportadoraSelecionar", 
                Mapear, 
                new SqlParameter("@ShipperID", id)
                ).SingleOrDefault();
           
        }

        public void Inserir(Transportadora transportadora)
        {

            transportadora.Id = Convert.ToInt32(ExecuteScalar("TransportadoraInserir", Mapear(transportadora)));
        }

        public void Atualizar(Transportadora transportadora)
        {

            ExecuteNomQuery("TransportadoraAtualizar", Mapear(transportadora));
        }

        public void Excluir(Int32 id)
        {
            ExecuteNomQuery("TransportadoraExcluir", new SqlParameter("@ShipperID", id));
        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            //SqlParameter[] parametros = new List<SqlParameter>();
            var parametros = new List<SqlParameter>() {
                new SqlParameter("@companyName", transportadora.Nome),
                new SqlParameter("@phone",transportadora.Telefone)
            };

            if (transportadora.Id > 0)
            {
                parametros.Add(new SqlParameter("@ShipperID", transportadora.Id));
            }

            return parametros.ToArray();
        }

        private Transportadora Mapear(SqlDataReader registro)
        {
            return new Transportadora()
            {
                Id = Convert.ToInt32(registro["ShipperID"]),
                Nome = registro["CompanyName"].ToString(),
                Telefone = Convert.ToString(registro["Phone"])
            };
        }
    }
}
