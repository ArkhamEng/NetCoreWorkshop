namespace GigaWorkshop.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category()
        {
            this.IsActive = true;
        }

        public Category ParentCategory { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
