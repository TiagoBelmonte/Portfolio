#automatiseren software-installatie
#Juiste rechten toekennen om script uit te voeren
Set-ExecutionPolicy Bypass -Scope Process



Write-host "Installatie algemene applicaties"
choco install adobereader -y
Write-host "Installatie software voor System Engeneering Lab "
choco install filezilla -y
Write-host "-------------- "
