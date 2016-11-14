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
	$cid = $_POST["CID"];
							
	if( $calcValidator == $vcode ) {
		
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
				doLog("NORESULTS: UpdateDunk ".$accesskey);
				die('<MAINROOT><RESULT>NORESULTS</RESULT></MAINROOT>');
		}		
				
		$result_dunksleft="0";	
		while($row = mysql_fetch_array($result))
		{
			$result_dunksleft += (int)$row['dunksleft'];
		}	
		
		if( ($result_dunksleft > 0) || ($accesskey == "none") ) {
					
			$query = "UPDATE dd_orders SET dunksleft=dunksleft-1 WHERE accesskey='$accesskey'";
			$result = mysql_query($query);
			if (!$result) {
					doLog("select failed: ".$accesskey);
					die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
			}							
			
			// ($accesskey != "none") &&
			if(  ($accesskey != "385937829483aa82759287592") ) { // if no accesskey, then don't increment, to prevent hacks
				$query = "UPDATE ddchars SET dunkcount=dunkcount+1 WHERE cid='$cid'";
				$result = mysql_query($query);
				if (!$result) {
						doLog("insert failed: ".$uname);
						die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
				}		
			}
		}
			
		$output .= "<MAINROOT>";
		$output .= "<RESULT>SUCCESS</RESULT>";
		$output .= "</MAINROOT>";			
				
		print ($output);
	}
	
?>
