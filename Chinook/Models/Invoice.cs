using System;
using System.Collections.Generic;

namespace Chinook.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Invoice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public long InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public long CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        /// <value>
        /// The invoice date.
        /// </value>
        public byte[] InvoiceDate { get; set; } = null!;
        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>
        /// The billing address.
        /// </value>
        public string? BillingAddress { get; set; }
        /// <summary>
        /// Gets or sets the billing city.
        /// </summary>
        /// <value>
        /// The billing city.
        /// </value>
        public string? BillingCity { get; set; }
        /// <summary>
        /// Gets or sets the state of the billing.
        /// </summary>
        /// <value>
        /// The state of the billing.
        /// </value>
        public string? BillingState { get; set; }
        /// <summary>
        /// Gets or sets the billing country.
        /// </summary>
        /// <value>
        /// The billing country.
        /// </value>
        public string? BillingCountry { get; set; }
        /// <summary>
        /// Gets or sets the billing postal code.
        /// </summary>
        /// <value>
        /// The billing postal code.
        /// </value>
        public string? BillingPostalCode { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public byte[] Total { get; set; } = null!;

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customer Customer { get; set; } = null!;
        /// <summary>
        /// Gets or sets the invoice lines.
        /// </summary>
        /// <value>
        /// The invoice lines.
        /// </value>
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
