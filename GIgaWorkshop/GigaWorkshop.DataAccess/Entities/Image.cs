namespace GigaWorkshop.DataAccess.Entities
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public string Path { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
