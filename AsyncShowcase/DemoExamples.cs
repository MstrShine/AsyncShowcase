using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncShowcase
{
    public static class DemoExamples
    {
        public static async Task WhenAllDemo()
        {
            var taskList = new List<Task>();
            for (int i = 0; i < 100; i++)
                taskList.Add(StupidTask(i));

            await Task.WhenAll(taskList).ConfigureAwait(false);
        }

        public static async Task NotWaitingForOtherTask()
        {
            var heavyTask = HeavyTask(); // Hot task
            for (int i = 0; i < 20; i++)
                await StupidTask(i); // Cold task

            await heavyTask;
        }

        private static async Task HeavyTask()
        {
            Console.WriteLine("Starting heavy task");
            await Task.Delay(30000);
            Console.WriteLine("Done with heavy task");

        }

        private static async Task StupidTask(int i)
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Starting delay on Task {i}, thread {currentThread.ManagedThreadId}");
            await Task.Delay(1000);
            Console.WriteLine($"Stopped delay on Task {i}, thread {currentThread.ManagedThreadId}");
        }
    }
}
