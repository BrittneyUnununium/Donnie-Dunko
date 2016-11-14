<?php
	define( 'parentFile' , 1 ); 
	require_once( 'db_include.php' );
		
	//	connect to the database
	$mysql = mysql_connect(DATABASE_SERVER, DATABASE_USERNAME, DATABASE_PASSWORD) or die(mysql_error());

	// select the database
	mysql_select_db( DATABASE_NAME );
	
	require_once( 'common.php' );
	
	$uname = mysql_real_escape_string($_POST["UNAME"]);
	$pword = mysql_real_escape_string($_POST["PWORD"]);					
	$atoken = mysql_real_escape_string($_POST["ATOKEN"]);
	$vcode = mysql_real_escape_string($_POST["VALIDATOR"]);	
	$clist = mysql_real_escape_string($_POST["CHARLIST"]);
	$calcValidator = md5("kfjew82uthsj".$uname.$pword.$atoken."loe992u5hs");
									
	if( $calcValidator == $vcode ) {

		if( $clist == 'all') {
			$query = "SELECT * FROM ddchars ORDER BY cid";
		} else {		
			$query = "SELECT * FROM ddchars WHERE cid IN ($clist) ORDER BY cid";
		}
		
		$result = mysql_query($query);
		if (!$result) {
				doLog("select failed: ".$uname);
				die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
		}	
		$number_of_rows = mysql_num_rows($result);	
		if ($number_of_rows==0) {
				doLog("NORESULTS: GetCharacters ".$uname);
				die('<MAINROOT><RESULT>NORESULTS</RESULT></MAINROOT>');
		}			

		$output = "<MAINROOT>";				
		$output .= "<RESULT>SUCCESS</RESULT>";
		$output .= "<RESULTXML><![CDATA[<ROOT>";
	
		while($row = mysql_fetch_array($result))
		{								
			$result_cid = $row['cid'];		
			$result_name = $row['cname'];
			$result_head = $row['chead'];
			$result_body = $row['cbody'];
			$result_cid = $row['cid'];
			$result_dunks = $row['dunkcount'];
						
			$output .= "<char>";											
			$output .= "<CID>".$result_cid."</CID>";
			$output .= "<name>".$result_name."</name>";
			$output .= "<head>".$result_head."</head>";
			$output .= "<body>".$result_body."</body>";
			$output .= "<dunkcount>".$result_dunks."</dunkcount>";						
			$output .= "</char>";
					
		}

		$output .= "</ROOT>]]></RESULTXML>"; 		
		$output .= "</MAINROOT>";		
		
		//output all the XML
		print ($output);
	
}
		
			
	
?>
