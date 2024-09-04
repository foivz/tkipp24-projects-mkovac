Feature: Funkcionalnost i izgled stranica za prikaz statističkih podataka

Svrha ovog scenarija je osigurati da stranica za prikaz statističkih podataka
ima intuitivan, funkcionalan i vizualno privlačan dizajn koji omogućava korisnicima
jednostavan pregled i analizu ključnih statističkih informacija. Cilj je provjeriti
da su svi potrebni elementi pravilno implementirani, jasno prikazani i lako dostupni
korisnicima.

Background:
Given Korisnik sam koji je prijavljen u sustav kao Admin
When Kliknem na karticu Statistics

Scenario: Korisnik vidi tri različite statistike za odabir
Then Vidim karticu Children Attendance
And Vidim karticu Children Gender
And Vidim karticu Children Groups

Scenario: Korisnik vidi padajući izbornik za odabire godine na kartici Children Attendance
And Kliknem na karticu Children Attendance
Then Vidim padajući izbornik na vrhu stranice
And Vidim Select a year ispred padajućeg izbornika

Scenario: Korisnik vidi stupčasti graf na kartici Children Attendance
And Kliknem na karticu Children Gender
Then Vidim graf koji je popunjen sa vrijednostima
And Vrijednosti su u skladu s bazom podataka

Scenario: Korisnik vidi stupčasti graf na kartici Children Gender
And Kliknem na karticu Children Gender
Then Vidim graf koji je popunjen sa vrijednostima
And Vrijednosti su u skladu s bazom podataka

Scenario: Korisnik vidi stupčasti graf na kartici Children Groups
And Kliknem na karticu Children Groups
Then Vidim graf koji je popunjen sa vrijednostima
And Vrijednosti su u skladu s bazom podataka