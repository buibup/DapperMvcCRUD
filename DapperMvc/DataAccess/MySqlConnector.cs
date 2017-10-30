using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperMvc.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Web.Mvc;

namespace DapperMvc.DataAccess
{
    public class MySqlConnector : IDataConnection
    {
        private string conString = GlobalConfig.CnnString("DapperMySqlDB");
        public void CreateFriend(Friend friend)
        {
            using (IDbConnection db = new MySqlConnection(conString))
            {
                string sqlQuery = "Insert Into tblFriends (FriendName,City,PhoneNumber) Values('" + friend.FriendName + "','" + friend.City + "','" + friend.PhoneNumber + "')";

                int rowsAffected = db.Execute(sqlQuery);

            }
        }

        public Friend DeleteFriend(int id)
        {
            Friend friend = new Friend();
            using(IDbConnection db = new MySqlConnection(conString))
            {
                friend = db.Query<Friend>("Select * From tblFriends " +
                                     "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }
            return friend;
        }

        public void DeleteFriend(int id, FormCollection collection)
        {
            using(IDbConnection db = new MySqlConnection(conString))
            {
                string sqlQuery = "Delete From tblFriends WHERE FriendID = " + id;

                int rowsAffected = db.Execute(sqlQuery);
            }
        }

        public Friend EditFriend(int id)
        {
            Friend friend = new Friend();
            using(IDbConnection db = new MySqlConnection(conString))
            {
                friend = db.Query<Friend>("Select * From tblFriends " +
                                     "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }
            return friend;
        }

        public void EditFriend(Friend friend)
        {
            using (IDbConnection db = new MySqlConnection(conString))

            {
                string sqlQuery = $@"update tblFriends 
                set FriendName='{friend.FriendName}',City='{friend.City}'
                ,PhoneNumber='{friend.PhoneNumber}' where friendid= {friend.FriendID}";

                int rowsAffected = db.Execute(sqlQuery);
            }
        }

        public Friend GetFriend(int id)
        {
            Friend friend = new Friend();
            using(IDbConnection db = new MySqlConnection(conString))
            {
                friend = db.Query<Friend>("Select * From tblFriends " +
                                      "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }

            return friend;
        }

        public List<Friend> GetFriends()
        {
            using(IDbConnection db = new MySqlConnection(conString))
            {
                var sqlQuery = "Select * From tblFriends";
                var friens = db.Query<Friend>(sqlQuery).ToList();

                return friens;
            }
        }
    }
}