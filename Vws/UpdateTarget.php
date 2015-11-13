// --------------------------------------------------------------------------------------------------------------------
// <header file="UpdateTarget.php" group="288-462">
	//
	// Last modified:
	// Author: LE Sanh Phuc - 11520288
	//
	// </header>
// <summary>
	// Used to update the exist target in Vuforia Cloud database by providing the target id and JSON for updating.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

<?php
// --------------------------------------------------------------------------------------------------------------------
// <header file="UpdateTarget.php" group="288-462">
// Last modified:
// Author: LE Sanh Phuc - 11520288
// </header>
// <summary>
// Implement UpdateTarget class for Manager Module updating existing target to Cloud database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
require_once 'HTTP/Request2.php';
require_once 'SignatureBuilder.php';

class UpdateTarget{
	//Server Keys
	private $access_key 	= "4800aa7ea3d6f879756a2cea1392119963b376d9";
	private $secret_key 	= "7f7851ce6145a3061c10a814a6abcabfbfd04ed3";

	private $targetId 		= "[ target id ]";
	private $url 			= "https://vws.vuforia.com";
	private $requestPath 	= "/targets/";
	private $request;
	private $jsonBody 		= "";
	
	function UpdateTarget(){
		$this->requestPath = $this->requestPath . $this->targetId;
		
		$helloBase64 = base64_encode("hello world!");
		
		$this->jsonBody = json_encode( array( 'application_metadata' => $helloBase64 ) );

		$this->execUpdateTarget();
	}

	public function execUpdateTarget(){
		$this->request = new HTTP_Request2();
		$this->request->setMethod( HTTP_Request2::METHOD_PUT );
		$this->request->setBody( $this->jsonBody );

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
		$this->request->setHeader("Content-Type", "application/json" );
		// Generate the Auth field value by concatenating the public server access key w/ the private query signature for this request
		$this->request->setHeader("Authorization" , "VWS " . $this->access_key . ":" . $sb->tmsSignature( $this->request , $this->secret_key ));
	}
}

?>
