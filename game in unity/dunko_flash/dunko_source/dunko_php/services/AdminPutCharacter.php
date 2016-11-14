<?php
	define( 'parentFile' , 1 ); 
	require_once( 'db_include.php' );
		
	//	connect to the database
	$mysql = mysql_connect(DATABASE_SERVER, DATABASE_USERNAME, DATABASE_PASSWORD) or die(mysql_error());

	// select the database
	mysql_select_db( DATABASE_NAME );

	//
	$cname = $_POST["name"];
	$chead = $_POST["head"];
	$cbody = $_POST["body"];
	$dunkcount = 0;

							
	if( $calcValidator == $vcode ) {
		$query = "INSERT INTO ddchars (cname, chead, cbody, dunkcount) VALUES ('$cname','$chead','$cbody','$dunkcount')";
		$result = mysql_query($query);
		if (!$result) {
				doLog("insert failed: ".$uname);
				die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
		}	
		$cid = mysql_insert_id($mysql);			
							
		$output .= "<MAINROOT>";
		$output .= "<RESULT>SUCCESS</RESULT>";
		$output .= "<CID>".$cid."</CID>";
		$output .= "</MAINROOT>";			

		//output all the XML
		print ($output);
	}
	
?>
