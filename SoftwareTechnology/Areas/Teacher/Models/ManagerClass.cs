using SoftwareTechnology.Models;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Teacher.Models
{
    public class ManagerClass
    {
        public ElementClass Insert { get; set; }
        public ElementClass Update { get; set; }
        public string InsertClass(ManagerClass model, int classTypeID, int branchID, string username, int statusID)
        {
            ModifyClass mc = new ModifyClass();
            List<ListClass> listClass = new ModifyClass().GetList();
            if (CheckHasOpenRegister())
            {
                if (CheckExist(model.Insert.dayID, model.Insert.timeID, model.Insert.roomID, listClass))
                {
                    return ReturnMessageRegister(model.Insert.dayID, model.Insert.timeID, model.Insert.roomID, listClass);
                }
                else
                {
                    List<ListClass> listDayTime = new ModifyClass().GetListDayTimeByBranchID(branchID);
                    if (CheckSameSchedule(branchID, model.Insert.dayID, model.Insert.timeID, listDayTime))
                    {
                        mc.Insert(classTypeID, model.Insert.subjectID, model.Insert.dayID, model.Insert.timeID, model.Insert.roomID, branchID, username, statusID);
                        return "true";
                    }
                    else
                    {
                        return "Đăng ký bị trùng ngày và giờ học";
                    }
                }
            }
            else
            {
                return "Chưa mở đăng ký lớp";
            }
        }
        public string UpdateClass(ManagerClass model, int branchID) // them 1 bien list<class> vao ham de su dung cho lan update + insert
        {
            ModifyClass mc = new ModifyClass();
            List<ListClass> listClass = new ModifyClass().GetListForUpdaate(model.Update.classID);
            if (CheckHasOpenRegister())
            {
                if (CheckExist(model.Update.dayID, model.Update.timeID, model.Update.roomID, listClass))
                {
                    return ReturnMessageRegister(model.Update.dayID, model.Update.timeID, model.Update.roomID, listClass);
                }
                else
                {
                    List<ListClass> listDayTime = new ModifyClass().GetListDayTimeByBranchIDForUpdate(branchID, model.Update.classID);
                    if (CheckSameSchedule(branchID, model.Update.dayID, model.Update.timeID, listDayTime))
                    {
                        mc.Update(model.Update.classID, model.Update.subjectID, model.Update.dayID, model.Update.timeID, model.Update.roomID);
                        return "true";
                    }
                    else
                    {
                        return "Đăng ký bị trùng ngày và giờ học";
                    }
                }
            }
            else
            {
                return "Chưa mở đăng ký lớp";
            }
        }
        public string DeleteClassByID(int ClassID)
        {
            ModifyClass mc = new ModifyClass();
            if (mc.CheckStatusDelete(ClassID))
            {
                mc.Delete(ClassID);
                return "true";
            }
            else
                return "false";
        }
        public bool CheckHasOpenRegister()
        {
            List<OpenRegister> list = new ModifyOpenRegister().GetListByStatusID(3);
            if (list.Count() == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (DateTime.Now > list[i].DayEndClassRegister)
                        return false;
                }
                return true;
            }
        }
        public bool CheckExist(int dayID, int timeID, int roomID, List<ListClass> listClass)
        {
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID == dayID && listClass[i].timeID == timeID && listClass[i].roomID == roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                    return true;
            }
            return false;
        }
        public bool CheckSameSchedule(int branchID, int dayID, int timeID, List<ListClass> listClass)
        {
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID == dayID && listClass[i].timeID == timeID)
                    return false;
            }
            return true;
        }
        public string ReturnMessageRegister(int dayID, int timeID, int roomID, List<ListClass> listClass)
        {
            List<int> listCount = new List<int>();
            List<Room> listRoom = new ModifyRoom().GetList();
            List<Time> listTime = new ModifyTime().GetList();
            List<Day> listDay = new ModifyDay().GetList();
            if (CheckExist(dayID, timeID, roomID, listClass))
            {
                string fail = "Đăng ký thất bại\n";
                if (CheckRoom(dayID, timeID, roomID,listClass))
                {
                    string s = fail + new ModifyDay().GetDayByID(dayID) + " ," + new ModifyTime().GetTimeByID(timeID) + " còn các phòng: ";
                    for (int i = 0; i < listClass.Count(); i++)
                    {
                        if (listClass[i].dayID == dayID && listClass[i].timeID == timeID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                        {
                            listCount.Add(listClass[i].roomID);
                        }
                    }
                    for (int i = 0; i < listRoom.Count(); i++)
                    {
                        bool check = true;
                        for (int j = 0; j < listCount.Count(); j++)
                        {
                            if (listRoom[i].ID == listCount[j])
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check == true)
                        {
                            s += listRoom[i].Name + ", ";
                        }
                    }
                    return s;
                }
                else
                {
                    if (CheckTime(dayID, timeID, roomID, listClass))
                    {
                        string s = fail + new ModifyDay().GetDayByID(dayID) + " , Phòng " + new ModifyRoom().GetRoomByID(roomID) + " còn các ca: ";
                        for (int i = 0; i < listClass.Count(); i++)
                        {
                            if (listClass[i].dayID == dayID && listClass[i].roomID == roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                            {
                                listCount.Add(listClass[i].timeID);
                            }
                        }
                        for (int i = 0; i < listTime.Count(); i++)
                        {
                            bool check = true;
                            for (int j = 0; j < listCount.Count(); j++)
                            {
                                if (listRoom[i].ID == listCount[j])
                                {
                                    check = false;
                                    break;
                                }
                            }
                            if (check == true)
                            {
                                s += listTime[i].Name + ", ";
                            }
                        }
                        return s;
                    }
                    else
                    {
                        if (CheckDay(dayID, timeID, roomID, listClass))
                        {
                            string s = fail + new ModifyTime().GetTimeByID(timeID) + ", Phòng " + new ModifyRoom().GetRoomByID(roomID) + " còn các ngày: ";
                            for (int i = 0; i < listClass.Count(); i++)
                            {
                                if (listClass[i].timeID == timeID && listClass[i].roomID == roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                                {
                                    listCount.Add(listClass[i].dayID);
                                }
                            }
                            for (int i = 0; i < listDay.Count(); i++)
                            {
                                bool check = true;
                                for (int j = 0; j < listCount.Count(); j++)
                                {
                                    if (listDay[i].ID == listCount[j])
                                    {
                                        check = false;
                                        break;
                                    }
                                }
                                if (check == true)
                                {
                                    s += listDay[i].Name + ", ";
                                }
                            }
                            return s;
                        }
                        else
                        {
                            return "Lớp học đã được đăng ký";
                        }
                    }
                }
            }
            else
                return "Lớp học đã được đăng ký";
        }
        public bool CheckRoom(int dayID, int timeID, int roomID, List<ListClass> listClass)
        {
            int Count = 0;
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID == dayID && listClass[i].timeID == timeID && listClass[i].roomID != roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                {
                    Count++;
                }
            }
            if (Count == new ModifyRoom().GetList().Count() - 1)
                return false;
            else
                return true;
        }
        public bool CheckTime(int dayID, int timeID, int roomID, List<ListClass> listClass)
        {
            int Count = 0;
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID == dayID && listClass[i].timeID != timeID && listClass[i].roomID == roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                {
                    Count++;
                }
            }
            if (Count == new ModifyTime().GetList().Count() - 1)
                return false;
            else
                return true;
        }
        public bool CheckDay(int dayID, int timeID, int roomID, List<ListClass> listClass)
        {
            int Count = 0;
            for (int i = 0; i < listClass.Count(); i++)
            {
                if (listClass[i].dayID != dayID && listClass[i].timeID == timeID && listClass[i].roomID == roomID && (listClass[i].statusID == 1 || listClass[i].statusID == 2 || listClass[i].statusID == 3))
                {
                    Count++;
                }
            }
            if (Count == new ModifyDay().GetList().Count() - 1)
                return false;
            else
                return true;
        }
    }
}