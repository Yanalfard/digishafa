using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblDoctor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblDoctor ToRegular()
        {
            return new TblDoctor(id, Name, Image, Description, SectionId);
        }

        public DtoTblDoctor(TblDoctor doctor, HttpStatusCode statusEffect)
        {
            id = doctor.id;
            Name = doctor.Name;
            Image = doctor.Image;
            Description = doctor.Description;
            SectionId = doctor.SectionId;

            StatusEffect = statusEffect;
        }

        public DtoTblDoctor()
        {
        }
    }
}