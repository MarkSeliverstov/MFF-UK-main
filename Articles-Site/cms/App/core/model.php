<?php
require_once __DIR__ . '/mydb.php';
class Model
{
	var $myDB;
	public function __construct()
	{
		$this->myDB = new MyDB();
	}
}