using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class WorkoutsDB : BaseDB
    {
        public WorkoutsRec Workouts;
        private string SQLSelectByUsername;

        public WorkoutsDB()
        {
            Workouts = new WorkoutsRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Workouts " +
                      "(aTitle, aDate, aVisibility, aWorkoutsID) " +
                      "Values (@Title, @Date, @Visibility, @WorkoutsID) ";

            SQLUpdate = "Update Workouts Set " +
                                    "aTitle = @Title, " +
                                    "aDate = @Date " +
                                    "aVisibility = @Visibility " +
                                    "aWorkoutsID = @WorkoutsID " +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Workouts " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Workouts " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Workouts " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Workouts.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Content", Workouts.Title);
                DB.ParameterAdd("@Phone", Workouts.Date);
                DB.ParameterAdd("@Phone", Workouts.Visibility);
                DB.ParameterAdd("@Phone", Workouts.WorkoutsID);


            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Workouts.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Workouts);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, WorkoutsRec Workouts)
        {
            Workouts.ID = (int)Convert.ToInt64(dbRow["aID"].ToString());
            Workouts.Title = dbRow["aTtile"].ToString();
            Workouts.Date = (DateTime)dbRow["aDate"];
            Workouts.Visibility = dbRow["aVisibility"].ToString();
            Workouts.WorkoutsID = (int)Convert.ToInt64(dbRow["aWorkoutsID"]);
            return Workouts;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity WorkoutsRec)
        {
            Workouts.ID = ((WorkoutsRec)WorkoutsRec).ID;
            Workouts.Title = ((WorkoutsRec)WorkoutsRec).Title;
            Workouts.Date = ((WorkoutsRec)WorkoutsRec).Date;
            Workouts.Visibility = ((WorkoutsRec)WorkoutsRec).Visibility;
            Workouts.WorkoutsID = ((WorkoutsRec)WorkoutsRec).WorkoutsID;



        }

        //-----Local-------------------------------------------- 

        public WorkoutsList SelectAll()
        {
            WorkoutsList WorkoutsList = new WorkoutsList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new WorkoutsList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                WorkoutsRec Workouts = new WorkoutsRec();
                MoveDBToRecord(dbRow, Workouts);
                //Join Columns 
                Workouts.CountryName = dbRow["coName"].ToString();
                WorkoutsList.Add(Workouts);
            }
            return WorkoutsList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public WorkoutsRec SelectByUsername(string Username)
        {
            string SQL = SQLSelectByUsername;
            ErrorClear();
            DB.ParametersClear();
            DB.ParameterAdd("@Username", Username);
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return null;
            }
            MoveDBToRecord(DB.dbDataTable.Rows[0]);

            return Workouts;
        }
    }
}