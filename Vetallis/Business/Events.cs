
namespace Vetallis.Business
{
    public class Events
    {
        public int idEvent { get; set; }
        public string eventTitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string region { get; set; }
        public string idSponsoredBy { get; set; }
        public double totalCost { get; set; }
        public int numberOfSeats { get; set; }
    }
}