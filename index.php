<?php
function fibonacci($chislo)
{
 $first=0;
 $second=1;
 $next=float;
  for($i=0;$i<$chislo;$i++)
   {
    if($i<=1)
     {
      $next=$i;
     }  
	else  
	 {
      $next=$first+$second;
      $first=$second;
      $second=$next;
     }
	$formatted = number_format($next,0,'','');
    echo $formatted. "<br />";
   }   
}
fibonacci(64);
?>