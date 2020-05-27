using System.Collections.Generic;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;

namespace DigiShafa.Services.Api
{
    public interface IPackService : IPackRepo
    {
        List<TblIngredient>SelectIngredientsByPackId(int packId);

    }
}