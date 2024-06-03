using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;

namespace Gimji.BLL
{

    internal class CRUD_Staff_BLL
    {
        public CRUD_Staff_DAO newDao = new CRUD_Staff_DAO();
        public List<Staff> getAllStaff() {
            return newDao.getAllStaff_DAO();
        }
        public Staff getStaffbyId(String Staffid)
        {
            return newDao.getStaffById_DAO(Staffid);
        }
        public void AddStaff_BLL(Staff newStaff) {
            newDao.addStaff_DAO(newStaff);
        }
        public void deletebyId(String Staffid)
        {
            newDao.deleteStaff_DAO(Staffid);
        }
        public void updateStaff(Staff staff)
        {
            newDao.UpdateStaff_DAO(staff);
        }
        public List<string> getAllStaffIds()
        {
            return newDao.getAllStaffIds();
        }
    }
}
