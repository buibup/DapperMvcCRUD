using DapperMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DapperMvc.DataAccess
{
    public interface IDataConnection
    {
        List<Friend> GetFriends();
        Friend GetFriend(int id);
        void CreateFriend(Friend friend);
        Friend EditFriend(int id);
        void EditFriend(Friend friend);
        Friend DeleteFriend(int id);
        void DeleteFriend(int id, FormCollection collection);
    }
}
