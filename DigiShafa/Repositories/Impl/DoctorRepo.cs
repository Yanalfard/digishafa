using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class DoctorRepo : IDoctorRepo
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return (TblDoctor)new MainProvider().Add(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblDoctor, id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new MainProvider().Update(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblDoctor).Cast<TblDoctor>().ToList();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new MainProvider().SelectById(MainProvider.Tables.TblDoctor, id);
        }
        public List<TblDoctor> SelectDoctorByName(string name)
        {
            return new MainProvider().SelectDoctorByName(name);
        }
        public TblDoctor SelectDoctorByImage(string image)
        {
            return new MainProvider().SelectDoctorByImage(image);
        }
        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            return new MainProvider().SelectDoctorBySectionId(sectionId);
        }

    }
}