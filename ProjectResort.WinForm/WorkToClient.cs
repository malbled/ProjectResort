using ProjectResort.Context1.Enum;
using ProjectResort.Context1.Models;

namespace ProjectResort.WinForm
{
    internal static class WorkToClient
    {
        private static Client client;

        public static Client Client
        {
            get
            {
                if (client == null)
                {
                    client = new Client()
                    {
                        Id = -1,
                        FIO = "Гость не добавлен",
                    };
                }
                return client;
            }
            set { client = value; }
        }

        //internal static bool CompareRole(Post post)=> post == Staff.Post;
    }
}
