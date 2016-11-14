<?php 

	defined( 'parentFile' ) or die( 'You Can Not Access This File' ); 
	
	function doLog($msg)
	{	
		$query_log = "INSERT INTO logs (message) VALUES ('$msg')";
		$result_log = mysql_query($query_log);		
	}
					
	
    function encrypt($string, $key='%5key984872923825&') {
        $result = '';
        for($i=0; $i<strlen($string); $i++) {
            $char = substr($string, $i, 1);
            $keychar = substr($key, ($i % strlen($key))-1, 1);
            $ordChar = ord($char);
            $ordKeychar = ord($keychar);
            $sum = $ordChar + $ordKeychar;
            $char = chr($sum);
            $result.=$char;
        }
        return base64_encode($result);
    }
		
?>	


