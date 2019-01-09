using Projeto_Stefanini.DAO;
using Projeto_Stefanini.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Stefanini.BLL
{
    public class InserirBLL
    {
        public static InserirMDL Inserir(InserirMDL Parametro)
        {
            return InserirDAO.insert(Parametro);
        }
    }
}
