// <copyright file="CRUDMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Data;
    using Streaming.Logic;
    using Streaming.Logic.Interfaces;

    /// <summary>
    /// Class for the CRUDMenu
    /// </summary>
    public class CRUDMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CRUDMenu"/> class.
        /// </summary>
        /// <param name="type">takes a type string as a parameter</param>
        public CRUDMenu(string type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the Type of the menu
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Option in the menu
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// Display method that displays the menu and calls the Action() method
        /// </summary>
        public void Display()
        {
            // this.Option = string.Empty;
            do
            {
                Console.Clear();

                Console.WriteLine($"MENU FOR {this.Type} \n");
                Console.WriteLine("1 INSERT");
                Console.WriteLine("2 GET ALL");
                Console.WriteLine("3 GET BY ID");
                Console.WriteLine("4 UPDATE");
                Console.WriteLine("5 DELETE");
                Console.WriteLine("6 BACK");

                this.Option = Console.ReadLine();
                this.Action(this.Type);
            }
            while (this.Option != "6");
            Console.WriteLine("Press any key to return to original menu...");
        }

        /// <summary>
        /// the Action method that performs the actions on the tables
        /// </summary>
        /// <param name="inputType">takes a string type as a parameter to determine table</param>
        public void Action(string inputType)
        {
            int idNum;
            try
            {
                SongLogic songLogic = SongLogic.CreateRealLogic();
                ArtistLogic artistLogic = ArtistLogic.CreateRealLogic();
                ListenerLogic listenerLogic = ListenerLogic.CreateRealLogic();
                PlayedOnConnLogic playedOnConnLogic = PlayedOnConnLogic.CreateRealLogic();
                ListensToConnLogic listensToConnLogic = ListensToConnLogic.CreateRealLogic();
                ServLogic serviceLogic = ServLogic.CreateRealLogic();
                switch (inputType)
                {
                    case "song":

                        switch (this.Option)
                        {
                            case "1":
                                song newSong = new song();
                                newSong.song_id = songLogic.GetAll().Count() + 1;
                                Console.WriteLine("New Song Title: ");
                                newSong.song_title = Console.ReadLine();
                                Console.WriteLine("New Song Album: ");
                                newSong.song_album = Console.ReadLine();
                                Console.WriteLine("New Song Length (seconds): ");
                                newSong.song_length = int.Parse(Console.ReadLine());
                                Console.WriteLine("Is the new song explicit? (true/false)");
                                newSong.song_explicit = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Date of Release (DD/MM/YYYY): ");
                                newSong.song_dateReleased = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Select an artist ID from below: \n ");
                                foreach (artist item in artistLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.artist_id} {item.artist_name} \n");
                                }

                                newSong.song_artistId = int.Parse(Console.ReadLine());
                                songLogic.Insert(newSong);
                                Console.WriteLine("Song has been added!");
                                break;
                            case "2":
                                foreach (var item in songLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(songLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the song you wish to update?");
                                song s = songLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("New Song Title: ");
                                s.song_title = Console.ReadLine();
                                Console.WriteLine("New Song Album: ");
                                s.song_album = Console.ReadLine();
                                Console.WriteLine("New Song Length (seconds): ");
                                s.song_length = int.Parse(Console.ReadLine());
                                Console.WriteLine("Is the new song explicit? (true/false)");
                                s.song_explicit = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Date of Release (DD/MM/YYYY): ");
                                s.song_dateReleased = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Select an artist ID from below: \n ");
                                foreach (artist item in artistLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.artist_id} {item.artist_name} \n");
                                }

                                s.song_artistId = int.Parse(Console.ReadLine());
                                songLogic.Update(s);
                                Console.WriteLine("Song has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of Song to be Deleted");
                                idNum = int.Parse(Console.ReadLine());
                                songLogic.Delete(songLogic.GetById(idNum));
                                Console.WriteLine("Song has been deleted!");
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "artist":

                        switch (this.Option)
                        {
                            case "1":
                                artist newArtist = new artist();
                                newArtist.artist_id = artistLogic.GetAll().Count() + 1;
                                Console.WriteLine("New Artist Name: ");
                                newArtist.artist_name = Console.ReadLine();
                                Console.WriteLine("New Artist Label: ");
                                newArtist.artist_label = Console.ReadLine();
                                Console.WriteLine("New Artist Age: ");
                                newArtist.artist_age = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Artist Gender: ");
                                newArtist.artist_gender = Console.ReadLine();
                                Console.WriteLine("New Artist Genre: ");
                                newArtist.artist_genre = Console.ReadLine();
                                artistLogic.Insert(newArtist);
                                Console.WriteLine("Artist has been added!");
                                break;
                            case "2":
                                foreach (var item in artistLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(artistLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the artist you wish to update?");
                                artist a = artistLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("New Artist Name: ");
                                a.artist_name = Console.ReadLine();
                                Console.WriteLine("New Artist Label: ");
                                a.artist_label = Console.ReadLine();
                                Console.WriteLine("New Artist Age: ");
                                a.artist_age = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Artist Gender: ");
                                a.artist_gender = Console.ReadLine();
                                Console.WriteLine("New Artist Genre: ");
                                a.artist_genre = Console.ReadLine();
                                artistLogic.Update(a);
                                Console.WriteLine("Artist has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of Artist to be Deleted");
                                int deleteId = int.Parse(Console.ReadLine());
                                artistLogic.Delete(artistLogic.GetById(deleteId));
                                Console.WriteLine("Artist has been deleted!");
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "listener":

                        switch (this.Option)
                        {
                            case "1":
                                listener newListener = new listener();
                                newListener.listener_id = listenerLogic.GetAll().Count() + 1;
                                Console.WriteLine("New Listener Name: ");
                                newListener.listener_name = Console.ReadLine();
                                Console.WriteLine("New Listener Country: ");
                                newListener.listener_country = Console.ReadLine();
                                Console.WriteLine("New Listener Device Type: ");
                                newListener.listener_deviceType = Console.ReadLine();
                                Console.WriteLine("New Listener Email: ");
                                newListener.listener_email = Console.ReadLine();
                                Console.WriteLine("New Listener Gender: ");
                                newListener.listener_gender = Console.ReadLine();
                                listenerLogic.Insert(newListener);
                                Console.WriteLine("Listener has been added!");
                                break;
                            case "2":
                                foreach (var item in listenerLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(listenerLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the listener you wish to update?");
                                listener l = listenerLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("New Listener Name: ");
                                l.listener_name = Console.ReadLine();
                                Console.WriteLine("New Listener Country: ");
                                l.listener_country = Console.ReadLine();
                                Console.WriteLine("New Listener Device Type: ");
                                l.listener_deviceType = Console.ReadLine();
                                Console.WriteLine("New Listener Email: ");
                                l.listener_email = Console.ReadLine();
                                Console.WriteLine("New Listener Gender: ");
                                l.listener_gender = Console.ReadLine();
                                listenerLogic.Update(l);
                                Console.WriteLine("Listener has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of listener to be Deleted");
                                int deleteId = int.Parse(Console.ReadLine());
                                listenerLogic.Delete(listenerLogic.GetById(deleteId));
                                Console.WriteLine("Listener has been deleted!");
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "playedon":

                        switch (this.Option)
                        {
                            case "1":
                                // GET ALL DOENST ORDER CORRECTLY
                                conn_song_service newPlayedOnConn = new conn_song_service();
                                Console.WriteLine("Select a song ID from below: \n ");
                                foreach (song item in songLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.song_id} {item.song_title} \n");
                                }

                                newPlayedOnConn.connOne_songId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select a service ID from below: \n ");
                                foreach (serv item in serviceLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.serv_id} {item.serv_name} \n");
                                }

                                newPlayedOnConn.connOne_serviceId = int.Parse(Console.ReadLine());

                                playedOnConnLogic.Insert(newPlayedOnConn);
                                Console.WriteLine("New played on connection has been added!");
                                break;
                            case "2":
                                foreach (var item in playedOnConnLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(playedOnConnLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the connection you wish to update?");
                                conn_song_service css = playedOnConnLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("Select a song ID from below: \n ");
                                foreach (song item in songLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.song_id} {item.song_title} \n");
                                }

                                css.connOne_songId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select a service ID from below: \n ");
                                foreach (serv item in serviceLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.serv_id} {item.serv_name} \n");
                                }

                                css.connOne_serviceId = int.Parse(Console.ReadLine());
                                playedOnConnLogic.Update(css);
                                Console.WriteLine("Connection has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of PlayedOn Connection to be Deleted");
                                int deleteId = int.Parse(Console.ReadLine());
                                playedOnConnLogic.Delete(playedOnConnLogic.GetById(deleteId));
                                Console.WriteLine("Connection has been deleted!");
                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "listensto":

                        switch (this.Option)
                        {
                            case "1":
                                conn_listener_song newListensToConn = new conn_listener_song();
                                Console.WriteLine("Select a listener ID from below: \n ");
                                foreach (listener item in listenerLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.listener_id} {item.listener_name} \n");
                                }

                                newListensToConn.connTwo_listenerId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select a song ID from below: \n ");
                                foreach (song item in songLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.song_id} {item.song_title} \n");
                                }

                                newListensToConn.connTwo_songId = int.Parse(Console.ReadLine());

                                listensToConnLogic.Insert(newListensToConn);
                                Console.WriteLine("New listens to connection has been added!");
                                break;
                            case "2":
                                foreach (var item in listensToConnLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(listensToConnLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the connection you wish to update?");
                                conn_listener_song cls = listensToConnLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("Select a listener ID from below: \n ");
                                foreach (listener item in listenerLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.listener_id} {item.listener_name} \n");
                                }

                                cls.connTwo_listenerId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select a song ID from below: \n ");
                                foreach (song item in songLogic.GetAll())
                                {
                                    Console.WriteLine($"{item.song_id} {item.song_title} \n");
                                }

                                cls.connTwo_songId = int.Parse(Console.ReadLine());

                                listensToConnLogic.Update(cls);
                                Console.WriteLine("Connection has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of connection to be Deleted");
                                int deleteId = int.Parse(Console.ReadLine());
                                listensToConnLogic.Delete(listensToConnLogic.GetById(deleteId));
                                Console.WriteLine("Connection has been deleted!");

                                break;
                        }

                        Console.ReadKey();
                        break;
                    case "service":

                        switch (this.Option)
                        {
                            case "1":
                                serv newService = new serv();
                                newService.serv_id = serviceLogic.GetAll().Count() + 1;
                                Console.WriteLine("New Service Name: ");
                                newService.serv_name = Console.ReadLine();
                                Console.WriteLine("New Service Size: ");
                                newService.serv_size = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Service Website: ");
                                newService.serv_website = Console.ReadLine();
                                Console.WriteLine("New Service Price: ");
                                newService.serv_price = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Service Country: ");
                                newService.serv_country = Console.ReadLine();
                                serviceLogic.Insert(newService);
                                Console.WriteLine("New Service has been added!");
                                break;
                            case "2":
                                foreach (var item in serviceLogic.GetAll())
                                {
                                    Console.WriteLine(item.ToString() + "\n");
                                }

                                break;
                            case "3":
                                Console.WriteLine("Give an ID number");
                                idNum = int.Parse(Console.ReadLine());
                                Console.WriteLine(serviceLogic.GetById(idNum).ToString());
                                break;
                            case "4":
                                Console.WriteLine("What is the ID of the service you wish to update?");
                                serv ser = serviceLogic.GetById(int.Parse(Console.ReadLine()));
                                Console.WriteLine("New Service Name: ");
                                ser.serv_name = Console.ReadLine();
                                Console.WriteLine("New Service Size: ");
                                ser.serv_size = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Service Website: ");
                                ser.serv_website = Console.ReadLine();
                                Console.WriteLine("New Service Price: ");
                                ser.serv_price = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Service Country: ");
                                ser.serv_country = Console.ReadLine();
                                serviceLogic.Update(ser);
                                Console.WriteLine("Service has been updated!");
                                break;
                            case "5":
                                Console.WriteLine("Give an ID number of Service to be Deleted");
                                int deleteId = int.Parse(Console.ReadLine());
                                serviceLogic.Delete(serviceLogic.GetById(deleteId));
                                Console.WriteLine("Service has been deleted!");
                                break;
                        }

                        Console.ReadKey();
                        break;
                }
            }
            catch
            {
                new ArgumentNullException();
            }
        }
    }
}
