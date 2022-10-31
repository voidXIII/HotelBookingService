namespace Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public string RoomName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string RoomPictureUrl { get; set; }
        public string Type { get; set; }
    }
}