using System;
using CSharpFunctionalExtensions;
using SkillTest.Core;

namespace SkillTest.API
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Command(ICommandArgs command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            return (Result)handler.Handle((dynamic)command);
        }

        public T Query<T>(IQueryArgs<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            return (T)handler.Handle((dynamic)query);
        }
    }
}
