using MyCookBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCookBook.Data
{
    public class LocalDB
    {
        protected readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
            database.CreateTableAsync<Igredient>().Wait();
        }

        public async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        public async Task<List<Recipe>> GeRecipeByText(string text)
        {
            return await database.Table<Recipe>().Where(x => x.Name.ToLower().Contains(text.ToLower())).ToListAsync();
        }

        public async Task<T> GetItemByID<T>(int id) where T : class, ISqlModel, new()
        {
            return await database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> SaveItem<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);
            
            return item;
        }

        public async Task<int> DeleteItem<T>(T item)
        {
            return await database.DeleteAsync(item);
        }

        public void Drop<T>() where T : class, new()
        {
            database.ExecuteAsync("Truncate table RECIPE");
        }

        public async Task<List<Igredient>> GetAllIgredientsByRecipe(Recipe recipe)
        {
            return await database.Table<Igredient>().Where(x => x.RecipeId == recipe.Id).ToListAsync();
        }
    }
}
