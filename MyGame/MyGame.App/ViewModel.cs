using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ViewModel : ObservableObject // Система, через которую мы будем управлять формами и вызывать их команды 
    {
        #region data
        public GameOptions _gm;
        public List<Player> _players;


        private PackRepository packRepository;
        private ThemeRepository themeRepository;
        private QuestionRepository questionRepository;
        private AnswerRepository answerRepository;

        private ObservableCollection<Question> questionList;
        public ObservableCollection<Question> QuestionList { get => questionList; set { questionList = value; OnPropertyChanged("QuestionList"); } }


        private int themeNumber;
        private int questionNumber;

        public int ThemeNumber { get => themeNumber; set { themeNumber = value; OnPropertyChanged("ThemeNumber"); } }
        public int QuestionNumber { get => questionNumber; set { questionNumber = value; OnPropertyChanged("QuestionNumber"); }}

        private List<Pack> packList;
        #endregion

        public ViewModel(PackRepository packRepository, ThemeRepository themeRepository, QuestionRepository questionRepository, AnswerRepository answerRepository)
        {
            this.packRepository = packRepository;
            this.themeRepository = themeRepository;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;

            packList = this.packRepository.Read();

            List<Theme> tmpThemes = this.themeRepository.ReadByPackId(packList[0].Id);
            themeNumber = tmpThemes.Count();
            List<Question> tmp = this.questionRepository.ReadByPackId(packList[0].Id);
            QuestionNumber = tmp.Where(x => x.Themeid == tmp[0].Themeid).Count();
            QuestionList = new ObservableCollection<Question>();
        }

    }
}