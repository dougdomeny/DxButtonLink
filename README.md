DxButtonLink
============

Displays a button that navigates like a hyperlink. 

Derived from DevExpress ASPxButton.

Requirement: Licensed version of DevExpress product that includes ASPxButton.

This project references DevExpress.Web.v12.2 version 12.2.15.0, but the version can be changed to a newer or older version.

The server control source code is at DxButtonLink/DxButtonLink/ButtonLink.cs and is really all you need to add to your application. The rest is just scaffolding and a test web page. The source code is short and should be self-explanatory. The default target framework is ASP.NET 4.5, but can be changed to a newer or older version.

Example,

      <dxx:ButtonLink runat="server"
            Text="Derived from DevExpress ASPxButton Class"
            NavigateUrl="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxEditorsASPxButtontopic" />
