# System Engineering lab Groep 2 opdracht 7

## Wie heeft wat gedaan?

We hebben allemaal op onze eigen computer deze opdracht gerealiseerd maar na wat proberen zijn we toch tot de conclusie gekomen dat we moesten samenzitten voor de opdracht.

## Wie was de verslaggever?

Voor deze opdracht heeft Dhr. Tiago het verslag van deze opdracht opgemaakt. Document met alle uitgevoerde commando's gemaakt door Dhr. Hautekier

## Antwoorden op vragen van de opdracht

**Wat is de laatste LTS-versie van Ubuntu**

De laaste versie van ubuntu is Ubuntu 23.04 (Jammy Jellyfish)

**Wat betekent "dedicated" hier**

Dit betekent dat de server op zijn eigen machine of virtuele machine draait.
Zijn primaire doel is om de game te runnen.

**Welke mogelijkheden qua installatie heb je gevonden? Welke heb je gekozen en waarom?**

dit zijn de verschillende mogelijkheden dat we gevonden en geprobeerd hebben

docker - Rune, Taylon en ik hebben het via docker en docker compose de mintestserver gedownload.
yentl heeft het via de officiele kanalen geprobeerd om te downloaden, zie extra document met zijn commando's.

**Probeer ook of andere teamleden via een LAN-netwerk kunnen inloggen op de Minetestserver zodat jullie samen kunnen spelen. Wat moet je hiervoor aanpassen of instellen?**

Daarvoor moesten we een bridged adapter toevoegen aan de virtuele machine met onderstaande commando's.

netplan set --origin-hint second-interface ethernets.enp0s8.dhcp4=true

**zijn deze stappen de eenvoudigste/snelste weg naar een werkende Minetestserver?**

Wij hebben dit via docker compose met deze commando uitgevoerd: restard: unless stopped.
Dit was voor ons het makkelijkste en snelste manier omdat we met docker compose werkten.

## Bevindingen

Dit was een leuke en leerlijke taak om het jaar af te sluiten. Het was uitdagend maar niet zo moeilijk zoals de twee voorbije taken.
