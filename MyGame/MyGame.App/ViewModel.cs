using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ViewModel // Система, через которую мы будем управлять формами и вызывать их команды 
    {
        #region data
        public GameOptions _gm;
        public List<Player> _players;
        #endregion
    }
}