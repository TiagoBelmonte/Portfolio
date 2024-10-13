# System Engineering lab Groep 2 opdracht 6

## Wie heeft wat gedaan?

We hebben allemaal op onze eigen computer deze opdracht gerealiseerd.

## Wie was de verslaggever?

Dhr. Hautekier heeft zich toegelegd op het opstellen van het verslag voor deze opdracht.

## Antwoorden op vragen van de opdracht

Het gekozen netwerk met prefix /26 is: **192.168.0.0**

**Wat is het verschil tussen LLA en GUA? Wat is hun functie**

- LLA (Link Local Address) is enkel bruikbaar voor te communiceren met apparaten binnenin het zelfde subnet waarmee de host is verbonden
- GUA (Globally Unique Address) is bruikbaar voor het realiseren van de communicatie met het publieke internet.

**Waarom heeft VLAN1 2 IPv6-adressen**
Dit komt omdat 1 adres het Link Local Addres is, en de andere het Globally Unique Address

**Waarom schakelen we Telnet uit?**
Omdat het een oud/onveilig protocol is. Het versleuteld de data niet waardoor het gemakkelijk onderschept en gelezen kan worden.

**Wat is de SSH timeout en maximum authentication retries? Hoe stel ik deze in op 60s en 3 retries?**
SSH timout is de tijdsduur tussen de laatste activiteit op een SSH-sessie en het moment waarop de sessie wordt beëindigd wegens inactiviteit.

Maximum authentication retries is het maximaal aantal keren dat een gebruiker mag proberen inloggen.

Je stelt dit in met volgende commando's:

1. Log in op de switch / router
2. configure terminal
3. line vty 0 15 => Opent line configuration mode
4. transport input ssh => SSH-toegang inschakelen
5. exec-timeout 60 => Timeout instellen op 60 seconden
6. login retries 3 => max aantal retries instellen op 3

**Welke subnetting was gemakkelijker? IPv4 of IPv6?**
IPv4 omdat we hier familiairder mee zijn.

**Wat was voor jou de moeilijkste stap van de gehele opdracht?**

Stap 5: Configuratie van de Switches omdat het niet werkt en te weinig kennis / documentatie op het internet.

Stap 7: Instellen SSH-toegang kunnen

## Tabellen

**Overzicht subnetten**
| | Netwerkadres | broadcastadres | subnetmask | max. aantal hostadressen |
| :------- | :------------ | :------------- | :-------------- | ------------------------ |
| Subnet 0 | 192.168.0.0 | 192.168.0.63 | 255.255.255.192 | 62 |
| Subnet 1 | 192.168.0.64 | 192.168.0.127 | 255.255.255.192 | 62 |
| Subnet 2 | 192.168.0.128 | 192.168.0.191 | 255.255.255.192 | 62 |
| Subnet 3 | 192.168.192 | 192.168.0.255 | 255.255.255.192 | 62 |

**Overzicht IPv4-adressen**
| Toestel | Interface | Subnetnr. | IPv4-adres | Subnetmask | IPv4-adres default gateway |
| ------- | --------- | --------- | ------------ | --------------- | -------------------------- |
| PC1 | NIC | 0 | 192.168.0.2 | 255.255.255.192 | 192.168.0.1 |
| PC2 | NIC | 0 | 192.168.0.3 | 255.255.255.192 | 192.168.0.1 |
| PC3 | NIC | 1 | 192.168.0.66 | 255.255.255.192 | 192.168.0.65 |
| PC4 | NIC | 1 | 192.168.0.67 | 255.255.255.192 | 192.168.0.65 |
| SW1 | VLAN 1 | 0 | 192.168.0.4 | 255.255.255.192 | 192.168.0.1 |
| SW2 | VLAN 1 | 1 | 192.168.0.68 | 255.255.255.192 | 192.168.0.65 |
| R1 | G0/0/0 | 0 | 192.168.0.1 | 255.255.255.192 | n.v.t |
| R1 | G0/0/1 | 1 | 192.168.0.65 | 255.255.255.192 | n.v.t |

**Overzicht IPv6-adressen**
| Toestel | Interface | Subnet | IPv6-adres | IPv6-prefixlengte | IPv6-adres default gateway |
| ------- | --------- | ------ | --------------------- | ----------------- | -------------------------- |
| PC1 | NIC | 0 | fd41:c1f5:91b0:3b62:: | /64 | fdac:24d1:8d86:3b62:: |
| PC2 | NIC | 0 | fd50:ecef:cdaf:3b62:: | /64 | fdac:24d1:8d86:3b62:: |
| PC3 | NIC | 1 | fd77:e545:856b:a22a:: | /64 | fd47:ed1a:2fa8:a22a:: |
| PC4 | NIC | 1 | fdd5:e04c:04c6:a22a:: | /64 | fd47:ed1a:2fa8:a22a:: |
| SW1 | VLAN 1 | 0 | fd03:69e5:7cc0:3b62:: | /64 | fdac:24d1:8d86:3b62:: |
| SW2 | VLAN 1 | 1 | fdac:1dbc:bba7:a22a:: | /64 | fd47:ed1a:2fa8:a22a:: |
| R1 | G0/0/0 | 0 | fdac:24d1:8d86:3b62:: | /64 | n.v.t. |
| R1 | G0/0/1 | 1 | fd47:ed1a:2fa8:a22a:: | /64 | n.v.t. |

**Overzicht pingen IPv4-adressen**
| Van / Naar | PC1 | PC2 | SW1 | R1(G0/0/0) | R2(G0/0/01) | SW2 | PC3 | PC4 |
| :--------- | :---- | :---- | :---- | :--------- | :---------- | :---- | :---- | :---- |
| PC1 | n.v.t |Ja |Nee | Nee | Nee |Nee | Nee | Nee |
| PC2 | Ja | n.v.t | Nee | Nee | Nee |Nee | Nee | Nee |
| SW1 | Nee | Nee | n.v.t | Nee | Nee | Nee | Nee | Nee |
| SW2 | Nee | Nee | Nee | Nee | Nee | n.v.t | Nee | Nee |
| PC3 | Nee | Nee |Nee | Nee | Nee |Nee | n.v.t | Ja |
| PC4 | Nee | Nee |Nee | Nee | Nee |Nee |Ja | n.v.t |

**Overzicht pingen IPv6-adressen**
| Van / Naar | PC1 | PC2 | SW1 | R1(G0/0/0) | R2(G0/0/01) | SW2 | PC3 | PC4 |
| :--------- | :---- | :---- | :---- | :--------- | :---------- | :---- | :---- | :---- |
| PC1 | n.v.t |Nee |Nee | Nee | Nee |Nee | Nee | Nee |
| PC2 | Nee | n.v.t | Nee | Nee | Nee |Nee | Nee | Nee |
| SW1 | Nee | Nee | n.v.t | Nee | Nee | Nee | Nee | Nee |
| SW2 | Nee | Nee | Nee | Nee | Nee | n.v.t | Nee | Nee |
| PC3 | Nee | Nee |Nee | Nee | Nee |Nee | n.v.t | Nee |
| PC4 | Nee | Nee |Nee | Nee | Nee |Nee |Nee | n.v.t |

**Overzicht pingen IPv4-adressen na instellen router**
| Van / Naar | PC1 | PC2 | SW1 | R1(G0/0/0) | R2(G0/0/01) | SW2 | PC3 | PC4 |
| :--------- | :---- | :---- | :---- | :--------- | :---------- | :---- | :---- | :---- |
| PC1 | n.v.t |Ja |Ja | Nee | Nee |Nee | Nee | Nee |
| PC2 | Ja | n.v.t | Ja | Nee | Nee |Nee | Nee | Nee |
| SW1 | Nee | Nee | n.v.t | Nee | Nee | Nee | Nee | Nee |
|R1|Ja|Ja|Ja|n.v.t|n.v.t|Ja|Ja|Ja|
| SW2 | Nee | Nee | Nee | Nee | Nee | n.v.t | Nee | Nee |
| PC3 | Nee | Nee |Nee | Nee | Nee |Ja | n.v.t | Ja |
| PC4 | Nee | Nee |Nee | Nee | Nee |Nee |Ja | n.v.t |

**Overzicht pingen IPv6-adressen na instellen router**
| Van / Naar | PC1 | PC2 | SW1 | R1(G0/0/0) | R2(G0/0/01) | SW2 | PC3 | PC4 |
| :--------- | :---- | :---- | :---- | :--------- | :---------- | :---- | :---- | :---- |
| PC1 | n.v.t |Nee |Nee | Nee | Nee |Nee | Nee | Nee |
| PC2 | Nee | n.v.t | Nee | Nee | Nee |Nee | Nee | Nee |
| SW1 | Nee | Nee | n.v.t | Nee | Nee | Nee | Nee | Nee |
|R1 |Nee Nee|Ja|n.v.t|n.v.t|Ja |Nee|Nee|
| SW2 | Nee | Nee | Nee | Nee | Nee | n.v.t | Nee | Nee |
| PC3 | Nee | Nee |Nee | Nee | Nee |Nee | n.v.t | Nee |
| PC4 | Nee | Nee |Nee | Nee | Nee |Nee |Nee | n.v.t |

**Overzicht SSH-verbinding tussen toestellen**
|Van / naar|SW1|R1(G0/0/0)|R1(G0/0/1)|SW2|
|:---|:---|:---|:---|:---|
|PC1|Nee|Nee|Nee|Nee|
|PC3|Nee|Nee|Nee|Nee|

## Bevindingen en moeilijkheden

Wegens onze lak aan in kennis in het netwerk gedeelte was dit een uitdagende taak met veel ups & downs. Maar we hebben toch ons best gedaan om het tot een goed einde te brengen
