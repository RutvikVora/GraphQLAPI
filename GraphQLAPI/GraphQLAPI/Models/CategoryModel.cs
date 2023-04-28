using GraphQLAPI.Infrastructure.DBContext;
using System;
using System.Collections.Generic;

namespace GraphQLAPI.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }

        public CategoryModel(Categories category)
        {
            this.categoryId = category.Id;
            this.Name = category.Name;
            this.CreatedDate = category.CreatedDate;

        }

        public long categoryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }

        public void MappingModelToEntity(Categories category, CategoryModel categoryModel)
        {
            category.Id = categoryModel.categoryId;
            category.Name = categoryModel.Name;
            category.CreatedDate = categoryModel.CreatedDate;
        }

        public static implicit operator Categories(CategoryModel categoryModel)
        {
            return new Categories
            {
                Id = categoryModel.categoryId,
                Name = categoryModel.Name,
                CreatedDate = categoryModel.CreatedDate
            };
                
        } 
    }
}
