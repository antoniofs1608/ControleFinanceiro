using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly Contexto _contexto; //private readonly ITipoRepositorio _tipoRepositorio;

        //public TiposController(ITipoRepositorio tipoRepositorio)
        //{
        //    _tipoRepositorio = tipoRepositorio;
        //}
        public TiposController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Tipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos()
        {
            //return await _tipoRepositorio.PegarTodos().ToListAsync();
            return await _contexto.Tipos.ToListAsync();
        }
    }
}
