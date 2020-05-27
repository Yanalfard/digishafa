using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class PackRepo : IPackRepo
    {
        public TblPack AddPack(TblPack pack)
        {
            return (TblPack)new MainProvider().Add(pack);
        }
        public bool DeletePack(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblPack, id);
        }
        public bool UpdatePack(TblPack pack, int logId)
        {
            return new MainProvider().Update(pack, logId);
        }
        public List<TblPack> SelectAllPacks()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblPack).Cast<TblPack>().ToList();
        }
        public TblPack SelectPackById(int id)
        {
            return (TblPack)new MainProvider().SelectById(MainProvider.Tables.TblPack, id);
        }
        public List<TblPack> SelectPackByName(string name)
        {
            return new MainProvider().SelectPackByName(name);
        }
        public List<TblPack> SelectPackBySectionId(int sectionId)
        {
            return new MainProvider().SelectPackBySectionId(sectionId);
        }

    }
}