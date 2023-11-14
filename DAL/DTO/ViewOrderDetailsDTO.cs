namespace DAL.DTO
{
    public class ViewOrderDetailsDTO
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }  
        public List<OrderBriefDTO> Details { get; set; }

    }
}
