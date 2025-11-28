using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class ExercisesDB : BaseDB
    {
        public ExercisesRec Exercises;
        private string SQLSelectByUsername;

        public ExercisesDB()
        {
            Exercises = new ExercisesRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Exercises " +
                      "(aName, aSets, aReps, aWeight) " +
                      "Values (@Name, @Sets, @Reps, @Weight) ";

            SQLUpdate = "Update Exercises Set " +
                                    "aName = @Name, " +
                                    "aSets = @Sets, " +
                                    "aReps = @Reps " +
                                    "aWeight = @Weight " +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Exercises " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Exercises " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Exercises " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Exercises.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Name", Exercises.Name);
                DB.ParameterAdd("@Sets", Exercises.Sets);
                DB.ParameterAdd("@Reps", Exercises.Reps);
                DB.ParameterAdd("@Weight", Exercises.Weight);

            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Exercises.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Exercises);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, ExercisesRec Exercises)
        {
            Exercises.ID = (int)Convert.ToInt64(dbRow["aID"].ToString());
            Exercises.Name = dbRow["aName"].ToString();
            Exercises.Sets = (int)Convert.ToInt64(dbRow["aSets"]);
            Exercises.Reps = (int)Convert.ToInt64(dbRow["aReps"]);
            Exercises.Weight = (int)Convert.ToInt64(dbRow["aWeight"]);


            return Exercises;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity ExercisesRec)
        {
            Exercises.ID = ((ExercisesRec)ExercisesRec).ID;
            Exercises.Name = ((ExercisesRec)ExercisesRec).Name;
            Exercises.Sets = ((ExercisesRec)ExercisesRec).Sets;
            Exercises.Reps = ((ExercisesRec)ExercisesRec).Reps;
            Exercises.Weight = ((ExercisesRec)ExercisesRec).Weight;



        }

        //-----Local-------------------------------------------- 

        public ExercisesList SelectAll()
        {
            ExercisesList ExercisesList = new ExercisesList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new ExercisesList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                ExercisesRec Exercises = new ExercisesRec();
                MoveDBToRecord(dbRow, Exercises);
                //Join Columns 
                Exercises.CountryName = dbRow["coName"].ToString();
                ExercisesList.Add(Exercises);
            }
            return ExercisesList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public ExercisesRec SelectByUsername(string Username)
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

            return Exercises;
        }
    }
}