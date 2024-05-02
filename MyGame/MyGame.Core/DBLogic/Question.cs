namespace ClassLibrary
{
    public class Question
    {
        private int _id;
        private string _name;
        private string _tquestion;
        private int _answerid;
        private int _themeid;
        private int _packid;

        public Question(int id, string name, string tquestion, int answerid)
        {
            _id = id;
            _name = name;
            _tquestion = tquestion;
            _answerid = answerid;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string tQuestion { get => _tquestion; set => _tquestion = value; }
        public int Answerid { get => _answerid; set => _answerid = value; }
        public int Themeid { get => _themeid; set => _themeid = value; }
        public int Packid { get => _packid; set => _packid = value; }
    }
}