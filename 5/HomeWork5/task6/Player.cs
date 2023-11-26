namespace task6
{
    /*public class Player
    {
        private static int nextId = 1;

        public string Name { get; }
        public int InitialAmount { get; private set; }
        public int CurrentAmount { get; private set; }

        public Player()
        {
            Name = $"Гравець{nextId++}";
            InitialAmount = new Random().Next(100, 1001);
            CurrentAmount = InitialAmount;
        }

        public void MakeBet()
        {
            int betAmount = new Random().Next(1, CurrentAmount + 1);
            int betNumber = new Random().Next(1, 37); // Assuming a standard roulette wheel

            // Simulate winning or losing
            bool wins = (new Random().Next(2) == 0);
            if (wins)
            {
                Console.WriteLine($"{Name} виграв {betAmount} на числі {betNumber}");
                CurrentAmount += betAmount;
            }
            else
            {
                Console.WriteLine($"{Name} програв {betAmount} на числі {betNumber}");
                CurrentAmount -= betAmount;
            }

            if (CurrentAmount <= 0)
            {
                Console.WriteLine($"{Name} банкрот. Звільняє стіл.");
                players.Remove(this);
            }
        }

        public void Play()
        {
            while (Program.roundsPlayed == 0) ; // Wait for the start of the game

            while (CurrentAmount > 0)
            {
                Thread.Sleep(100); // Simulate time between bets
                CasinoTable table = new CasinoTable(0, 0); // Dummy table to call methods
                table.PlayRound();
            }
        }
    }*/
}
