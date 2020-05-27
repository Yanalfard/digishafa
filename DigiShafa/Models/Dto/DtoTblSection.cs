using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblSection
    {
        public int id { get; set; }
        public string Name { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblSection ToRegular()
        {
            return new TblSection(id, Name);
        }

        public DtoTblSection(TblSection section, HttpStatusCode statusEffect)
        {
            id = section.id;
            Name = section.Name;

            StatusEffect = statusEffect;
        }

        public DtoTblSection()
        {
        }
    }
}