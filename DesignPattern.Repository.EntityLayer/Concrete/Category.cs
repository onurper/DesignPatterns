using System.Collections.Generic;

namespace DesignPattern.Repository.EntityLayer.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<Product> Products { get; set; }
    }
}