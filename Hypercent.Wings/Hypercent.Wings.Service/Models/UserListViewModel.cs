using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hypercent.Wings.Models
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> UserList { get; set; }
    }
}