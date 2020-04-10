using Xunit;
using NSubstitute;
using SkillTest.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillTest.CoreTest
{
    public class LokasiTest
    {
        [Fact]
        public void TryGetLokasiListFromInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "GetLokasi")
                .Options;

            var query = Any.Instance<LokasiListQuery>();

            using (var context = new SkillTestContext(options))
            {
                for(int i = 0; i< 10; i++)
                {
                    var dummy = Any.Instance<Lokasi>();
                    context.Lokasi.Add(dummy);
                }
                context.SaveChanges();
            }

            using (var context = new SkillTestContext(options))
            {
                var handler = new LokasiQueryHandler(context);
                var actual = handler.Handle(query);

                // Assert.True(actual.Count == 0);
                Assert.True(actual.Count > 0);
            }
        }
    }
}