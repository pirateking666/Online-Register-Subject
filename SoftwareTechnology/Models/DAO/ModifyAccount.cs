using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyAccount
    {
        public Account Select(string username)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Account acc = db.Accounts.SingleOrDefault(x => x.UserName == username);
            return acc;
        }
        public bool Check(string username)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Account acc = db.Accounts.SingleOrDefault(x => x.UserName == username);
            if (acc != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetPositionID(string username)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Account acc = db.Accounts.SingleOrDefault(x => x.UserName == username);
            return acc.PositionID;
        }
        public void Update(string username, string password)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Account acc = db.Accounts.SingleOrDefault(x => x.UserName == username);
            acc.PassWord = password;
            db.SaveChanges();
        }
        public void Insert(string username, string password, int positionID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Account acc = new Account();
            acc.UserName = username;
            acc.PassWord = password;
            acc.PositionID = positionID;
            db.Accounts.Add(acc);
            db.SaveChanges();
        }
    }
}