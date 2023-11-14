namespace DAL.DTO
{
    public class ViewShoppingCartDTO
    {
        public int CartID { get; set; }
        public float TotalAmount { get; set; }
       public List<ViewProductsInCartDTO> ProductsInCart { get; set; }
    }
}
