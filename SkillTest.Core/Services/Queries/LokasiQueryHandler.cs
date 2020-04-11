using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SkillTest.Core
{
    public class LokasiQueryHandler :
    IQueryHandler<LokasiListQuery, List<LokasiDto>>
    {
        private readonly SkillTestContext _context;
        public LokasiQueryHandler(SkillTestContext context)
        {
            _context = context;
        }

        public List<LokasiDto> Handle(LokasiListQuery args)
        {
            return _context.Lokasi.AsNoTracking()
            .Select( x=> new LokasiDto()
            {
                LokasiID = x.ID,
                Deskripsi = x.Deskripsi,
            })
            .ToList();
        }
        
    }
}