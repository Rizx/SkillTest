namespace SkillTest.API
{
    public class EditDataDto
    {
        public long DataID {set;get;}
        public string Keterangan { set; get; }
        public byte[] Foto { set; get; }
        public long LokasiID {set; get; }
    }
}