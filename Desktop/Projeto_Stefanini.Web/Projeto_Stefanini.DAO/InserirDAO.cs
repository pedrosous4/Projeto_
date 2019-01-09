using Projeto_Stefanini.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Stefanini.DAO
{
    public class InserirDAO
    {
        public static InserirMDL insert(InserirMDL Parametro)
        {
            //definição da string de conexão
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Producao"].ConnectionString); //System.Configuration.ConfigurationManager.ConnectionStrings["Producao"].ConnectionString
            SqlCommand comando = new SqlCommand("PR_Projeto_Insert", conn);
            comando.CommandType = CommandType.StoredProcedure;

            InserirMDL Retorno = new InserirMDL();

            try
            {
               
                comando.Parameters.Add(new SqlParameter("@PASTA", Parametro.Caminho));
                
                if(Parametro.Nome == "ARQUIVO1-PLENO.TXT"){
                    comando.Parameters.Add(new SqlParameter("@TABELA", "TBL_PROJETO_USUARIO"));
                }
                else{
                    comando.Parameters.Add(new SqlParameter("@TABELA", "TBL_PROJETO_PRODUTO"));
                }
               
                comando.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader sqlRead = comando.ExecuteReader();

                while (sqlRead.Read())
                {
                    Retorno.id = int.Parse(sqlRead["Retorno"].ToString());
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return Retorno;
        }
    }
}
