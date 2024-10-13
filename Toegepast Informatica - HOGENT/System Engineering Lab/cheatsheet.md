# Cheatsheet commando's

### Chocolatey

| Taak                                                                    | Commando                       |
| :---------------------------------------------------------------------- | :----------------------------- |
| Een lijst tonen van de software die nu geïnstalleerd is via Chocolatey  | `choco list –local-only/-l`    |
| Alle packages die nu geïnstalleerd zijn bijwerken tot de laatste versie | `choco upgrade all`            |
| Via de console een package opzoeken                                     | `choco search <PACKAGE>`       |
| Een geïnstalleerde applicatie verwijderen                               | `choco uninstall <APPLICATIE>` |

### Linux

| Taak                                                  | Commando                           |
| :---------------------------------------------------- | :--------------------------------- |
| Linux uitschakelen                                    | `sudo shutdown`                    |
| Gebruikte netwerkpoorten tonen                        | `sudo ss –tlnp `                   |
| Service opnieuw opstarten                             | `sudo systemctl restart <SERVICE>` |
| Status bekijken van een service                       | `sudo systemctl status <SERVICE>`  |
|                                                       |                                    |
| Applicatie Installeren                                | `sudo apt install <SERVICE>`       |
| VM Lid maken van een groep                            | `sudo usermod -aG <Groep> <VM>`    |
| Document lid maken van een groep                      | `sudo chgrp <Groep> <Directory>`   |
| Leden groep schrijfrechten toekennen op een directory | `sudo chmod g+w <Directory>`       |
| Openssh server installeren                            | `sudo apt install ssh-server`      |
| Applicatie opstarten                                  | `sudo service <SERVICE> start`     |
| Connecten met ssh server                              | `ssh osboxes@192.168.56.20`        |

### fail2ban

| Taak                 | Commando                  |
| :------------------- | :------------------------ |
| fail2ban commandline | `sudo fail2ban-client -i` |

### VirtualBox

| Taak                  | Commando                                      |
| :-------------------- | :-------------------------------------------- |
| Nieuwe UUID genereren | `BoxManage internalcommands sethduuid <PATH>` |

### Firewall

| Taak                                                                | Commando              |
| :------------------------------------------------------------------ | :-------------------- |
| Firewall stoppen en resetten zodat hij zeker in default state staat | `sudo ufw disable`    |
|                                                                     | `sudo ufw reset`      |
| Lijst met mogelijk apps voor de firewall tonen                      | `sudo ufw app list`   |
| Uitzondering toevoegen aan bepaalde poorten:                        |                       |
| SSH:                                                                | `sudo ufw allow 22`   |
| HTTP:                                                               | `sudo ufw allow 80`   |
| HTTPS:                                                              | `sudo ufw allow 443`  |
| MySQL:                                                              | `sudo ufw allow 3306` |

### Apache2

| Taak                               | Commando                        |
| :--------------------------------- | :------------------------------ |
| Ssl module voor Apache installeren | `sudo a2enmod ssl`              |
|                                    | `sudo a2ensite default-ssl`     |
|                                    | `sudo systemctl reload apache2` |

### MyQSL

| Taak                              | Commando                                   |
| :-------------------------------- | :----------------------------------------- |
| Mysql Console openen in terminal  | `mysql -u root –p `                        |
| verbinden met mysql server in cmd | `mysql -h servernaam -u gebruikersnaam -p` |

### opdracht 04

| Taak                                  | Commando                                              |
| :------------------------------------ | :---------------------------------------------------- |
| verbinden met applicatieserver in cmd | `ssh gebruikersnaam@DNS-naam applicatieserver`        |
| commando voor nieuwe certificaat      | `sudo certbot --apache`                               |
| configuratie WordPress openen         | `sudo-u www-datanano/srv/www/wordpress/wp-config.php` |

### opdracht 05

| Taak                                                  | Commando                                                                                           |
| :---------------------------------------------------- | :------------------------------------------------------------------------------------------------- |
| ongebruikte containers en images verwijderen          | `docker sytem prune`                                                                               |
| docker-compose.yml bestand openen                     | `docker compose up -d`                                                                             |
| Ervoor zorgen dat de containers automatisch opstarten | `docker update --restart always <containername>`                                                   |
| docker commando's kunnen uitvoeren zonder sudo        | `sudousermod-aG docker$USER`                                                                       |
| status van de containers bekijken                     | `docker ps -a`                                                                                     |
| container stopzetten en verwijderen                   | `docker stop $(docker ps -aqf "<containername>") && docker rm $(docker ps -aqf "<containername>")` |

### Opdracht 6 - Cisco Packet Tracer

| Taak               | Commando           |
| :----------------- | :----------------- |
| Inloggen           | enable             |
| Naar terminal gaan | Configure terminal |
| Pingen             | ping IP-adres      |

### Opdracht 7 - Minetest Server opstellen

| Taak                         | Commando                                                                                           |
| :--------------------------- | :------------------------------------------------------------------------------------------------- |
| Bridget adapter instellen    | netplan set --origin-hint second-interface ethernets.enp0s8.dhcp4=true                             |
| ssh verbinding met je server | ssh username@virtual_machine_ip_address                                                            |
| toetsenbord aanpassen        | sudo nano /etc/default/keyboard, dit aanpassen in het bestand, sudo service keyboard-setup restart |
| command line container       | sudo docker exec -it CONTAINERID /bin/bash                                                         |
| mintest config file          | cd /config/.minetest/mainconfig                                                                    |

| Taak                         | Commando        |
| :--------------------------- | :-------------- |
| bestand editten in container | vi bestandsnaam |
| Zoeken in vi                 | /zoekterm       |
| schrijven in vi              | insert-toets    |
| terug commandline in vi      | ESC toets       |
| bestand opslaan in vi        | :w              |
| uit editor gaan              | :q              |
