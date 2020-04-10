using System;

namespace SkillTest.Core
{
    public class Lokasi : AggregateRoot
    {
        public string Deskripsi { protected set; get; }

        public Lokasi(long id, string deskripsi)
        {
            ID = id;
            Deskripsi = deskripsi;
        }

        public Lokasi(string deskripsi) : this(0, deskripsi)
        {
        }

        protected Lokasi()
        {
        }
    }
}