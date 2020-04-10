using AutoFixture;

namespace SkillTest.CoreTest
{
    public static class Any
    {
        private static readonly Fixture _any = new Fixture();

        public static T Instance<T>()
        {
            return _any.Create<T>();
        }
    }
}