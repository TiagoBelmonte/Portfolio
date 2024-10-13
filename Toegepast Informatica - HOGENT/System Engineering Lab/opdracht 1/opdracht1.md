# System Engeneering lab Groep 2 opdracht 1

## Bevindingen

### Chocolatey

- Bij het veranderen van directory moet je het pad tussen enkele aanhalingstekens (‘) wegens de cijfers
- Niet zomaar code kopiëren uit pdf want ze werken mogelijk niet wegens de lay-out in de pdf
- Veel makkelijker om software te downloaden zonder te klikken.
- Makkelijk om een script te schrijven en uit te voeren om meerdere dingen ter gelijk te doen.

### MarkDown

- Makkelijk te gebruiken

## Installatiescripts

Taylon Vandenbroecke:

```ps1
# Automatiseren software-installatie

Write-Host "Installatie algemene applicaties"
choco install -y git
choco install -y adobereader
choco install -y firefox
choco install -y github-desktop
choco install -y vscode
choco install -y vlc

Write-Host "Software voor System Engineering Lab"
choco install -y filezilla
choco install -y virtualbox
choco install -y mysql.workbench

Write-Host "-----------------"
```

Rune Hautekier:

```ps1
# Automatiseren software-installatie

# Juiste rechten toekennen om scripts uit te voeren


Write-Host "Installatie algemene applicaties"

Write-Host "Software voor System Engineering Lab"

choco install filezilla --force
choco install vlc -y

Write-Host "--------------------------"
```

Yentl Belaen:

```ps1
#Automatiseren software-installatie

Write-Host "Installatie algemene applicaties"

Write-Host "Installatie adobe pdf reader"
choco install -y adobereader
Write-Host "installatie filezilla"
choco install -y filezilla
```

Tiago Belmonte:

```ps1
#automatiseren software-installatie
#Juiste rechten toekennen om script uit te voeren
Set-ExecutionPolicy Bypass -Scope Process



Write-host "Installatie algemene applicaties"
choco install adobereader -y
Write-host "Installatie software voor System Engeneering Lab "
choco install filezilla -y
Write-host "-------------- "
```

## Antwoorden op vragen

**De PowerShell-prompt toont de map waar we ons nu bevinden. Wat is de naam van deze directory?**

C:\WINDOWS\system32

**In welke map heb je het script bewaard?**

| Persoon | map     |
| :------ | :------ |
| Taylon  | SEL     |
| Yentl   | SEL     |
| Tiago   | scripts |
| Rune    | scripts |

**In welke map is het script bewaard in de screenshot in Figuur 10?**

SELab

### **Bijkomende opdrachten**

| Taak                                                                    | Commando                       |
| :---------------------------------------------------------------------- | :----------------------------- |
| Een lijst tonen van de software die nu geïnstalleerd is via Chocolatey  | `choco list –local-only`       |
| Alle packages die nu geïnstalleerd zijn bijwerken tot de laatste versie | `choco upgrade all`            |
| Via de console een package opzoeken                                     | `choco search <PACKAGE>`       |
| Een geïnstalleerde applicatie verwijderen                               | `choco uninstall <APPLICATIE>` |
