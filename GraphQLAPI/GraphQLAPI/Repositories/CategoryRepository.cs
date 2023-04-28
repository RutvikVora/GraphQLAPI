using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories.Interfaces;
using System;
using System.Linq;

namespace GraphQLAPI.Repositories
{
    public class CategoryRepository : RepositoryBase<Categories>, ICategoryRepository
    {

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(BookStoreContext bookStoreContext) : base(bookStoreContext)
        {

        }

        /// <summary>
        /// get list of all Categories
        /// </summary>
        /// <returns>list of all Categorys</returns>
        public IQueryable<Categories> GetCategorysList()
        {
            return this.Find();
        }

        /// <summary>
        /// Get Category Details By Id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns>Category of particular Id</returns>
        public Categories GetCategoryById(long? CategoryId)
        {
            return this.Find(x => x.Id == CategoryId).FirstOrDefault();
        }

        /// <summary>
        ///  add or edit Category
        /// </summary>
        /// <param name="CategoryModel"></param>
        /// <returns>Category Entity</returns>
        public Categories UpsertCategory(CategoryModel categoryModel)
        {
            try
            {
                Categories categoryDb = GetCategoryById(categoryModel.categoryId);
                if (categoryDb != null)
                {
                    categoryModel.MappingModelToEntity(categoryDb, categoryModel);

                    this.UpdateEntity(categoryDb);
                    this.Save();
                    return categoryDb;

                }
                else
                {
                    Categories category = categoryModel;
                    this.CreateEntity(category);
                    this.Save();
                    return category;

                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// delete Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public void DeleteCategory(int categoryId)
        {
            Categories category = this.Find(x => x.Id == categoryId).FirstOrDefault();
            this.DeleteEntity(category);
            this.Save();
        }

    }
}
