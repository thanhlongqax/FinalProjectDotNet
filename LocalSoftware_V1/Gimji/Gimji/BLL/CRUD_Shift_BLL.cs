using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class CRUD_Shift_BLL
    {
        CRUD_Shift_DAO  newDao = new CRUD_Shift_DAO();
        public List<Shift> getAllShift_BLL()
        {
            return newDao.GetAllShift_DAO();
        }
        public Shift GetShiftByInfor_BLL(String shift, String staffID, DateTime date)
        {
            return newDao.GetShilftByInfor_DAO(shift,staffID,date);
        }
        public Shift GetShiftByID_BLL(String shift)
        {
            return newDao.GetShilftByID_DAO(shift);
        }

        public void addShift_DAO(Shift addShift)
        {
            newDao.AddShift_DAO(addShift);
        }
        public void updateShift_BLL(Shift shift)
        {
            newDao.UpdateShift_DAO(shift);
        }
        public void DeleteShiftById(String idShift)
        {
            newDao.DeleteShiftById_DAO(idShift);
        }
    }
}
