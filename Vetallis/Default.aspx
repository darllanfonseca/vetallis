<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vetallis.Default" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script>
        // Copyright 2006-2007 javascript-array.com

        var timeout = 10;
        var closetimer = 0;
        var ddmenuitem = 0;

        // open hidden layer
        function mopen(id) {
            // cancel close timer
            mcancelclosetime();

            // close old layer
            if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';

            // get new layer and show it
            ddmenuitem = document.getElementById(id);
            ddmenuitem.style.visibility = 'visible';

        }
        // close showed layer
        function mclose() {
            if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';
        }

        // go close timer
        function mclosetime() {
            closetimer = window.setTimeout(mclose, timeout);
        }

        // cancel close timer
        function mcancelclosetime() {
            if (closetimer) {
                window.clearTimeout(closetimer);
                closetimer = null;
            }
        }

        // close layer when click-out
        document.onclick = mclose;
    </script>
<style>
#sddm
{	margin: 0;
	padding: 0;
	z-index: 30}

#sddm li
{	margin: 0;
	padding: 0;
	list-style: none;
	float: left;
	font: bold 11px arial}

#sddm li a
{	display: block;
	margin: 0 1px 0 0;
	padding: 4px 10px;
	width: 60px;
	background: #8AC007;
	color: #FFF;
	text-align: center;
	text-decoration: none}

#sddm li a:hover
{	background: #8AC007}

#sddm div
{	position: absolute;
	visibility: hidden;
	margin: 0;
	padding: 0;
	background: #8AC007;
	border: 1px solid #5970B2}

	#sddm div a
	{	position: relative;
		display: block;
		margin: 0;
		padding: 5px 10px;
		width: auto;
		white-space: nowrap;
		text-align: left;
		text-decoration: none;
		background: #8AC007;
		color: #2875DE;
		font: 11px arial}

	#sddm div a:hover
	{	background: #8AC007;
		color: #FFF} 

     
#header {
    background-color:#606060;
    color:white;
    text-align:center;
    padding: 50px;
}
#nav {
    line-height:30px;
    background-color:#eeeeee;
    height:522px;
    width:200px;
    float:left;
    padding:5px;	      
}
#section {
    width:968px;
    float:left;
    padding:10px;
    text-align:center;	 	 
}
#link1 {
    float:left;
    text-align:center;
    display: table-cell;
    padding: 2px 5px;
}
#link2 {
    float:left;
    text-align:center;
    display: table-cell;
    padding: 2px 5px;
}
#link3 {
    float:left;
    text-align:center;
    display:table-cell;
    padding: 2px 5px;
}
#footer {
    background-color:#606060;
    color:white;
    clear:both;
    text-align:center;
   padding:5px;	 	 
}
#container {
    position:relative;
    left:20px;
    top:20px;   
    width:1200px;
    height:658px;
    text-align:center;
    border: 3px solid #8AC007;
}
.btn-primary {
    background: #28A828;
    color: #ffffff;
    border-radius:0;
}
.btn-toggle{
background: #8AC007;
}
</style>
</head>
<body>


    <div id="container">
<div id="header">
<div id="link1" class="dropdown">
    <button class="btn btn-primary dropdown-toggle" type="button" id="menu1" data-toggle="dropdown">Insert
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">New Member</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">New Partner</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">New CE Event</a></li>
    </ul>
  </div>
    <div id="link2" class="dropdown">
    <button class="btn btn-primary dropdown-toggle" type="button" id="menu2" data-toggle="dropdown">Edit
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="menu2">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Member</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Partner</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">CE Event</a></li>
    </ul>
  </div>
    <div id="link3" class="dropdown">
    <button class="btn btn-primary dropdown-toggle" type="button" id="menu3" data-toggle="dropdown">Remove
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="menu3">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Member</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Partner</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">CE Event</a></li>
    </ul>
  </div>
</div>

<div id="nav">
Rebate Sheet<br>
Membership List<br>
</div>

<div id="section">
<h2>Vet Alliance Rebate 2015</h2>
<p>
Text to include
</p>
<p>
...
</p>
</div>

<div id="footer">
© 2015 Vet Alliance Inc.
</div>
</div>
</body>
</html>
