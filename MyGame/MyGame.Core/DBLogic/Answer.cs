namespace ClassLibrary
{
    public class Answer
    {
        private int _id;
        private string _name;

        public Answer(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }
}