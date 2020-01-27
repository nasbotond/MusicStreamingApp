// <copyright file="INonCRUDLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streaming.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Streaming.Data;

    /// <summary>
    /// INonCRUDLogic interface outlines all the non CRUD methods
    /// </summary>
    public interface INonCRUDLogic
    {
        /// <summary>
        /// Outline of the GetNumberOfListenersBasedOnGender method
        /// </summary>
        /// <returns>returns an IEnumerable of type ListenersGroupBy</returns>
        IEnumerable<ListenersGroupBy> GetNumberOfListenersBasedOnGender();

        /// <summary>
        /// Outlines the GetServicesThatPlayGivenSong method, to be implemented in NonCRUDLogic
        /// </summary>
        /// <param name="songId">takes a songId integer as a parameter</param>
        /// <returns>returns an IEnumerable of type serv</returns>
        IEnumerable<serv> GetServicesThatPlayGivenSong(int songId);

        /// <summary>
        /// Outlines the GetLongestSong method
        /// </summary>
        /// <returns>returns a song</returns>
        song GetLongestSong();

        /// <summary>
        /// Outlines the GetArtistsThatReleasedMusicAfterDate method, to be implemented in NonCRUDLogic
        /// </summary>
        /// <param name="givenDate">Takes a DateTime type as a parameter</param>
        /// <returns>Returns an IEnumerable of type artist</returns>
        IEnumerable<artist> GetArtistsThatReleasedMusicAfterDate(DateTime givenDate);
    }
}
