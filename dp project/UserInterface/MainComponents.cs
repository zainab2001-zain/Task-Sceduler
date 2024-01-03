using System;
using System.Collections.Generic;
using System.Text;

namespace dp_project
{
    class MainComponents
    {
        public void Title()
        {
            Console.SetCursorPosition(31, 5);

            Console.WriteLine(@" 888888888888    db          ad88888ba   88      a8P
                                     88        d88b        d8'     '8b  88    ,88'
                                     88       d8'`8b       Y8,          88  ,88'
                                     88      d8'  `8b      `Y8aaaaa,    88,d88'
                                     88     d8YaaaaY8b       `'''''8b,  8888'88,
                                     88    d8''`'''''8b            `8b  88P   Y8b
                                     88   d8'        `8b   Y8a     a8P  88     '88,
                                     88  a8'           8ba,  '888888P'  888      888
                               
                                 ad88888ba8'   ,ad8888ba,  '88        88  88888888888  88888888ba,    88        88  88           88888888888  88888888ba  
                                d8'     '8b   d8''    `'8b  88        88  88           88      `'8b   88        88  88           88           88     ''8b 
                                Y8,          d8'            88        88  88           88        `8b  88        88  88           88           88      ,8P 
                                `Y8aaaaa,    88             88aaaaaaaa88  88aaaaaaa    88         88  88        88  88           88aaaaa      88aaaaaa8P' 
                                  `'''''8b, 88              88''''''''88  88'''''``    88         88  88        88  88           88'''''      88''''88'   
                                        `8b  Y8,            88        88  88           88         8P  88        88  88           88           88    `8b   
                                Y8a     a8P   Y8a.    .a8P  88        88  88           88      .a8P   Y8a.    .a8P  88           88           88     `8b  
                                 'Y88888P'     `'Y8888Y''   88        88  88888888888  88888888Y''     `'Y8888Y''   88888888888  88888888888  88      `8b");
        } 
        public void LeftBorder()
        {
          for(int i = 0; i < 39; i++)
            {
                Console.SetCursorPosition(15, i + 3);
                Console.WriteLine("#");
            }
        }
        public void TopBorder()
        {
            for (int i = 0; i < 100; i++)
            {
                
                Console.SetCursorPosition(i+15, 2);
                Console.WriteLine("=");
            }
        }
        public void RightBorder()
        {
            for (int i = 0; i < 35; i++)
            {
                Console.SetCursorPosition(100, i+3);
                Console.WriteLine("#");
            }
        }
        public void BottomBorder()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(15+i, 41);
                Console.WriteLine("=");
            }
        }
        public void MenuBox()
        {
            Console.SetCursorPosition(33, 25);
            Console.WriteLine(".-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-.");
            for (int i = 0; i < 13; i++)
            {
                Console.SetCursorPosition(33, 26+i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < 13; i++)
            {
                Console.SetCursorPosition(100, 26 + i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(33, 39);
            Console.WriteLine("`-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-`");
            
        }
    }
}
