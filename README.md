# PIO

GRA: NIM SUBTRACTION GAME

Przebieg i zasady gry:

Gra rozgrywana jest między graczem a komputerem lub dwoma graczami. Na planszy ustawione są obiekty. Gracze na zmianę zabierają 1, 2 lub 3 obiekty. Grę wygrywa gracz, który zabierze ostatni obiekt. Grę w przypadku gry z komputerem rozpoczyna strona wybrana przez gracza a w przypadku 2 graczy zaczyna gracz 1.
https://en.wikipedia.org/wiki/Nim#The_subtraction_game

Backlog:
1. Istnieje "stół" dla obiektów
2. Można usuwać obiekty
3. Obiekty są umieszczane na planszy
4. Gra kończy się po usunięciu ostatniego obiektu
5. Gra podzielona jest na tury
6. Gracze są zmuszeni do przestrzegania zasad
7. Menu / ekran rozpoczynania gry

Diagram UML:
- [GAME]1<>-1..2[PLAYER]
- [GAME]1<>-0..1[CPU]
- [GAME]1<>-1[TABLE] 
- [GAME]0..1<>-*[MATCH] 
- [GAME OBJECT]^-[TABLE] 
- [GAME OBJECT]^-[MATCH]
- [Interface\nTAKES FROM TABLE] <- implementuje [PLAYER] 
- [Interface\nTAKES FROM TABLE] <- implementuje  [CPU] 
