using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class IngredientService : IIngredientService
    {
        public TblIngredient AddIngredient(TblIngredient ingredient)
        {
            return (TblIngredient)new IngredientRepo().AddIngredient(ingredient);
        }
        public bool DeleteIngredient(int id)
        {
            return new IngredientRepo().DeleteIngredient(id);
        }
        public bool UpdateIngredient(TblIngredient ingredient, int logId)
        {
            return new IngredientRepo().UpdateIngredient(ingredient, logId);
        }
        public List<TblIngredient> SelectAllIngredients()
        {
            return new IngredientRepo().SelectAllIngredients();
        }
        public TblIngredient SelectIngredientById(int id)
        {
            return (TblIngredient)new IngredientRepo().SelectIngredientById(id);
        }
        public TblIngredient SelectIngredientByName(string name)
        {
            return new IngredientRepo().SelectIngredientByName(name);
        }

    }
}