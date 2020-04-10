using System;
using System.Collections.Generic;

namespace SkillTest.Core
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<Delegate> handles = new List<Delegate>();
        private readonly List<Type> _handles = new List<Type>();

        public virtual void RegisterEvent<T>(IEventHandler<T> handler)
            where T : IEventArgs
        {
            _handles.Add(handler.GetType());
        }

        public virtual void RaiseEvents<T>(T args)
            where T : IEventArgs
        {
            for (int i = 0; i < _handles.Count; i++)
            {
                var instance = (IEventHandler<T>)Activator.CreateInstance(typeof(T));
                instance.Handle(args);
            }
        }

        public virtual void ClearEvents()
        {
            handles.Clear();
        }
    }
}