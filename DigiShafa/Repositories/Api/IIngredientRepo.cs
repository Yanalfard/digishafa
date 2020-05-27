using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface IIngredientRepo
    {
        TblIngredient AddIngredient(TblIngredient ingredient);
        bool DeleteIngredient(int id);
        bool UpdateIngredient(TblIngredient ingredient, int logId);
        List<TblIngredient> SelectAllIngredients();
        TblIngredient SelectIngredientById(int id);
        TblIngredient SelectIngredientByName(string name);

    }
}