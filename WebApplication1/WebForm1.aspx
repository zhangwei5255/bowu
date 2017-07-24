<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



<head>
    <style type="text/css">
        .auto-style2 {
            height: 45px;
        }
    </style>
</head>



<body>
   
   
    <div>
        <h2>
        交通区間を選択してください。
    </h2>
    <table>
       
        <tr >
            <td >
                &nbsp;
                <a href="#" onclick="clickListViewButton('./addonLedgerMapSearchDetailEvent.do?selTab=event', eventId">
                    交通区間1
                </a>
            </td>
        </tr>
        <tr >
            <td class="auto-style2" >
                　<a href="#">交通区間2</a>

            </td>
        </tr>
    </table>
   </div>
   
    
</body>
</html>
