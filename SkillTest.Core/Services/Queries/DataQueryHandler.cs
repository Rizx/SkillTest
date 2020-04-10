namespace SkillTest.Core
{
    public class DataQueryHandler : IQueryHandler<DataSingleByIdQuery, Data>
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

        private Data GetDataById(long id)
        {
            var result = _context.Data.Find(id);
            return result;
        }
    }
}