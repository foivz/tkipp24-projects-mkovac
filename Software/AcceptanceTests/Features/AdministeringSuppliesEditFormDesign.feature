Feature: Izgled forme za uređivanje postojeće opreme i resursa

Svrha ovog scenarija je osigurati da forma za uređivanje postojeće opreme i
resursa omogućuje korisnicima jednostavno i precizno ažuriranje podataka.
Cilj je provjeriti da su svi elementi forme pravilno implementirani, da su
jasno označeni, te da korisnici mogu nesmetano izvršavati sve potrebne radnje
za ažuriranje podataka o opremi i resursima.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na gumb Administration
And Kliknem na gumb Administering Supplies

Scenario: Korisnik vidi naslov forme za uređivanje opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Se otvori forma za dodavanje nove opreme
Then Vidi se naslov Edit equipment

Scenario: Korisnik vidi naslov forme za uređivanje resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Se otvori forma za uređivanje resursa
Then Vidi se naslov Edit resource

Scenario: Korisnik vidi naziv polja i polje za unos naziva opreme u formi za uređivanje opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje opreme
Then Vidi se naziv polja Equipment:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos naziva resursa u formi za uređivanje resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje resursa
Then Vidi se naziv polja Resource:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos količine opreme u formi za uređivanje opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje opreme
Then Vidi se naziv polja Amount:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos količine resursa u formi za uređivanje resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje resursa
Then Vidi se naziv polja Amount:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos opisa opreme u formi za dodavanje nove opreme
And Kliknem na gumb Add new
And Se otvori forma za uređivanje opreme
Then Vidi se naziv polja Description:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos opisa resursa u formi za uređivanje resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs
And Kliknem na gumb Edit
Then Otvori se forma za dodavanje novog resursa
And Vidi se naziv polja Description:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi gumb za spremanje uređene opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Otvori se forma za uređivanje opreme
Then Vidi se gumb zelene boje Save

Scenario: Korisnik vidi gumb za spremanje uređenog resursa
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
Then Otvori se forma za dodavanje novog resursa
And Vidi se gumb zelene boje Save

Scenario: Korisnik vidi gumb za poništavanje spremanja podataka uređene opreme
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Edit
And Se otvori forma za dodavanje nove opreme
Then Vidi se gumb crvene boje Cancel

Scenario: Korisnik vidi gumb za poništavanje spremanja podataka o uređenom resursu
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Edit
Then Otvori se forma za dodavanje novog resursa
And Vidi se gumb crvene boje Cancel

