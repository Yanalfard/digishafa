namespace DigiShafa.Models.Regular
{
    public class TblPack
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public TblPack(int id)
        {
            this.id = id;
        }

		public TblPack(int id, string name, string description, int sectionId)
        {
            this.id = id;
            Name = name;
            Description = description;
            SectionId = sectionId;
        }
        public TblPack(string name, string description, int sectionId)
        {
            Name = name;
            Description = description;
            SectionId = sectionId;
        }

        public TblPack()
        {
            
        }
    }
}