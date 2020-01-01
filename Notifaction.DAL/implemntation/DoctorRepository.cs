using Notifaction.DAL.contract;
using Notifaction.DAL.implemntation.Base;
using Notifaction.DB;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.implemntation
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly DataContext _Context;

        public DoctorRepository(DataContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
