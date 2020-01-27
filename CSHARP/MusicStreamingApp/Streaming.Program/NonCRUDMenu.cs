// <copyright file="NonCRUDMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Program
{
    using System;
    using Streaming.Data;
    using Streaming.Logic;

    /// <summary>
    /// Class for the NonCRUDMenu
    /// </summary>
    public class NonCRUDMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonCRUDMenu"/> class.
        /// </summary>
        public NonCRUDMenu()
        {
        }

        /// <summary>
        /// Gets or sets the Option of the menu
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// Displays the NonCrud menu
        /// </summary>
        public void Display()
        {
            do
            {
                this.Option = string.Empty;

                Console.Clear();

                Console.WriteLine($"MENU FOR NONCRUD METHODS \n");
                Console.WriteLine("1 Get Longest Song");
                Console.WriteLine("2 Get Services that play a given song");
                Console.WriteLine("3 Get number of listeners based on gender");
                Console.WriteLine("4 Get all artists active after a given date");
                Console.WriteLine("5 BACK");

                this.Option = Console.ReadLine();
                this.Action();
            }
            while (this.Option != "5");
            Console.WriteLine("Press any key to return to original menu...");
        }

        /// <summary>
        /// Performs the actions inside the menu, calls the methods
        /// </summary>
        public void Action()
        {
            SongLogic songLogic = SongLogic.CreateRealLogic();

            NonCRUDLogic nonCrudLogic = NonCRUDLogic.CreateRealLogic();

            switch (this.Option)
            {
                case "1":
                    Console.WriteLine(nonCrudLogic.GetLongestSong().ToString());
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Select a song ID from below: \n ");
                    foreach (song item in songLogic.GetAll())
                    {
                        Console.WriteLine($"{item.song_id} {item.song_title} \n");
                    }

                    foreach (serv item in nonCrudLogic.GetServicesThatPlayGivenSong(int.Parse(Console.ReadLine())))
                    {
                        Console.WriteLine(item.ToString() + "\n");
                    }

                    Console.ReadKey();
                    break;
                case "3":
                    foreach (ListenersGroupBy item in nonCrudLogic.GetNumberOfListenersBasedOnGender())
                    {
                        Console.WriteLine(item.ToString() + "\n");
                    }

                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Please provide a date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    foreach (artist item in nonCrudLogic.GetArtistsThatReleasedMusicAfterDate(date))
                    {
                        Console.WriteLine(item.ToString() + "\n");
                    }

                    Console.ReadKey();
                    break;
            }
        }
    }
}
