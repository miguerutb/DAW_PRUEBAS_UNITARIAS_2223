using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {

        [TestMethod]
        public void validarReintegroNormal()
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
        public void validarIngreso1()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = -100;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarIngreso(ingreso);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarIngreso2()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = -1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarIngreso(ingreso); 
                
            } catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarIngreso3()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = -200;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarIngreso(ingreso);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarIngreso4()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = 1;
            double saldoEsperado = 1001;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.realizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error.");
        }

        [TestMethod]
        public void validarIngreso5()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = 100;
            double saldoEsperado = 1100;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.realizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error.");
        }
    }
}
