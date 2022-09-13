using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeptosES.AccesoADatos;
using DeptosES.EntidadesDeNegocio;

namespace DeptosES.LogicaDeNegocio
{
    public class DepartamentoBL
    {
        public async Task<int> crearAsync(Departamento pDepartamento)
        {
            return await DepartamentoDAL.CrearAsync(pDepartamento);
        }

        public async Task<int> ModificarAsync(Departamento pDepartamento)
        {
            return await DepartamentoDAL.ModificarAsync(pDepartamento);
        }

        public async Task<int> EliminarAsync(Departamento pDepartamento)
        {
            return await DepartamentoDAL.EliminarAsync(pDepartamento);
        }

        public async Task<Departamento> ObtenerPorIdAsync(Departamento pDepartamento)
        {
            return await DepartamentoDAL.ObtenerPorIdAsync(pDepartamento);
        }

        public async Task<List<Departamento>> ObtenerTodosAsync()
        {
            return await DepartamentoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Departamento>> BuscarAsync(Departamento pDepartamento)
        {
            return await DepartamentoDAL.BuscarAsync(pDepartamento);
        }
    }
}
