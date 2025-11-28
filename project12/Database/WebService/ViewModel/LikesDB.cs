using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class LikesDB : BaseDB
    {
        public LikesRec Likes;
        private string SQLSelectByUsername;

        public LikesDB()
        {
            Likes = new LikesRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Likes " +
                      "(aDate, aPostID) " +
                      "Values (@Date, @PostID) ";

            SQLUpdate = "Update Likes Set " +
                                    "aDate = @Date, " +
                                    "aPostID = @PostID " +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Likes " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Likes " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Likes " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Likes.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Date", Likes.Date);
                DB.ParameterAdd("@PostID", Likes.PostID);
                
            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Likes.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Likes);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, LikesRec Likes)
        {
            Likes.ID = (int)Convert.ToInt64(dbRow["aID"].ToString());
            Likes.Date = (DateTime)dbRow["aDate"];
            Likes.PostID = (int)Convert.ToInt64(dbRow["aDate"]);
            return Likes;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity LikesRec)
        {
            Likes.ID = ((LikesRec)LikesRec).ID;
            Likes.Date = ((LikesRec)LikesRec).Date;
            Likes.PostID = ((LikesRec)LikesRec).PostID;

        }

        //-----Local-------------------------------------------- 

        public LikesList SelectAll()
        {
            LikesList LikesList = new LikesList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new LikesList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                LikesRec Likes = new LikesRec();
                MoveDBToRecord(dbRow, Likes);
                //Join Columns 
                Likes.CountryName = dbRow["coName"].ToString();
                LikesList.Add(Likes);
            }
            return LikesList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public LikesRec SelectByUsername(string Username)
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

            return Likes;
        }
    }
}