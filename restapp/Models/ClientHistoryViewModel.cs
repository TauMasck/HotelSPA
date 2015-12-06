using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
	/// <summary>
	/// Client history view model class.
	/// </summary>
    public class ClientHistoryViewModel
    {
        //ClientId chyba jest tutaj niepotrzebne
		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>The client identifier.</value>
        public Guid ClientId { get; set; }
		/// <summary>
		/// Gets or sets the treatment identifier.
		/// </summary>
		/// <value>The treatment identifier.</value>
        public TreatmentViewModel Treatment { get; set; } 
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RestApp.Models.ClientHistoryViewModel"/> treatment is supposed to be performed during current stay.
		/// </summary>
		/// <value><c>true</c> if this stay; otherwise, <c>false</c>.</value>
        public bool ThisStay { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether treatment is done.
		/// </summary>
		/// <value><c>true</c> if this instance is done; otherwise, <c>false</c>.</value>
        public bool IsDone { get; set; }
    }
}