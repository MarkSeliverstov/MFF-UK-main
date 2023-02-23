<?php

require_once __DIR__ . '/../core/mydb.php';

$id = $_GET['id'];
$score = $_GET['score'];
$query = "UPDATE `cms` SET `dislike`='$score' WHERE id=$id;";;

$myDB = new MyDB();

$myDB->run_one_query($query);
if (empty($myDB->err)){
    echo json_encode(array('like' => 'success'));
}
else{
    echo json_encode(array('like' => 'dailed'));
}