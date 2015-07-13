
namespace Vetallis.Business
{
    public class Rebate
    {
        public int idRebate { get; set; }
        public int idMember { get; set; }
        public int idPartner { get; set; }
        public bool isDeliveredByPartner { get; set; }
        public double quantity { get; set; }
        public string type { get; set; }
        public string year { get; set; }
    }
}