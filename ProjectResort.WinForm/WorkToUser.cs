using ProjectResort.Context1.Enum;
using ProjectResort.Context1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectResort.WinForm
{
    internal static class WorkToUser
    {
        private static Staff staff;

        public static Staff Staff
        {
            get
            {
                if (staff == null)
                {
                    staff = new Staff()
                    {
                        Id = -1,
                        FIO = "Неавторизованный гость",
                        Post = Post.Administrator
                    };
                }
                return staff;
            }
            set { staff = value; }
        }

        internal static bool CompareRole(Post post)
         => post == Staff.Post;

    }
}
