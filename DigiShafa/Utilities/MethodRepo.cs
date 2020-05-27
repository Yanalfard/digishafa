using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DigiShafa.Utilities
{
    public static class MethodRepo
    {
        private static Random _rng = new Random();
        private static readonly string ConnectionString = Config.ConnectionString;

        private static SqlConnection _connection;
        private static SqlCommand _command;

        public static DateTime C24To12(string t24)
        {
            if (t24 == "0001-01-01")
            {
                return new DateTime(1900, 1, 1, 12, 1, 1);
            }
            else
            {
                string[] datetime = t24.Split(' ');
                string time = datetime[1];
                string[] timeLaps = time.Split(':');
                int hour = Convert.ToInt32(timeLaps[0]);
                int min = Convert.ToInt32(timeLaps[1]);
                int sec = Convert.ToInt32(timeLaps[2]);
                if (hour > 12)
                {
                    hour -= 12;
                    return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
                }
                if (hour == 12 && (min > 0 || sec > 0))
                    return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
                if (datetime[2] == "PM")
                    return DateTime.Parse(t24);
                if (hour == 0 && min == 0 && sec == 0)
                    return DateTime.Parse(t24.Split('.')[0] + " AM");
                return DateTime.Parse(datetime[0] + " " + datetime[1] + " AM");
            }
        }

        public static string C12To24(DateTime t12)
        {
            string[] datetime = t12.ToString().Split(' ');
            string[] cdate = datetime[0].Split('/');
            string date = cdate[2] + '-' + cdate[0] + '-' + cdate[1];
            string[] time = datetime[1].Split(':');
            int hour = Convert.ToInt32(time[0]);
            int min = Convert.ToInt32(time[1]);
            int sec = Convert.ToInt32(time[2]);
            if (datetime[2] == "PM")
                hour += 12;
            if (hour == 24)
                hour = 0;
            return date + " " + hour + ":" + min + ":" + sec;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static bool ExistInDb(string tableName, string columnName, string columnValue)
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            _command = new SqlCommand($"SELECT id FROM {tableName} WHERE {columnName} = '{columnValue}'", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            bool result = reader.Read();
            reader.Close();
            _connection.Close();
            return result;
        }

        public static string ImageToBase64(System.Drawing.Image image)
        {
            using (MemoryStream memoryStreams = new MemoryStream())
            {
                image.Save(memoryStreams, image.RawFormat);
                byte[] imageBytes = memoryStreams.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream, true);
            return image;
        }
    }
}