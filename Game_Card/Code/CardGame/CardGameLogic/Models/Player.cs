using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLogic.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; private set; }  // Tay bài của người chơi

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            Id = new Guid();
        }
        // Phương thức xóa tay bài của người chơi (sử dụng khi bắt đầu một ván mới)
        public void ClearHand()
        {
            Hand.Clear();
        }

    }
}
