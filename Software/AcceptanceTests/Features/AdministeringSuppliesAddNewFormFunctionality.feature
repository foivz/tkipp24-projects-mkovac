Feature: Funkcionalnost stranice za unose nove opreme i resursa

Svrha ovog scenarija je osigurati da stranica za unos nove opreme i resursa
omogućuje korisnicima efikasan i točan unos svih potrebnih podataka o novoj
opremi i resursima dječjeg vrtića. Cilj je provjeriti da su svi elementi stranice
pravilno implementirani, da funkcionalnosti rade prema specifikacijama i da
korisnici mogu nesmetano izvršavati sve potrebne radnje.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na gumb Administration
And Kliknem na gumb Administering Supplies

Scenario: Korisnik može spremiti novo unesenu opremu
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Ispunim sva polja u forma
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Nova oprema je spremljena
And Zatvori se forma za dodavanje nove opreme
And Prikaže se kartica Equipment

Scenario: Korisnik ne može spremiti opremu ukoliko sva polja forme ostavi prazna
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik ne može spremiti opremu ukoliko samo polje Equipment ostavi praznim
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Ispunim sva polja osim polja Equipment
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Oprema nije spremljena

Scenario: Korisnik ne može spremiti opremu ukoliko samo polje Amount ostavi praznim
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Ispunim sva polja osim polja Amount
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik ne može spremiti opremu ukoliko u polje Amount unese tekst
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And U polje Amount unesem slovo ili riječ
And Ispunim ostala polja
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik može spremiti opremu ukoliko samo polje Description ostavi praznim
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Ispunim sva polja osim polja Description
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Nova oprema je spremljena
And Zatvori se forma za dodavanje nove opreme
And Prikaže se kartica Equipment

Scenario: Korisnik može zatvoriti prozor za dodavanje nove opreme i poništiti spremanje unesenih podataka pritiskom gumba Cancel
And Kliknem na gumb Add new
And Otvori se forma za unos nove opreme
And Ispunim sva polja osim polja forme
And Kliknem Cancel
Then Forma za dodavanje nove opreme se zatvori
And Prikaže se kartica Equipment
And Oprema nije spremljena

Scenario: Korisnik može spremiti novo uneseni resurs
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And Ispunim sva polja u forma
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Novi resurs je spremljena
And Zatvori se forma za dodavanje novog resursa
And Prikaže se kartica Resources

Scenario: Korisnik ne može spremiti resurs ukoliko sva polja ostavi prazna
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik ne može spremiti resurs ukoliko samo polje Resource ostavi praznim
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And Ispunim sva polja osim polja Resource
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Resurs nije spremljen

Scenario: Korisnik ne može spremiti resurs ukoliko samo polje Amount ostavi praznim
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And Ispunim sva polja osim polja Amount
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik ne može spremiti resurs ukoliko u polje Amount unese tekst
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And U polje Amount unesem slovo ili riječ
And Ispunim ostala polja
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"

Scenario: Korisnik može spremiti resurs ukoliko samo polje Description ostavi praznim
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog resursa
And Ispunim sva polja osim polja Description
And Kliknem Save
Then Prikaže se skočni prozor s obavijesti "unesi koja obavijest"
And Novi resurs je spremljena
And Zatvori se forma za dodavanje novog resursa
And Prikaže se kartica Resources

Scenario: Korisnik može zatvoriti prozor za dodavanje novog resursa i poništiti spremanje unesenih podataka pritiskom gumba Cancel
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za unos novog

