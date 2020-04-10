namespace SkillTest.Core
{
    public interface IQueryArgs<TResult>
    {
    }

    public interface IQueryHandler<TQuery,TResult>
        where TQuery : IQueryArgs<TResult>
    {
        TResult Handle(TQuery args);
    }
}