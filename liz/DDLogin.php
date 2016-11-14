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
	$accesskey = mysql_real_escape_string($_POST["ACCESSKEY"]); // use to look up in dd_orders
	$wpid = mysql_real_escape_string($_POST["WPID"]); // use to look up in dd_orders
	$calcValidator = md5("kfjew82uthsj".$uname.$pword.$atoken."loe992u5hs");
	//
		
	if( $calcValidator == $vcode ) {
		
		// validate accesskey
		// can have multiple oders
		
		if( $accesskey == "none" ) {
			$query = "SELECT * FROM dd_orders WHERE wp_user_id = '$wpid' ";
		} else {
			$query = "SELECT * FROM dd_orders WHERE accesskey = '$accesskey' ";
		}
		
		$result = mysql_query($query);
		
		if (!$result) {
				doLog("select failed: ".$accesskey);
				die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
		}	
		$number_of_rows = mysql_num_rows($result);	
		if ($number_of_rows==0) {
				doLog("NORESULTS: DDLogin ".$accesskey);
				die('<MAINROOT><RESULT>NORESULTS</RESULT></MAINROOT>');
		}
			
		$result_dunksleft=0;
		$result_charlist="";		
		while($row = mysql_fetch_array($result))
		{
			$result_dunksleft += (int)$row['dunksleft'];
			$result_charlist .= $row['charlist'].',';
		}	
		// remove last char
		$result_charlist = substr_replace($result_charlist ,"",-1);							
					
		if( $accesskey=="385937829483aa82759287592" ) { // this access key is for unlimited access
			$result_dunksleft = 100;
		}
		
		$output .= "<MAINROOT>";
		$output .= "<RESULT>SUCCESS</RESULT>";
		$output .= "<RESULTXML><![CDATA[<ROOT>";
		$output .= "<DUNKS>".$result_dunksleft."</DUNKS>";
		$output .= "<CHARLIST>".$result_charlist."</CHARLIST>";
		$output .= "</ROOT>]]></RESULTXML>"; 			
		$output .= "</MAINROOT>";			
		//output all the XML
		print ($output);
	}
	
?>

