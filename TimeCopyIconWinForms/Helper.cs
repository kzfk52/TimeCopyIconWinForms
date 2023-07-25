using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCopyIconWinForms
{
    public class Helper
    {
        public static string getUnixTimeStr(DateTimeOffset dto)
        {
            return dto.ToUnixTimeSeconds().ToString();
        }

        public static string getYmd1Str(DateTimeOffset dto)
        {
            return dto.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string getYmd2Str(DateTimeOffset dto)
        {
            return dto.LocalDateTime.ToString("yyyyMMddHHmmss");
        }
    }
   

}
