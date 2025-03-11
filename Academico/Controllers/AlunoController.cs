using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new List<Aluno>();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome", "Email", "Telefone", "Endereco", "Complemento", "Bairro", "Municipio", "Uf", "Cep")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoID = alunos.Count + 1;
                    alunos.Add(aluno);
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch(Exception ex)
            {
                ViewData["Erro"] = ex.Message;
                return View(aluno);
            }
        }

        public IActionResult Index()
        {
            return View(alunos);
        }
    }
}
