using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SkillTest.Core
{
    public class DataQueryHandler :
     IQueryHandler<DataSingleByIdQuery, Data>,
     IQueryHandler<DataListQuery,List<DataDto>>
    {
        private readonly ISkillTestContext _context;

        public DataQueryHandler(ISkillTestContext context)
        {
            _context = context;
        }

        public Data Handle(DataSingleByIdQuery args)
        {
            return GetDataById(args.DataID);
        }

        public List<DataDto> Handle(DataListQuery args)
        {
            return _context.Data.AsNoTracking().Select(x=> new DataDto()
            {
                DataID = x.ID,
                Judul = x.Judul,
                Keterangan = x.Keterangan,
                Foto = x.Foto,
                LokasiID = x.LokasiID
            }).ToList();
        }

        private Data GetDataById(long id)
        {
            var result = _context.Data.AsNoTracking().ToList().SingleOrDefault(x=>x.ID == id);
            return result;
        }
    }
}