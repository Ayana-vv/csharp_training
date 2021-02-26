using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        public string allPhones;
        public string allEmails;
        public string fullInfo;

        public ContactsData(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
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
            return (Fname + Lname).GetHashCode();
        }
        public override string ToString()
        {
            return "fname= " + Fname
                + "\nlname= " + Lname
                + "\nmname= " + Mname
                + "\nnname= " + Nname
                + "\ntitle= " + Title
                + "\ncompany= " + Company
                + "\naddress= " + Address
                + "\nhome= " + Home
                + "\nmobile= " + Mobile
                + "\nwork= " + Work
                + "\nfax= " + Fax
                + "\nemail= " + Email
                + "\nemail2= " + Email2
                + "\nemail3= " + Email3
                + "\nhomepage= " + Homepage
                + "\naddress2= " + Address2
                + "\nphone2= " + Phone2
                + "\nnotes= " + Notes;
        }
        public int CompareTo(ContactsData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lname.CompareTo(other.Lname) == 0)
            {
                return Fname.CompareTo(other.Fname);
            }
            return Lname.CompareTo(other.Lname);
        }       
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
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
        public string AllPhones 
        { 
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + "\r\n" + CleanUp(Mobile) + "\r\n" +
                        CleanUp(Work) + "\r\n" + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + "\r\n" + CleanUp(Email2) + "\r\n" + 
                        CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -() ]", "") + "\r\n";
        }
        public string FullInfo
        {
            get
            { 
                return (CleanUp(fullInfo)).Trim();
            }
            set
            {
                fullInfo = value;
            }
        }
    }
}