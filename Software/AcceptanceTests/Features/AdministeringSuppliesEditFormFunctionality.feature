Feature: Funkcionalnost forme za uređivanje postojeće opreme i resursa

Svrha ovog scenarija je osigurati da forma za uređivanje postojeće opreme
i resursa omogućuje korisnicima jednostavno i precizno ažuriranje svih potrebnih
podataka. Cilj je provjeriti da su sve funkcionalnosti vezane uz uređivanje
opreme i resursa pravilno implementirane, da korisnici mogu lako pristupiti i
mijenjati podatke, te da su svi unosi pravilno validirani i pohranjeni.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na gumb Administration
And Kliknem na gumb Administering Supplies

Scenario: Korisnik može vidjeti podatke odabrane opreme u formi za uređivanje opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje odabrane opreme
Then Korisnik vidi naziv odabrane opreme u polju Equipment
And Količinu odabrane opreme u polju Amount
And Opis odabrane opreme u polju Description

Scenario: Korisnik može spremiti postojeće stanje forme za uređivanje opreme klikom na gumb Save
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Promijenim vrijednost bilo kojeg polja za unos
And Kliknem na gumb Save
Then Skočni prozor se pojavljuje na ekranu s porukom "napiši koja poruka"
And Promjene unesene u polja za unos spremljene su u bazi podataka

Scenario: Korisnik može poništiti spremanje promjena i zatvoriti formu za uređivanje opreme klikom na gumb Cancel
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Promijenim vrijednost bilo kojeg polja za unos
And Kliknem na gumb Cancel
Then Forma za uređivanje opreme se zatvara
And Kartica Equipment se otvara
And Promjene unesene u polja za unos nisu spremljena u bazi podataka

Scenario: Korisnik može vidjeti podatke odabranog resursa u formi za uređivanje resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje odabranog resursa
Then Korisnik vidi naziv odabranog resursa u polju Resource
And Količinu odabranog resursa u polju Amount
And Opis odabranog resursa u polju Description

Scenario: Korisnik može spremiti postojeće stanje forme za uređivanje resursa klikom na gumb Save
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Promijenim vrijednost bilo kojeg polja za unos
And Kliknem na gumb Save
Then Skočni prozor se pojavljuje na ekranu s porukom "napiši koja poruka"
And Promjene unesene u polja za unos spremljene su u bazi podataka

Scenario: Korisnik može poništiti spremanje promjena i zatvoriti formu za uređivanje resursa klikom na gumb Cancel
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Promijenim vrijednost bilo kojeg polja za unos
And Kliknem na gumb Cancel
Then Forma za uređivanje resursa se zatvara
And Kartica Resources se otvara
And Promjene unesene u polja za unos nisu spremljena u bazi podataka

