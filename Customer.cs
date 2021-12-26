using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoserviceAppication
{
    /// <summary>
    /// Entity of client
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique identificator of a client
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Client's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Client's phonenumber
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Client's car
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// Client's complaint about the car
        /// </summary>
        public string Problem { get; set; }

        /// <summary>
        /// Name of the mechanic performing the work
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Used details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Services provided
        /// </summary>
        public string Services { get; set; }
    }
}
