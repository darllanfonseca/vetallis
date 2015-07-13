<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vetallis.Default" %>

<!DOCTYPE html>
<html>
<head>
<style>
#header {
    background-color:#606060;
    color:white;
    text-align:center;
    padding:5px;
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
    width:950px;
    float:left;
    padding:10px;
    text-align:center;	 	 
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
    height:650px;
    text-align:center;
    border: 3px solid #8AC007;
}
</style>
</head>
<body>


    <div id="container">
<div id="header">
<h1>City Gallery</h1>
</div>

<div id="nav">
London<br>
Paris<br>
Tokyo<br>
</div>

<div id="section">
<h2>London</h2>
<p>
London is the capital city of England. It is the most populous city in the United Kingdom,
with a metropolitan area of over 13 million inhabitants.
</p>
<p>
Standing on the River Thames, London has been a major settlement for two millennia,
its history going back to its founding by the Romans, who named it Londinium.
</p>
</div>

<div id="footer">
Copyright © W3Schools.com
</div>
</div>
</body>
</html>
