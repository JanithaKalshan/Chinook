using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InvoiceLine
    {
        /// <summary>
        /// Gets or sets the invoice line identifier.
        /// </summary>
        /// <value>
        /// The invoice line identifier.
        /// </value>
        public long InvoiceLineId { get; set; }
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public long InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the track identifier.
        /// </summary>
        /// <value>
        /// The track identifier.
        /// </value>
        public long TrackId { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public byte[] UnitPrice { get; set; } = null!;
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public long Quantity { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual Invoice Invoice { get; set; } = null!;
        /// <summary>
        /// Gets or sets the track.
        /// </summary>
        /// <value>
        /// The track.
        /// </value>
        public virtual Track Track { get; set; } = null!;
    }
}
