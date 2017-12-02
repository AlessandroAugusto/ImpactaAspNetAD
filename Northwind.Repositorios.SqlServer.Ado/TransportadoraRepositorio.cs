using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class TransportadoraRepositorio : RepositorioListBase
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;
        
        public List<Transportadora> Selecionar()
        {
            return base.ExecuteReader("TransportadoraSelecionar", Mapear);

        }

        public Transportadora Selecionar(int id)
        {
            return base.ExecuteReader("TransportadoraSelecionar", Mapear, new SqlParameter("@shipperId", id)).SingleOrDefault();
        }

        public void Inserir(Transportadora transportadora)
        {
            transportadora.Id = Convert.ToInt32(base.ExecuteScalar("TransportadoraInserir", Mapear(transportadora)));
        }

        public void Atualizar(Transportadora transportadora)
        {
            base.ExecuteNonQuery("TransportadoraAtualizar", Mapear(transportadora));
        }

        public void Excluir(int id)
        {
            base.ExecuteNonQuery("TransportadoraExcluir", new SqlParameter("@shipperId", id));

        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            var parametros = new List<SqlParameter>();

            if(transportadora.Id != 0)
            {
                parametros.Add(new SqlParameter("@shipperId", transportadora.Id));
            }

            parametros.Add(new SqlParameter("@companyName", transportadora.Nome));
            parametros.Add(new SqlParameter("@phone", transportadora.Telefone));

            return parametros.ToArray();
        }

        private Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();

            transportadora.Id = Convert.ToInt32(registro["ShipperId"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = Convert.ToString(registro["Phone"]);

            return transportadora;
        }
    }
}
