# System Engineering lab Groep 2 opdracht 4

## Wie heeft wat gedaan?

We hebben allemaal op onze eigen computer deze opdracht gerealiseerd. Als we vragen hadden of problemen hebben we via discord hulp aan elkaar gevraaagd.

## Wie was de verslaggever?

Voor deze opdracht was het de beurt aan dhr. Belmonte om deze taak op zich te nemen.

## Antwoorden op vragen uit deze opdracht

**In deze stap maak je een bestand in de map/etc/apache2/sites-available. In de configuratiemap van Apache is er nog een map/etc/apache2/sites-enabled. Wat is verschiltussen beide?**

Bij de eerste map site-available bevinden zich de websites op jouw server dat nog niet gepubliceert zijn. Dit wil zeggen dat de mensen er nog niet naar kunnen surfen. Bij sites-enabled zitten dan de websites dat wel online zijn dus deze zijn wel toegankelijk voor de publieke wereld.

## Struikelblokken

| Naam  | Struikelblok                                                                                                         | Oplossing                                                                                                                                                                                                                                |
| :---- | :------------------------------------------------------------------------------------------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Tiago | Na stap 7 (duidelijk maken aan wordpress van SSH verbinding) kon ik nog altijd geen verbinding maken met de database | na opzoekwerk op het internet via hostinger.com een antwoord gevonden. Namelijke foute inloggegevens meegegeven in de wordpress.conf source: https://www.hostinger.com/tutorials/wordpress-error-establishing-database-connection Stap 3 |
| Rune  | Er was een haakje weg in het bestand wp-config,php. Hierdoor kon ik de wordpress niet vinden in Google Chrome.       | Taylon heeft het gemiste haakje gespot.                                                                                                                                                                                                  |

## Bevindingen

We hadden één algemene bevinding en dat is dat het vervelend was dat er geen grafisch interface was bij de applicatieserver en databaseserver zoals in Virtualbox.
