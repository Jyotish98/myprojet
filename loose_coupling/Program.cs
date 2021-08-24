using System;

namespace loose_coupling
{
    class Program
    {
        static void Main(string[] args)
        {
            Veichle c = new Bike();
            c.start();
            Console.ReadLine();
        }
    }
    public interface Veichle
    {
        public void start();
    }
    public class car : Veichle
    {
        public void start()
        {
            Console.WriteLine("Car has started");
        }
    }
    public class Bike : Veichle
    {
        public void start()
        {
            Console.WriteLine(" bike has started");
        }
    }
}
