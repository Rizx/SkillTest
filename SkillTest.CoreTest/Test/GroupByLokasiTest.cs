using Xunit;
using NSubstitute;
using SkillTest.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SkillTest.CoreTest
{
    public class GroupByLokasiTest
    {
        [Fact]
        public void TryGetGroupByLokasiFromInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "GetGroupByLokasi")
                .Options;

            var query = Any.Instance<GroupByLokasiQuery>();

            using (var context = new SkillTestContext(options))
            {
                for(int i = 1; i < 10; i++)
                {
                    var dummyLokasi = new Lokasi(i, Any.Instance<string>());
                    context.Lokasi.Add(dummyLokasi);

                    for (int j = 1; j < 5; j++)
                    {
                        var dummyData = new Data(Any.Instance<long>(),
                         Any.Instance<string>(),
                         Any.Instance<string>(),
                         Any.Instance<string>(),
                         dummyLokasi.ID);
                         context.Data.Add(dummyData);
                    }
                }
                context.SaveChanges();
            }

            using (var context = new SkillTestContext(options))
            {
                var handler = new GroupByLokasiQueryHandler(context);
                var actual = handler.Handle(query);

                // Assert.True(actual.Count == 0);
                Assert.True(actual.Count > 0);
            }
        }
    }
}