Feature: Funkcionalnost stranice za manipulaciju opreme i  resursa

Svrha ovog scenarija je osigurati da stranica za manipulaciju opremom
i resursima pruža sve potrebne funkcionalnosti koje omogućuju korisnicima
učinkovito upravljanje opremom i resursima u dječjem vrtiću. Cilj je provjeriti
da svi elementi stranice ispravno funkcioniraju i da korisnici mogu
jednostavno dodavati, ažurirati, brisati i pregledavati podatke o opremi i
resursima. Kroz ovaj scenarij, želimo osigurati da stranica omogućava intuitivno
i bezgrešno upravljanje svim aspektima opreme i resursa, te da sustav pruža
odgovarajuće povratne informacije korisnicima.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na gumb Administration
And Kliknem na gumb Administering Supplies

Scenario: Korisnik vidi svu opremu koja je unesena u bazi podataka u tablici opreme
Then Na desnoj strani ekrana vidim tablicu s popisom sve opreme iz baze podataka

Scenario: Korisnik vidi sve resurse koji su uneseni u bazi podataka u tablici resursa
And Kliknem na karticu Resource
Then Na desnoj strani ekrana vidim tablicu s popisom svih resursa iz baze podataka

Scenario: Korisnik može otvoriti formu za dodavanje nove opreme
And Kliknem na gumb Add new
Then Otvori se forma za unos nove opreme

Scenario: Korisnik može otvoriti formu za dodavanje novog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Add new
Then Otvori se forma za unos novog resursa

Scenario: Korisnik može otvoriti formu za uređivanje postojeće opreme
And Kliknem na bilo koju opremu iz tablice
And Kliknem na gumb Edit
Then Otvori se forma za uređivanje odabrane opreme

Scenario: Korisnik ne može otvoriti formu za uređivanje postojeće opreme bez odabiranja ijedne opreme
And Kliknem na gumb Edit
Then Otvori se skočni prozor za upozorenjem "Molimo odaberite opremu koju želite urediti."

Scenario: Korisnik može otvoriti formu za uređivanje postojećeg resursa
And Kliknem na karticu Resource
And Kliknem na bilo koji resurs iz tablice
And Kliknem na gumb Edit
Then Otvori se forma za uređivanje odabranog resursa

Scenario: Korisnik ne može otvoriti formu za uređivanje postojećeg resursa bez odabiranja ijednog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Edit
Then Otvori se skočni prozor za upozorenjem "Molimo odaberite resurs koji želite urediti."

Scenario: Korisnik može obrisati opremu
And Odaberem bilo koju opremu iz tablice
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Jeste li sigurni da želite obrisati ovu opremu?"
And Prethodno odabrana oprema je obrisana

Scenario: Korisnik ne može obrisati opremu bez prethodnog odabiranja ijedne opreme
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Molimo odaberite opremu koju želite obrisati."

Scenario: Korisnik ne može obrisati opremu prilikom odabira praznog retka tablice opreme
And Kliknem na prazni redak u tablici
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Molimo odaberite važeću opremu."

Scenario: Korisnik može obrisati resurs
And Kliknem na karticu Resource
And Odaberem bilo koji resurs iz tablice
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Jeste li sigurni da želite obrisati ovaj resurs?"
And Prethodno odabran resurs je obrisan

Scenario: Korisnik ne može obrisati resurs bez prethodnog odabiranja ijednog resursa
And Kliknem na karticu Resource
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Molimo odaberite resurs koji želite obrisati."

Scenario: Korisnik ne može obrisati resurs prilikom odabira praznog retka tablice resursa
And Kliknem na karticu Resource
And Kliknem na prazni redak u tablici
And Kliknem na gumb Delete
Then Otvori se skočni prozor s obavijesti "Molimo odaberite važeći resurs."

