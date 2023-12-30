using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenhND2.Utils
{
    internal class Checked
    {
        public static bool IsNumber(string value)
        {
            // Kiểm tra xem chuỗi nhập vào textbox có phải là kiểu số không
            Double number;
            return Double.TryParse(value, out number);
        }

        public static bool CheckedDate(string value)
        {
            if (IsNumber(value))
            {
                int day = Int32.Parse(value);
                if (day > 0 && day < 32)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public static bool CheckedMonth(string value)
        {
            if (IsNumber(value))
            {
                int month = Int32.Parse(value);
                if (month > 0 && month < 13)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
