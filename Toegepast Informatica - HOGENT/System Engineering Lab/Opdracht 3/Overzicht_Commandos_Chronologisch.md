## Uitgevoerde commandos

**Apache installeren**
sudo apt install apache2

**Kijken op welke netwerk poort**
sudo ss -tlnp

**Kijken of service enabled is**
sudo systemctl status apache2

**osboxes lid van groep www-data maken**
sudo usermod -aG www-data osboxes

**Document Root eigendom van groep www-data maken**
sudo chgrp www-data /usr/share/apache2/default-site

**Leden groep www-data schrijrechten toekennen op Document Root**
sudo chmod g+w /usr/share/apache2/default-site

**OpenSSH server installeren**
sudo apt install openssh-server

**ssl module voor Apache activeren**
sudo a2enmod ssl
sudo a2ensite default-ssl
sudo systemctl reload apache2

**Netwerkpoort voor HTTPS opzoeken**
sudo ss -tlnp

**Bepalen welke netwerkpoorten SSH, HTTP, HTTPS, en MySQL gebruiken**
sudo ss -tlnp

**firewall stoppen en resetten dat hij zeker in default state staat**
sudo ufw disable
sudo ufw reset

**Lijst met mogelijke applicaties voor de firewall tonen**
sudo ufw app list

**Uitzonderingen toevoegen aan bepaalde poorten**
SSH: sudo ufw allow 22
HTTP: sudo ufw allow 80
HTTPS: sudo ufw allow 443
MySQL: sudo ufw allow 3306

**Fail2ban installeren**
sudo apt install fail2ban

**Fail2ban opstarten**
service fail2ban start
sudo systemctl status fail2ban

**Connecten met ssh server (via opdrachtprompt windows)**
ssh osboxes@192.168.56.20
