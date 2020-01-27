//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Streaming.Data
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Class which defines a listener element
    /// </summary>
    public partial class listener
    {
        /// <summary>
        /// Constructor of the listener which sets the list of conn_listener_song to a new HashSet of conn_listener_song objects
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public listener()
        {
            this.conn_listener_song = new HashSet<conn_listener_song>();
        }

        /// <summary>
        /// Properties for the listener_id of the listener
        /// </summary>
        public int listener_id { get; set; }
        /// <summary>
        /// Properties for the listener_name of the listener
        /// </summary>
        public string listener_name { get; set; }
        /// <summary>
        /// Properties for the listener_country of the listener
        /// </summary>
        public string listener_country { get; set; }
        /// <summary>
        /// Properties for the listener_deviceType of the listener
        /// </summary>
        public string listener_deviceType { get; set; }
        /// <summary>
        /// Properties for the listener_email of the listener
        /// </summary>
        public string listener_email { get; set; }
        /// <summary>
        /// Properties for the listener_gender of the listener
        /// </summary>
        public string listener_gender { get; set; }

        /// <summary>
        /// Properties for the conn_listener_song of the listener        
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conn_listener_song> conn_listener_song { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Listener ID: {listener_id}, Listener Name: {listener_name}, Country: {listener_country}," +
                $" Type of Device: {listener_deviceType}, Email: {listener_email}, Gender: {listener_gender}";
        }
    }
}