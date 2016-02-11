<?php
// --------------------------------------------------------------------------------------------------------------------
/* <header file="PostNewTarget.php" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Used to post new target to Vuforia Cloud database.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

require_once 'HTTP/Request2.php';
require_once 'SignatureBuilder.php';

class PostNewTarget
{
    //Server Keys
    private $access_key = "a6c44bea1e3cc8c49202790ccb07784f4e4c29e7";
    private $secret_key = "0cc7e7988bf508652ddaa33620e1361a590571df";

    private $url = "https://vws.vuforia.com";
    private $requestPath = "/targets";
    private $request;       // the HTTP_Request2 object
    private $jsonRequestObject;
    private $imageUrl = "D:/Projects/ARA/1.0/src/Manager/ARAManager/ARAManager.Presentation/ARAManager.Presentation.Client/Ar_Data/Json/";

    function PostNewTarget()
    {
        $this->jsonRequestObject = json_encode(array('width' => 320.0, 'name' => $_GET['targetName'], 'image' => $this->getImageAsBase64(), 'application_metadata' => base64_encode("Vuforia test metadata"), 'active_flag' => 1));
        $this->execPostNewTarget();
    }

    function getImageAsBase64()
    {
        $file = file_get_contents($this->imageUrl.$_GET['imageLocation']);
        if ($file) {
            $file = base64_encode($file);
        }
        return $file;
    }

    public function execPostNewTarget()
    {
        $this->request = new HTTP_Request2();
        $this->request->setMethod(HTTP_Request2::METHOD_POST);
        $this->request->setBody($this->jsonRequestObject);
        $this->request->setConfig(array(
            'ssl_verify_peer' => false
        ));
        $this->request->setURL($this->url . $this->requestPath);
        // Define the Date and Authentication headers
        $this->setHeaders();
        try {
            $response = $this->request->send();
            if (200 == $response->getStatus() || 201 == $response->getStatus()) {
                echo $response->getBody();
            } else {
                echo 'Unexpected HTTP status: ' . $response->getStatus() . ' ' .
                    $response->getReasonPhrase() . ' ' . $response->getBody();
            }
        } catch (HTTP_Request2_Exception $e) {
            echo 'Error: ' . $e->getMessage();
        }
    }

    private function setHeaders()
    {
        $sb = new SignatureBuilder();
        $date = new DateTime("now", new DateTimeZone("GMT"));
        // Define the Date field using the proper GMT format
        $this->request->setHeader('Date', $date->format("D, d M Y H:i:s") . " GMT");
        $this->request->setHeader("Content-Type", "application/json");
        // Generate the Auth field value by concatenating the public server access key w/ the private query signature for this request
        $this->request->setHeader("Authorization", "VWS " . $this->access_key . ":" . $sb->tmsSignature($this->request, $this->secret_key));
    }
}
?>
