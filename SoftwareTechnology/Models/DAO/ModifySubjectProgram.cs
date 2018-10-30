using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifySubjectProgram
    {
        public List<ListSubject> GetList()
        {
            DateTime dt = DateTime.Now;
            if (dt.Month == 7 || dt.Month == 8 || dt.Month == 9 || dt.Month == 10 || dt.Month == 11)
            {
                List<ListSubject> list = new SoftwareTechnologyDBContext().SubjectPrograms.Where(x => x.SemesterID == 1 || x.SemesterID == 3 || x.SemesterID == 5 || x.SemesterID == 7).Select(x => new ListSubject { name = x.Subject.Name, credit = x.Subject.Credit, subjectID = x.Subject.ID, branchID = x.BranchID, semesterID = x.SemesterID }).ToList();
                return list;
            }
            else
            {
                List<ListSubject> list = new SoftwareTechnologyDBContext().SubjectPrograms.Where(x => x.SemesterID == 2 || x.SemesterID == 4 || x.SemesterID == 6 || x.SemesterID == 8).Select(x => new ListSubject { name = x.Subject.Name, credit = x.Subject.Credit, subjectID = x.Subject.ID, branchID = x.BranchID, semesterID = x.SemesterID }).ToList();
                return list;
            }
        }
        public List<ListSubject> GetList(int branchID)
        {
            List<ListSubject> list = new SoftwareTechnologyDBContext().SubjectPrograms.Where(x => x.BranchID == branchID).Select(x => new ListSubject { subjectID = x.SubjectID, name = x.Subject.Name, credit = x.Subject.Credit }).ToList();
            return list;
        }
    }
}