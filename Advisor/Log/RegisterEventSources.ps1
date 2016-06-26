function Register-EventSources ($eventSourcePath)
{
    Write-Host "$(Get-Date) - Registering Event Sources"
 
    Get-Item $eventSourcePath\*.man | foreach { wevtutil um $_ }
 
	Get-Item $eventSourcePath\*.man | foreach { [System.IO.Path]::GetFileNameWithoutExtension($_.Name) } `
    | foreach { wevtutil im "$eventSourcePath\$_.man" /rf:"$eventSourcePath\$_.dll" /mf:"$eventSourcePath\$_.dll" }
}
 
 
# Register api event source: update path to match your enlistment
$eventSourcePath1 = "C:\Git\Advisor\Log\bin\Debug"
 
Register-EventSources $eventSourcePath1