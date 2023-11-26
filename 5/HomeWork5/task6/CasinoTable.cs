namespace task6
{
    /*public class CasinoTable
    {
        private List<Player> players;
        private int playerCount;
        private int potentialPlayers;

        public CasinoTable(int playerCount, int potentialPlayers)
        {
            this.players = new List<Player>();
            this.playerCount = playerCount;
            this.potentialPlayers = potentialPlayers;
        }

        public Player AddPlayer()
        {
            lock (players)
            {
                if (players.Count < playerCount && players.Count < potentialPlayers)
                {
                    Player player = new Player();
                    players.Add(player);
                    return player;
                }
                else
                {
                    return null;
                }
            }
        }

        public void PlayRound()
        {
            lock (players)
            {
                Console.WriteLine($"Round {++Program.roundsPlayed}");
                foreach (Player player in players)
                {
                    player.MakeBet();
                }
            }
        }
    }*/
}
