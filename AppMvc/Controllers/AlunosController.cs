using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMvc.Models;

namespace AppMvc.Controllers {

    public class AlunosController : Controller {
        
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alunos
        [HttpGet]
        [Route("listar-alunos")]
        public async Task<ActionResult> Index() {
            return View(await db.Alunos.ToListAsync());
        }

        // GET: Alunos/Details/5
        [HttpGet]
        [Route("aluno-detalhe/{id:int}")]
        public async Task<ActionResult> Details(int? id) {
            
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null) return HttpNotFound();
            
            return View(model: aluno);

        }

        // GET: Alunos/Create
        [HttpGet]
        [Route("novo-aluno")]
        public ActionResult Create() {
            return View();
        }

        // POST: Alunos/Create
        #region comment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        #endregion
        [HttpPost]
        [Route("novo-aluno")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,CPF,DataMatricula,Ativo")] Aluno aluno) {

            if (ModelState.IsValid) {
                db.Alunos.Add(aluno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        [HttpGet]
        [Route("editar-aluno/{id:int}")]
        public async Task<ActionResult> Edit(int? id) {
            
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null) return HttpNotFound();
            
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        #region comment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        #endregion
        [HttpPost]//[Route("editar-aluno/")] --> assim dá erro.
        [Route("editar-aluno/{id:int}")] //mesmo não tendo id no parâmetro, tem que adicionar no attribute route, pois a rota HttpGet e rota HttpPost têm que ser a mesma.
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,CPF,DataMatricula,Ativo")] Aluno aluno) {

            if (ModelState.IsValid) {
                db.Entry(aluno).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Delete/5
        [HttpGet]
        [Route("excluir-aluno/{id:int}")]
        public async Task<ActionResult> Delete(int? id) {
            
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var aluno = await db.Alunos.FindAsync(id);
            
            if (aluno == null) return HttpNotFound();
            
            return View(aluno);

        }

        // POST: Alunos/Delete/5     
        [HttpPost] //[HttpPost, ActionName("Delete")]
        [Route("excluir-aluno/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            
            var aluno = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing) {
            
            if (disposing) db.Dispose();
            
            base.Dispose(disposing);

        }

    }
}
