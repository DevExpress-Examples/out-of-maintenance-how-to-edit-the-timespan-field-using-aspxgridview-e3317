<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128539810/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3317)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to edit the TimeSpan field using ASPxGridView
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3317/)**
<!-- run online end -->


<p>ASPxGridView is able to create an editor for the DateTime field, but not for the TimeSpan field. Since the TimeSpan data type represents a time interval of an appropriate string <a href="http://msdn.microsoft.com/en-us/library/1ecy8h51.aspx"><u>format</u></a>, it becomes possible to edit the TimeSpan data type using the textbox column and <a href="http://documentation.devexpress.com/#AspNet/CustomDocument8171"><u>Mask</u></a>.<br />
The example demonstrates how to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_ParseValuetopic"><u>ASPxGridView.ParseValue</u></a> event to parse a user value to TimeSpan objects. The grid performs reversed process (from the TimeSpan type to the String) automatically.</p>


<h3>Description</h3>

<p>A main idea of the sample is to correct the conversion from the TimeSpan object to the String which can be applied to an editor with an enabled mask.</p>

<br/>


