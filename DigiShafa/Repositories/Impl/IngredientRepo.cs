using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class IngredientRepo : IIngredientRepo
    {
        public TblIngredient AddIngredient(TblIngredient ingredient)
        {
            return (TblIngredient)new MainProvider().Add(ingredient);
        }
        public bool DeleteIngredient(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblIngredient, id);
        }
        public bool UpdateIngredient(TblIngredient ingredient, int logId)
        {
            return new MainProvider().Update(ingredient, logId);
        }
        public List<TblIngredient> SelectAllIngredients()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblIngredient).Cast<TblIngredient>().ToList();
        }
        public TblIngredient SelectIngredientById(int id)
        {
            return (TblIngredient)new MainProvider().SelectById(MainProvider.Tables.TblIngredient, id);
        }
        public TblIngredient SelectIngredientByName(string name)
        {
            return new MainProvider().SelectIngredientByName(name);
        }

    }
}