using Ebd.Application.Mappers;
using Ebd.Application.Responses.Revista;
using Ebd.Domain.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

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

        [TestMethod]
        public void FromRequestToEntity_WhenNull()
        {
            var result = RevistaMapper.FromEntityToResponse((Revista)null);

            result.Should().BeNull();
        }
    }
}
