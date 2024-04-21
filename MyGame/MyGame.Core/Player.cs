using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player
    {
        public static int number_of_players = 1;
        #region Private
        private string _nickName;       // Ник игрока
        private int _count_of_points;   // Количество очков, закреплённых за игроком
        private int _number_of_player;  // Номер игрока, пока не очень понимаю как правильно его реализовать 
        #endregion
        #region Get/Set
        public string NickName { get => _nickName; set => _nickName = value; }
        public int Count_of_points { get => _count_of_points; set => _count_of_points = value; }
        public int Number_of_player { get => _number_of_player; set => _number_of_player = value; }
        #endregion
        #region Constructions
        public Player(string nickName, int count_of_points, int number_of_player) // Конструтор с параметрами
        {
            NickName = nickName;
            Count_of_points = count_of_points;
            Number_of_player = number_of_player;
            number_of_players++;
        }
        public Player() // Конструтор по умолчанию
        {
            NickName = "Player" + _number_of_player.ToString();
            Count_of_points = 0;
            Number_of_player = number_of_players;
            number_of_players++;
        }
        #endregion
    }
}
