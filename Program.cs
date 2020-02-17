using System;

namespace InterfaceCSharp8
{
    interface IMovable
    {
        protected internal void Move();
        protected internal string Name { get; set; }
        delegate void MoveHandler();
        protected internal event MoveHandler MoveEvent;
    }
    class Person : IMovable
    {
        string IMovable.Name { get; set; }
        
        IMovable.MoveHandler _moveEvent;
        event IMovable.MoveHandler IMovable.MoveEvent
        {
            add => _moveEvent += value;
            remove => _moveEvent -= value;
        }
        
        void IMovable.Move()
        {
            Console.WriteLine("Person is walking"); 
            _moveEvent();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IMovable mov = new Person();
            mov.MoveEvent += () => Console.WriteLine("IMovable is moving");
            mov.Move();
        }
    }
}
