using System;
using System.Collections.Generic;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        public int Currency { get; private set; }

        private readonly List<Action<int>> _subscriptions = new ();

        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
            
            foreach (var subscription in _subscriptions)
            {
                subscription.Invoke(Currency);
            }
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }

        public void Subscribe(Action<int> onChanged)
        {
            _subscriptions.Add(onChanged);
        }
        
        public void UnSubscribe(Action<int> onChanged)
        {
            _subscriptions.Remove(onChanged);
        }
    }
}