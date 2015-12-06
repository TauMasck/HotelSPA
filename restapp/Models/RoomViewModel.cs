using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
	/// <summary>
	/// Room view model class.
	/// </summary>
    public class RoomViewModel
    {
		/// <summary>
		/// Gets or sets the identifier of a room.
		/// </summary>
		/// <value>The identifier.</value>
        public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the how many person can stay in a room.
		/// </summary>
		/// <value>The how many person.</value>
        public int HowManyPerson { get; set; }
		/// <summary>
		/// Gets or sets the size of a room.
		/// </summary>
		/// <value>The size.</value>
        public double Size { get; set; }
		/// <summary>
		/// Gets or sets the price of a room.
		/// </summary>
		/// <value>The price.</value>
        public double Price { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RestApp.Models.RoomViewModel"/> is available.
		/// </summary>
		/// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Available { get; set; }
    }
}