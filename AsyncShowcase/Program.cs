namespace AsyncShowcase
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Making breakfast sync");
            await RealWorldExample.MakeBreakFast();

            Console.WriteLine();

            Console.WriteLine("Making breakfast async");
            await RealWorldExample.MakeBreakFastAsync();
        }
    }
}