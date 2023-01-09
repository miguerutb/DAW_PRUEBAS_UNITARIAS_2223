using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {

        [TestMethod]
        public void validarReintegro()
        {
            //preparacion del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            //metodo a probar
            miApp.realizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        [TestMethod]
        public void validarIngreso()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = 200;
            double saldoEsperado = 1200;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            //metodo a probar
            miApp.realizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el integro, saldo incorrecto");
        }
    }
}
