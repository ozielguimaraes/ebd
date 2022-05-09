using Ebd.Application.Mappers;
using Ebd.Application.Responses.Revista;
using Ebd.Domain.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebd.Application.Tests.Mappers
{
    [TestClass]
    public class RevistaMapperTest
    {
        [TestMethod]
        public void FromRequestToEntity()
        {
            var result = RevistaMapper.FromEntityToResponse(new Revista(1, 10, "Test Unit", 2022, 2));

            result.Should().BeEquivalentTo(new RevistaResponse(1, 10, "Test Unit", 2022, 2));
        }
    }
}
