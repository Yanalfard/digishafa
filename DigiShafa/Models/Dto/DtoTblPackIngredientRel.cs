using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblPackIngredientRel
    {
        public int id { get; set; }
        public int PackId { get; set; }
        public int IngredientId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPackIngredientRel ToRegular()
        {
            return new TblPackIngredientRel(id, PackId, IngredientId);
        }

        public DtoTblPackIngredientRel(TblPackIngredientRel packIngredientRel, HttpStatusCode statusEffect)
        {
            id = packIngredientRel.id;
            PackId = packIngredientRel.PackId;
            IngredientId = packIngredientRel.IngredientId;

            StatusEffect = statusEffect;
        }

        public DtoTblPackIngredientRel()
        {
        }
    }
}