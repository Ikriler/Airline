using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DataSetTableAdapters;

namespace Airline.Models
{
    internal class Session
    {
        private static DataSet.SessionsDataTable initSessionDataTable()
        {
            SessionsTableAdapter sessionsTableAdapter = new SessionsTableAdapter();
            DataSet.SessionsDataTable sessionsRows = new DataSet.SessionsDataTable();

            sessionsTableAdapter.Fill(sessionsRows);

            return sessionsRows;
        }

        public static List<DataSet.SessionsRow> getSessionsForUser(DataSet.UsersRow user)
        {
            DataSet.SessionsDataTable sessionsRows = initSessionDataTable();
            List<DataSet.SessionsRow> sessionList = sessionsRows.Where(s => s.user_id.Equals(user.ID)).ToList();

            sessionList.Reverse();

            sessionList.RemoveAt(0);

            return sessionList;
        }

        public static DataSet.SessionsRow getLastSession(DataSet.UsersRow user)
        {
            DataSet.SessionsDataTable sessionsRows = initSessionDataTable();
            DataSet.SessionsRow sessionsRow = sessionsRows.Where(s => s.user_id.Equals(user.ID)).Last();

            return sessionsRow;
        }

        public static void startSessionInit(DataSet.UsersRow user)
        {
            DateTime date = DateTime.Now;
            TimeSpan login_time = new TimeSpan(hours: date.Hour, minutes: date.Minute, seconds: date.Second);
            Session.insertSession(date.ToString().Split(' ')[0], login_time.ToString(), "", "", "", user.ID);
        }

        public static void insertSession(string date, string login_time, string logout_time, string spent_time, string reason, int user_id)
        {
            SessionsTableAdapter sessionsTableAdapter = new SessionsTableAdapter();

            sessionsTableAdapter.InsertSession(date, login_time, logout_time, spent_time, reason, user_id);   
        }

        public static void updateSession(string date, string login_time, string logout_time, string spent_time, string reason, int user_id, int original_id)
        {
            SessionsTableAdapter sessionsTableAdapter = new SessionsTableAdapter();

            sessionsTableAdapter.UpdateSession(date, login_time, logout_time, spent_time, reason, user_id, original_id);
        }

        public static string getAmountSpentTime(DataSet.UsersRow user)
        {
            DataSet.SessionsDataTable sessionsRows = initSessionDataTable();

            List<DataSet.SessionsRow> sessionsList = sessionsRows.Where(s => s.user_id.Equals(user.ID)).ToList();

            TimeSpan amountTime = new TimeSpan(0, 0, 0);

            foreach(DataSet.SessionsRow session in sessionsList)
            {
                if(session.spent_time != "")
                {
                    TimeSpan time = TimeSpan.Parse(session.spent_time);
                    amountTime = amountTime.Add(time);
                }
            }

            return amountTime.ToString();
        }

        public static int getCountCrashes(DataSet.UsersRow user)
        {
            DataSet.SessionsDataTable sessionsRows = initSessionDataTable();

            List<DataSet.SessionsRow> sessionsList = sessionsRows.Where(s => s.user_id.Equals(user.ID)).ToList();

            int countCrashes = 0;

            foreach (DataSet.SessionsRow session in sessionsList)
            {
                if (session.reason != "")
                {
                    countCrashes++;
                }
            }

            return countCrashes;
        }

        public static bool getLogoutStatus(DataSet.UsersRow user)
        {
            DataSet.SessionsRow session =  getLastSession(user);

            if (session.logout_time != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
