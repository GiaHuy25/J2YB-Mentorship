using CardGameLogic.Models;
using CardGameLogic.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Deck deck = new Deck();
        int nbplayer = 0;
        string name;
        Console.WriteLine("Nhap so luong ng choi");
        nbplayer = int.Parse(Console.ReadLine());
        while (nbplayer > 52 / 3)
        {
            Console.WriteLine("vui long nhap so luong ng choi < 17");
            Console.WriteLine("Nhap so luong ng choi");
            nbplayer = int.Parse(Console.ReadLine());
        }
        var players = new List<string>();
        for (int i = 0; i < nbplayer; i++) {
            Console.WriteLine("Input Player Name: ");
            name = Console.ReadLine();
            players.Add(name);
        }
        CommonServices.Shuffle(deck);
        var ListPlayers = Bacarat.CreatePlayers(players);
        for (int i = 0; i < 3; i++) {
            foreach (var item in ListPlayers) {
                Bacarat.DrawCard(item, deck);
            }
        }
        foreach (var item in ListPlayers)
        {
            int point = Bacarat.CalculatePoints(item);
            Console.WriteLine(item.Name + ": " + point);
        }
        var winner = Bacarat.DetermineWinner(ListPlayers);
        Console.WriteLine(winner);
    }
}