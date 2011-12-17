<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application.catalogbrowsing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <% foreach (var department in this.model)
               {%>
              <tr class="ListItem">

               <td><a href="<%= StoryUrl.to.run<ViewProductsInDepartment>()
                                           .or<ViewDepartmentsInDepartment>()
                                           .based_on(department.has_products)
                                           .include(department,options => options.item(x => x.department_id))
                %>"><%=department.name%></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
