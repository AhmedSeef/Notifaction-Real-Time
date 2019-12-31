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
    public class patientService : Service<patient>, IPatientService
    {
        IUnitOfWork _unitOfWork;
        IPatientRepository _patientRepository;

        public patientService(IUnitOfWork unitOfWork, IPatientRepository patientRepository)
            : base(unitOfWork, patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }
    }
}
