using System;

namespace Memento
{
    class Program
    {
        private int _result;

        public Program(int i = 0)
        {
            _result = 0;
        }

        public void SetResult(int i = 0)
        {
            this._result = 0;
        }

        public void Add(int x)
        {
            _result += x;
        }

        public int Solution()
        {
            return _result;
        }

        public Memento CreateMemento()
        {
            return new Memento(_result);
        }

        public void SetMemento(Memento memento)
        {
            _result = memento.State;
        }
    }

    public class Memento
    {
        int state;
        public Memento(int state)
        {
            this.state = state;
        }

        public int State
        {
            get { return state; }
        }
    }

    public class Undo
    {
        Memento memento;
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
        static void Main(string[] args)
        {
            Program adder = new Program();
            adder.Add(5);
            adder.Add(10);
            adder.Add(20);

            Undo undo = new Undo();
            undo.Memento = adder.CreateMemento();

            adder.Add(100);
            Console.WriteLine($"The solution of addition is:{adder.Solution()}");

            adder.SetMemento(undo.Memento);

            Console.WriteLine($"The solution at first checkpoint is:{adder.Solution()}");
            Console.Read();
        }
    }
}
