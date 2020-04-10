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

        public void Handle(DataCreateCommand args)
        {
            var data = ConvertToModel(args);
            _context.Data.Add(data);
            _context.SaveChanges();
        }

        public void Handle(DataUpdateCommand args)
        {
            UpdateData(ConvertToModel(args));
        }

        public void Handle(DataUpdateJudulCommand args)
        {
            UpdateData(ConvertToModel(args));
        }

        public void Handle(DataDeleteCommand args)
        {
            var data = _context.Data.Find(args.ID);
            _context.Data.Remove(data);
            _context.SaveChanges();
        }

        private void UpdateData(Data data)
        {
            _context.Data.Attach(data);
            _context.Data.Update(data);
            _context.SaveChanges();
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