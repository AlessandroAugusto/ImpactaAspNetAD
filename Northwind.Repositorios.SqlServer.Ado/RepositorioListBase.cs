using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class RepositorioListBase
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

        public delegate Transportadora MapearDelegate(SqlDataReader registro);

        public void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    comando.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    return comando.ExecuteScalar();
                }
            }
        }

        public List<Transportadora> ExecuteReader(String nomeProcedure, MapearDelegate metodoMapeamento, params SqlParameter[] parametros)
        {
            var transportadoras = new List<Transportadora>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            transportadoras.Add(metodoMapeamento(registro));
                        }
                    }
                }
            }
            return transportadoras;
        }
    }
}