using System;

namespace SummativeAssignment
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SummativeAssignment())
                game.Run();
        }
    }
}
