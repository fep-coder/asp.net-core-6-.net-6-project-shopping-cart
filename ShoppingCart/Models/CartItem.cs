namespace ShoppingCart.Models
{
        public class CartItem
        {
                public long ProductId { get; set; }
                public string ProductName { get; set; }
                public int Quantity { get; set; }
                public decimal Price { get; set; }
                public decimal Total
                {
                        get { return Quantity * Price; }
                }
                public string Image { get; set; }

                public CartItem()
                {
                }

                public CartItem(Product product)
                {
                        ProductId = product.Id;
                        ProductName = product.Name;
                        Price = product.Price;
                        Quantity = 1;
                        Image = product.Image;
                }

        }
}
