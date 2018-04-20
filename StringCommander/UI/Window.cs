using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander.UI
{
    abstract class Window
    {
        public string Title { get; set; }

        public Window(string title)
        {
            Title = title;
        }

        public virtual void Display()
        {
            DisplayTitle();
        }

        public void DisplayTitle()
        {
            Console.Clear();
            Console.Title = Title;
            Console.SetCursorPosition((UIManager.Instance.Columns - Title.Length) / 2, 0);
            Console.Write(Title);
        }
    }
}
