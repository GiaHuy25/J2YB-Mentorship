using CardGameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Services
{
    public class Bacarat
    {
        //Tính điểm
        public static int CalculatePoints(Player player)
        {
            int totalPoints = player.Hand.Sum(card =>
            {
                if (card.CardValue == Value.Jack || card.CardValue == Value.Queen || card.CardValue == Value.King)
                    return 10;  // Các lá bài mặt (J, Q, K) được tính là 10 điểm
                return (int)card.CardValue;  // Các lá bài khác giữ nguyên giá trị
            });

            // Chỉ lấy chữ số cuối của tổng điểm (nếu tổng lớn hơn hoặc bằng 10)
            return totalPoints % 10;
        }

        //Tạo ng chơi
        public static List<Player> CreatePlayers(List<string> inputNames)
        {
            var players = new List<Player>();
            foreach (var item in inputNames)
            {
                var player = new Player(item);
                players.Add(player);
            }
            return players;
        }


        public static string DetermineWinner(List<Player> players)
        {
            int maxPoints = -1;
            Player winner = null;
            bool isDraw = false;

            foreach (var player in players)
            {
                int playerPoints = CalculatePoints(player);

                if (playerPoints > maxPoints)
                {
                    maxPoints = playerPoints;
                    winner = player;
                    isDraw = false;
                }
                else if (playerPoints == maxPoints)
                {
                    isDraw = true;
                }
            }

            if (isDraw)
                return "It's a draw!";
            else
                return $"{winner.Name} wins!";
        }
        //Chia bài
        public static void DrawCard(Player player, Deck deck)
        {
            if (deck.Cards.Count > 0)
            {
                var card = deck.Cards[0];
                player.Hand.Add(card);
                deck.Cards.RemoveAt(0);
            }
        }
    }
}
