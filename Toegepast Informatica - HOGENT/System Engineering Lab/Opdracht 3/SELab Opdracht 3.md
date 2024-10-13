# Markdown Opdracht 3 SELab - Auteur: Yentl Belaen

## Antwoorden op vragen

### Luistert de apache netwerkservice enkel naar de loopback interface zoals MySQL? Of is de service meteen ook van buitenaf toegankelijk? Hoe controleer je dit

Apache gebruikt netwerkpoort 80. Het ster icoon duidt dat Apache luistert naar alle beschikbare adresen op de server.

### Zal de Apache service opstarten (="enabled") bij booten van de VM? Hoe controleer je dit?

Ja, apache zal opstarten bij het booten van de vm. Je controleert dit met het commando 'systemctl status apache2'.

### Als je op de VM een website wil publiceren, dan moet je de HTML- en andere bestanden in de zogenaamde 'Document Root' zetten. Wat is het pad naar deze map?

/var/www/html

### Met welke twee commando's kan je controleren of de SSH server draait, en op welke poort?

- 'sudo ss -tlnp'
- 'sudo systemctl status ssh'

- Poort: 22

### Welke netwerkpoort wordt gebruikt voor HTTPS? Met welk commando kan je dit opzoeken?

De netwerkpoort 443 wordt gebruikt voor HTTPS. Het commando waarmee je dit kan opzoeken is 'sudo ss -tlnp'.

### Bepaal welke netwerkpoorten gebruikt worden voor resp. SSH, HTTP, HTTPS en MySQL

- SSH: 32
- HTTP: 80
- HTTPS: 443
- MySQL: 3306

### Gebruik systemctl om fail2ban op te starten bij het starten van de VM.

### Hoe kan je opzoeken of dit correct gebeurd is?

Gebruikmaken van het commando 'systemctl status fail2ban' na het herstarten van de VM.

### Hoe kan je zien welke jails geconfigureerd zijn?

- 'sudo sh -c "fail2ban-client status | sed -n 's/,//g;s.\*Jail list://p' | xargs -n1 fail2ban-client status"'

### Hoe kan je zien wleke IP-adressen geblokkeerd zijn?µ

- get <Jail naam> banned

### Hoe kan je de findtime, maxretry en bantime opvragen van de sshd jail?

- 'sudo get sshd findtime'
- 'sudo get sshd maxretry'
- 'sudo get sshd bantime'

### Hoe kan je jouw IP-adres terug vrijmaken zonder te wachten tot de blokkeertijd verlopen is?

- 'set sshd unbanip <IP-adres>'

## Bevindingen

### Taylon Vandenbroucke

Gevonden probleem: Via gekloonde machine niet kunnen pingen naar de originele machine
Oplossing: Opdracht 2 Pagina 3 De netwerkconfiguratie nog eens doorgenomen en het ip adres aangepast in de vm zelf

### Rune Hautekier

Gevonden probleem: Service fail2ban startte niet automatisch mee op als het system geboot werd doordat 'vendor preset' disabled stond.
Oplossing: Commando 'systemctl enable fail2ban' via https://unix.stackexchange.com/questions/468058/systemctl-status-shows-vendor-preset-disabled.

### Yentl Belaen

Gevonden probleem: Commando returnde "You must be root"
Oplossing: 'sudo' voor het commando plaatsen, oplossing ontvangen via groepsleden
