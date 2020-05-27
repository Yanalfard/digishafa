using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface ISectionRepo
    {
        TblSection AddSection(TblSection section);
        bool DeleteSection(int id);
        bool UpdateSection(TblSection section, int logId);
        List<TblSection> SelectAllSections();
        TblSection SelectSectionById(int id);
        List<TblSection> SelectSectionByName(string name);

    }
}