using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;


namespace OnlineTicketingSystem.forms.academic.zcalender
{

    public class ImproperCalendarEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool allDay { get; set; }
        public string color { get; set; }
    }


    public class CalendarEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
        public string color { get; set; }
    }



    public class EventDAO
    {
        //change the connection string as per your database connection.
        //private static string connectionString = "Data Source=(local);Initial Catalog=test;Integrated Security=True";//ConfigurationManager.AppSettings["DBConnString"];
        private static string connectionString = zglobal.constring;

        //this method retrieves all events within range start-end
        public static List<CalendarEvent> getEvents(DateTime start, DateTime end)
        {
            List<CalendarEvent> events = new List<CalendarEvent>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT event_id, description, title, event_start, event_end, all_day,color FROM mscalendervw where event_start>=@start AND event_end<=@end AND zid=@zid AND xlocation=@xlocation", con);
            cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@zid", Convert.ToInt32(HttpContext.Current.Session["business"]));
            cmd.Parameters.Add("@xlocation", Convert.ToString(HttpContext.Current.Session["school"]));

            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    events.Add(new CalendarEvent()
                    {
                        id = Convert.ToInt32(reader["event_id"]),
                        title = Convert.ToString(reader["title"]),
                        description = Convert.ToString(reader["description"]),
                        start = Convert.ToDateTime(reader["event_start"]),
                        end = Convert.ToDateTime(reader["event_end"]),
                        color = Convert.ToString(reader["color"]),
                        //allDay = Convert.ToBoolean(reader["all_day"])
                    });
                }
            }
            return events;
            //side note: if you want to show events only related to particular users,
            //if user id of that user is stored in session as Session["userid"]
            //the event table also contains an extra field named 'user_id' to mark the event for that particular user
            //then you can modify the SQL as:
            //SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
            //then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
        }

        //this method updates the event title and description
        public static void updateEvent(int id, String title, String description, String color)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Event SET title=@title, description=@description, color=@color WHERE event_id=@event_id", con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
            cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = color;
            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //this method updates the event start and end time ... allDay parameter added for FullCalendar 2.x
        public static void updateEventTime(int id, DateTime start, DateTime end, bool allDay)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Event SET event_start=@event_start, event_end=@event_end, all_day=@all_day WHERE event_id=@event_id", con);
            cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = end;
            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = allDay;

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //this mehtod deletes event with the id passed in.
        public static void deleteEvent(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Event WHERE (event_id = @event_id)", con);
            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //this method adds events to the database
        public static int addEvent(CalendarEvent cevent)
        {
            //add event to the database and return the primary key of the added event row

            //insert
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Event(title, description, event_start, event_end, all_day, color) VALUES(@title, @description, @event_start, @event_end, @all_day, @color)", con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = cevent.title;
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = cevent.description;
            cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = cevent.start;
            cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = cevent.end;
            cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = cevent.allDay;
            cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = cevent.color;

            int key = 0;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

                //get primary key of inserted row
                cmd = new SqlCommand("SELECT max(event_id) FROM Event where title=@title AND description=@description AND event_start=@event_start AND event_end=@event_end AND all_day=@all_day AND color=@color", con);
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = cevent.title;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = cevent.description;
                cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = cevent.start;
                cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = cevent.end;
                cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = cevent.allDay;
                cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = cevent.color;

                key = (int)cmd.ExecuteScalar();
            }

            return key;
        }
    }

    public partial class amcalender : System.Web.UI.Page
    {
        //this method only updates title and description
        //this is called when a event is clicked on the calendar
        [System.Web.Services.WebMethod(true)]
        public static string UpdateEvent(CalendarEvent cevent)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(cevent.id))
            {
                if (CheckAlphaNumeric(cevent.title) && CheckAlphaNumeric(cevent.description))
                {
                    EventDAO.updateEvent(cevent.id, cevent.title, cevent.description, cevent.color);

                    return "updated event with id:" + cevent.id + " update title to: " + cevent.title +
                    " update description to: " + cevent.description;
                }

            }

            return "unable to update event with id:" + cevent.id + " title : " + cevent.title +
                " description : " + cevent.description;
        }

        //this method only updates start and end time
        //this is called when a event is dragged or resized in the calendar
        [System.Web.Services.WebMethod(true)]
        public static string UpdateEventTime(ImproperCalendarEvent improperEvent)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(improperEvent.id))
            {
                EventDAO.updateEventTime(improperEvent.id,
                                         Convert.ToDateTime(improperEvent.start),
                                         Convert.ToDateTime(improperEvent.end),
                                         improperEvent.allDay);  //allDay parameter added for FullCalendar 2.x

                return "updated event with id:" + improperEvent.id + " update start to: " + improperEvent.start +
                    " update end to: " + improperEvent.end;
            }

            return "unable to update event with id: " + improperEvent.id;
        }

        //called when delete button is pressed
        [System.Web.Services.WebMethod(true)]
        public static String deleteEvent(int id)
        {
            //idList is stored in Session by JsonResponse.ashx for security reasons
            //whenever any event is update or deleted, the event id is checked
            //whether it is present in the idList, if it is not present in the idList
            //then it may be a malicious user trying to delete someone elses events
            //thus this checking prevents misuse
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(id))
            {
                EventDAO.deleteEvent(id);
                return "deleted event with id:" + id;
            }

            return "unable to delete event with id: " + id;
        }

        //called when Add button is clicked
        //this is called when a mouse is clicked on open space of any day or dragged 
        //over mutliple days
        [System.Web.Services.WebMethod]
        public static int addEvent(ImproperCalendarEvent improperEvent)
        {
            CalendarEvent cevent = new CalendarEvent()
            {
                title = improperEvent.title,
                description = improperEvent.description,
                color = improperEvent.color,
                start = Convert.ToDateTime(improperEvent.start),
                end = Convert.ToDateTime(improperEvent.end),
                allDay = improperEvent.allDay
            };

            if (CheckAlphaNumeric(cevent.title) && CheckAlphaNumeric(cevent.description))
            {
                int key = EventDAO.addEvent(cevent);

                List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];

                if (idList != null)
                {
                    idList.Add(key);
                }

                return key; //return the primary key of the added cevent object
            }

            return -1; //return a negative number just to signify nothing has been added
        }

        private static bool CheckAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9 ]*$");
        }

        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["curuser"] == null ||
                    Convert.ToString(HttpContext.Current.Session["curuser"]) == "")
                {
                    //FormsAuthentication.SignOut();
                    //FormsAuthentication.RedirectToLoginPage();
                    Response.Redirect("~/forms/zlogin.aspx");
                }

                

                if (!IsPostBack)
                {
                    zglobal.fnGetComboDataCD("Location", grid_xlocation);
                    zglobal.fnGetComboDataCalendar(grid_xdate);
                    grid_xlocation.Items.RemoveAt(0);
                    grid_xdate.Items.RemoveAt(0);
                    //grid_xdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                   // prevPage = Request.UrlReferrer.ToString();

                }

                HttpContext.Current.Session["school"] = grid_xlocation.Text;
                grid_xdate.SelectedValue = DateTime.Today.ToString("MM/dd/yyyy");
                //grid_xdate.Text = DateTime.Today.ToString("MMMM yyyy");
                //message.InnerHtml = grid_xdate.SelectedValue.ToString();
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }

        }

        protected void fnGoBack(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect(prevPage);
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception exp)
            {
                message.InnerHtml = exp.Message;
                message.Style.Value = zglobal.errormsg;
            }
        }
    }
}