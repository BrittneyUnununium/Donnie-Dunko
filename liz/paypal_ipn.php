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
		 	case "2014_Donnie_Dunko":
	 			$charlist = '120,119';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Bad_Boys":
	 			$charlist = '120,111,71,138';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Girls_Gone_Wild":
	 			$charlist = '120,77,104,139';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Weird_Wet_Women":
	 			$charlist = '120,97,95,135';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Loony_Loosers":
	 			$charlist = '120,106,134,140';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;	
		 	case "2014_Billionare_Bozos":
	 			$charlist = '120,81,98,78';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;
		 	case "2014_The_Talking_Dead":
	 			$charlist = '120,112,92,84';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Village_Idiots":
	 			$charlist = '120,83,80,101';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Dismals":
	 			$charlist = '120,58,113,74';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_KKK":
	 			$charlist = '120,95,94,96';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Wild_and_Crazy_Guys":
	 			$charlist = '120,73,90,117';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Super_Soakers":
	 			$charlist = '120,72,89,86';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Unbelievables":
	 			$charlist = '120,128,135,141';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Drama_Queens":
	 			$charlist = '120,91,87,116';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Dim_And_The_Lame":
	 			$charlist = '120,129,136,113';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Unfabulous":
	 			$charlist = '120,130,134,142';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Zombie_Nation":
	 			$charlist = '120,131,29,85';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Dumb_And_Dumber":
	 			$charlist = '120,132,113,97';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Idiot_Factor":
	 			$charlist = '120,133,137,81';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Tacky_Trio":
	 			$charlist = '120,147,146,151';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_The_Entitled":
	 			$charlist = '120,145,150,143';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Stop_Talking":
	 			$charlist = '120,144,149,148';
		 		$numberofdunks = 999999; 
		 		$packpurchase = "true";
	 		break;						
		 	case "2014_Dunk_the_Hawks":
	 			$charlist = '120,152,153,154,155,156,157,158,159,160';
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