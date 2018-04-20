using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander.UI
{
    class UIManager : Singleton<UIManager>
    {
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public Window CurrentWindow { get; private set; }

        private string message;
        private Stack<Window> windowStack;

        public UIManager()
        {
            windowStack = new Stack<Window>();
        }

        public void Initialize(int columns, int rows, Window window)
        {
            Columns = columns;
            Rows = rows;
            CurrentWindow = window;
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(columns, rows);
            Console.SetBufferSize(columns, rows);
        }

        public void ShowWindow(Window window, bool pushCurrent = false)
        {
            if(pushCurrent)
            {
                windowStack.Push(CurrentWindow);
            }
            CurrentWindow = window;
            Refresh();
        }

        public void PopWindow()
        {
            if(windowStack.Count > 1)
            {
                CurrentWindow = windowStack.Pop();
                Refresh();
            }
        }

        public void Begin()
        {
            message = null;
        }

        private void DisplayMessage()
        {
            int width = message.Length;
            if (width > Columns + 4)
            {
                throw new Exception("Text too long, add wrapping");
            }
            Console.SetCursorPosition((Columns - width - 2) / 2, Rows / 2 - 2);
            for (int i = 0; i < width + 4; i++)
            {
                Console.Write('-');
            }
            Console.SetCursorPosition((Columns - width - 2) / 2, Rows / 2 - 1);
            for (int i = 0; i < width + 4; i++)
            {
                Console.Write((i == 0 || i == width + 3) ? '|' : ' ');
            }

            Console.SetCursorPosition((Columns - width - 2) / 2, Rows / 2);
            Console.Write('|');
            Console.SetCursorPosition((Columns - width) / 2 + 1, Rows / 2);
            Console.Write(message);
            Console.SetCursorPosition((Columns - width - 2) / 2 + width + 3, Rows / 2);
            Console.Write('|');

            Console.SetCursorPosition((Columns - width - 2) / 2, Rows / 2 + 1);
            for (int i = 0; i < width + 4; i++)
            {
                Console.Write((i == 0 || i == width + 3) ? '|' : ' ');
            }
            Console.SetCursorPosition((Columns - width - 2) / 2, Rows / 2 + 2);
            for (int i = 0; i < width + 4; i++)
            {
                Console.Write('-');
            }
            HomeCursor();
        }

        public void ShowMessage(string message)
        {
            this.message = message;
        }

        public void HandleInput(string[] input)
        {
            Refresh();
        }

        private void Refresh()
        {
            CurrentWindow.Display();
            if(message != null)
            {
                DisplayMessage();
            }
            HomeCursor();
        }

        private void HomeCursor()
        {
            Console.SetCursorPosition(0, Rows - 1);
            Console.Write("> ");
        }
    }
}
