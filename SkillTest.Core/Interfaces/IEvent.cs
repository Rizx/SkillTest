namespace SkillTest.Core
{
    public interface IEventArgs
    {
    }

    public interface IEventHandler<T>
        where T : IEventArgs
    {
        void Handle(T args);
    }
}