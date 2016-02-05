<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phoneindex.aspx.cs" Inherits="WebApplication3.WebForm1" EnableEventValidation = "false"  UICulture="el-GR" Culture="el-GR"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Τηλεφωνικός Κατάλογος</title>
    <link rel="shortcut icon" href="http://192.168.1.201:8082/mini.ico"/>
    <link rel="stylesheet" type="text/css" href="style.css"/>
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.3/jquery.min.js"></script>
       <script type="text/javascript">
           var z = 1;

           function function1() {
               var grow = setInterval(function () {
                   document.getElementById("grow").style.fontSize = z + "px";
                   z += 10;
                   if (document.getElementById("grow").style.fontSize >= "50px") {
                       clearInterval(grow);
                   }
               }, 1000);
           }

           function function2(obj)
           {
               var controlID = obj.id;
               var soapmessage = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><findperson xmlns="http://tempuri.org/"><id>'+ controlID +'</id></findperson></soap:Body></soap:Envelope>';
                   
               var webServiceURL = "http://192.168.1.201:8082/WebService2.asmx?op=findperson";
                $.ajax({
                    url: webServiceURL,
                    type: "POST",
                    dataType: "xml",
                    data: soapmessage,
                    contentType: "text/xml; charset=\"utf-8\"",
                    processData: false,
                    success: processSuccess,
                    error: processError
                });
           }

           function onMouseOver(rowIndex)
           {
               var gv = document.getElementById("GridView1");
               var rowElement = gv.rows[rowIndex];
               rowElement.display(rowElement.cells[0].text);
           }

           function SendAttach() {
               var theApp	//Reference to Outlook.Application 
               var theMailItem	//Outlook.mailItem
               //Attach Files to the email
               var attach1 = "c:\\temp\\sheet.xls"
               var attach2 = "c:\\temp\\mail.doc"
               var attach3 = "c:\\temp\\test.txt"
               //Construct the Email including To(address),subject,body
               //var recipient
               var subject = "Email Using JavaScript"
               var msg = "This is a test mail,sent to you using javascript by kushan thakershy"
               //Create a object of Outlook.Application
               try {
                   var theApp = new ActiveXObject("Outlook.Application")

                   var theMailItem = theApp.CreateItem(0) // value 0 = MailItem
                   //Bind the variables with the email
                   theMailItem.to = "venkatalakshmi.pingali@wipro.com"
                   theMailItem.Subject = (subject);
                   theMailItem.Body = (msg);
                   theMailItem.Attachments.Add(attach1)
                   theMailItem.Attachments.add(attach2)
                   theMailItem.Attachments.add(attach3)
                   //Show the mail before sending for review purpose
                   //You can directly use the theMailItem.send() function
                   //if you do not want to show the message.
                   theMailItem.display()
               }
               catch (err) {
                   alert("The following may have cause this error: \n" +
                    "1. The Outlook express 2003 is not installed on the machine.\n" +
                    "2. The msoutl.olb is not availabe at the location " +
                    "C:\\Program Files\\Microsoft Office\\OFFICE11\\msoutl.old on client's machine " +
                    "due to bad installation of the office 2003." +
                    "Re-Install office2003 with default settings.\n" +
                    "3. The Initialize and Scripts ActiveX controls not marked as safe is not set to enable.")
                   document.write("<a href=\"" + "./testemail.asp" + "\"" + ">" + "Go Back" + "</a>")
               }

           }


           function processSuccess(data, status, req) {
               if (status == "success")
                   $("#Label3").text(($(req.responseXML).find("findpersonResult").find("name").text()));
           }

           function processError(data, status, req) {
               alert(req.responseText + " " + status);
           }
               
        </script>
    <style type="text/css">
        .auto-style1 {
            width: 188px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" visible="True" lang="el">
    <div>
        <div class="image">
            <a href="http://server/index/phoneindex.aspx">
                <img id="3" class="Image1" src="http://192.168.1.201:8082/technor.png" height="178" width="634" alt="Alternate Text" /></a>
            
        </div>
        <div style="height: 72px">
            <div class="android inlineBlock">
                <asp:Label ID="Label9" runat="server" Text="Technor Chat" Height="16px" Font-Bold="True" Font-Names="Cambria" ForeColor="#336699" style="margin-left: 73px; margin-bottom: 0px;" Width="105px"></asp:Label>
                <br />
                <a href="http://192.168.1.201:8082/technor-chat.apk">
                    <img id="4" src="http://192.168.1.201:8082/android.png" alt="Alternate Text" style="height: 50px; width: 118px; margin-top: 0px; margin-left: 0px; margin-right: 0px;" /></a>
                <a href="http://chat-geo7geg.rhcloud.com/WebMobileGroupChatServer">
                    <img id="5" src="http://192.168.1.201:8082/web-link.png" alt="Alternate Text" style="margin: 0px; height: 50px; width: 119px; " /></a>
            </div>
            <div class="inlineBlock">
                <iframe class="clock" src="http://free.timeanddate.com/clock/i4w6b6bm/n26/tlgr17/fn17/fs20/fc103a56/tct/pct/pa8/tt0/th1/tb4" frameborder="0" allowTransparency="true" style="height: 62px; width: 363px; margin-left: 0px; margin-right: 0px"></iframe>
            </div>
        </div>
        <div class="textbox1">
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" CssClass="rounded" style="margin-right: 26px; text-align: left; margin-left: 27px; margin-top: 6px; margin-bottom: 0px;" Font-Size="Large" Height="23px" Width="418px" ></asp:TextBox>
            <br />
            <br />
&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Αναζήτηση" BackColor="#006699" ForeColor="White" style="margin-right: 3px; text-align: center; margin-left: 44px;" Font-Names="Calibri"  CssClass="button rounded" Height="33px" Width="107px"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" BackColor="#339966" ForeColor="White" OnClick="Button5_Click" Text="Νέα Επαφή" Width="107px" style="margin-right: 0px; margin-left: 0px;" CssClass="button rounded" Font-Names="Calibri" Height="33px" />       
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Εορτάζοντες" BackColor="#D96C00" ForeColor="White" style="text-align: center; margin-left: 18px;" Font-Names="Calibri"  CssClass="button rounded" Height="33px" Width="107px"/>
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Google" BackColor="#FF1A1A" ForeColor="White" style="margin-right: 14px; text-align: center; margin-left: 18px;" Font-Names="Calibri"  CssClass="button rounded" Height="33px" Width="107px"/>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" OnClick="ImageButton2_Click" style="margin-top: 0px; margin-bottom: 0px; margin-left: 19px;" Width="20px" />
        </div>
        <div class="textbox">

            <asp:Label ID="Label7" runat="server" Text="ΔΡΑΣΤΗΡΙΟΤΗΤΑ" Font-Bold="True" CssClass="headlabels" Font-Names="Calibri" ForeColor="#336699" Height="25px" Visible="False"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-right: 0px; margin-top: 11px; margin-left: 8px; margin-bottom: 0px;" Height="22px" Width="146px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
                <asp:ListItem Selected="True"> ΟΛΑ</asp:ListItem>
                <asp:ListItem>ΕΡΓΟΛΗΠΤΗΣ</asp:ListItem>
                <asp:ListItem>ΜΕΛΕΤΗΤΗΣ</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ</asp:ListItem>
                <asp:ListItem>ΕΙΔΙΚΕΣ ΕΤΑΙΡΕΙΕΣ</asp:ListItem>
                <asp:ListItem>ΠΕΡΙΦΕΡΕΙΑ</asp:ListItem>
                <asp:ListItem>ΔΗΜΟΣ</asp:ListItem>
                <asp:ListItem>ΔΕΥΑ</asp:ListItem>
                <asp:ListItem>ΔΕΚΟ</asp:ListItem>
                <asp:ListItem>ΔΗΜΟΣΙΟ</asp:ListItem>
                <asp:ListItem>ΑΝΤΛΙΑΣ</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ Α</asp:ListItem>
                <asp:ListItem>ΠΡΟΜΗΘΕΥΤΗΣ Β</asp:ListItem>
                <asp:ListItem>ΠΙΝΑΚΑΣ Α</asp:ListItem>
                <asp:ListItem>ΠΙΝΑΚΑΣ Β</asp:ListItem>
                <asp:ListItem>ΑΛΛΟΙ</asp:ListItem>
            </asp:DropDownList>
            
            <asp:Label ID="Label8" runat="server" Text="ΠΕΡΙΟΧΗ" Font-Bold="True" CssClass="headlabels" Font-Names="Calibri" ForeColor="#336699" Height="25px" Visible="False"></asp:Label>
            
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="22px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="146px" style="margin-top: 10px; margin-bottom: 0px; margin-right: 10px; margin-left: 0px;" Visible="False">
                <asp:ListItem Selected="True">ΟΛΕΣ</asp:ListItem>
                <asp:ListItem>ΑΝ. ΜΑΚΕΔΟΝΙΑ &amp; ΘΡΑΚΗ</asp:ListItem>
                <asp:ListItem>ΚΕΝΤΡΙΚΗ ΜΑΚΕΔΟΝΙΑ</asp:ListItem>
                <asp:ListItem>ΔΥΤΙΚΗ ΜΑΚΕΔΟΝΙΑ</asp:ListItem>
                <asp:ListItem>ΗΠΕΙΡΟΣ</asp:ListItem>
                <asp:ListItem>ΘΕΣΣΑΛΙΑ</asp:ListItem>
                <asp:ListItem>ΙΟΝΙΟΙ ΝΗΣΟΙ</asp:ListItem>
                <asp:ListItem>ΔΥΤΙΚΗ ΕΛΛΑΔΑ</asp:ListItem>
                <asp:ListItem>ΣΤΕΡΕΑ ΕΛΛΑΔΑ</asp:ListItem>
                <asp:ListItem>ΑΤΤΙΚΗ</asp:ListItem>
                <asp:ListItem>ΠΕΛΟΠΟΝΝΗΣΟΣ</asp:ListItem>
                <asp:ListItem>ΒΟΡΕΙΟ ΑΙΓΑΙΟ</asp:ListItem>
                <asp:ListItem>ΝΟΤΙΟ ΑΙΓΑΙΟ</asp:ListItem>
                <asp:ListItem>ΚΡΗΤΗ</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownList3" runat="server" style="margin-bottom: 0px" Height="22px" Width="146px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Visible="False">
                <asp:ListItem> </asp:ListItem>
            </asp:DropDownList>
            
        </div>
        <div class="textbox4">
            <asp:Image ID="Image6" runat="server" ImageUrl="http://192.168.1.201:8082/giorti.gif" Height="147px" Width="175px" Visible="False"/>
            <br />
            <asp:Label ID="Label10" runat="server" Height="16px" Font-Bold="True" Font-Names="Calibri" ForeColor="#006C00" style="margin-left: 0px; margin-bottom: 0px;" Width="1032px" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="173px" Width="416px" CellPadding="3" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" OnRowCreated="GridView1_RowCreated">
                <AlternatingRowStyle BackColor="#A4EDFF" />
                <EditRowStyle Font-Names="Calibri" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#103A56" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <br />
        
    </div>
        <div id="grow" hidden="hidden">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            </p>
            <p>

                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

            </p>
            <p id="label3" onmouseover="function1()" >

                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

            </p>
            <p>

                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox>

            </p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <p> 
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </p>
            <p>

                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_LocalResources/castle.png"/>
                <input  id="2" class="2" type="button" value="Call Web Service" onclick="function2(); return false;" onmouseover="function2(this); return false;" />
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
                        
            </p>
        </div>
        
        <div aria-hidden="True" hidden="hidden">
            <img id="1" class="1" src="http://assets3.parliament.uk/iv/main-large//ImageVault/Images/id_7382/scope_0/ImageVaultHandler.aspx.jpg" onclick="function2(this)" alt="Alternate Text" />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server"  />
        </div>
       
        <div hidden="hidden">

            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/Advert.xml" Height="500px" Width="500px" />
            <asp:Localize ID="Localize1" runat="server"></asp:Localize>
            <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [information]"></asp:SqlDataSource>--%>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <p>

                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />

                    </p>
                </asp:View>
            </asp:MultiView>

        </div>
        <div hidden="hidden">
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <asp:Panel ID="Panel1" runat="server" Height="800px" Width="800px"></asp:Panel>
        </div>
    </form>
    <form id="form2" hidden="hidden" action="http://localhost:12051/WebService2.asmx/findperson" method="post" target="_blank" visible="False">
        <table>
          <tr>
            <td>Find Person:</td>
            <td class="auto-style1">
            <input class="frmInput" type="text" size="30" name="Fahrenheit"/>
            </td>
          </tr>
          <tr>
            <td></td>
            <td class="auto-style1">
             <input type="submit" value="Submit" class="button"/>
             </td>
          </tr>
        </table>
    </form>
    </body>
</html>
