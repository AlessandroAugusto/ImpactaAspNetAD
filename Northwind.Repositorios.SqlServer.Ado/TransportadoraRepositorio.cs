using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class TransportadoraRepositorio
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;
        
        public List<Transportadora> Selecionar()
        {
            var transportadoras = new List<Transportadora>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TransportadoraSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            transportadoras.Add(Mapear(registro));
                        }
                    }
                }
            }

            return transportadoras;
        }

        public Transportadora Selecionar(int id)
        {
            Transportadora transportadora = null;

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TransportadoraSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@shipperId", id));

                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            transportadora = Mapear(registro);
                        }
                    }
                }
            }

            return transportadora;
        }

        public void Inserir(Transportadora transportadora)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TransportadoraInserir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(transportadora));

                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            transportadora = Mapear(registro);
                        }
                    }
                }
            }
        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            throw new NotImplementedException();
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
