using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeptosES.AccesoADatos;
using DeptosES.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.AccesoADatos.Tests
{
    [TestClass()]
    public class DepartamentoDALTests
    {
        private static Departamento deptoInicial = new Departamento { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var depto = new Departamento();
            depto.Nombre = "Ahuachapán";
            depto.Zona = (byte)Zona_Depto.OCCIDENTAL;
            int result = await DepartamentoDAL.CrearAsync(depto);
            Assert.AreNotEqual(0, result);
            deptoInicial.Id = depto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var depto = new Departamento();
            depto.Id = deptoInicial.Id;
            depto.Nombre = "Santa Ana";
            depto.Zona = (byte)Zona_Depto.OCCIDENTAL;
            int result = await DepartamentoDAL.ModificarAsync(depto);
            Assert.AreNotEqual(0, result);
        }        

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var depto = new Departamento();
            depto.Id = deptoInicial.Id;
            var resultDepto = await DepartamentoDAL.ObtenerPorIdAsync(depto);
            Assert.AreEqual(depto.Id, resultDepto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultDeptos = await DepartamentoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultDeptos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var depto = new Departamento();
            depto.Nombre = "a";
            depto.Top_Aux = 10;
            var resultDeptos = await DepartamentoDAL.BuscarAsync(depto);
            Assert.AreNotEqual(0, resultDeptos.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var depto = new Departamento();
            depto.Id = deptoInicial.Id;
            int result = await DepartamentoDAL.EliminarAsync(depto);
            Assert.AreNotEqual(0, result);
        }
    }
}