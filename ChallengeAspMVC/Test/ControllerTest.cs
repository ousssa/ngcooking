using ChallengeAspMVC.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Test
{
    [TestFixture]
    public class ControllerTest
    {
        IRecettesServices _recettesServices;
        public ControllerTest(IRecettesServices recettesServices)
        {
            _recettesServices = recettesServices;
        }
        [Test]
        public void TestAdd()
        {
            var recette = _recettesServices.GetRecette("1");
            Assert.That(recette.ID == "1");
        }
    }
}