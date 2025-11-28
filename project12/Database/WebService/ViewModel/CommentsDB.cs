using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class CommentsDB : BaseDB
    {
        public CommentsRec comments;
        private string SQLSelectByUsername;

        public CommentsDB()
        {
            comments = new CommentsRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Comments " +
                      "(aContent, aDate, aCommentsID) " +
                      "Values (@Content, @Date, @CommentsID) ";

            SQLUpdate = "Update Comments Set " +
                                    "aContent = @Content, " +
                                    "aDate = @Date " +
                                    "aCommentsID = @CommentsID" +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Comments " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Comments " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Comments " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", comments.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Content", comments.Content);
                DB.ParameterAdd("@Date", comments.Date);
                
            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", comments.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, comments);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, CommentsRec comments)
        {
            comments.ID = (int)Convert.ToInt64(dbRow["aID"]);
            comments.Content = dbRow["aContent"].ToString();
            comments.Date = (DateTime)dbRow["aDate"];
            comments.CommentsID = (int)Convert.ToInt64(dbRow["aCommentsID"]);
            return comments;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity commentsRec)
        {
            comments.ID = ((CommentsRec)commentsRec).ID;
            comments.Content = ((CommentsRec)commentsRec).Content;
            comments.Date = ((CommentsRec)commentsRec).Date;
            comments.CommentsID = ((CommentsRec)commentsRec).CommentsID;

        }

        //-----Local-------------------------------------------- 

        public CommentsList SelectAll()
        {
            CommentsList CommentsList = new CommentsList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new CommentsList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                CommentsRec comments = new CommentsRec();
                MoveDBToRecord(dbRow, comments);
                //Join Columns 
                comments.CountryName = dbRow["coName"].ToString();
                CommentsList.Add(comments);
            }
            return CommentsList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public CommentsRec SelectByUsername(string Username)
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

            return comments;
        }
    }
}