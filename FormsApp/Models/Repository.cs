namespace FormsApp.Models
{
    public static class Repository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{ Id = 1, Name = "Telefon"},
            new Category{ Id = 2, Name = "Bilgisayar"}
        };

        private static List<Product> _products = new List<Product>()
        {
            new Product{ Id=1, Name="iPhone 14", Price=40000, IsActive=true, Image="1.jpg", CategoryId=1 },
            new Product{ Id=2, Name="iPhone 15", Price=50000, IsActive=false, Image="2.jpg", CategoryId=1 },
            new Product{ Id=3, Name="iPhone 16", Price=60000, IsActive=true, Image="3.jpg", CategoryId=1 },
            new Product{ Id=4, Name="Macbook Air", Price=80000, IsActive=false, Image="4.jpg", CategoryId=2 },
            new Product{ Id=5, Name="Macbook Pro", Price=90000, IsActive=true, Image="5.jpg", CategoryId=2 }
        };

        public static List<Product> Products => _products;
        public static List<Category> Categories => _categories;
    }
}
