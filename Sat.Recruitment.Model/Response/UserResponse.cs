using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model.Response
{
    /// <summary>
    /// class to send the resulting data when a call is made to the api controller
    /// </summary>
    public class UserResponse
    {
        public Guid IdGuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }

        public decimal Money { get; set; }

    }
}
