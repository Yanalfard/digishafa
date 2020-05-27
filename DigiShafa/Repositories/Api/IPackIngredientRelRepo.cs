using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface IPackIngredientRelRepo
    {
        TblPackIngredientRel AddPackIngredientRel(TblPackIngredientRel packIngredientRel);
        bool DeletePackIngredientRel(int id);
        bool UpdatePackIngredientRel(TblPackIngredientRel packIngredientRel, int logId);
        List<TblPackIngredientRel> SelectAllPackIngredientRels();
        TblPackIngredientRel SelectPackIngredientRelById(int id);
        List<TblPackIngredientRel> SelectPackIngredientRelByPackId(int packId);
        List<TblPackIngredientRel> SelectPackIngredientRelByIngredientId(int ingredientId);

    }
}