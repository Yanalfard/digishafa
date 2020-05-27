using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        public TblDoctor AddDoctor(TblDoctor doctor)
        {
            return (TblDoctor)new DoctorRepo().AddDoctor(doctor);
        }
        public bool DeleteDoctor(int id)
        {
            return new DoctorRepo().DeleteDoctor(id);
        }
        public bool UpdateDoctor(TblDoctor doctor, int logId)
        {
            return new DoctorRepo().UpdateDoctor(doctor, logId);
        }
        public List<TblDoctor> SelectAllDoctors()
        {
            return new DoctorRepo().SelectAllDoctors();
        }
        public TblDoctor SelectDoctorById(int id)
        {
            return (TblDoctor)new DoctorRepo().SelectDoctorById(id);
        }
        public List<TblDoctor> SelectDoctorByName(string name)
        {
            return new DoctorRepo().SelectDoctorByName(name);
        }
        public TblDoctor SelectDoctorByImage(string image)
        {
            return new DoctorRepo().SelectDoctorByImage(image);
        }
        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            return new DoctorRepo().SelectDoctorBySectionId(sectionId);
        }

    }
}