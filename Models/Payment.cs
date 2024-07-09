public class Payment
{
    public int Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime DouDate { get; set; }
    public Decimal UnitPrice { get; set; }
    public Decimal MeterReadingStart { get; set; }
    public Decimal MeterReadingEnd { get; set; }
    public Decimal Total { get; set; }
    public string PaymentMethod { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
    // Customer fK
}
