namespace VermutClub.Models
{
    public class Payment
    {
        public int Ida { get; set; }
        public int OrderId { get; set; }
        public string Method { get; set; } 
        public string Status { get; set; } 
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }

        public virtual Order? Order { get; set; }
    }
}
