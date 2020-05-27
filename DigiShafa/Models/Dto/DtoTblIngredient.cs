using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblIngredient
    {
        public int id { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblIngredient ToRegular()
        {
            return new TblIngredient(id, Name);
        }

        public DtoTblIngredient(TblIngredient ingredient, HttpStatusCode statusEffect)
        {
            id = ingredient.id;
            Name = ingredient.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblIngredient()
        {
        }
    }
}