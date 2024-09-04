Feature: Izgled forme za unos nove opreme i resursa

Svrha ovog scenarija je osigurati da forma za unos nove opreme i resursa
ima intuitivan, funkcionalan i estetski ugodan dizajn koji omogućava
korisnicima jednostavan i efikasan unos podataka. Cilj je provjeriti da su
svi potrebni elementi prisutni, pravilno raspoređeni i označeni, te da korisnici
mogu nesmetano unositi i spremati podatke o novoj opremi i resursima.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na gumb Administration
And Kliknem na gumb Administering Supplies

Scenario: Korisnik vidi naslov forme za unos nove opreme
And Kliknem na gumb Add new
Then Otvori se forma za dodavanje nove opreme
And Vidi se naslov Add new equipment

Scenario: Korisnik vidi naslov forme za unos novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
Then Otvori se forma za dodavanje novog resursa
And Vidi se naslov Add new resource

Scenario: Korisnik vidi naziv polja i polje za unos naziva opreme u formi za dodavanje nove opreme
And Kliknem na gumb Add new
And Otvori se forma za dodavanje nove opreme
Then Vidi se naziv polja Equipment:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos naziva resursa u formi za dodavanje novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za dodavanje novog resursa
Then Vidi se naziv polja Resource:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos količine opreme u formi za dodavanje nove opreme
And Kliknem na gumb Add new
And Otvori se forma za dodavanje nove opreme
Then Vidi se naziv polja Amount:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos količine resursa u formi za dodavanje novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za dodavanje novog resursa
Then Vidi se naziv polja Amount:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos opisa opreme u formi za dodavanje nove opreme
And Kliknem na gumb Add new
And Se otvori forma za dodavanje nove opreme
Then Vidi se naziv polja Description:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi naziv polja i polje za unos opisa resursa u formi za dodavanje novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za dodavanje novog resursa
Then Vidi se naziv polja Description:
And Vidi se polje za unos pored naziva

Scenario: Korisnik vidi gumb za spremanje nove opreme
And Kliknem na gumb Add new
And Otvori se forma za dodavanje nove opreme
Then Vidi se gumb zelene boje Save

Scenario: Korisnik vidi gumb za spremanje novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za dodavanje novog resursa
Then Vidi se gumb zelene boje Save

Scenario: Korisnik vidi gumb za poništavanje spremanja nove opreme
And Kliknem na gumb Add new
And Otvori se forma za dodavanje nove opreme
Then Vidi se gumb crvene boje Cancel

Scenario: Korisnik vidi gumb za poništavanje spremanja novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
And Otvori se forma za dodavanje novog resursa
Then Vidi se gumb crvene boje Cancel

