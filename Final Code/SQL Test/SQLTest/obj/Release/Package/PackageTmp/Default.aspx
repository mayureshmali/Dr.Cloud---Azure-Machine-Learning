<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StrokePredictionMali.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stroke Prediction Calculator</title>
    <style>
        body{font-family:'Berlin Sans FB';font-size:12px;}
    </style>
</head>
<body style="background:url(../img/healthbg.jpg) no-repeat 100% 0;">


    
    <form id="form1" runat="server">
        <div>
            <h1>Dr.Cloud Stroke Prediction App (Mayuresh and Yufei)</h1>
        </div>
        <table>
            <tr>
                <td style="font-size: large">Gender:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList></td>                    
            </tr>
            <tr>
                <td style="font-size: large">Age:</td>
                <td>
                    <asp:TextBox ID="Age" runat="server"></asp:TextBox></td>                  
            </tr>
            <tr>
                <td style="font-size: large">Hypertension:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblHypertension" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:RadioButtonList></td>                  
            </tr>
            <tr>
                <td style="font-size: large">Heart Disease:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblHeartDisease" runat="server">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                </asp:RadioButtonList></td>                  
            </tr>
            <tr>
                <td style="font-size: large">Marital Status:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblMaritalStatus" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList></td>                    
            </tr>
            <tr>
                <td style="font-size: large">Work Type:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblWorkType" runat="server">
                    <asp:ListItem>Private</asp:ListItem>
                    <asp:ListItem>children</asp:ListItem>
                    <asp:ListItem>Self-employed</asp:ListItem>
                    <asp:ListItem>Govt_job</asp:ListItem>
                    <asp:ListItem>Never_worked</asp:ListItem>                    
                </asp:RadioButtonList></td>                    
            </tr>
            <tr>
                <td style="font-size: large">Residence Type:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblResidence" runat="server">
                    <asp:ListItem>Urban</asp:ListItem>
                    <asp:ListItem>Rural</asp:ListItem>
                </asp:RadioButtonList></td>                    
            </tr>
            <tr>
                <td style="font-size: large">Average Glucose Level:</td>
                <td style="font-size: large">
                    <asp:TextBox ID="Glucoselvl" runat="server"></asp:TextBox></td>                  
            </tr>
            <tr>
                <td style="font-size: large">BMI:</td>
                <td style="font-size: large">
                    <asp:TextBox ID="BMI" runat="server"></asp:TextBox></td>                  
            </tr>
            <tr>
                <td style="font-size: large">Smoking status:</td>
                <td style="font-size: large"><asp:RadioButtonList ID="rblSmokingStatus" runat="server">
                    <asp:ListItem>never smoked</asp:ListItem>
                    <asp:ListItem>formerly smoked</asp:ListItem>
                    <asp:ListItem>smokes</asp:ListItem>
                </asp:RadioButtonList></td>                    
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="lbPredict" runat="server" OnClick="lbPredict_Click">Show me the result</asp:LinkButton>                               
            </tr>
            <tr>
                                
        </table>
        <h2><asp:Label ID="lblResults" runat="server" Text="Test" Font-Size="XX-Large"></asp:Label></h2>
        
        <tr>  
                    <td> </td>  
                    <td>  
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>  
                    </td>  
                </tr>  

        <tr>  
                    <td></td>  
                    <td>  
                        <asp:Button ID="btnSave" runat="server" Text="Save Record" onclick="btnSave_Click" />    
                         
                </tr>  
        <br /><br /><br />
    </form>
</body>
</html>
