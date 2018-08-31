using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MNJvWeb.Models
{
    public class Utilities
    {
        public static string formatDate(string dateInput)
        {
            if (dateInput != null)
            {
                if (dateInput.Contains('-'))
                {
                    string[] arr_date = dateInput.Split('-').ToArray();
                    return string.Format("{0}{1}{2}", arr_date[2], arr_date[1], arr_date[0]);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }

        }
    }
}