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
                         Any.Instance<byte[]>(),
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

    public class GroupByLokasiQueryHandler
    {
        private readonly SkillTestContext _context;

        public GroupByLokasiQueryHandler(SkillTestContext context)
        {
            _context = context;
        }

        public List<GroupByLokasiDto> Handle(GroupByLokasiQuery query)
        {
            var result = (from lokasi in _context.Lokasi
                select new GroupByLokasiDto()
                {
                    LokasiID = lokasi.ID,
                    Deskripsi = lokasi.Deskripsi,
                    Lines = (from data in _context.Data
                            where lokasi.ID == data.LokasiID
                            select new DataDto()
                            {
                                DataID = data.ID,
                                Judul = data.Judul,
                                Keterangan = data.Keterangan,
                                Foto = data.Foto,
                                LokasiID = data.LokasiID,
                            }).ToList()
                }).ToList();

            return result;
        }
    }
}