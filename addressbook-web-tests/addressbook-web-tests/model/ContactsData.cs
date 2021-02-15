using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        private string fname;
        private string lname = "";
        public ContactsData(string fname)
        {
            this.fname = fname;
        }
        public bool Equals(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Fname == other.Fname && Lname == other.Lname;
        }
        public override int GetHashCode()
        {
            //return 0;
            return (Fname + Lname).GetHashCode();
        }
        public override string ToString()
        {
            return "fname=" + Fname + "  " + "lname=" + Lname;
        }
        public int CompareTo(ContactsData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lname.CompareTo(other.Lname) != 0)
            {
                return Lname.CompareTo(other.Lname);
            }
            return Fname.CompareTo(other.Fname);
            //return (Fname + Lname).CompareTo(other.Fname + other.Lname);
        }
        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }
        //public string Fname { get; set; }
        public string Mname { get; set; }
        //public string Lname { get; set; }
        public string Nname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Byear { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }
    }
}
