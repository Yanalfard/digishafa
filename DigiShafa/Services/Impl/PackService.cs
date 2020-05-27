using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class PackService : IPackService
    {
        public TblPack AddPack(TblPack pack)
        {
            return (TblPack)new PackRepo().AddPack(pack);
        }
        public bool DeletePack(int id)
        {
            return new PackRepo().DeletePack(id);
        }
        public bool UpdatePack(TblPack pack, int logId)
        {
            return new PackRepo().UpdatePack(pack, logId);
        }
        public List<TblPack> SelectAllPacks()
        {
            return new PackRepo().SelectAllPacks();
        }
        public TblPack SelectPackById(int id)
        {
            return (TblPack)new PackRepo().SelectPackById(id);
        }
        public List<TblPack> SelectPackByName(string name)
        {
            return new PackRepo().SelectPackByName(name);
        }
        public List<TblPack> SelectPackBySectionId(int sectionId)
        {
            return new PackRepo().SelectPackBySectionId(sectionId);
        }
        public List<TblIngredient>SelectIngredientsByPackId(int packId)
        {
            List<TblPackIngredientRel> stp1 = new PackIngredientRelRepo().SelectPackIngredientRelByPackId(packId);
            List<TblIngredient> stp2 = new List<TblIngredient>();
            foreach (TblPackIngredientRel rel in stp1)
                stp2.Add(new IngredientRepo().SelectIngredientById(rel.IngredientId));
            return stp2;
        }

    }
}