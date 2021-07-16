using EntityFrameworkCore.Projectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheDrift.Samples.EFCoreProjectablesPerfMagic.Models.Extensions
{
    public static class UserExtensions
    {
        [Projectable]
        public static string FullName(this User user)
            => user.FirstName + " " + user.LastName;

        [Projectable]
        public static int GetFriendsOfFriendsByFirstNameCount(this User user, string fullName)
            => user.Friends.SelectMany(x => x.Friends).Where(x => x.FullName() == fullName).Count();
    }
}
