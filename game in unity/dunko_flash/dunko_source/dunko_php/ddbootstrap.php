<?php
	$appservice = $_POST["DDSERVICE"];
		
	try {
		switch( $appservice ) {

				
			case "AdminGetCharacters" : require 'services/AdminGetCharacters.php';
			break;

			case "AdminPutCharacter" : require 'services/AdminPutCharacter.php';
			break;
			
			case "AdminDeleteCharacter" : require 'services/AdminDeleteCharacter.php';
			break;	
																					
			case "UpdateDunk" : require 'services/UpdateDunk.php';
			break;
			
			case "DDLogin" : require 'services/DDLogin.php';
			break;	
			
			case "GetCharacters" : require 'services/GetCharacters.php';
			break;
			
			case "GetDunkList" : require 'services/GetDunkList.php';
			break;							
										
			default :
				echo 'error ' . $appservice;		
			break;
		}
	    
	} catch (Exception $exception) {
	    echo '<error>An exception occured while bootstrapping the application.</error>';
	    exit(1);
	}
	

?>
