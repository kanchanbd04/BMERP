<%@ Page Title="" Language="C#" MasterPageFile="~/academic_site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OnlineTicketingSystem._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .link
        {
            text-align: center;
            font-size: 16px;
        }
        /*.image:hover*/
        .link_con:hover
        {
            /*width: 85px;
            height: 85px;*/
            transform: scale(1.2);
        }
        a
        {
            text-decoration: none;
        }
        a:hover
        {
            /*text-decoration: underline;*/
        }
        .link_con
        {
            display: inline-block;
            margin-right: 20px;
            margin-bottom: 20px;
        }

         .link_con img
        {
             width: 100px;
             height: 100px;
        }

    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%-- <table>
        <tr>
            <td>
                <a href="#" ><img id="image" src="images/Calendar.png" width="75px" height="75px"/><br><div class="link">Calender</div></a>
            </td> 
            <td>
                <img src="images/Lesson Plan.png"  width="75px" height="75px" />
            </td>
             <td>
                <img src="images/Lesson Plan.png"  width="75px" height="75px" />
            </td>
        </tr>
       
    </table>--%>
   <%-- <div style="width: 1200px; text-align: center; margin: 0 auto;">--%>
     <div style="width: 1200px; text-align: left; ">
        <div id="group1" runat="server" style="margin-top: 20px;" >
            <%--<div class="link_con">
                <a href="/forms/academic/worksheet/amworksheetteacher.aspx">
                    <div style="text-align: center">
                        <img class="image" src="images/homework.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Homework</div>
                </a>
            </div>
             <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Calendar.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Calender</div>
                </a>
            </div>
           <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Lesson Plan.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Lesson Plan</div>
                </a>
            </div>
            <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Sports.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Sports</div>
                </a>
            </div>
            <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Routine.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Routine</div>
                </a>
            </div>
            <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Students' Profile.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Student's Profile</div>
                </a>
            </div>
            <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Teachers' Profile.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Teacher's Profile</div>
                </a>
            </div>
            <div class="link_con">
                <a href="#">
                    <div style="text-align: center">
                        <img class="image" src="images/Admission.png" width="75px" height="75px" /></div>
                    <div class="link">
                        Admission</div>
                </a>
            </div>--%>
            
            <div class="link_con" runat="server" id="admissionOnline">
                <a href="/forms/academic/profile/student/amadmisonline.aspx?subnav=myDropdown38&link=LinkButton38&xid=1420">
                    <div style="text-align: center">
                        <img class="image" src="images/1.4- Online Application.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
             <div class="link_con" runat="server" id="candidateInfo">
                <a href="/forms/academic/profile/student/student.aspx?subnav=myDropdown38&link=LinkButton38&xid=53">
                    <div style="text-align: center">
                        <img class="image" src="images/1.1- Input Candidate Information.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="numberOfCandidate">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div1">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div2">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            

            
            <div class="link_con" runat="server" id="Div3">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div4">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div5">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div6">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            
            <div class="link_con" runat="server" id="Div7">
                <a href="/forms/academic/profile/student/numcandidates.aspx?subnav=myDropdown38&link=LinkButton38&xid=54">
                    <div style="text-align: center">
                        <img class="image" src="/images/1.2- Number of Candidates.png"  /></div>
                   <%-- <div class="link">
                        Admission</div>--%>
                </a>
            </div>
            

        </div>
    </div>

   

</asp:Content>


