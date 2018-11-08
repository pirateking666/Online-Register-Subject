using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyRoom
    {
        public List<Room> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Rooms.ToList();
        }
        public string GetRoomByID(int roomID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Room r = db.Rooms.SingleOrDefault(x => x.ID == roomID);
            return r.Name;
        }
    }
}