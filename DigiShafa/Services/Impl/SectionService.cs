using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class SectionService : ISectionService
    {
        public TblSection AddSection(TblSection section)
        {
            return (TblSection)new SectionRepo().AddSection(section);
        }
        public bool DeleteSection(int id)
        {
            return new SectionRepo().DeleteSection(id);
        }
        public bool UpdateSection(TblSection section, int logId)
        {
            return new SectionRepo().UpdateSection(section, logId);
        }
        public List<TblSection> SelectAllSections()
        {
            return new SectionRepo().SelectAllSections();
        }
        public TblSection SelectSectionById(int id)
        {
            return (TblSection)new SectionRepo().SelectSectionById(id);
        }
        public List<TblSection> SelectSectionByName(string name)
        {
            return new SectionRepo().SelectSectionByName(name);
        }

    }
}