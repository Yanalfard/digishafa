using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class PackIngredientRelService : IPackIngredientRelService
    {
        public TblPackIngredientRel AddPackIngredientRel(TblPackIngredientRel packIngredientRel)
        {
            return (TblPackIngredientRel)new PackIngredientRelRepo().AddPackIngredientRel(packIngredientRel);
        }
        public bool DeletePackIngredientRel(int id)
        {
            return new PackIngredientRelRepo().DeletePackIngredientRel(id);
        }
        public bool UpdatePackIngredientRel(TblPackIngredientRel packIngredientRel, int logId)
        {
            return new PackIngredientRelRepo().UpdatePackIngredientRel(packIngredientRel, logId);
        }
        public List<TblPackIngredientRel> SelectAllPackIngredientRels()
        {
            return new PackIngredientRelRepo().SelectAllPackIngredientRels();
        }
        public TblPackIngredientRel SelectPackIngredientRelById(int id)
        {
            return (TblPackIngredientRel)new PackIngredientRelRepo().SelectPackIngredientRelById(id);
        }
        public List<TblPackIngredientRel> SelectPackIngredientRelByPackId(int packId)
        {
            return new PackIngredientRelRepo().SelectPackIngredientRelByPackId(packId);
        }
        public List<TblPackIngredientRel> SelectPackIngredientRelByIngredientId(int ingredientId)
        {
            return new PackIngredientRelRepo().SelectPackIngredientRelByIngredientId(ingredientId);
        }

    }
}