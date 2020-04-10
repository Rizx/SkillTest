using System.Collections.Generic;

namespace SkillTest.Core
{
    public class GroupByLokasiDto
    {
        public long LokasiID {set;get;}
        public string Deskripsi {set;get;}
        public List<DataDto> Lines {set;get;}
    }
}