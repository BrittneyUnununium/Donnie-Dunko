<?php
	define( 'parentFile' , 1 ); 
	require_once( 'db_include.php' );
		
	//	connect to the database
	$mysql = mysql_connect(DATABASE_SERVER, DATABASE_USERNAME, DATABASE_PASSWORD) or die(mysql_error());

	// select the database
	mysql_select_db( DATABASE_NAME );

	$cid = $_POST["cid"];

	$query = "DELETE FROM ddchars WHERE cid=$cid";	
	$result = mysql_query($query);
	if (!$result) {
			doLog("delete failed: ".$uname);
			die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>delete failed</MESSAGE></MAINROOT>');
	}	
											
	$output .= "<MAINROOT>";
	$output .= "<RESULT>SUCCESS</RESULT>";
	$output .= "</MAINROOT>";
				
	//output all the XML
	print ($output);
	
?>

