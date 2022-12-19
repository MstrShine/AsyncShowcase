using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncShowcase
{
    public static class RealWorldExample
    {
        public static async Task MakeBreakFast()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Starting toast!");
            await MakeToast();
            Console.WriteLine("Toast is done!");

            Console.WriteLine("Making eggs!");
            await BakeEggs();

            stopwatch.Stop();
            Console.WriteLine($"I have toast and eggs! Done in {(stopwatch.ElapsedMilliseconds / 1000)} seconds");
        }
            
        public static async Task MakeBreakFastAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Starting toast!");
            var toastTask = MakeToast();

            Console.WriteLine("Making eggs!");
            await BakeEggs();

            Console.WriteLine("Eggs are done, is the toast done?");
            await toastTask;

            stopwatch.Stop();
            Console.WriteLine($"I have toast and eggs! Done in {(stopwatch.ElapsedMilliseconds / 1000)} seconds");
        }

        private static async Task BakeEggs()
        {
            Console.WriteLine("Cracking eggs in pan");
            await Task.Delay(15000);
            Console.WriteLine("Eggs are nice and crispy");
        }

        private static Task MakeToast()
        {
            Console.WriteLine("Pushing the toaster button.");
            var toasterTask = Task.Delay(10000);
            Console.WriteLine("Pushed the toaster button!");

            return toasterTask;
        }
    }
}
