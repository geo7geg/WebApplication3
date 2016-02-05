using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebApplication1.ServiceReference1;
using WebApplication1.ServiceReference2;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Xml;


namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string connectionString = "server=localhost;user id=root;Password=;database=contacts;persist security info=False;charset=utf8";
        int XOff1 = 400;
        int Yoff1 = 400;
        string url = WebApplication1.Class1.sqlstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox4.Focus();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("el-GR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("el-GR");
            if (InputLanguage.InstalledInputLanguages.Count == 1)
                return;
            // Get index of current Input Language
            int currentLang = InputLanguage.InstalledInputLanguages.IndexOf(InputLanguage.CurrentInputLanguage);
            // Calculate next Input Language
            //InputLanguage nextLang = ++currentLang == InputLanguage.InstalledInputLanguages.Count ?
            //   InputLanguage.InstalledInputLanguages[0] : InputLanguage.InstalledInputLanguages[currentLang];
            //InputLanguage.CurrentInputLanguage = nextLang;
            InputLanguage nextLang1 = InputLanguage.FromCulture(new System.Globalization.CultureInfo("el-GR"));
            InputLanguage.CurrentInputLanguage = nextLang1;
            //MessageBox.Show(nextLang1.Culture.ToString());
            // Change current Language to the calculated:
            //System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo("ell");
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
            //display.ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/1/1a/Bachalpseeflowers.jpg";
            //display += new EventHandler(display_MouseHover);
            //.Attributes.Add()
            ImageButton LB = new ImageButton();
            LB.ImageUrl = "http://localhost/castle.png";
            //LB.Height = 32;
            //LB.Width = 37;
            LB.ID = "4";
            Panel1.BackImageUrl = "http://localhost/pelo.jpg";
            //Image1.ImageUrl = "http://192.168.1.201:8082/technor.png";
            ImageButton2.ImageUrl = "http://192.168.1.201:8082/filter.png";
            //ImageButton3.ImageUrl = "http://192.168.1.208:8082/technor.png";
            //Image2.ImageUrl = "http://localhost/address.png";
            LB.Attributes.Add("Style", "margin-top:" + Convert.ToString(Yoff1 - 314) + "px;margin-left:" + Convert.ToString(XOff1 + (-136)) + "px;");
            LB.Click += new ImageClickEventHandler(LB_Click);
            ImageButton1.Attributes.Add("onmouseover", "return function2(this);");
            LB.Attributes.Add("onmouseover", "return function2(this);");
            Panel1.Controls.Add(LB);
            Panel1.Attributes.Add("Style", "margin-left:500px;");
            ImageButton1.ImageUrl = "http://localhost/castle.png";
        }

        public void ChangeInputLanguage(InputLanguage InputLang)
        {
            // Check is this Language really installed. Raise exception to warn if it is not:
            if (InputLanguage.InstalledInputLanguages.IndexOf(InputLang) == -1)
                throw new ArgumentOutOfRangeException();
            // InputLAnguage changes here:
            InputLanguage.CurrentInputLanguage = InputLang;
        }

        protected void LB_Click(object sender, EventArgs e)
        {
            //attempt to cast the sender as a label
            ImageButton lbl = sender as ImageButton;
            WebService2SoapClient client = new WebService2SoapClient();
            Person person = client.findperson(Convert.ToInt32(lbl.ID));

            Label4.Text = Convert.ToString(person.id);
            Label5.Text = Convert.ToString(person.name);
            Label6.Text = Convert.ToString(person.phone);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM information where id=1";
            command.Prepare();
            //command.Parameters.AddWithValue("@p1", item);
            reader = command.ExecuteReader();
            reader.Read();
            string name = reader["name"].ToString();
            string phone = reader["phone"].ToString();
            
            reader.Close();
            connection.Close();
            WebService1SoapClient client = new WebService1SoapClient();


            Label1.Text = name;
            Label2.Text = phone;
            Label3.Text = client.HelloWorld(TextBox1.Text);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
          
          
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Dothat(object sender, EventArgs e)
        {
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;

            string word = TextBox4.Text;
            char[] letters = word.ToCharArray();
            char[] letters1 = word.ToCharArray();
            string[] words = word.Split(null);

            for (int i = 0; i <= letters.Length - 1; i++)
            {
                switch (letters[i])
                {
                    case 'a':
                        letters1[i] = 'α';
                        break;
                    case 'b':
                        letters1[i] = 'β';
                        break;
                    case 'c':
                        letters1[i] = 'ψ';
                        break;
                    case 'd':
                        letters1[i] = 'δ';
                        break;
                    case 'e':
                        letters1[i] = 'ε';
                        break;
                    case 'f':
                        letters1[i] = 'φ';
                        break;
                    case 'g':
                        letters1[i] = 'γ';
                        break;
                    case 'h':
                        letters1[i] = 'η';
                        break;
                    case 'i':
                        letters1[i] = 'ι';
                        break;
                    case 'j':
                        letters1[i] = 'ξ';
                        break;
                    case 'k':
                        letters1[i] = 'κ';
                        break;
                    case 'l':
                        letters1[i] = 'λ';
                        break;
                    case 'm':
                        letters1[i] = 'μ';
                        break;
                    case 'n':
                        letters1[i] = 'ν';
                        break;
                    case 'o':
                        letters1[i] = 'ο';
                        break;
                    case 'p':
                        letters1[i] = 'π';
                        break;
                    case 'q':
                        letters1[i] = 'κ';
                        break;
                    case 'r':
                        letters1[i] = 'ρ';
                        break;
                    case 's':
                        letters1[i] = 'σ';
                        break;
                    case 't':
                        letters1[i] = 'τ';
                        break;
                    case 'u':
                        letters1[i] = 'θ';
                        break;
                    case 'v':
                        letters1[i] = 'β';
                        break;
                    case 'w':
                        letters1[i] = 'ω';
                        break;
                    case 'x':
                        letters1[i] = 'χ';
                        break;
                    case 'y':
                        letters1[i] = 'υ';
                        break;
                    case 'z':
                        letters1[i] = 'ζ';
                        break;
                    case 'A':
                        letters1[i] = 'α';
                        break;
                    case 'B':
                        letters1[i] = 'β';
                        break;
                    case 'C':
                        letters1[i] = 'ψ';
                        break;
                    case 'D':
                        letters1[i] = 'δ';
                        break;
                    case 'E':
                        letters1[i] = 'ε';
                        break;
                    case 'F':
                        letters1[i] = 'φ';
                        break;
                    case 'G':
                        letters1[i] = 'γ';
                        break;
                    case 'H':
                        letters1[i] = 'η';
                        break;
                    case 'I':
                        letters1[i] = 'ι';
                        break;
                    case 'J':
                        letters1[i] = 'ξ';
                        break;
                    case 'K':
                        letters1[i] = 'κ';
                        break;
                    case 'L':
                        letters1[i] = 'λ';
                        break;
                    case 'M':
                        letters1[i] = 'μ';
                        break;
                    case 'N':
                        letters1[i] = 'ν';
                        break;
                    case 'O':
                        letters1[i] = 'ο';
                        break;
                    case 'P':
                        letters1[i] = 'π';
                        break;
                    case 'Q':
                        letters1[i] = 'κ';
                        break;
                    case 'R':
                        letters1[i] = 'ρ';
                        break;
                    case 'S':
                        letters1[i] = 'σ';
                        break;
                    case 'T':
                        letters1[i] = 'τ';
                        break;
                    case 'U':
                        letters1[i] = 'θ';
                        break;
                    case 'V':
                        letters1[i] = 'β';
                        break;
                    case 'W':
                        letters1[i] = 'ω';
                        break;
                    case 'X':
                        letters1[i] = 'χ';
                        break;
                    case 'Y':
                        letters1[i] = 'υ';
                        break;
                    case 'Z':
                        letters1[i] = 'ζ';
                        break;
                    case 'ά':
                        letters1[i] = 'α';
                        break;
                    case 'έ':
                        letters1[i] = 'ε';
                        break;
                    case 'ή':
                        letters1[i] = 'η';
                        break;
                    case 'ύ':
                        letters1[i] = 'υ';
                        break;
                    case 'ί':
                        letters1[i] = 'ι';
                        break;
                    case 'ό':
                        letters1[i] = 'ο';
                        break;
                    case 'ώ':
                        letters1[i] = 'ω';
                        break;
                    case 'Ά':
                        letters1[i] = 'α';
                        break;
                    case 'Έ':
                        letters1[i] = 'ε';
                        break;
                    case 'Ή':
                        letters1[i] = 'η';
                        break;
                    case 'Ύ':
                        letters1[i] = 'υ';
                        break;
                    case 'Ί':
                        letters1[i] = 'ι';
                        break;
                    case 'Ό':
                        letters1[i] = 'ο';
                        break;
                    case 'Ώ':
                        letters1[i] = 'ω';
                        break;
                }  
            }
            word = string.Join("", letters1);
            string[] words1 = word.Split(null);
            //MessageBox.Show(word);

            string query = "";

            if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0)
            {
                if (DropDownList3.SelectedIndex != 0)
                {
                    if (words.Length == 1)
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + TextBox4.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%') AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "' AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "%'";
                    }
                    else
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where ((FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')) AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "' AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "%'";
                    }
                    //MessageBox.Show("1");
                }
                else
                {
                    if (words.Length == 1)
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + TextBox4.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%') AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "' AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "%'";
                    }
                    else
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where ((FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')) AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "' AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "%'";
                    }
                    //MessageBox.Show("2");
                }
            }else if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex == 0)
            {
                if (words.Length == 1)
                {
                    query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + TextBox4.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%') AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "'";
                }
                else
                {
                    query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where ((FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')) AND ACTIVITY='" + DropDownList1.SelectedItem.Text + "'";
                }
                //MessageBox.Show("3");
            }
            else if (DropDownList1.SelectedIndex == 0 && DropDownList2.SelectedIndex != 0)
            {
                if (DropDownList3.SelectedIndex != 0)
                {
                    if (words.Length == 1)
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + TextBox4.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%') AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "%'";
                    }
                    else
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where ((FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')) AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "%'";
                    }
                    //MessageBox.Show("4");
                }
                else
                {
                    if (words.Length == 1)
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + TextBox4.Text + "%' OR FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%') AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "%'";
                    }
                    else
                    {
                        query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where ((FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')) AND TERRITORY LIKE '%" + DropDownList2.SelectedItem.Text + "%'";
                    }
                    //MessageBox.Show("5");
                }
            }
            else if (DropDownList1.SelectedIndex == 0 && DropDownList2.SelectedIndex == 0)
            {
                if (words.Length == 1)
                {
                    query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where FirstName LIKE '%" + TextBox4.Text + "%' OR  FirstName LIKE '%" + word + "%' OR LastName LIKE '%" + TextBox4.Text + "%' OR  LastName LIKE '%" + word + "%' OR Company LIKE '%" + TextBox4.Text + "%' OR  Company LIKE '%" + word + "%' OR MobilePhone LIKE '%" + TextBox4.Text + "%' OR EmailAddress LIKE '%" + TextBox4.Text + "%' OR  EmailAddress LIKE '%" + word + "%' OR BusinessPhone LIKE '%" + TextBox4.Text + "%'";
                }
                else
                {
                    query = "SELECT Company,FirstName,LastName,Department,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,BusinessFax,EmailAddress,WebPage,ACTIVITY,TERRITORY,Uid FROM contacts where (FirstName LIKE '%" + words[0] + "%' AND  LastName LIKE '%" + words[1] + "%') OR (FirstName LIKE '%" + words1[0] + "%' AND  LastName LIKE '%" + words1[1] + "%')";
                }
                //MessageBox.Show(word);
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();

            connection.Close();

            Image6.Visible = false;
            Label10.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (e.Row.Cells.Count > 11)
                {
                    e.Row.Cells[0].Text = "Εταιρεία";
                    e.Row.Cells[1].Text = "Όνομα";
                    e.Row.Cells[2].Text = "Επώνυμο";
                    e.Row.Cells[3].Text = "Τμήμα";
                    e.Row.Cells[4].Text = "Επάγγελμα";
                    e.Row.Cells[5].Text = "Τηλέφωνο Εργασίας";
                    e.Row.Cells[6].Text = "Τηλέφωνο Εργασίας 2";
                    e.Row.Cells[7].Text = "Τηλέφωνο Οικίας";
                    e.Row.Cells[8].Text = "Κινητό Τηλέφωνο";
                    e.Row.Cells[9].Text = "Άλλο Τηλέφωνο";
                    e.Row.Cells[10].Text = "FAX Εργασίας";
                    e.Row.Cells[11].Text = "Email";
                    e.Row.Cells[12].Text = "Διαδικτυακή Σελίδα";
                    e.Row.Cells[13].Text = "Δραστηριότητα";
                    e.Row.Cells[14].Text = "Περιοχή";
                }
                else
                {
                    e.Row.Cells[0].Text = "Όνομα";
                    e.Row.Cells[1].Text = "Επώνυμο";
                    e.Row.Cells[2].Text = "Εταιρεία";
                    e.Row.Cells[3].Text = "Επάγγελμα";
                    e.Row.Cells[4].Text = "Τηλέφωνο Εργασίας";
                    e.Row.Cells[5].Text = "Τηλέφωνο Εργασίας 2";
                    e.Row.Cells[6].Text = "Τηλέφωνο Οικίας";
                    e.Row.Cells[7].Text = "Κινητό Τηλέφωνο";
                    e.Row.Cells[8].Text = "Άλλο Τηλέφωνο";
                    e.Row.Cells[9].Text = "Email";
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells.Count > 11)
                {
                    e.Row.Cells[0].ToolTip = "Εταιρεία";
                    e.Row.Cells[1].ToolTip = "Όνομα";
                    e.Row.Cells[2].ToolTip = "Επώνυμο";
                    e.Row.Cells[3].ToolTip = "Τμήμα";
                    e.Row.Cells[4].ToolTip = "Επάγγελμα";
                    e.Row.Cells[5].ToolTip = "Τηλέφωνο Εργασίας";
                    e.Row.Cells[6].ToolTip = "Τηλέφωνο Εργασίας 2";
                    e.Row.Cells[7].ToolTip = "Τηλέφωνο Οικίας";
                    e.Row.Cells[8].ToolTip = "Κινητό Τηλέφωνο";
                    e.Row.Cells[9].ToolTip = "Άλλο Τηλέφωνο";
                    e.Row.Cells[10].ToolTip = "FAX Εργασίας";
                    e.Row.Cells[11].ToolTip = "Email";
                    e.Row.Cells[12].ToolTip = "Διαδικτυακή Σελίδα";
                    e.Row.Cells[13].ToolTip = "Δραστηριότητα";
                    e.Row.Cells[14].ToolTip = "Περιοχή";
               
                    e.Row.Cells[11].Text = "<a href = 'mailto:" + e.Row.Cells[11].Text + "'>" + e.Row.Cells[11].Text + "</a>";
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                    //e.Row.Attributes["onmouseover"] = "onMouseOver('" + e.Row.RowIndex + "')";
                }
                else
                {
                    e.Row.Cells[0].ToolTip = "Όνομα";
                    e.Row.Cells[1].ToolTip = "Επώνυμο";
                    e.Row.Cells[2].ToolTip = "Εταιρεία";
                    e.Row.Cells[3].ToolTip = "Επάγγελμα";
                    e.Row.Cells[4].ToolTip = "Τηλέφωνο Εργασίας";
                    e.Row.Cells[5].ToolTip = "Τηλέφωνο Εργασίας 2";
                    e.Row.Cells[6].ToolTip = "Τηλέφωνο Οικίας";
                    e.Row.Cells[7].ToolTip = "Κινητό Τηλέφωνο";
                    e.Row.Cells[8].ToolTip = "Άλλο Τηλέφωνο";
                    e.Row.Cells[9].ToolTip = "Email";

                    e.Row.Cells[9].Text = "<a href = 'mailto:" + e.Row.Cells[9].Text + "'>" + e.Row.Cells[9].Text + "</a>";
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                    //e.Row.Attributes["onmouseover"] = "onMouseOver('" + e.Row.RowIndex + "')";
                }
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.Cells.Count > 11)
            {
                int index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.SelectedRow.Cells[1].Text;
                string surname = GridView1.SelectedRow.Cells[2].Text;
                string uid = GridView1.SelectedRow.Cells[15].Text;

                Response.Redirect("http://"+ url +"/phoneindex2.aspx?Uid=" + uid);
            }
            else
            {
                int index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.SelectedRow.Cells[0].Text;
                string surname = GridView1.SelectedRow.Cells[1].Text;
                string uid = GridView1.SelectedRow.Cells[10].Text;

                Response.Redirect("http://" + url + "/phoneindex2.aspx?Uid=" + uid);
            }

            //string message = "Row Index: " + index + "\\nName: " + name + "\\nCountry: " + country;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + url + "/phoneindex2.aspx");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList2.SelectedItem.Text)
            {
                case "ΟΛΕΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        break;
                    }
                case "ΑΝ. ΜΑΚΕΔΟΝΙΑ & ΘΡΑΚΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΕΒΡΟΣ");
                        DropDownList3.Items.Add("ΡΟΔΟΠΗ");
                        DropDownList3.Items.Add("ΞΑΝΘΗ");
                        DropDownList3.Items.Add("ΔΡΑΜΑ");
                        DropDownList3.Items.Add("ΚΑΒΑΛΑ");
                        DropDownList3.Items.Add("ΘΑΣΟΣ");

                        break;
                    }
                case "ΚΕΝΤΡΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΘΕΣΣΑΛΟΝΙΚΗ");
                        DropDownList3.Items.Add("ΣΕΡΡΕΣ");
                        DropDownList3.Items.Add("ΧΑΛΚΙΔΙΚΗ");
                        DropDownList3.Items.Add("ΚΙΛΚΙΣ");
                        DropDownList3.Items.Add("ΠΕΛΛΑ");
                        DropDownList3.Items.Add("ΗΜΑΘΙΑ");
                        DropDownList3.Items.Add("ΠΙΕΡΙΑ");
                        break;
                    }
                case "ΔΥΤΙΚΗ ΜΑΚΕΔΟΝΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΟΖΑΝΗ");
                        DropDownList3.Items.Add("ΦΛΩΡΙΝΑ");
                        DropDownList3.Items.Add("ΚΑΣΤΟΡΙΑ");
                        DropDownList3.Items.Add("ΓΡΕΒΕΝΑ");
                        break;
                    }
                case "ΗΠΕΙΡΟΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΙΩΑΝΝΙΝΑ");
                        DropDownList3.Items.Add("ΑΡΤΑ");
                        DropDownList3.Items.Add("ΘΕΣΠΡΩΤΙΑ");
                        DropDownList3.Items.Add("ΠΡΕΒΕΖΑ");
                        break;
                    }
                case "ΘΕΣΣΑΛΙΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΑΡΔΙΤΣΑ");
                        DropDownList3.Items.Add("ΛΑΡΙΣΑ");
                        DropDownList3.Items.Add("ΜΑΓΝΗΣΙΑ");
                        DropDownList3.Items.Add("ΤΡΙΚΑΛΑ");
                        DropDownList3.Items.Add("ΣΠΟΡΑΔΕΣ");
                        break;
                    }
                case "ΙΟΝΙΟΙ ΝΗΣΟΙ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΖΑΚΥΝΘΟΣ");
                        DropDownList3.Items.Add("ΚΕΡΚΥΡΑ");
                        DropDownList3.Items.Add("ΚΕΦΑΛΛΟΝΙΑ");
                        DropDownList3.Items.Add("ΛΕΥΚΑΔΑ");
                        break;
                    }
                case "ΔΥΤΙΚΗ ΕΛΛΑΔΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑ");
                        DropDownList3.Items.Add("ΑΧΑΪΑ");
                        DropDownList3.Items.Add("ΗΛΕΙΑ");
                        break;
                    }
                case "ΣΤΕΡΕΑ ΕΛΛΑΔΑ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΦΘΙΟΤΙΔΑ");
                        DropDownList3.Items.Add("ΕΥΡΥΤΑΝΙΑ");
                        DropDownList3.Items.Add("ΒΟΙΩΤΙΑ");
                        DropDownList3.Items.Add("ΕΥΒΟΙΑ");
                        DropDownList3.Items.Add("ΦΩΚΙΔΑ");
                        break;
                    }
                case "ΑΤΤΙΚΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΚΕΝΤΡΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΝΟΤΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΒΟΡΕΙΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΔΥΤΙΚΟΣ ΤΟΜΕΑΣ ΑΘΗΝΩΝ");
                        DropDownList3.Items.Add("ΠΕΙΡΑΙΑΣ");
                        DropDownList3.Items.Add("ΝΗΣΟΙ");
                        DropDownList3.Items.Add("ΔΥΤΙΚΗ ΑΤΤΙΚΗ");
                        DropDownList3.Items.Add("ΑΝΑΤΟΛΙΚΗ ΑΤΤΙΚΗ");
                        break;
                    }
                case "ΠΕΛΟΠΟΝΝΗΣΟΣ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΡΓΟΛΙΔΑ");
                        DropDownList3.Items.Add("ΑΡΚΑΔΙΑ");
                        DropDownList3.Items.Add("ΚΟΡΙΝΘΙΑ");
                        DropDownList3.Items.Add("ΛΑΚΩΝΙΑ");
                        DropDownList3.Items.Add("ΜΕΣΣΗΝΙΑ");
                        break;
                    }
                case "ΒΟΡΕΙΟ ΑΙΓΑΙΟ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΛΕΣΒΟ");
                        DropDownList3.Items.Add("ΣΑΜΟ");
                        DropDownList3.Items.Add("ΧΙΟ");
                        DropDownList3.Items.Add("ΛΗΜΝΟΣ");
                        DropDownList3.Items.Add("ΙΚΑΡΙΑ");
                        break;
                    }
                case "ΝΟΤΙΟ ΑΙΓΑΙΟ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΑΝΔΡΟΣ");
                        DropDownList3.Items.Add("ΘΗΡΑ");
                        DropDownList3.Items.Add("ΚΑΛΥΜΝΟΣ");
                        DropDownList3.Items.Add("ΚΑΡΠΑΘΟΣ");
                        DropDownList3.Items.Add("ΚΕΑ-ΚΥΘΝΟΣ");
                        DropDownList3.Items.Add("ΚΩΣ");
                        DropDownList3.Items.Add("ΜΗΛΟΣ");
                        DropDownList3.Items.Add("ΜΥΚΟΝΟΣ");
                        DropDownList3.Items.Add("ΝΑΞΟΣ");
                        DropDownList3.Items.Add("ΠΑΡΟΣ");
                        DropDownList3.Items.Add("ΡΟΔΟΣ");
                        DropDownList3.Items.Add("ΣΥΡΟΣ");
                        DropDownList3.Items.Add("ΤΗΝΟΣ");
                        break;
                    }
                case "ΚΡΗΤΗ":
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Add("ΟΛΕΣ");
                        DropDownList3.Items.Add("ΗΡΑΚΛΕΙΟ");
                        DropDownList3.Items.Add("ΛΑΣΙΘΙ");
                        DropDownList3.Items.Add("ΧΑΝΙΑ");
                        DropDownList3.Items.Add("ΡΕΘΥΜΝΟ");
                        break;
                    }

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if(DropDownList1.Visible == false)
            {
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
            }
            else
            {
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
                DropDownList3.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                DropDownList1.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;
                DropDownList3.SelectedIndex = 0;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            InputLanguage nextLang1 = InputLanguage.FromCulture(new System.Globalization.CultureInfo("el-GR"));
            InputLanguage.CurrentInputLanguage = nextLang1;
        }


        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = connectionString;

                XmlDocument doc = new XmlDocument();

                doc.Load("http://www.eortologio.gr/rss/si_el.xml");

                //Display all the book titles.
                XmlNode node = doc.SelectSingleNode("/rss/channel/item/title");
                string trimmed = node.InnerText;
                string label = trimmed;
                if (TextBox4.Text == "")
                {
                    int index1 = trimmed.IndexOf(':');
                    trimmed = trimmed.Remove(0, index1 + 2);
                    int index2 = trimmed.IndexOf('(');
                    int index3 = label.IndexOf('(');
                    trimmed = trimmed.Remove(index2, trimmed.Length - index2);
                    label = label.Remove(index3, label.Length - index3);
                }
                else
                {
                    trimmed = TextBox4.Text.Trim();
                    label = "Σήμερα " + DateTime.Today.ToLongDateString() + " γιορτάζουν οι : " + trimmed;
                    label = "";
                    //label = "Εορτάζοντες : " + trimmed;
                }
                trimmed.Trim(new Char[] { ' ' });
                string[] people = trimmed.Split(',');
                foreach (string p in people)
                {
                    p.Trim();
                }

                string word = string.Join(",", people);
                char[] letters = word.ToCharArray();
                char[] letters1 = word.ToCharArray();


                for (int i = 0; i <= letters.Length - 1; i++)
                {
                    switch (letters[i])
                    {
                        case 'a':
                            letters1[i] = 'α';
                            break;
                        case 'b':
                            letters1[i] = 'β';
                            break;
                        case 'c':
                            letters1[i] = 'ψ';
                            break;
                        case 'd':
                            letters1[i] = 'δ';
                            break;
                        case 'e':
                            letters1[i] = 'ε';
                            break;
                        case 'f':
                            letters1[i] = 'φ';
                            break;
                        case 'g':
                            letters1[i] = 'γ';
                            break;
                        case 'h':
                            letters1[i] = 'η';
                            break;
                        case 'i':
                            letters1[i] = 'ι';
                            break;
                        case 'j':
                            letters1[i] = 'ξ';
                            break;
                        case 'k':
                            letters1[i] = 'κ';
                            break;
                        case 'l':
                            letters1[i] = 'λ';
                            break;
                        case 'm':
                            letters1[i] = 'μ';
                            break;
                        case 'n':
                            letters1[i] = 'ν';
                            break;
                        case 'o':
                            letters1[i] = 'ο';
                            break;
                        case 'p':
                            letters1[i] = 'π';
                            break;
                        case 'q':
                            letters1[i] = 'κ';
                            break;
                        case 'r':
                            letters1[i] = 'ρ';
                            break;
                        case 's':
                            letters1[i] = 'σ';
                            break;
                        case 't':
                            letters1[i] = 'τ';
                            break;
                        case 'u':
                            letters1[i] = 'θ';
                            break;
                        case 'v':
                            letters1[i] = 'β';
                            break;
                        case 'w':
                            letters1[i] = 'ω';
                            break;
                        case 'x':
                            letters1[i] = 'χ';
                            break;
                        case 'y':
                            letters1[i] = 'υ';
                            break;
                        case 'z':
                            letters1[i] = 'ζ';
                            break;
                        case 'A':
                            letters1[i] = 'α';
                            break;
                        case 'B':
                            letters1[i] = 'β';
                            break;
                        case 'C':
                            letters1[i] = 'ψ';
                            break;
                        case 'D':
                            letters1[i] = 'δ';
                            break;
                        case 'E':
                            letters1[i] = 'ε';
                            break;
                        case 'F':
                            letters1[i] = 'φ';
                            break;
                        case 'G':
                            letters1[i] = 'γ';
                            break;
                        case 'H':
                            letters1[i] = 'η';
                            break;
                        case 'I':
                            letters1[i] = 'ι';
                            break;
                        case 'J':
                            letters1[i] = 'ξ';
                            break;
                        case 'K':
                            letters1[i] = 'κ';
                            break;
                        case 'L':
                            letters1[i] = 'λ';
                            break;
                        case 'M':
                            letters1[i] = 'μ';
                            break;
                        case 'N':
                            letters1[i] = 'ν';
                            break;
                        case 'O':
                            letters1[i] = 'ο';
                            break;
                        case 'P':
                            letters1[i] = 'π';
                            break;
                        case 'Q':
                            letters1[i] = 'κ';
                            break;
                        case 'R':
                            letters1[i] = 'ρ';
                            break;
                        case 'S':
                            letters1[i] = 'σ';
                            break;
                        case 'T':
                            letters1[i] = 'τ';
                            break;
                        case 'U':
                            letters1[i] = 'θ';
                            break;
                        case 'V':
                            letters1[i] = 'β';
                            break;
                        case 'W':
                            letters1[i] = 'ω';
                            break;
                        case 'X':
                            letters1[i] = 'χ';
                            break;
                        case 'Y':
                            letters1[i] = 'υ';
                            break;
                        case 'Z':
                            letters1[i] = 'ζ';
                            break;
                        case 'ά':
                            letters1[i] = 'α';
                            break;
                        case 'έ':
                            letters1[i] = 'ε';
                            break;
                        case 'ή':
                            letters1[i] = 'η';
                            break;
                        case 'ύ':
                            letters1[i] = 'υ';
                            break;
                        case 'ί':
                            letters1[i] = 'ι';
                            break;
                        case 'ό':
                            letters1[i] = 'ο';
                            break;
                        case 'ώ':
                            letters1[i] = 'ω';
                            break;
                        case 'Ά':
                            letters1[i] = 'α';
                            break;
                        case 'Έ':
                            letters1[i] = 'ε';
                            break;
                        case 'Ή':
                            letters1[i] = 'η';
                            break;
                        case 'Ύ':
                            letters1[i] = 'υ';
                            break;
                        case 'Ί':
                            letters1[i] = 'ι';
                            break;
                        case 'Ό':
                            letters1[i] = 'ο';
                            break;
                        case 'Ώ':
                            letters1[i] = 'ω';
                            break;
                    }
                }
                word = string.Join("", letters1);
                //MessageBox.Show(word);
                string[] words = word.Split(',');
                string query = "";

                foreach (string item in words)
                {
                    if (item == words[0])
                    {
                        query = "SELECT FirstName,LastName,Company,JobTitle,BusinessPhone,BusinessPhone2,HomePhone,MobilePhone,OtherPhone,EmailAddress,Uid FROM contacts where FirstName LIKE '%" + words[0].Trim() + "%'";
                    }
                    else
                    {
                        query = query + " OR FirstName LIKE '%" + item.Trim() + "%'";
                    }
                    //MessageBox.Show(item);
                }
                //MessageBox.Show(word);
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);

                da.Fill(dataTable);

                GridView1.DataSource = null;
                GridView1.DataBind();

                GridView1.DataSource = dataTable;
                GridView1.DataBind();

                connection.Close();

                Image6.Visible = true;
                Label10.Text = label;
                Label10.Visible = true;
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 11)
            {
                e.Row.Cells[15].Visible = false;
            }
            else
            {
                e.Row.Cells[10].Visible = false;
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://google.com/search?q=" + TextBox4.Text);
        }
    }
}