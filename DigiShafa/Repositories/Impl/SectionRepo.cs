using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class SectionRepo : ISectionRepo
    {
        public TblSection AddSection(TblSection section)
        {
            return (TblSection)new MainProvider().Add(section);
        }
        public bool DeleteSection(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblSection, id);
        }
        public bool UpdateSection(TblSection section, int logId)
        {
            return new MainProvider().Update(section, logId);
        }
        public List<TblSection> SelectAllSections()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblSection).Cast<TblSection>().ToList();
        }
        public TblSection SelectSectionById(int id)
        {
            return (TblSection)new MainProvider().SelectById(MainProvider.Tables.TblSection, id);
        }
        public List<TblSection> SelectSectionByName(string name)
        {
            return new MainProvider().SelectSectionByName(name);
        }

    }
}