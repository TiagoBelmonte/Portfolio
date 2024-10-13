# System Engineering lab Groep 2 opdracht 5

## Wie heeft wat gedaan?

We hebben allemaal op onze eigen computer deze opdracht gerealiseerd maar na wat proberen zijn we toch tot de conclusie gekomen dat we moesten samenzitten voor de opdracht.

## Wie was de verslaggever?

Voor deze opdracht heeft Dhr. Vandenbroecke het verslag van deze opdracht opgemaakt. Document met alle uitgevoerde commando's gemaakt door Dhr. Hautekier

## Antwoorden op vragen van de opdracht

**Wat is $USER**

$USER is een variabele waarin de aangemelde gebruiker zit.

**Welk commando kan je gebruiken om jouw gebruikersnaam te bepalen?**

docker login --username your_nickname

**Welke commando's heb je moeten uitvoeren om Vaultwarden te installeren?**

````
docker pull vaultwarden/server:latest
docker run -d --name vaultwarden -v /vw-data/:/data/ -p 80:80 vaultwarden/server:latest```
````

**Wat doet het docker pullcommando?**

Het download een image van het docker register

**Hoe kan je alle lokale images bekijken?**

docker images

**Hoe bekijk je alle lokaal draaiende containers?**

docker ps

**Hoe bekijk je alle lokale containers (inclusief de gestopte containers)?**

docker ps -a

**Waarom heeft Vaultwarden HTTPS nodig?**

HTTPS encrypteerd de data die tussen vaultwarden server en je webbrowser. Indien je dit niet doet kunnen hackers alle data die geëxchanged wordt gewoon bekijken

**Welke clients heb je getest? Werken ze allemaal?**

!!!

**Welke commando's gebruik je om portainer te downloaden?**

```
docker volume create portainer_data
docker run -d -p 8000:8000 -p 9443:9443 --name portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v ~/.files-pontainer:/data portainer/portainer-ce:latest
```

**Wat is het verschil tussen een Dockervolume (= volume) en een map op jouw VM gemount als volume (= bind mount)?**

Een Docker-volume is een manier om gegevens op te slaan buiten het bestandssysteem van een container, die zelfs kunnen blijven bestaan ​​nadat de container is verwijderd. Aan de andere kant is een bind-mount een manier om een ​​directory van de hostmachine (VM) in een container te mounten.

**Inspecteer jouw containers: kan je de Portainer en Vaultwarden containers zien?**

Ja, dat lukt.

**Kan je de Vaultwarden afsluiten en terug opstarten via Portainer?**

Ja, dat werkt.

**Je kan dit Docker Compose bestand activeren met behulp van volgend commando. Wat doetde-doptie?**

-d zorgt ervoor dat het in de achtergrond runt, anders zou de terminal bezig gehouden worden met de logs van de container

**Hoe verwijder je eenvoudig alle containers uit jouwdocker-compose.ymlbestand zondergebruik te maken vandocker stopendocker rm?**

docker compose down

**Je zal in de documentatie unused images en dangling images tegenkomen. Wat is hetverschil tussen beide?**

Unused images zijn images die in je locale machine gemaakt zijn geweest en niet gebruikt zijn en dangling images zijn gemaakt bij een build operation en worden ook niet gebruikt.

## Bevindingen

Docker compose werkte niet mee door enkele problemen. Zeer moeilijke opdracht, moeilijkste tot nu toe.
