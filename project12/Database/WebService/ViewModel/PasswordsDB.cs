using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace ViewModel
{
    public class PasswordsDB : BaseDB
    {
        public PasswordsRec Passwords;
        private string SQLSelectByUsername;

        public PasswordsDB()
        {
            Passwords = new PasswordsRec();
            InitValues();
        }
        //-----Private--------------------------------------------- 

        private void InitValues()
        {
            SQLInsert = "Insert Into Passwords " +
                      "(aUsername, aPassword, aRole) " +
                      "Values (@Username, @Password, @Role) ";

            SQLUpdate = "Update Passwords Set " +
                                    "aUsername = @Username, " +
                                    "aPassword = @Password " +
                                    "aRole = @Role " +
                                    "Where aID = @ID ";

            SQLDelete = "Delete From Passwords " +
                                    "Where aID = @ID ";

            SQLSelect = "Select * From Passwords " +
                                    "Where aID = @ID ";

            SQLSelectAll = "SELECT * From Passwords " +
                            "Order By aID ";



        }
        protected override void SetParameters(string Oper)
        {
            DB.ParametersClear();

            if (Oper == DB.doDelete ||
                Oper == DB.doSelect)
            {
                DB.ParameterAdd("@ID", Passwords.ID.ToString());
            }

            if (Oper == DB.doInsert ||
                Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@Username", Passwords.Username);
                DB.ParameterAdd("@Password", Passwords.Password);
                DB.ParameterAdd("@Role", Passwords.Role);

            }

            if (Oper == DB.doUpdate)
            {
                DB.ParameterAdd("@ID", Passwords.ID.ToString());
            }

        }

        protected override BaseEntity MoveDBToRecord(DataRow dbRow)
        {
            return MoveDBToRecord(dbRow, Passwords);
        }


        private BaseEntity MoveDBToRecord(DataRow dbRow, PasswordsRec Passwords)
        {
            Passwords.Username = dbRow["aUsername"].ToString();
            Passwords.Password = dbRow["aPassword"].ToString();
            Passwords.Role = dbRow["aRole"].ToString();
            return Passwords;
        }


        // םינותנ תרבעה הנכותהמ טקייבואה תונוכתל 
        public override void MoveValuesToRecord(BaseEntity PasswordsRec)
        {
            Passwords.Username = ((PasswordsRec)PasswordsRec).Username;
            Passwords.Password = ((PasswordsRec)PasswordsRec).Password;
            Passwords.Role = ((PasswordsRec)PasswordsRec).Role;


        }

        //-----Local-------------------------------------------- 

        public PasswordsList SelectAll()
        {
            PasswordsList PasswordsList = new PasswordsList();
            string SQL = SQLSelectAll;
            if (!DB.Select(SQL))
            {
                priErrorMessage = DB.Error;
                priErrorNo = -1;
                return new PasswordsList();
            }
            foreach (DataRow dbRow in DB.dbDataTable.Rows)
            {
                PasswordsRec Passwords = new PasswordsRec();
                MoveDBToRecord(dbRow, Passwords);
                //Join Columns 
                Passwords.CountryName = dbRow["coName"].ToString();
                PasswordsList.Add(Passwords);
            }
            return PasswordsList;
        }

        //Passwords  תלבטל רשק ןהל שיש תוקלחמב קר 
        public PasswordsRec SelectByUsername(string Username)
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

            return Passwords;
        }
    }
}