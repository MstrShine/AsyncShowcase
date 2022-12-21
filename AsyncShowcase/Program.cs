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