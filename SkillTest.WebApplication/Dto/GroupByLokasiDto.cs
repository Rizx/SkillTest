using System.Collections.Generic;

namespace SkillTest.WebApplication
{
    public class GroupByLokasiDto
    {
        public long LokasiID {set;get;}
        public string Deskripsi {set;get;}
        public List<DataDto> Lines {set;get;}
    }
}