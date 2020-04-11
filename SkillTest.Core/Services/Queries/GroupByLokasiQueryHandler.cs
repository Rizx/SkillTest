using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace SkillTest.Core
{
    public class GroupByLokasiQueryHandler:
        IQueryHandler<GroupByLokasiQuery,List<GroupByLokasiDto>>
    {
        private readonly ISkillTestContext _context;

        public GroupByLokasiQueryHandler(ISkillTestContext context)
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
                            }).AsNoTracking().ToList()
                }).AsNoTracking().ToList();

            return result;
        }
    }
}