using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GameOptions
    {
        #region Private
        private int _number_of_players;   // Количество игроков, лучше ограничиться 4
        private int _number_of_Questions; // Количество вопросов в одной теме
        private int _number_of_themes;    // Количество тем
        private int _number_of_rounds;    // количество раундов
        private int _price_of_questions;  // Цена вопроса
        private int _price_of_fine;       // Цена штрафа
        private int _time_for_answer;     // Время на ответ
        private bool _progression;        // Equalization mode || Уравнивающий режим
                                          // постоянно растёт цена вопроса и цена штрафа, уход в минус невозможен,
                                          // реализовать через сценарий
        #endregion
        #region Get/Set
        public int Number_of_players { get => _number_of_players; set => _number_of_players = value; }
        public int Number_of_Questions { get => _number_of_Questions; set => _number_of_Questions = value; }
        public int Number_of_themes { get => _number_of_themes; set => _number_of_themes = value; }
        public int Number_of_rounds { get => _number_of_rounds; set => _number_of_rounds = value; }
        public int Price_of_questions { get => _price_of_questions; set => _price_of_questions = value; }
        public int Price_of_fine { get => _price_of_fine; set => _price_of_fine = value; }
        public int Time_for_answer { get => _time_for_answer; set => _time_for_answer = value; }
        public bool Progression { get => _progression; set => _progression = value; }
        #endregion
        #region Constructors
        public GameOptions(int number_of_players, int number_of_Questions,
                           int number_of_themes, int number_of_rounds,
                           int price_of_questions, int price_of_fine, int time_for_answer, bool progression) // Конструктор с параметрами
        {
            _number_of_players = number_of_players;
            _number_of_Questions = number_of_Questions;
            _number_of_themes = number_of_themes;
            _number_of_rounds = number_of_rounds;
            _price_of_questions = price_of_questions;
            _price_of_fine = price_of_fine;
            _time_for_answer = time_for_answer;
            _progression = progression;
        }
        public GameOptions() // Конструктор по умолчанию
        {
            _number_of_players = 4;
            _number_of_Questions = 5;
            _number_of_themes = 5;
            _number_of_rounds = 3;
            _price_of_questions = 100;
            _price_of_fine = 50;
            _time_for_answer = 10;
            _progression = false;
        }
        #endregion
        void ModifierProgression() // Модификатор прогрессии
        {
            _price_of_questions *= 2;
            _price_of_fine *= 4;
        }
    }
}
