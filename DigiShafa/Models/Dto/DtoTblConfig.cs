using System.Net;
using DigiShafa.Models.Regular;

namespace DigiShafa.Models.Dto
{
    public class DtoTblConfig
    {
        public string TellNo { get; set; }

        public HttpStatusCode StatusEffect { get; set; }

        public TblConfig ToRegular()
        {
            return new TblConfig(TellNo);
        }

        public DtoTblConfig(TblConfig config, HttpStatusCode statusEffect)
        {
            TellNo = config.TellNo;

            StatusEffect = statusEffect;
        }

        public DtoTblConfig()
        {
        }
    }
}