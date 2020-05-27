namespace DigiShafa.Models.Regular
{
    public class TblIngredient
    {
        public int id { get; set; }
        public string Name { get; set; }

        public TblIngredient(int id)
        {
            this.id = id;
        }

		public TblIngredient(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public TblIngredient(string name)
        {
            Name = name;
        }

        public TblIngredient()
        {
            
        }
    }
}