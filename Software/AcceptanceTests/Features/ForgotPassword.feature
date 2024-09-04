Feature: Funkcionalnost i izgled stranice za dohvaćanje zaboravljene lozinke

Svrha ovog scenarija je osigurati da stranica za dohvaćanje zaboravljene lozinke
ima intuitivan, funkcionalan i estetski ugodan dizajn koji omogućava korisnicima
jednostavan i siguran postupak oporavka pristupa svojim računima. Cilj je provjeriti
da su svi potrebni elementi pravilno implementirani, jasno prikazani i lako dostupni
korisnicima. Cilj je provjeriti da su sve funkcionalnosti pravilno implementirane, da
proces oporavka radi glatko i da korisnici mogu bez poteškoća dohvatiti svoju
lozinku putem mail adrese.

Background: 
	Given Korisnik sam aplikacije
	And Učita se prozor za prijavu
	When Kliknem na gumb Forgot password?
	And Vidim prozor za dohvaćanje lozinke

Scenario: Korisnik vidi tekst Email
Then Vidim tekst Email

Scenario: Korisnik vidi polje za unos
Then Vidim polje za unos ispod teksta Email

Scenario: Korisnik vidi gumb Send
Then Vidim gumb Send ispod polja za unos

Scenario: Korisnik može unijeti tekst u polje za unos
And Odaberem polje za unos
Then Unesem bilo koji tekst

Scenario: Korisnik može poslati lozinku na upisani mail
And Odaberem polje za unos
And Unesem mail kojemu imam pristup
And Kliknem Send
Then Skočni prozor se prikazuje s porukom za uspješno slanje "Your password has been sent successfully to inserted email:"

Scenario: Korisnik ne može poslati lozinku na mail koji se ne nalazi u bazi podataka
And Odaberem polje za unos
And Unesem bilo koji mail koji se ne nalazi u bazi podataka
And Kliknem Send
Then Skočni prozor se prikazuje s porukom za nepostojeći mail "There is no account registered with the provided email address. Please verify the email address and try again."

Scenario: Korisnik ne može poslati lozinku na mail ukoliko uneseni email ne sadrži @gmail.com
And Odaberem polje za unos
And Unesem bilo koji mail bez @gmail.com
And Kliknem Send
Then Skočni prozor se prikazuje s porukom  za neispavano unesen mail "The invalid email. Please provide a valid email address ending with '@gmail.com'."
