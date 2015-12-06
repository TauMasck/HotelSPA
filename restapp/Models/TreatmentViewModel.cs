using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
	/// <summary>
	/// Treatment view model class.
	/// </summary>
    public class TreatmentViewModel
    {
		/// <summary>
		/// Gets or sets the identifier of a treatment.
		/// </summary>
		/// <value>The identifier.</value>
        public Guid Id { get; set; }
		/// <summary>
		/// Gets or sets the name of a treatment.
		/// </summary>
		/// <value>The name.</value>
        public string Name { get; set; }
		/// <summary>
		/// Gets or sets the price of a treatment.
		/// </summary>
		/// <value>The price.</value>
        public double Price { get; set; }
		/// <summary>
		/// Gets or sets the duration of a treatment.
		/// </summary>
		/// <value>The duration.</value>
        public int Duration { get; set; }
		/// <summary>
		/// Gets or sets the description of a treatment.
		/// </summary>
		/// <value>The description.</value>
        public string Description { get; set; }
        //public bool Active { get; set; }
    }
}