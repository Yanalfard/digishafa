namespace DigiShafa.Models.Regular
{
    public class TblSection
    {
        public int id { get; set; }
        public string Name { get; set; }

        public TblSection(int id)
        {
            this.id = id;
        }

		public TblSection(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public TblSection(string name)
        {
            Name = name;
        }

        public TblSection()
        {
            
        }
    }
}