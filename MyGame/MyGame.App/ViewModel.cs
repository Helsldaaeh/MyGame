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

            List<Theme> themesList = this.themeRepository.ReadByPackId(1);
            themeNumber = themesList.Count();
            List<Question> questionList = this.questionRepository.ReadByPackId(1);
            QuestionNumber = questionList.Where(x => x.Themeid == questionList[0].Themeid).Count();
            QuestionList = new ObservableCollection<Question>(questionList);


        }

    }
}