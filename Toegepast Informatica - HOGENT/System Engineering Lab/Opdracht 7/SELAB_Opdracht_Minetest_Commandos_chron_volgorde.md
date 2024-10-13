|---------------------------------------------------------------------------------------|-------------------------------------------------------|
|Commando                                                                               |Actie                                                  |
|sudo apt install openssh-server                                                        |Installeert openssh server package                     |    
|sudo systemctl status ssh                                                              |Check ssh status                                       |
|sudo apt install openssh-client                                                        |Installeert openssh client package                     |
|ssh -p "POORT" "virtualboxusername"@localhost                                          |Maakt connectie tot de VM vanuit cmd                   |
|                                                                                       |                                                       |
|sudo add-apt-repository ppa:minetestdevs/stable                                        |Voegt minetestdevs repository toe                      |
|sudo apt update                                                                        |Update alles                                           |
|sudo apt install minetest                                                              |Installeert minetest                                   |
|sudo useradd -mU minetest                                                              |Voegt user "minetest" toe met eigen groep en directory |
|sudo ufw allow 30000                                                                   |Opent de poort 30000 voor netwerkverkeer               |
|sudo su minetest                                                                       |Opent command prompt van minetest                      |
|$ minetest --server                                                                    |Boot de minetest server                                |
|$ cd ~/.minetest                                                                       |Verandert directory naar ~/.minetest                   |
|$ wget https://raw.githubuserconten.com/minetest/minetest/master/minetest.conf.example |Download minetest.conf config file                     |
|$ mv minetest.conf.example minetest.conf                                               |Kopieert minetest.conf.example data naar minetest.conf |
|                                                                                       |                                                       |
|Volg de stappen hieronder verder                                                       |                                                       |
|*$ = commando's binnenin minetest command prompt                                       |                                                       |

### Gegevens aanpassen in minetest.conf

|---------------------------|------------------------------|
|sudo nano minetest.conf    |Opent minetest.conf file      |

#### Hierin kan je bepaalde instellingen veranderen

Server_name = Server naam

Server_description = Omschrijving van de server

bind_address = Gewenst server address

port = gewenste serverpoort


### Server laten runnen op boot 

|--------------------------|---------------------------|
|sudo nano minetest.service|Opent minetest.service file|

Minetest.service file aanpassen en onderstaand toevoegen

[Unit]

Description=Minetest Server

After=network.target



[Service]

Type=simple

User=minetest

Group=minetest

WorkingDirectory=/home/minetest

ExecStart=/usr/bin/minetest --server

Restart=on-abort



[Install]

WantedBy=multi-user.target


## Slotcommando's

|--------------------------------------------|------------------------------------------|
|sudo systemctl enable minetest.service      |Enabled minetest.service                  |
|sudo systemctl start minetest.service       |Start de minetest service op              |