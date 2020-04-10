using System.Collections.Generic;

namespace SkillTest.Core
{
    public interface IRepository<T>
    {
        T Single(long id);
        List<T> List();
        void Add(T args);
        void Update(T args);
        void Delete(T args);
    }
}