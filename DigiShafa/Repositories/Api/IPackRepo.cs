using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface IPackRepo
    {
        TblPack AddPack(TblPack pack);
        bool DeletePack(int id);
        bool UpdatePack(TblPack pack, int logId);
        List<TblPack> SelectAllPacks();
        TblPack SelectPackById(int id);
        List<TblPack> SelectPackByName(string name);
        List<TblPack> SelectPackBySectionId(int sectionId);

    }
}