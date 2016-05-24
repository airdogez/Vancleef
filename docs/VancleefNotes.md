=Vancleef Notes=

==Changes to make==
- Remove Hangar/Store, dont break the game flow, keep player in action(Sprint 3 will be when we decide if to implement this)
- Maybe keep some form of pause from action to not overload players
- There will be 2 character ships: Vancleef & Reol (New sprites, Green and Purple pallet)
- Each character has a specific bullet pattern and type
- Maybe have a selection of Bullets pre-game
- Characters start weak, that is, they shoot few bullets, shoot slowly and move slow.
- Have enemies drop money for now
- Have enemies drop kinds of power ups, allows player to shoot more bullets, faster and move faster, there is a limit.
- Don't bother with a boss for now, keep the game with a constant flow of enemies, try to introduce harder enemies as more time passes.
- There will be a minimum of 4 diferent looking enemies for now.
- Each enemy type has its own unique shooting pattern
- A single kind of enemy wont be able to shoot in diferent ways, this is to have the player learn an enemy and know what to expect.
- Addons for ships might not be implemented, depends on how modular we can make the classes.
- We need at least 1 level, decide if it should be space or over some ocean. (Make brakground for these)
- Drops will be random
- Drops will be: Add bullet, Shoot faster, Move Faster.
- Scoring system will be implemented, maybe even a ranking, there will be multipliers.
- Game ends when player hits bullet or enemies, there is no "finish" for now, some kind of boss will be needed.
- HUD will be a simple display of score and bombs, maybe a timer.
- For dificulty have enemies increase the number of bullets they shoot and even make their patterns more dificult.

==Characters==
Both character must be recognisable while player, so they must have a brigth, distiguishable color
Make them look diferent from each other, and have them make sense with their bullet patterns.

===Vancleef===
* Niveles de daño de balas:
  1) Cada bala hace 1 de daño
  2) Cada bala hace 1.5 de daño
  3) Cada bala hace 2 de daño
* Patron de balas:
  * Dispara 2 balas paralelas e individuales con una pequeña separación entre ellas
  * Se moverán en una linea recta hacia arriba.
  * Las balas se moverán a una velocidad de 1.


- Green color pallet
- Shoots a pair of bullets
- Maybe a powerup increased the number of bullets per shoot

===Reol===
* Niveles de daño de balas:
  1) Cada bala hace 0.7 de daño
  2) Cada bala hace 1 de daño
  3) Cada bala hace 1.3 de daño
  
* Patron de balas:
tendrán* Dispara 3 balas individuales rotadas en un angulo de 20 grados con respecto al punto de origen.
  * Estas balas tendrán un movimiento ondulado pero se moverán en una recta que sigue su dirección original.
  * Las balas se moverán a una velocidad de 0.66.
 
- Purple color pallet
- Shoots 3 wavy bullets in a 20 degree angle from each other.

==Enemies==
For now they will be identified by their shooting pattern (Enemy = Bullet)
All must be dark/threatening looking, still keeping a ship look
Extra enemies ideas: 
- Moves towards the player, suicide bomber
- Stays on screen and must be killed
===Triple Way===
- Has a sigle canon in front that shoots 3 bullets in diferent directions
===Full Circle===
- Must be some kind of 8 point star shaped ship, 
===Wave===
===Triple way wave===

* Tabla de Balance entre jugadores
* Daño de balas a enemigos
* Evolucion de balas pra cada jugador
* Evolucion de dificultad de cada enemigo
* Porque y como aparecen los objetos
* Listar todos los objetos
* Tabla de atributos de cada enemigo
* Monedas deben tener un fin
* Falta el escudo
* Movimiento de grupo de enemigos
* Flujo de pantallas
* Espcificar hit boxe

==Powerups==
* Escudo:
  * Tendrá un tiempo de duración
  * Dará inmunidad al jugador mientras este activo
  * Todas las balas enemigas que colisión se eliminaran, sin importar el tipo
* Aumento de frecuencia de disparo:
  * Reducirá el tiempo entre disparo de balas.
* Aumento de daño:
  * Mejorara el daño que cada bala del jugador realiza. El numero que incrementa lo define cada personaje.

