namespace ClassLibrary
{
    public class Question_and_Theme
    {
        private int _id;
        private int _questionid;
        private int _themeid;
        private int _packid;

        public Question_and_Theme(int id, int questionid, int themeid, int packid)
        {
            _id = id;
            _questionid = questionid;
            _themeid = themeid;
            _packid = packid;
        }
        public int Id { get => _id; set => _id = value; }
        public int Questionid { get => _questionid; set => _questionid = value; }
        public int Themeid { get => _themeid; set => _themeid = value; }
        public int Packid { get => _packid; set => _packid = value; }
    }
}