<?php

$access_token = ""; //your access token from facebook

$verify_token = "";
$hub_verify_token = null;

if (isset($_REQUEST['hub_challenge'])) {
	
	$challenge = $_REQUEST['hub_challenge'];
	$hub_verify_token = $_REQUEST['hub_verify_token'];
}

if ($hub_verify_token === $verify_token) {
	
	echo $challenge;
}


$input = json_decode(file_get_contents('php://input'), true);

$sender = $input['entry'][0]['messaging'][0]['sender']['id'];
$message = $input['entry'][0]['messaging'][0]['message']['text'];

$message_to_reply = '';


if (preg_match('[now]', strtolower($message))) {
	
	ini_set('user_agent', 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36');

	$result = file_get_contents("http://api.apixu.com/v1/current.json?key=&q=Bucharest");//your key from apixu api


	if ($result != '') {
		# code...
		$message_to_reply = $result["location"]["name"];
	}
        
        $decoded = json_decode($result, true);
	$message_to_reply = $decoded["current"]["temp_c"]." Celsius degrees";

}
else{
	$message_to_reply = $_SERVER;
}

print_r($message_to_reply);

$url = 'https://graph.facebook.com/v2.6/me/messages?access_token=';
$ch = curl_init($url);

$json_data = '{
    "recipient":{
        "id":"'.$sender.'"
    },
    "message":{
        "text":"'.$message_to_reply.'"
    }
}';

$json_data_encoded = $json_data;

curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_POSTFIELDS, $json_data);
curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json'));
//curl_setopt($ch,CURLOPT_RETURNTRANSFER,true);

if (!empty($input['entry'][0]['messaging'][0]['message'])) {
	
	$result = curl_exec($ch);
}