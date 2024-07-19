using System.Data;
using System.Data.SqlClient;
using crudAdoRes.Models;

namespace crudAdoRes.Models
{
    public class DGroupMeeting
    {
        static string strConnectionString = "User Id=sa;Password=tich;Server=DESKTOP-FLC9CU6;Database=DBEmpleado;";
        public static IEnumerable<GroupMeeting> GetGroupMeetings()
        {
            List<GroupMeeting> groupMeetingsList = new List<GroupMeeting>();
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("GetGroupMeetingDetails", con);
                command.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    GroupMeeting groupMeeting = new GroupMeeting();
                    groupMeeting.GroupMeetingId = Convert.ToInt32(dataReader["Id"]);
                    groupMeeting.ProjectName = dataReader["ProjectName"].ToString();
                    groupMeeting.GroupMeetingLeadName = dataReader["GroupMeetingLeadName"].ToString();
                    groupMeeting.TeamLeadName = dataReader["TeamLeadName"].ToString();
                    groupMeeting.Description = dataReader["Description"].ToString();
                    groupMeeting.GroupMeetingDate = Convert.ToDateTime(dataReader["GroupMeetingDate"]);
                    groupMeetingsList.Add(groupMeeting);
                }
            }
            return groupMeetingsList;
        }


        public static GroupMeeting GetGroupMeetingById(int? id)
        {
            GroupMeeting groupMeeting = new GroupMeeting();
            if (id == null)
                return groupMeeting;

            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("GetGroupMeetingByID", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    groupMeeting.GroupMeetingId = Convert.ToInt32(dataReader["Id"]);
                    groupMeeting.ProjectName = dataReader["ProjectName"].ToString();
                    groupMeeting.GroupMeetingLeadName = dataReader["GroupMeetingLeadName"].ToString();
                    groupMeeting.TeamLeadName = dataReader["TeamLeadName"].ToString();
                    groupMeeting.Description = dataReader["Description"].ToString();
                    groupMeeting.GroupMeetingDate = Convert.ToDateTime(dataReader["GroupMeetingDate"]);
                }
            }
            return groupMeeting;
        }


        public static int AddGroupMeeting(GroupMeeting groupMeeting)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProjectName", groupMeeting.ProjectName);
                command.Parameters.AddWithValue("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                command.Parameters.AddWithValue("@TeamLeadName", groupMeeting.TeamLeadName);
                command.Parameters.AddWithValue("@Description", groupMeeting.Description);
                command.Parameters.AddWithValue("@GroupMeetingDate", groupMeeting.GroupMeetingDate);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }

        public static int UpdateGroupMeeting(GroupMeeting groupMeeting)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", groupMeeting.GroupMeetingId);
                command.Parameters.AddWithValue("@ProjectName", groupMeeting.ProjectName);
                command.Parameters.AddWithValue("@GroupMeetingLeadName", groupMeeting.GroupMeetingLeadName);
                command.Parameters.AddWithValue("@TeamLeadName", groupMeeting.TeamLeadName);
                command.Parameters.AddWithValue("@Description", groupMeeting.Description);
                command.Parameters.AddWithValue("@GroupMeetingDate", groupMeeting.GroupMeetingDate);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }

        public static int DeleteGroupMeeting(int id)
        {
            int rowAffected = 0;
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand command = new SqlCommand("DeleteGroupMeeting", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            return rowAffected;
        }
    }
}
