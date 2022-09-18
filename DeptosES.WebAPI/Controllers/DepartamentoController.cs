using DeptosES.EntidadesDeNegocio;
using DeptosES.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeptosES.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartamentoController : ControllerBase
    {
        private DepartamentoBL deptoBL = new DepartamentoBL();

        [HttpGet]
        public async Task<IEnumerable<Departamento>> Get()
        {
            return await deptoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Departamento> Get(int id)
        {
            Departamento depto = new Departamento();
            depto.Id = id;
            return await deptoBL.ObtenerPorIdAsync(depto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Departamento departamento)
        {
            try
            {
                await deptoBL.crearAsync(departamento);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Departamento departamento)
        {

            if (departamento.Id == id)
            {
                await deptoBL.ModificarAsync(departamento);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Departamento depto = new Departamento();
                depto.Id = id;
                await deptoBL.EliminarAsync(depto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Departamento>> Buscar([FromBody] object pDepartamento)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDepto = JsonSerializer.Serialize(pDepartamento);
            Departamento depto = JsonSerializer.Deserialize<Departamento>(strDepto, option);
            return await deptoBL.BuscarAsync(depto);
        }
    }
}
