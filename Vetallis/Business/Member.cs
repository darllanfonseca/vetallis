using System;

namespace Vetallis.Business
{
    public class Member
    {
        public string id { get; set; }
        public string idGroup { get; set; }
        public string accountNumber { get; set; }
        public string name { get; set; }
        public DateTime dateJoined { get; set; }
        public string status { get; set; }
        public string doctor { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string website { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string faxNumber { get; set; }
        public string contactPerson { get; set; }
    }
}