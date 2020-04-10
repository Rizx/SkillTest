using System.Collections.Generic;

namespace SkillTest.Core
{
    public class DataListQuery : IQueryArgs<List<DataDto>>
    {
    }

    public class DataSingleByIdQuery : IQueryArgs<Data>
    {
        public long DataID { get; }
        public DataSingleByIdQuery(long dataId)
        {
            DataID = dataId;
        }
    }
}