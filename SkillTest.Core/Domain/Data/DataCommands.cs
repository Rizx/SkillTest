namespace SkillTest.Core
{
    public sealed class DataCreateCommand : ICommandArgs
    {
        public long ID { get; }
        public string Judul { get; }
        public string Keterangan { get; }
        public byte[] Foto { get; }
        public long LokasiID { get; }
        public DataCreateCommand(long dataId, string judul, string keterangan, byte[] foto, long lokasiId)
        {
            ID = dataId;
            Judul = judul;
            Keterangan = keterangan;
            Foto = foto;
            LokasiID = lokasiId;
        }
    }

    public sealed class DataUpdateCommand : ICommandArgs
    {
        public long ID { get; }
        public string Keterangan { get; }
        public byte[] Foto { get; }
        public long LokasiID { get; }

        public DataUpdateCommand(long dataId, string keterangan, byte[] foto, long lokasiId)
        {
            this.ID = dataId;
            this.Keterangan = keterangan;
            this.Foto = foto;
            this.LokasiID = lokasiId;
        }
    }

    public sealed class DataUpdateJudulCommand : ICommandArgs
    {
        public long ID { get; }
        public string Judul { get; }

        public DataUpdateJudulCommand(long dataId, string judul)
        {
            this.ID = dataId;
            this.Judul = judul;
        }
    }

    public sealed class DataDeleteCommand : ICommandArgs
    {
        public long ID { get; }

        public DataDeleteCommand(long dataId)
        {
            this.ID = dataId;
        }
    }
}