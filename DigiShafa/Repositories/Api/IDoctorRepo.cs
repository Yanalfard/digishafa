using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface IDoctorRepo
    {
        TblDoctor AddDoctor(TblDoctor doctor);
        bool DeleteDoctor(int id);
        bool UpdateDoctor(TblDoctor doctor, int logId);
        List<TblDoctor> SelectAllDoctors();
        TblDoctor SelectDoctorById(int id);
        List<TblDoctor> SelectDoctorByName(string name);
        TblDoctor SelectDoctorByImage(string image);
        List<TblDoctor> SelectDoctorBySectionId(int sectionId);

    }
}