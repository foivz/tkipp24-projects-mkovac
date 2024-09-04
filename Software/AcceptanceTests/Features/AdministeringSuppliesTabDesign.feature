Feature: Izgled stranice za manipulaciju opreme i resursa

Svrha ovog scenarija je osigurati da stranica za manipulaciju opremom i 
resursima ima intuitivan, funkcionalan i estetski ugodan dizajn koji omogućava
korisnicima jednostavno i efikasno upravljanje opremom i resursima dječjeg
vrtića. Cilj je provjeriti da su svi elementi stranice pravilno raspoređeni,
lako dostupni i jasno označeni kako bi se korisnicima omogućilo nesmetano
obavljanje potrebnih aktivnosti. Kroz ovaj scenarij, želimo osigurati da
korisničko iskustvo bude pozitivno i da stranica podržava učinkovito izvršavanje
zadataka povezanih s opremom i resursima.

Scenario: Korisnik vidi gumb za dodavanje novog resursa Add new
	And Kliknem na karticu Resource
	Then Na desnoj strani ekrana, ispod tablice, vidim gumb zelene boje Add new

Scenario: Korisnik vidi gumb za uređivanje postojećeg resursa Edit
	And Kliknem na karticu Resource
	Then Na desnoj strani ekrana, ispod tablice, vidim gumb plave boje Edit

Scenario: Korisnik vidi gumb za brisanje postojećeg resursa Delete
	And Kliknem na karticu Resource
	Then Na desnoj strani ekrana, ispod tablice, vidim gumb crvene boje Delete


