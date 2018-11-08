using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class ModifyClass
    {
        public List<ListClass> GetList()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.ClassTypeID == 1).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListScheduleByTeacherID(int teacherID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.TeacherID == teacherID).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListByBranchIDAndCourseID(int branchID, int courseID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.BranchID == branchID && x.CourseID == courseID).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListByBranchID(int branchID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.BranchID == branchID).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListClassWithStatusIDAndClassTypeID(int statusID, int classTypeID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID == statusID && x.ClassTypeID == classTypeID).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListClassRe()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.ClassTypeID == 2).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListClassForStudent()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID == 2 || x.StatusID == 3).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListScheduleByStudentID(int studentID, int branchID) // processing
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            int[] classIDArray = new ModifyStudentDetail().GetArrayClassIDByStudentID(studentID);
            return db.Classes.Where(x => classIDArray.Contains(x.ID)).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListForUpdaate(int ClassID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.ID != ClassID).Select(x => new ListClass { ID = x.ID, classTypeID = x.ClassTypeID, courseID = x.CourseID, branchID = x.BranchID, subjectID = x.SubjectID, dayID = x.DayID, timeID = x.TimeID, roomID = x.RoomID, teacherID = x.TeacherID, statusID = x.StatusID, numberOfStudent = (int)x.NumberOfStudent, dayStart = (DateTime)x.DayStart, dayEnd = (DateTime)x.DayEnd, classType = x.ClassType.Name, course = x.Course.Name, branch = x.Branch.Name, subject = x.Subject.Name, day = x.Day.Name, time = x.Time.Name, room = x.Room.Name, teacher = x.Teacher.Name, status = x.Status.Name }).ToList();
        }
        public List<ListClass> GetListDayTimeByBranchID(int branchID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.BranchID == branchID).Select(x => new ListClass { dayID = x.DayID, timeID = x.TimeID }).ToList();
        }
        public List<ListClass> GetListDayTimeByBranchIDForUpdate(int branchID, int ClassID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            return db.Classes.Where(x => x.StatusID != 5 && x.BranchID == branchID && x.ID != ClassID).Select(x => new ListClass { dayID = x.DayID, timeID = x.TimeID }).ToList();
        }
        public Class GetClassByID(int ClassID)
        {
            return new SoftwareTechnologyDBContext().Classes.SingleOrDefault(x => x.ID == ClassID);
        }
        public bool CheckStatusDelete(int ClassID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = db.Classes.SingleOrDefault(x => x.ID == ClassID);
            if (c.StatusID == 2 || c.StatusID == 3)
            {
                return false;
            }
            else
                return true;
        }
        public void Update(int ClassID, int subjectID, int dayID, int timeID, int roomID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = db.Classes.SingleOrDefault(x => x.ID == ClassID);
            c.SubjectID = subjectID;
            c.DayID = dayID;
            c.TimeID = timeID;
            c.RoomID = roomID;
            db.SaveChanges();
        }
        public void Delete(int ClassID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = db.Classes.SingleOrDefault(x => x.ID == ClassID);
            db.Classes.Remove(c);
            db.SaveChanges();
        }
        public void Insert(int classTypeID, int subjectID, int dayID, int timeID, int roomID, int branchID, string username, int statusID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = new Class();
            c.ID = GetNextID();
            c.ClassTypeID = classTypeID;
            c.CourseID = GetCourseID(subjectID, branchID);
            c.BranchID = branchID;
            c.SubjectID = subjectID;
            c.DayID = dayID;
            c.TimeID = timeID;
            c.RoomID = roomID;
            c.TeacherID = new ModifyTeacher().GetTeacherByUsername(username).ID;
            c.StatusID = statusID;
            c.NumberOfStudent = 0;
            c.DayStart = new ModifyOpenRegister().GetDayStartByStatusID(3).AddDays(21);
            c.DayEnd = new ModifyOpenRegister().GetDayStartByStatusID(3).AddDays(126);
            db.Classes.Add(c);
            db.SaveChanges();
        }
        public void InsertForClassRe(int classTypeID, int subjectID, int dayID, int timeID, int roomID, int branchID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = new Class();
            c.ID = GetNextID();
            c.ClassTypeID = classTypeID;
            c.CourseID = 0;
            c.BranchID = branchID;
            c.SubjectID = subjectID;
            c.DayID = dayID;
            c.TimeID = timeID;
            c.RoomID = roomID;
            c.TeacherID = 0;
            c.StatusID = 1;
            c.NumberOfStudent = 0;
            c.DayStart = DateTime.Now;
            c.DayEnd = DateTime.Now;
            db.Classes.Add(c);
            db.SaveChanges();
        }
        public void ChangeStatusClass()
        {
            if (new SoftwareTechnologyDBContext().OpenRegisters.ToList().Count() != 0)
            {
                if (DateTime.Now > new ModifyOpenRegister().GetDayEndClassRegisterByStatus(3))
                {
                    List<Class> list = new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 1 && x.ClassTypeID == 1).ToList();
                    if (list.Count() != 0)
                    {
                        for (int i = 0; i < list.Count(); i++)
                        {
                            UpdateStatus(list[i].ID, 2);
                        }
                    }
                }
            }
        }
        public void ChangeStatusClassByNumberOfStudent()
        {
            if (new SoftwareTechnologyDBContext().OpenRegisters.ToList().Count() == 0)
            {
                //
            }
            else
            {
                if ((new SoftwareTechnologyDBContext().OpenRegisters.Where(x => x.StatusID == 3).ToList().Count() == 0 && new ModifyClass().GetListClassWithStatusIDAndClassTypeID(2, 1).Count() != 0) || (new ModifyOpenRegister().GetDayEndByStatusID(3) < DateTime.Now && new ModifyClass().GetListClassWithStatusIDAndClassTypeID(2, 1).Count() != 0))
                {
                    List<ListClass> listClass = new ModifyClass().GetListClassWithStatusIDAndClassTypeID(2, 1);
                    for (int i = 0; i < listClass.Count(); i++)
                    {
                        if (listClass[i].numberOfStudent >= 15)
                        {
                            UpdateStatus(listClass[i].ID, 3);
                        }
                        else
                        {
                            UpdateStatus(listClass[i].ID, 4);
                        }
                    }
                }
            }
        }
        public void ChangeStatusClassIfItEnd()
        {
            if (new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 3 && x.DayEnd < DateTime.Now && x.ClassTypeID == 1).ToList().Count == 0)
            {
                //
            }
            else
            {
                List<ListClass> listClass = new ModifyClass().GetListClassWithStatusIDAndClassTypeID(3, 1);
                for (int i = 0; i < listClass.Count(); i++)
                {
                    UpdateStatus(listClass[i].ID, 5);
                }
            }
        }
        public void ChangeStatusClassRe()
        {
            if (new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 1 && x.ClassTypeID == 2).ToList().Count() == 0)
            {
                //
            }
            else
            {
                List<Class> listClass = new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 1 && x.ClassTypeID == 2).ToList();
                for (int i = 0; i < listClass.Count(); i++)
                {
                    if (DateTime.Now > listClass[i].DayStart.Value.AddDays(7) && listClass[i].NumberOfStudent >= 15)
                    {
                        UpdateStatus(listClass[i].ID, 2);
                    }
                    else if (DateTime.Now > listClass[i].DayStart.Value.AddDays(7) && listClass[i].NumberOfStudent < 15)
                    {
                        UpdateStatus(listClass[i].ID, 4);
                    }
                }
            }
        }
        public void ChangeStatusIfTeacherNotReceive()
        {
            if (new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 2 && x.ClassTypeID == 2).ToList().Count() == 0)
            {
                //
            }
            else
            {
                List<Class> listClass = new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 2 && x.ClassTypeID == 2).ToList();
                for (int i = 0; i < listClass.Count(); i++)
                {
                    if(DateTime.Now > listClass[i].DayStart.Value.AddDays(14) && listClass[i].TeacherID == 0)
                    {
                        UpdateStatus(listClass[i].ID, 4);
                    }
                }
            }
        }
        public void ChangeStatusIfClassReEnd()
        {
            if(new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 3).ToList().Count() == 0)
            {
                //
            }
            else
            {
                List<Class> listClass = new SoftwareTechnologyDBContext().Classes.Where(x => x.StatusID == 3).ToList();
                for (int i = 0; i < listClass.Count(); i++)
                {
                    if (DateTime.Now > listClass[i].DayEnd)
                    {
                        UpdateStatus(listClass[i].ID, 5);
                    }
                }
            }
        }
        public void UpdateStatus(int ClassID, int StatusID)
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            Class c = db.Classes.SingleOrDefault(x => x.ID == ClassID);
            c.StatusID = StatusID;
            db.SaveChanges();
        }
        public int GetNextID()
        {
            SoftwareTechnologyDBContext db = new SoftwareTechnologyDBContext();
            List<Class> c = db.Classes.OrderByDescending(x => x.ID).Take(1).ToList();
            if (c.Count() == 0)
                return 1;
            return c[0].ID + 1;
        }
        public int GetCourseID(int subjectID, int branchID)
        {
            List<ListSubject> list = new ModifySubjectProgram().GetList(branchID);
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].subjectID == subjectID)
                {
                    if (list[i].semesterID == 3 || list[i].semesterID == 4)
                        return new ModifyCourse().GetCourseIDForYear(DateTime.Now.Year - 1);
                    else if (list[i].semesterID == 5 || list[i].semesterID == 6)
                        return new ModifyCourse().GetCourseIDForYear(DateTime.Now.Year - 2);
                    else if (list[i].semesterID == 7 || list[i].semesterID == 8)
                        return new ModifyCourse().GetCourseIDForYear(DateTime.Now.Year - 3);
                }
            }
            return 0;
        }
    }
}