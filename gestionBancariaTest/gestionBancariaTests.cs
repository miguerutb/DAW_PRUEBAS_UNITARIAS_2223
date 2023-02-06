using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        [TestMethod]
        public void validarIngresoArray1()
        {
            // Preparación
            double saldoInicial = 1000;
            double[] ingresos = { -100, -1, 0 };


            for (int i = 0; i < ingresos.Length; i++)
            {
                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.realizarIngreso(ingresos[i]);
                    Assert.Fail("Error. Se deberia haber producido una excepcion.");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                }
            }
        }

        [TestMethod]
        public void validarIngreso2()
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
        public void validarIngreso3()
        {
            //preparacion
            double saldoInicial = 1000;
            double ingreso = 100;
            double saldoEsperado = 1100;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.realizarIngreso(ingreso);

            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error.");
        }

        [TestMethod]
        public void validarReintegroArray1()
        {
            //preparacion
            double saldoInicial = 1000;
            double[] reintegro = { -100, -1, 0 };


            for (int i = 0; i < reintegro.Length; i++)
            {
                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.realizarReintegro(reintegro[i]);
                    Assert.Fail("Error. Se deberia haber producido una excepcion.");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                }
            }
        }

        [TestMethod]
        public void validarReintegro2()
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
        public void validarReintegro3()
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
        public void validarReintegroArray4()
        {
            //preparacion
            double saldoInicial = 1000;
            double[] reintegro = { saldoInicial + 1, saldoInicial + 1100 };


            for (int i = 0; i < reintegro.Length; i++)
            {
                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

                try
                {
                    miApp.realizarReintegro(reintegro[i]);
                    Assert.Fail("Error. Se deberia haber producido una excepcion.");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                }
            }
        }
    }
}
