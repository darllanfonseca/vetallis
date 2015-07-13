<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vetallis.Default" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

<style>  
#header {
    background-color:#606060;
    padding: 50px;
}
#nav {
    line-height:30px;
    background-color:#eeeeee;
    height:494px;
    width:200px;
    float:left;
    padding:5px;	      
}
#section {
    float:left;
    padding:10px;
    text-align:center;	
    color:#FFF; 	 
    background-image: url("logo.jpg"); width: 994px; height: 494px;
}

#link1 {
    float:left;
    text-align:center;
    display: table-cell;
    padding: 5px 5px 5px 5px;
}
#link2 {
    float:left;
    text-align:center;
    display: table-cell;
    padding: 5px 5px 5px 5px;
}
#link3 {
    float:left;
    text-align:center;
    display:table-cell;
    padding: 5px 5px 5px 5px;
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
    left:50px;
    top:5px;   
    width:1200px;
    height:630px;
    text-align:center;
    border: 3px solid #8AC007;
}
.btn-primary {
    background: #339900;
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
