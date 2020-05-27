namespace DigiShafa.Models.Regular
{
    public class TblPackIngredientRel
    {
        public int id { get; set; }
        public int PackId { get; set; }
        public int IngredientId { get; set; }

        public TblPackIngredientRel(int id)
        {
            this.id = id;
        }

		public TblPackIngredientRel(int id, int packId, int ingredientId)
        {
            this.id = id;
            PackId = packId;
            IngredientId = ingredientId;
        }
        public TblPackIngredientRel(int packId, int ingredientId)
        {
            PackId = packId;
            IngredientId = ingredientId;
        }

        public TblPackIngredientRel()
        {
            
        }
    }
}