using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technosuss_Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace Technosuss_Project.Controllers
{
    public class SankalpController : Controller
    {
        // GET: Sankalp
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";
            StudentData sd = new StudentData();
            sd.id = "";
            sd.studentName = "";
            sd.motherName = "";
            sd.fatherName = "";
            sd.age = "";
            sd.homeAddress = "";
            sd.RegistrationDate = "";
            ViewBag.cancelbutton = "disabled";
            ViewBag.updatebutton = "disabled";
            ViewBag.deletebutton = "disabled";
            ViewBag.savebutton = "disabled";
            ViewBag.searchbutton = "";
            ViewBag.addnewbutton = "";
            return View(sd);
            
        }
        [HttpPost]
        public ActionResult Index(string rollno, string cbutton, string sname, string mname, string fname)
        {
            StudentData sd = new StudentData();
            if (cbutton == "Search")
            {

                String mycon = "Data Source=(localdb)/Local; Initial Catalog=[C:\\USERS\\SANKA\\ONEDRIVE\\DESKTOP\\TECHNOSUSS PROJECT\\TECHNOSUSS PROJECT\\APP_DATA\\LOCAL_DB.MDF]; Integrated Security=True";
                String myquery = "Select * from studentdata where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.searchresult = "Roll Number Has Been Found";
                    sd.id = rollno;
                    sd.studentName = ds.Tables[0].Rows[0]["studentName"].ToString();
                    sd.fatherName = ds.Tables[0].Rows[0]["fathername"].ToString();
                    sd.motherName = ds.Tables[0].Rows[0]["mothername"].ToString();
                    ViewBag.updateresult = "Note : You can perform delete or update or cancel operation";
                    ViewBag.cancelbutton = "";
                    ViewBag.updatebutton = "";
                    ViewBag.deletebutton = "";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "disabled";

                }
                else
                {
                    ViewBag.updateresult = "";
                    ViewBag.searchresult = "Roll Number Has Not Found";
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "";
                }
                con.Close();


            }
            else if (cbutton == "Update")
            {
                String mycon = "Data Source=HP-PC\\SQLEXPRESS; Initial Catalog=CollegeData; Integrated Security=True";
                String updatedata = "Update studentdata set sname='" + sname + "', fathername='" + fname + "', mothername='" + mname + "' where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                sd.RegistrationDate = "";
                sd.studentName = "";
                sd.fatherName = "";
                sd.motherName = "";
                ViewBag.updateresult = "Data Has Been Updated Successfully with Rollno " + rollno;
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.addnewbutton = "";
            }
            else if (cbutton == "Cancel")
            {
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Add New Form and Search Cancelled";
            }
            else if (cbutton == "AddNew")
            {
                ViewBag.cancelbutton = "";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "";
                ViewBag.addnewbutton = "disabled";
                ViewBag.searchbutton = "disabled";
                ViewBag.updateresult = "New Blank Form Has Been Added Successfully";
            }
            else if (cbutton == "Save")
            {
                String mycon = "Data Source=HP-PC\\SQLEXPRESS; Initial Catalog=CollegeData; Integrated Security=True";

                String query = "insert into studentdata(rollno,sname,fathername,mothername) values(" + rollno + ",'" + sname + "','" + fname + "','" + mname + "')";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "New Data Has Been Successfully";
            }
            else if (cbutton == "Delete")
            {
                String mycon = "Data Source=HP-PC\\SQLEXPRESS; Initial Catalog=CollegeData; Integrated Security=True";
                String updatedata = "delete from studentdata where rollno=" + rollno;
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Data Has Been Deleted Successfully with Rollno " + rollno;
            }




            return View(sd);
        }

    }
}