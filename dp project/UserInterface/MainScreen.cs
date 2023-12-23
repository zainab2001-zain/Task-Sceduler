using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.UserInterface
{
    class MainScreen
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
        public void Borders()
        {
            //Console.SetCursorPosition(50, 10);
            Console.WriteLine(@"|");

        }
        public void AdminMenu()
        {
            Console.WriteLine("1.Create Tasks");
        }

    }
}
