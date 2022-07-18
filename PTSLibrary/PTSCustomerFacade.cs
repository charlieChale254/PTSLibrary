using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    class PTSCustomerFacade : PTSSuperFacade
    {
        private DAO.CustomerDAO dao;

        public PTSCustomerFacade() : base(new PTSLibrary.DAO.CustomerDAO)
        {
            dao = new DAO.CustomerDAO();    
        }

        public new Project[] GetListOfTasks(Guid projectId)
        {


            return (dao.GetListOfProjects(customerId)).ToArray();
        }

    }
}
