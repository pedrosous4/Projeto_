using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_Stefanini.MDL;
using Projeto_Stefanini.BLL;

namespace Projeto_Stefanini.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir()
        {
            int arquivosSalvos = 0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase arquivo = Request.Files[i];

                if (arquivo.ContentLength > 0)
                {
                    string nome = Path.GetFileName(arquivo.FileName);
                    string caminhoArquivo = Path.Combine(Path.GetDirectoryName(arquivo.FileName), nome);

                    
                    InserirMDL Parametro = new InserirMDL();
                    Parametro.Nome = nome;
                    Parametro.Caminho = caminhoArquivo;

                    InserirMDL objReturn = InserirBLL.Inserir(Parametro);

                    /*mensagens de retorno*/

                    arquivosSalvos++;
                }
            }

            return View("Index");
        }
    }
}