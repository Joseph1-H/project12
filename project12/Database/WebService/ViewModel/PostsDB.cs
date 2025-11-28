using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class PostsDB : BaseDB
    {
        public PostsRec Posts;
        private string SQLSelectByUsername;

        public PostsDB()
        {
            Posts = new PostsRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Posts " +
                      "(aCaption, aDate) " +
                      "Values (@Caption, @Date) ";

            SQLUpdate = "Update Posts Set " +
                                    "Caption = @Caption, " +
                                    "aDate = @Date " +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Posts " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Posts " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Posts " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Posts.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Caption", Posts.Caption);
                DB.ParameterAdd("@Phone", Posts.Date);

            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Posts.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Posts);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, PostsRec Posts)
        {
            Posts.ID = (int)Convert.ToInt64(dbRow["aID"].ToString());
            Posts.Caption = dbRow["aContent"].ToString();
            Posts.Date = (DateTime)dbRow["aDate"];
            return Posts;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity PostsRec)
        {
            Posts.ID = ((PostsRec)PostsRec).ID;
            Posts.Caption = ((PostsRec)PostsRec).Caption;
            Posts.Date = ((PostsRec)PostsRec).Date;

        }

        //-----Local-------------------------------------------- 

        public PostsList SelectAll()
        {
            PostsList PostsList = new PostsList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new PostsList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                PostsRec Posts = new PostsRec();
                MoveDBToRecord(dbRow, Posts);
                //Join Columns 
                Posts.CountryName = dbRow["coName"].ToString();
                PostsList.Add(Posts);
            }
            return PostsList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public PostsRec SelectByUsername(string Username)
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

            return Posts;
        }
    }
}