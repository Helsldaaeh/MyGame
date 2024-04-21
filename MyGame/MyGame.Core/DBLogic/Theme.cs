﻿namespace ClassLibrary
{
    public class Theme
    {
        private int _id;
        private string _name;

        public Theme(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }
}