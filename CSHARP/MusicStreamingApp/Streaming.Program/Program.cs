// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Data;
    using Streaming.Logic;

    /// <summary>
    /// Program class that contains the menu
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method of the Program class
        /// </summary>
        /// <param name="args">array of strings</param>
        public static void Main(string[] args)
        {
            string option = string.Empty;
            do
            {
                Console.WriteLine("MENU OF OPTIONS\n");
                Console.WriteLine("1 SONGS");
                Console.WriteLine("2 ARTISTS");
                Console.WriteLine("3 LISTENERS");
                Console.WriteLine("4 PLAYEDON");
                Console.WriteLine("5 LISTENSTO");
                Console.WriteLine("6 SERVICE");
                Console.WriteLine("7 JAVA QUERY");
                Console.WriteLine("8 NON CRUD METHODS");
                Console.WriteLine("9 EXIT MENU\n");

                option = Console.ReadLine();
                callCaseMethod(option);
                Console.ReadLine();
                Console.Clear();
            }
            while (option != "9");

            void callCaseMethod(string caseSelection)
            {
                CRUDMenu menu;

                // Console.Clear();
                switch (caseSelection)
                {
                    case "1":
                        Console.Clear();
                         menu = new CRUDMenu("song");
                        menu.Display();

                        break;
                    case "2":
                        Console.Clear();
                        menu = new CRUDMenu("artist");
                        menu.Display();

                        break;
                    case "3":
                        Console.Clear();
                        menu = new CRUDMenu("listener");
                        menu.Display();

                        break;
                    case "4":
                        Console.Clear();
                        menu = new CRUDMenu("playedon");
                        menu.Display();

                        break;
                    case "5":
                        Console.Clear();
                        menu = new CRUDMenu("listensto");
                        menu.Display();

                        break;
                    case "6":
                        Console.Clear();
                        menu = new CRUDMenu("service");
                        menu.Display();

                        break;
                    case "7":
                        Console.WriteLine("Give a song title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Give its artist: ");
                        string artist = Console.ReadLine();
                        WebClient wc = new WebClient();
                        string content = wc.DownloadString("http://localhost:8080/MusicStreamingJavaServer/MusicStreamingServlet?title=" + title + "&artist=" + artist);

                        Console.Write(content);

                        break;
                    case "8":
                        Console.Clear();
                        NonCRUDMenu nonCrudMenu = new NonCRUDMenu();
                        nonCrudMenu.Display();
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Press any key to exit...");
                        break;
                }
            }
        }
    }
}
