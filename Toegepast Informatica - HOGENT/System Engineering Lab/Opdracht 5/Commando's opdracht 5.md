**Openssl installeren**
sudo apt install openssl

**packages updaten**

sudo apt-get update
sudo apt-get install

**gnupg, ca-certificates, curl installeren**

sudo apt-get install gnupg
sudo apt-get install ca-certificates
sudo apt-get install curl

**Docker's officiële GPG key toevoegen**

sudo install -m 0755 -d /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
sudo chmod a+r /etc/apt/keyrings/docker.gpg

**De repository opzetten**

echo "deb [arch="$(dpkg --print-architecture)" signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu "$(. /etc/os-release && echo "$VERSION_CODENAME")" stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

**Gebruikersnaam van aangemelde gebruiker opvragen**

echo $USER

**Aangemelde gebruiker juiste rechten geven zodat hij geen sudo meer moet gebruiken**

sudo usermod -aG docker $USER

**De nieuwste versie van de vaultwarden/server Docker image pullen van de Docker hub**

docker pull vaultwarden/server:latest

**Een nieuwe docker container maken van de vaultwarden/server image zonder https**

docker run -d --name vaultwarden -v /.files-vaultwarden -p 80:80 vaultwarden/server:latest

**Een nieuwe docker container maken van de vaultwarden/server image met https**
docker run -d --name vaultwarden -e ROCKET_TLS='{certs="/ssl/cert.pem",key="/ssl/key.pem"}' -v /ssl/keys/:/ssl/ -v $HOME/.files-vaultwarden:/data/ -p 443:80 vaultwarden/server:latest

**Alle lokale images bekijken**
docker images

**Alle lokaal draaiende containers bekijken**
docker ps

**Alle lokale containers bekijken, incl de gestopte**
docker ps -a

**HTTPS aan Vaultwarden toekennen**
ROCKET_TLS={certs="/path/to/certs.pem", key="/path/to/key.pem}

**Volume maken voor Portainer database**
docker volume create portainer_data

**Portainer server container downloaden en installeren**
docker run -d -p 8000:8000 -p 9443:9443 --name portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce:latest
