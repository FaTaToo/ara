// --------------------------------------------------------------------------------------------------------------------
// <header file="GetAllTargets.php" group="288-462">
	//
	// Last modified:
	// Author: LE Sanh Phuc - 11520288
	//
	// </header>
// <summary>
	// Used to get all target in Vuforia Cloud database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

<?php
// --------------------------------------------------------------------------------------------------------------------
// <header file="GetAllTargets.php" group="288-462">
//
// Last modified:
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement GetAllTargets class for Manager and Presenter Module getting all uploaded targets
// in Cloud database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
require_once 'HTTP/Request2.php';
require_once 'SignatureBuilder.php';

class GetAllTargets{
	//Server Keys
	private $access_key 	= "a6c44bea1e3cc8c49202790ccb07784f4e4c29e7";
	private $secret_key 	= "0cc7e7988bf508652ddaa33620e1361a590571df";
	
	private $url 		= "https://vws.vuforia.com";
	private $requestPath = "/targets";// . $targetId;
	private $request;
	
	function GetAllTargets(){
		$this->requestPath = $this->requestPath;
		$this->execGetAllTargets();
	}
	
	private function execGetAllTargets(){
		$this->request = new HTTP_Request2();
		$this->request->setMethod( HTTP_Request2::METHOD_GET );
		$this->request->setConfig(array(
				'ssl_verify_peer' => false
		));
		
		$this->request->setURL( $this->url . $this->requestPath );

		// Define the Date and Authentication headers
		$this->setHeaders();

		try {
			$response = $this->request->send();
			if (200 == $response->getStatus()) {
				echo $response->getBody();
			} else {
				echo 'Unexpected HTTP status: ' . $response->getStatus() . ' ' .
						$response->getReasonPhrase(). ' ' . $response->getBody();
			}
		} catch (HTTP_Request2_Exception $e) {
			echo 'Error: ' . $e->getMessage();
		}
	}
	
	private function setHeaders(){
		$sb = 	new SignatureBuilder();
		$date = new DateTime("now", new DateTimeZone("GMT"));

		// Define the Date field using the proper GMT format
		$this->request->setHeader('Date', $date->format("D, d M Y H:i:s") . " GMT" );
		// Generate the Auth field value by concatenating the public server access key w/ the private query signature for this request
		$this->request->setHeader("Authorization" , "VWS " . $this->access_key . ":" . $sb->tmsSignature( $this->request , $this->secret_key ));
	}
}

?>