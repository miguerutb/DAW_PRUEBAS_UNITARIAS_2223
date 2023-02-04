using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        [TestMethod]
        public void validarReintegro1()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = -100;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarReintegro(reintegro);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarReintegro2()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = -1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarReintegro(reintegro);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarReintegro3()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = 0;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarReintegro(reintegro);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarReintegro4()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = saldoInicial - 1;
            double saldoEsperado = 1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.realizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error.");
        }

        [TestMethod]
        public void validarReintegro5()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = saldoInicial;
            double saldoEsperado = 0;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.realizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error.");
        }

        [TestMethod]
        public void validarReintegro6()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = saldoInicial + 1;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarReintegro(reintegro);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
        }

        [TestMethod]
        public void validarReintegro7()
        {
            //preparacion
            double saldoInicial = 1000;
            double reintegro = saldoInicial + 100;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarReintegro(reintegro);

            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se deberia haber producido una excepcion.");
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
