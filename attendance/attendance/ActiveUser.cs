using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace attendance
{
    /// <summary>
    /// ActiveUser is singleton
    /// </summary>
    public class ActiveUser
    {
        private static ActiveUser au = null;
        private static readonly object _lock = new object();

        public static ActiveUser Au
        {
            get
            {
                lock (_lock)
                {
                    if (au == null)
                    {
                        au = new ActiveUser();
                    }
                    return au;
                }
            }
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Beginning { get; set; }
    }
}
