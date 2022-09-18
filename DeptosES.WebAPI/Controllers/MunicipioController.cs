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
    public class MunicipioController : ControllerBase
    {
        private MunicipioBL municipioBL = new MunicipioBL();

        [HttpGet]
        public async Task<IEnumerable<Municipio>> Get()
        {
            return await municipioBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Municipio> Get(int id)
        {
            Municipio municipio = new Municipio();
            municipio.Id = id;
            return await municipioBL.ObtenerPorIdAsync(municipio);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Municipio municipio)
        {
            try
            {
                await municipioBL.CrearAsync(municipio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pMunicipio)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMunicipio = JsonSerializer.Serialize(pMunicipio);
            Municipio municipio = JsonSerializer.Deserialize<Municipio>(strMunicipio, option);
            if (municipio.Id == id)
            {
                await municipioBL.ModificarAsync(municipio);
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
                Municipio municipio = new Municipio();
                municipio.Id = id;
                await municipioBL.EliminarAsync(municipio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Municipio>> Buscar([FromBody] object pMunicipio)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMunicipio = JsonSerializer.Serialize(pMunicipio);
            Municipio municipio = JsonSerializer.Deserialize<Municipio>(strMunicipio, option);
            var municipios = await municipioBL.BuscarIncluirDepartamentosAsync(municipio);
            municipios.ForEach(s => s.Departamento.Municipio = null); // Evitar la redundacia de datos
            return municipios;
        }
    }
}
