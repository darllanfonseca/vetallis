
namespace Vetallis.Business
{
    public class Rebate
    {
        public string idRebate { get; set; }
        public string idMember { get; set; }
        public string idPartner { get; set; }
        public bool isDeliveredByPartner { get; set; }
        public string quantity { get; set; }
        public string type { get; set; }
        public string year { get; set; }
        public string dateModified { get; set; }
        public string modifiedBy { get; set; }
    }
}