using DeptosES.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.AccesoADatos
{
    public class DepartamentoDAL
    {
        public static async Task<int> CrearAsync(Departamento pDepartamento)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDepartamento);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Departamento pDepartamento)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var departamento = await bdContexto.Departamento.FirstOrDefaultAsync(s => s.Id == pDepartamento.Id);
                departamento.Nombre = pDepartamento.Nombre;
                departamento.Zona = pDepartamento.Zona;
                bdContexto.Update(departamento);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Departamento pDepartamento)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var departamento = await bdContexto.Departamento.FirstOrDefaultAsync(s => s.Id == pDepartamento.Id);
                bdContexto.Departamento.Remove(departamento);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Departamento> ObtenerPorIdAsync(Departamento pDepartamento)
        {
            var departamento = new Departamento();
            using (var bdContexto = new BDContexto())
            {
                departamento = await bdContexto.Departamento.FirstOrDefaultAsync(s => s.Id == pDepartamento.Id);
            }
            return departamento;
        }

        public static async Task<List<Departamento>> ObtenerTodosAsync()
        {
            var departamentos = new List<Departamento>();
            using (var bdContexto = new BDContexto())
            {
                departamentos = await bdContexto.Departamento.ToListAsync();
            }
            return departamentos;
        }

        internal static IQueryable<Departamento> QuerySelect(IQueryable<Departamento> pQuery, Departamento pDepartamento)
        {
            if (pDepartamento.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pDepartamento.Id);

            if (!string.IsNullOrWhiteSpace(pDepartamento.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pDepartamento.Nombre));

            if (pDepartamento.Zona > 0)
                pQuery = pQuery.Where(s => s.Id == pDepartamento.Zona);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pDepartamento.Top_Aux > 0)
                pQuery = pQuery.Take(pDepartamento.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Departamento>> BuscarAsync(Departamento pDepartamento)
        {
            var departamentos = new List<Departamento>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Departamento.AsQueryable();
                select = QuerySelect(select, pDepartamento);
                departamentos = await select.ToListAsync();
            }
            return departamentos;
        }
    }
}
