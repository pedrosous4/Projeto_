using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Projeto_Stefanini.MDL
{
    public class InserirMDL
    {
        public HttpPostedFileBase Anexo { get; set; }
        public int IDArquivo { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        public int id { get; set; }
    }
}
