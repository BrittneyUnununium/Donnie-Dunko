<?php
  //reading raw POST data from input stream. reading pot data from $_POST may cause serialization issues since POST data may contain arrays
	
	define( 'parentFile' , 1 ); 
	require_once( 'db_include.php' );
		
	//	connect to the database
	$mysql = mysql_connect(DATABASE_SERVER, DATABASE_USERNAME, DATABASE_PASSWORD) or die(mysql_error());

	// select the database
	mysql_select_db( DATABASE_NAME );

	require_once( 'common.php' );
		  	
	$ipn_post_data = $_POST;
	
  $raw_post_data = file_get_contents('php://input');
  
  $raw_post_array = explode('&', $raw_post_data);
  $myPost = array();
  foreach ($raw_post_array as $keyval)
  {
      $keyval = explode ('=', $keyval);
      if (count($keyval) == 2)
         $myPost[$keyval[0]] = urldecode($keyval[1]);
  }
  // read the post from PayPal system and add 'cmd'
  $req = 'cmd=_notify-validate';
  if(function_exists('get_magic_quotes_gpc'))
  {
       $get_magic_quotes_exits = true;
  } 
  foreach ($myPost as $key => $value)
  {        
       if($get_magic_quotes_exits == true && get_magic_quotes_gpc() == 1)
       { 
            $value = urlencode(stripslashes($value)); 
       }
       else
       {
            $value = urlencode($value);
       }
       $req .= "&$key=$value";
  }


if(array_key_exists('test_ipn', $ipn_post_data) && 1 === (int) $ipn_post_data['test_ipn'])
    $url = 'https://www.sandbox.paypal.com/cgi-bin/webscr';
else
    $url = 'https://www.paypal.com/cgi-bin/webscr';


$ch = curl_init();

//curl_setopt($ch, CURLOPT_URL, 'https://www.paypal.com/cgi-bin/webscr');
curl_setopt($ch, CURLOPT_URL, $url );
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_RETURNTRANSFER,1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $req);
curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 1);
curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 2);
curl_setopt($ch, CURLOPT_HTTPHEADER, array('Host: www.paypal.com'));
// In wamp like environment where the root authority certificate doesn't comes in the bundle, you need
// to download 'cacert.pem' from "http://curl.haxx.se/docs/caextract.html" and set the directory path 
// of the certificate as shown below.
// curl_setopt($ch, CURLOPT_CAINFO, dirname(__FILE__) . '/cacert.pem');
$res = curl_exec($ch);
curl_close($ch);
 
// assign posted variables to local variables
$item_name = $_POST['item_name'];
$item_number = $_POST['item_number'];
$payment_status = $_POST['payment_status'];
$payment_amount = $_POST['mc_gross'];
$payment_currency = $_POST['mc_currency'];
$txn_id = $_POST['txn_id'];
$receiver_email = $_POST['receiver_email'];
$payer_email = $_POST['payer_email'];
$user_id = $_POST['custom'];

if (strcmp ($res, "VERIFIED") == 0) {
	doLog("VERIFIED:: ".$txn_id." ".$payer_email." ".$payment_status." ".$payment_amount." ".$item_number);
	
	if( $payment_status == "Completed" ) {
		
		// %% check $item_number do decide what characters are included in purchase
		// DD01T
		$charlist = 'all';	
		$numberofdunks = 3; 
		$packpurchase = "false";
		
	 	switch( $item_number ) {
		 	case "DD01":
	 			$charlist = 'all';
		 		$numberofdunks = 3;
				$packpurchase = "false";
	 		break;
		 	case "DD01T": // test
	 			$charlist = '72,89,101,106';
		 		$numberofdunks = 999999;
				$packpurchase = "true";
	 		break;		
			
			// pack purchase 
		 	case "Presidential":
	 			$charlist = '72,89,101,106';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "Politicians_1":
	 			$charlist = '113,86,103,85';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;				
		 	case "Politicians_2":
	 			$charlist = '83,80,92,98';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	 									
		 	case "Conservative_Pundits":
	 			$charlist = '58,74,84,112';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
		 	case "Liberal_Pundits":
	 			$charlist = '117,90,73,109';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "Reality_Show_Females":
	 			$charlist = '87,102,93';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
		 	case "Bad_Boys":
	 			$charlist = '71,114,111,118';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
		 	case "Scandalous":
	 			$charlist = '88,70,69';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;		
		 	case "Naughty_Girls":
	 			$charlist = '104,97,77';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;		
		 	case "Jersey_Shore":
	 			$charlist = '116,99,91,107';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
		 	case "CEOs":
	 			$charlist = '81,79,78,75';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;			
		 	case "Male_TV_Stars":
	 			$charlist = '82,115,108';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;			
		 	case "The_Kardashians":
	 			$charlist = '95,94,96';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;										
		 	case "WA_State_Politicians":
	 			$charlist = '110,105,100';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
			
			//
	 	} 
	 	
	
		$query = "INSERT INTO dd_orders (wp_user_id, accesskey , dunksleft, charlist, buyer_email, item, payment) VALUES ('$user_id','$txn_id','$numberofdunks','$charlist','$payer_email','$item_name','$payment_amount')";
		$result = mysql_query($query);
		if (!$result) {
				doLog("insert failed: ".$uname);
				die('<MAINROOT><RESULT>SYSTEMERROR</RESULT><MESSAGE>select failed</MESSAGE></MAINROOT>');
		}	
		$cid = mysql_insert_id($mysql);			
			
		// send email
	 	$subject = "Donnie Dunko Order";
	 	$headers = "From: nioka@q.com\r\n"."X-Mailer: php";
	 	//$body = "Thank you for your purchase!\n\nHere is your Donnie Dunko game link: http://s365653042.onlinehome.us/donniedunko/play?chars=0&accesskey=".$txn_id;
	 	//$body = "Thank you for your purchase!\n\nHere is your Donnie Dunko game link: http://donniedunko.com/play?accesskey=".$txn_id;
	 	if( $packpurchase == "false" ) {
	 		$body = "Thank you for your purchase!\n\nHere is your Donnie Dunko game link: http://donniedunko.com?accesskey=".$txn_id;
	 	} else {
	 		$body = "Thank you for your purchase!\n\nHere is your Donnie Dunko game link: http://donniedunko.com/\n\nSimply Login to play.";
		}
		
	 	if (mail($payer_email, $subject, $body, $headers)) {
		 	// doLog("successfully: ".$payer_email); // no need to log successful send
	  	} else {
		 	doLog("FAILED to send email: ".$payer_email);
	  	}
		  
	} else {
		 doLog("IPN status: ".$payment_status." ".$txn_id." ".$payer_email);
	} 
 
}
else if (strcmp ($res, "INVALID") == 0) {
	// log for manual investigation
	 doLog("Invalid IPN: ".$payment_status." ".$txn_id." ".$payer_email);
}

?>