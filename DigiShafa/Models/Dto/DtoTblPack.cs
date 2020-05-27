using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblPack
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblPack ToRegular()
        {
            return new TblPack(id, Name, Description, SectionId);
        }

        public DtoTblPack(TblPack pack, HttpStatusCode statusEffect)
        {
            id = pack.id;
            Name = pack.Name;
            Description = pack.Description;
            SectionId = pack.SectionId;

            StatusEffect = statusEffect;
        }

        public DtoTblPack()
        {
        }
    }
}