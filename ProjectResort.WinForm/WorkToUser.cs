using ProjectResort.Context1.Enum;
using ProjectResort.Context1.Models;

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
                        FIO = "Неопознаный человек",
                        Post = Post.Seller
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
