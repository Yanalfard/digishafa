using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class PackIngredientRelRepo : IPackIngredientRelRepo
    {
        public TblPackIngredientRel AddPackIngredientRel(TblPackIngredientRel packIngredientRel)
        {
            return (TblPackIngredientRel)new MainProvider().Add(packIngredientRel);
        }
        public bool DeletePackIngredientRel(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPackIngredientRel, id);
        }
        public bool UpdatePackIngredientRel(TblPackIngredientRel packIngredientRel, int logId)
        {
            return new MainProvider().Update(packIngredientRel, logId);
        }
        public List<TblPackIngredientRel> SelectAllPackIngredientRels()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPackIngredientRel).Cast<TblPackIngredientRel>().ToList();
        }
        public TblPackIngredientRel SelectPackIngredientRelById(int id)
        {
            return (TblPackIngredientRel)new MainProvider().SelectById(MainProvider.Tables.TblPackIngredientRel, id);
        }
        public List<TblPackIngredientRel> SelectPackIngredientRelByPackId(int packId)
        {
            return new MainProvider().SelectPackIngredientRel(packId, MainProvider.PackIngredientRel.PackId);
        }
        public List<TblPackIngredientRel> SelectPackIngredientRelByIngredientId(int ingredientId)
        {
            return new MainProvider().SelectPackIngredientRel(ingredientId, MainProvider.PackIngredientRel.IngredientId);
        }

    }
}