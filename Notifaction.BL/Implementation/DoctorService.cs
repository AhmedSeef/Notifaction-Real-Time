using Notifaction.BL.Contract;
using Notifaction.BL.Implementation.Base;
using Notifaction.DAL.contract;
using Notifaction.DAL.contract.Base;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.BL.Implementation
{
    public class DoctorService : Service<Doctor>, IDoctorService
    {
        IUnitOfWork _unitOfWork;
        IDoctorRepository _doctorRepository;

        public DoctorService(IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
            : base(unitOfWork, doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
        }
    }
}
