namespace SkillTest.Core
{
    public class Data : AggregateRoot
    {
        public string Judul { protected set; get; }
        public string Keterangan { protected set; get; }
        public byte[] Foto { protected set; get; }
        public long LokasiID {protected set; get; }

        public Data(long id, string judul, string keterangan, byte[] foto, long lokasiId)
        {
            ID = id;
            Judul = judul;
            Keterangan = keterangan;
            Foto = foto;
            LokasiID = lokasiId;
        }

        public Data(long id, string keterangan, byte[] foto, long lokasiId)
        {
            ID = id;
            Keterangan = keterangan;
            Foto = foto;
            LokasiID = lokasiId;
        }

        public Data(long id, string judul)
        {
            ID = id;
            Judul = judul;
        }

        public Data(string judul, string keterangan, byte[] foto, long lokasiId)
        : this(0, judul, keterangan, foto, lokasiId)
        {
        }

        protected Data()
        {
        }

        public void Change(Data data)
        {
            Keterangan = Keterangan;
            Foto = data.Foto;
            LokasiID = data.LokasiID;
        }

        public void GantiJudul(string judul)
        {
            Judul = judul;
        }
    }
}