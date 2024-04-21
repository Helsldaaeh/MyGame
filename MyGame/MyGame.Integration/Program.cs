using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Integration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThemeRepository rep = new ThemeRepositoryImpl();

            List<Theme> themes = rep.Read();
            Console.WriteLine("Check empty");
            foreach (Theme theme in themes)
            {
                Console.WriteLine(theme.Name);
            }

            Theme next = new Theme(0, "Программирование");
            rep.Create(next);

            themes = rep.Read();
            next = themes.Last();
            Console.WriteLine("Check create");
            foreach (Theme theme in themes)
            {
                Console.WriteLine(theme.Name);
            }

            next.Name = "C#";
            rep.Update(next);

            themes = rep.Read();
            Console.WriteLine("Check update");
            foreach (Theme theme in themes)
            {
                Console.WriteLine(theme.Name);
            }

            rep.Delete(next.Id);

            themes = rep.Read();
            Console.WriteLine("Check delete");
            foreach (Theme theme in themes)
            {
                Console.WriteLine(theme.Name);
            }

            Console.ReadKey();
        }
    }
}
