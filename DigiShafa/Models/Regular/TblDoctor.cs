namespace DigiShafa.Models.Regular
{
    public class TblDoctor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public TblDoctor(int id)
        {
            this.id = id;
        }

		public TblDoctor(int id, string name, string image, string description, int sectionId)
        {
            this.id = id;
            Name = name;
            Image = image;
            Description = description;
            SectionId = sectionId;
        }
        public TblDoctor(string name, string image, string description, int sectionId)
        {
            Name = name;
            Image = image;
            Description = description;
            SectionId = sectionId;
        }

        public TblDoctor()
        {
            
        }
    }
}