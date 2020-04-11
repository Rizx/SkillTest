using System.Linq;
using Microsoft.EntityFrameworkCore;
using CSharpFunctionalExtensions;

namespace SkillTest.Core
{
    public class DataCommandHandler :
        ICommandHandler<DataCreateCommand>,
        ICommandHandler<DataUpdateCommand>,
        ICommandHandler<DataUpdateJudulCommand>,
        ICommandHandler<DataDeleteCommand>
    {
        private readonly ISkillTestContext _context;

        public DataCommandHandler(ISkillTestContext context)
        {
            _context = context;
        }

        public Result Handle(DataCreateCommand args)
        {
            var data = ConvertToModel(args);
            _context.Data.Add(data);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Handle(DataUpdateCommand args)
        {
            var data = ConvertToModel(args);
            var old =_context.Data.AsNoTracking().ToList()
                .SingleOrDefault(x=>x.ID == args.ID);

            old.Change(data);
            _context.Data.Update(old);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Handle(DataUpdateJudulCommand args)
        {
            var data = ConvertToModel(args);
            var old =_context.Data.AsNoTracking().ToList()
                .SingleOrDefault(x=>x.ID == args.ID);

            old.GantiJudul(data);
            _context.Data.Update(old);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Handle(DataDeleteCommand args)
        {
            var old =_context.Data.AsNoTracking().ToList()
                .SingleOrDefault(x=>x.ID == args.ID);

            _context.Data.Remove(old);
            _context.SaveChanges();
            return Result.Ok();
        }

        private Data ConvertToModel(DataCreateCommand dto)
        {
            return new Data(dto.ID,dto.Judul, dto.Keterangan, dto.Foto, dto.LokasiID);
        }

        private Data ConvertToModel(DataUpdateCommand dto)
        {
            return new Data(dto.ID, dto.Keterangan, dto.Foto, dto.LokasiID);
        }

        private Data ConvertToModel(DataUpdateJudulCommand dto)
        {
            return new Data(dto.ID, dto.Judul);
        }
    }

}