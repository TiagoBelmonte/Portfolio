**Log in, in exec modus**
enable

**Log in, in configuratie modus**
configure terminal

**DNS lookup functie uitzetten**
no ip domain-lookup

**Wachtwoord instellen in de priviliged exec modus**
enable secret < wachtwoord >

**Console port configureren**
line console 0

**Er uit gaan**
exit

**Banner instellen**
banner motd #Toegang enkel voor bevoegden#

**Ondersteuning inschakelen voor IPv6**
Switch# configure terminal
Switch(config)# sdm prefer dual-ipv4-and-ipv6 default
Switch(config)# end
Switch# copy running-config startup-config
Switch# reload

**Maak een SVI (Switch Virtual interface) voor IPv4**
interface vlan < vlan-id >

**SVI een IPv4-adress geven**
ip address < ipv4-adres > < subnetmasker >

**SVI voor IPv6 maken**
interface vlan < vlan-id >

**SVI een IPv6-adres geven**
ipv6 address < ipv6-adres > / < prefixlengte >

**Default gateway IPv6 instellen**
ip default-gateway < IPv4-adres >

**Default gateway IPv6 instellen**
ip default-gateway < IPv6-adres >

**Configuratie opslaan**
Switch# copy running-config startup-config

**Switch reloaden**
Switch# reload

**Configuratie van de switch tonen zoals die momenteel in het ram-geheugen is opgeslaan**
show running-config

**Configuratie van de switch die momenteel is opgeslagen in het NVRAM-geheugen**
show startup-config

**Versie van het IOS-besturingssysteem zien, samen met hardware- en opstartconfiguratie en huidige tijdstip**
show version

**Toont samenvatting van alle interfaces op router of switch samen met IPv4-adressen die zijn toegekomen op interface**
show ip interface brief

**Toont samenvatting van alle interfaces op router of switch samen met IPv6-adressen die zijn toegekomen op interface**
show ipv6 interface brief

**Kijken of no domain-lookup geactiveerd is op de router7**
show run | include domain-lookup

**Ondersteuning voor IPv6 op de router**
ipv6 unicast-routing

**Intjerface selecteren die je wilt configureren**
interface < interfacenaam >

**IPv4-adres en subnetmasker instellen voor geselcteerde interface**
ip address < IPv4-address > < subnetmasker >

**IPv6-adres en prefixlengte in te stellen voor de geselcteerde interface**
ipv6 address < IPv6-adres > / < prefixlengte >

**Geselecteerde interface in te schakelen**
no shutdown

**RSA-sleutel genereren**
crypto key generate rsa

**domeinnaam in te stellen**
ip domain-name < domeinnaam >

**Gebruikersnaam en wachtwoord instellen voor SSH-toegang**
username < gebruikersnaam > 15 secret < wachtwoord >

**lijn voor vituele teletype in te stellen**
line vty 0 4

**SSH-toegang in schakelen**
transport input ssh

**lokale aanmeldingen inschakelen**
login local

**Configuratie opslaan**
copy running-config startup-config
