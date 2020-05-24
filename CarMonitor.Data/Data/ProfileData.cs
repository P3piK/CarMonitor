using CarMonitor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CarMonitor.Data.Data
{
    public class ProfileData
    {
        public CMContext Context { get; }


        public ProfileData()
        {
            Context = new CMContext();
        }

        ~ProfileData()
        {
            Context.Dispose();
        }

        public Profile GetProfile(string name)
        {
            return Context.Profiles.Where(p => p.Name == name).Single();
        }

        public void InsertProfile(Profile profile)
        {
            profile.ChangeDate = DateTime.Now;
        }

    }
}
