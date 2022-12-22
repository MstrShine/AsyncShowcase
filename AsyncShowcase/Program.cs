namespace AsyncShowcase
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var loop = true;
            while (loop)
            {
                Console.WriteLine("1. Sync vs Async");
                Console.WriteLine("2. Doing many things at once");
                Console.WriteLine("3. Doing one heavy and some other stuf at the same time");
                Console.WriteLine("4. Deadlock");
                Console.WriteLine("5. Forget await with error");
                Console.WriteLine("6. Race condition");

                Console.WriteLine("Exit? Type E");
                Console.WriteLine("Choose one of the options");
                var chosenOption = Console.ReadLine();

                if (int.TryParse(chosenOption, out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await SyncVsAsync();
                            break;
                        case 2:
                            await DemoExamples.WhenAllDemo();
                            break;
                        case 3:
                            await DemoExamples.NotWaitingForOtherTask();
                            break;
                        case 4:
                            var t1 = Task.Run(() => { DemoExamples.DeadlockT1(); });
                            var t2 = Task.Run(() => { DemoExamples.DeadLockT2(); });

                            Task.WaitAll(t1, t2);
                            break;
                        case 5:
                            try
                            {
                                var forget = DemoExamples.Forget();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!");
                            }
                            break;
                        case 6:
                            for (int i = 0; i < 10; i++)
                                DoRace();
                            break;
                        default:
                            WrongChoice();
                            break;
                    }

                    Console.WriteLine(); // One enter for next loop
                }
                else if (chosenOption?.ToLower() == "e")
                {
                    loop = false;
                }
                else
                {
                    WrongChoice();
                }
            }
        }

        public static void DoRace()
        {
            var race = new RaceCondition();
            var r1 = new Thread(race.Race1);
            var r2 = new Thread(race.Race2);
            var r3 = new Thread(race.Race3);
            r1.Start();
            r2.Start();
            r3.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Result of race: {race.Race}");
            Console.ResetColor();
        }

        private static async Task SyncVsAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Making breakfast sync");
            Console.ResetColor();
            await RealWorldExample.MakeBreakFast();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Making breakfast async");
            Console.ResetColor();
            await RealWorldExample.MakeBreakFastAsync();
        }

        private static void WrongChoice()
        {
            Console.WriteLine("Chosen option is not found try again");
            Console.WriteLine();
        }
    }

}