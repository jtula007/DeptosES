using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeptosES.AccesoADatos;
using DeptosES.EntidadesDeNegocio;

namespace DeptosES.LogicaDeNegocio
{
    public class MunicipioBL
    {
        public async Task<int> CrearAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.CrearAsync(pMunicipio);
        }

        public async Task<int> ModificarAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.ModificarAsync(pMunicipio);
        }

        public async Task<int> EliminarAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.EliminarAsync(pMunicipio);
        }

        public async Task<Municipio> ObtenerPorIdAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.ObtenerPorIdAsync(pMunicipio);
        }

        public async Task<List<Municipio>> ObtenerTodosAsync()
        {
            return await MunicipioDAL.ObtenerTodosAsync();
        }

        public async Task<List<Municipio>> BuscarAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.BuscarAsync(pMunicipio);
        }

        public async Task<List<Municipio>> BuscarIncluirDepartamentosAsync(Municipio pMunicipio)
        {
            return await MunicipioDAL.BuscarIncluirDepartamentosAsync(pMunicipio);
        }
    }
}
