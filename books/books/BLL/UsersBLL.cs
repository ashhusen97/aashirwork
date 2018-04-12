using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace books.BLL
{
    class UsersBLL
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string  Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string img { get; set; }
        public string UserType{ get; set; }
        public string Depart{ get; set; }
        public string Gender { get; set; }
        public string Batch { get; set; }
        public DateTime Added_date { get; set; }
        public int Added_by { get; set; }
        
        
    }
}
