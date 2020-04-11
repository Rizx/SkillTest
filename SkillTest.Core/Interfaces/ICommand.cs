using CSharpFunctionalExtensions;

namespace SkillTest.Core
{
    public interface ICommandArgs
    {
        long ID { get; }
    }

    public interface ICommandHandler<TArgs>
        where TArgs : ICommandArgs
    {
        Result Handle(TArgs args);
    }
}