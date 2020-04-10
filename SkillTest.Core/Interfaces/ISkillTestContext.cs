using Microsoft.EntityFrameworkCore;

namespace SkillTest.Core
{
    public interface ISkillTestContext
    {
        DbSet<Data> Data {set;get;}
        DbSet<Lokasi> Lokasi {set;get;}
        int SaveChanges();
    }
}