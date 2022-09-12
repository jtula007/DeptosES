using DeptosES.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.AccesoADatos
{
    public class MunicipioDAL
    {
        public static async Task<int> CrearAsync(Municipio pMunicipio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMunicipio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Municipio pMunicipio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var municipio = await bdContexto.Municipio.FirstOrDefaultAsync(s => s.Id == pMunicipio.Id);
                municipio.IdDepartamento = pMunicipio.IdDepartamento;
                municipio.Nombre = pMunicipio.Nombre;
                municipio.Descripcion = pMunicipio.Descripcion;
                municipio.Imagen = pMunicipio.Imagen;
                bdContexto.Update(municipio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Municipio pMunicipio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var municipio = await bdContexto.Municipio.FirstOrDefaultAsync(s => s.Id == pMunicipio.Id);
                bdContexto.Municipio.Remove(municipio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Municipio> ObtenerPorIdAsync(Municipio pMunicipio)
        {
            var municipio = new Municipio();
            using (var bdContexto = new BDContexto())
            {
                municipio = await bdContexto.Municipio.FirstOrDefaultAsync(s => s.Id == pMunicipio.Id);
            }
            return municipio;
        }

        public static async Task<List<Municipio>> ObtenerTodosAsync()
        {
            var municipios = new List<Municipio>();
            using (var bdContexto = new BDContexto())
            {
                municipios = await bdContexto.Municipio.ToListAsync();
            }
            return municipios;
        }

        internal static IQueryable<Municipio> QuerySelect(IQueryable<Municipio> pQuery, Municipio pMunicipio)
        {
            if (pMunicipio.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMunicipio.Id);
            if (pMunicipio.IdDepartamento > 0)
                pQuery = pQuery.Where(s => s.IdDepartamento == pMunicipio.IdDepartamento);
            if (!string.IsNullOrWhiteSpace(pMunicipio.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pMunicipio.Nombre));
            if (!string.IsNullOrWhiteSpace(pMunicipio.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pMunicipio.Descripcion));            
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pMunicipio.Top_Aux > 0)
                pQuery = pQuery.Take(pMunicipio.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Municipio>> BuscarAsync(Municipio pMunicipio)
        {
            var municipios = new List<Municipio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Municipio.AsQueryable();
                select = QuerySelect(select, pMunicipio);
                municipios = await select.ToListAsync();
            }
            return municipios;
        }

        public static async Task<List<Municipio>> BuscarIncluirDepartamentosAsync(Municipio pMunicipio)
        {
            var municipios = new List<Municipio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Municipio.AsQueryable();
                select = QuerySelect(select, pMunicipio).Include(s => s.Departamento).AsQueryable();
                municipios = await select.ToListAsync();
            }
            return municipios;
        }
    }
}
