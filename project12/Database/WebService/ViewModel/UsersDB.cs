using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class UsersDB : BaseDB
    {
        public UsersRec Users;
        private string SQLSelectByUsername;

        public UsersDB()
        {
            Users = new UsersRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Users " +
                      "(uName, uPhone, uMail, uImageURL, uUsername) " +
                      "Values (@Name, @Phone, @Mail, @ImageURL, Username) ";

            SQLUpdate = "Update Users Set " +
                                    "uName = @Name, " +
                                    "uPhone = @Phone " +
                                    "uMail = @Mail " +
                                    "uImageURL = @ImageURL " +
                                    "uUsername = @Username " +
                                    "Where uID = @ID ";

            SQLDelete = "Delete From Users " +
                                    "Where uID = @ID ";

            SQLSelect = "Select * From Users " +
                                    "Where uID = @ID ";

            SQLSelectAll = "SELECT * From Users " +
                            "Order By uID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Users.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Name", Users.Name);
                DB.ParameterAdd("@Phone", Users.Phone);
                DB.ParameterAdd("@Mail", Users.Mail);
                DB.ParameterAdd("@ImageURL", Users.ImageURL);
                DB.ParameterAdd("@Username", Users.Username);




            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Users.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Users);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, UsersRec Users)
        {
            Users.ID = (int)Convert.ToInt64(dbRow["uID"].ToString());
            Users.Name = dbRow["uName"].ToString();
            Users.Phone = dbRow["uPhone"].ToString();
            Users.Mail = dbRow["uMail"].ToString();
            Users.ImageURL = dbRow["uImageURL"].ToString();
            Users.Username = dbRow["uUsername"].ToString();
            return Users;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity UsersRec)
        {
            Users.ID = ((UsersRec)UsersRec).ID;
            Users.Name = ((UsersRec)UsersRec).Name;
            Users.Phone = ((UsersRec)UsersRec).Phone;
            Users.Mail = ((UsersRec)UsersRec).Mail;
            Users.ImageURL = ((UsersRec)UsersRec).ImageURL;
            Users.Username = ((UsersRec)UsersRec).Username;


        }

        //-----Local-------------------------------------------- 

        public UsersList SelectAll()
        {
            UsersList UsersList = new UsersList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new UsersList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                UsersRec Users = new UsersRec();
                MoveDBToRecord(dbRow, Users);
                //Join Columns 
                Users.CountryName = dbRow["coName"].ToString();
                UsersList.Add(Users);
            }
            return UsersList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public UsersRec SelectByUsername(string Username)
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

            return Users;
        }
    }
}