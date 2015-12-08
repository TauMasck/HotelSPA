using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
	/// <summary>
	/// Client view model class.
	/// </summary>
    public class ClientViewModel
    {
		/// <summary>
		/// Gets or sets the identifier of a client.
		/// </summary>
		/// <value>The identifier.</value>
        public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the name and surname of a client.
		/// </summary>
		/// <value>The name surname.</value>
        public string NameSurname { get; set; }
		/// <summary>
		/// Gets or sets the identifier number of a client.
		/// </summary>
		/// <value>The identifier number.</value>
        public string IdNumber { get; set; }
		/// <summary>
		/// Gets or sets the company of a client.
		/// </summary>
		/// <value>The company.</value>
        public string Company { get; set; }
		/// <summary>
		/// Gets or sets the room number for a client.
		/// </summary>
		/// <value>The room number.</value>
        public Guid? RoomNumber { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the client is here.
		/// </summary>
		/// <value><c>true</c> if this instance is here; otherwise, <c>false</c>.</value>
        public bool IsHere { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RestApp.Models.ClientViewModel"/> is vegetarian.
		/// </summary>
		/// <value><c>true</c> if vegetarian; otherwise, <c>false</c>.</value>
        public bool Vegetarian { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RestApp.Models.ClientViewModel"/> filled a questionnaire.
		/// </summary>
		/// <value><c>true</c> if questionnaire; otherwise, <c>false</c>.</value>
        public bool Questionnaire { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RestApp.Models.ClientViewModel"/> obtained an invoice.
		/// </summary>
		/// <value><c>true</c> if invoice; otherwise, <c>false</c>.</value>
        public bool Invoice { get; set; }
	
    }
}