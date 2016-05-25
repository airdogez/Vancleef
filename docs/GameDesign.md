---
title: "Vancleef: Game Design Document"
revision: "Revisión 2"
author: 
  - "Andres Revolledo Galvez"
  - "Rodrigo Linares"
  - "Alvaro Barua"
institution: "Universidad Peruana de Ciencias Aplicadas"
documentclass: article
papersize: a4
fontsize: 12pt
date: \today
classoption:
  - titlepage
header-includes:
  - \usepackage{float}
  - \usepackage[spanish]{babel}
numbersections: true
toc: true
lof: true
lot: true
graphics: true
...

# Visión del proyecto

## Sinopsis del juego

##Genero

##Audiencia

##Plataformas


# Jugabilidad
Esta sección explica la experiencia que el usuario tendrá al jugar y controlar a su personaje, que sentimientos se tratan de evocar en el jugador y explica las mecánicas que cada personaje presenta.

## Satisfacción
El reto principal del juego es lograr llegar al final del nivel y derrotar al jefe final. Para ello el jugador tendrá que sobrevivir varias olas de enemigos y las balas que disparan, las cuales podrán llenar gran parte de la pantalla, y proveerse de diferentes _powerups_ que mejoraran las capacidades ofensivas y defensivas del personaje jugable.

## Aprendizaje
El juego contara con pocos controles para su fácil aprendizaje. Estos serán de movimiento, poder moverse por toda la pantalla, poder disparar tanto su arma principal como la secundaria y poder moverse mas lento para tener un control mas fino para esquivar todos los obstáculos que se le opongan.

## Controles

El juego se podrá controlar con el teclado en el caso de Windows, MacOSX y Linux, y con un dispositivo móvil en el caso de SmartTVs y Android. Acá se muestran las configuraciones a utilizar en cada esquema:

###Teclado

\begin{figure}[H]
\includegraphics{diagrams/keyboard_layout.eps}
\caption{Layout Teclado}
\end{figure}

En azul se resalta la configuración principal, mientras que en rojo los controles secundarios, para los usuarios que sean zurdos o prefieran esa configuración, ambos controles funcionaran a la vez ya que no se interponen.

W y Arriba:
: Incrementa la posición del jugador en Y

A y Izquierda:
: Decrementa la posición del jugador en X

S y Abajo:
: Decrementa la posición del jugador en Y

D y Derecha:
: Incrementa la posición del jugador en X

Z y M:
: Permite disparar la arma primaria

X y N:
: Permite hacer uso de la bomba, arma secundaria.

Shift Izquierdo y Derecho:
: Reduce la velocidad de movimiento del jugador mientras se mantenga apretado

###Móvil

\begin{figure}[H]
\includegraphics{diagrams/mobile_layout.eps}
\caption{Layout Móvil}
\end{figure}

Análogo:
: Moverá al jugador en la dirección unitaria que se refleja, las lineas punteadas reflejan un umbral que al pasarlo el jugador tendrá la velocidad normal, todo dentro es el movimiento lento, este umbral tendra un radio de 0.6.

Botón 1:
: Permite disparar el arma primaria

Botón 2:
: Permite disparar la bombas, arma secundaria

## Movimiento

Al moverse no contara con simulación de física, el movimiento sera 1:1, no habrá aceleración ni inercia. Una vez se deje de apretar los controles el personaje se detendrá y reproducirá la animación de _Idle_. Cuando se encuentre en movimiento se representara con una animación que muestre los motores de la nave funcionando y cuando vaya a la izquierda o derecha la nave deberá reflejarlo visualmente.

El movimiento del jugador dependerá de la velocidad base del personaje y un multiplicador determinado por el estado actual, disparando,  lento y combinación. A continuación es una tabla de como cada estado modifica la velocidad.

| Estado             | Multiplicador |
|--------------------+--------------:|
| Normal             | 1x            |
| Lento              | 0.4x          |
| Disparando         | 0.8x          |
| Lento y Disparando | 0.2x          |

: Multiplicador de movimiento

Usar el ataque secundario no afecta el movimiento del jugador. En el caso del control análogo para móviles, se utiliza un umbral para determinar si esta en estado normal o lento, no se tomara los valores intermedio.

## Personajes

A continuación se detallan cada uno de los dos personajes jugables, una pequeña biografía, las diferentes habilidades de cada uno y como se comparan entre ellos. Los niveles de velocidad y balas son mejoras que se consiguen mediante _powerups_.

Las balas de ambos personajes tendrán 3 atributos básicos, la velocidad de movimiento, el daño que hacen y su representación gráfica.

###Vancleef

 %%%BIO%%%
- Green color pallet

#### Velocidad

Tendrá la velocidad mas alta de los dos, representado visualmente por los dos motores que tiene y su basica tecnologia de disparo, la siguiente tabla están los valores de velocidad para cada nivel:

| Nivel | Velocidad |
|------:+----------:|
|     1 |        10 |
|     2 |        13 |
|     3 |        16 |

: Niveles de velocidad Vancleef

#### Patrón de balas
Vancleef tendrá láseres clásicos de color azul, estas tendrán un movimiento lineal hacia arriba y todas la balas serán paralelas, comenzara teniendo solo 1 punto de disparo pero a cada nivel incrementado aumentara, en la siguiente tabla se muestra como evoluciona, el daño que cada bala hace y la velocidad de viaje que tienen.

| Nivel | Daño | Velocidad | Patrón                                      |
|------:+-----:+----------:+:-------------------------------------------:|
| 1     | 1    | 1         | ![Vancleef_1](images/vancleef_bullet_1.png) |
| 2     | 1.2  | 1.5       | ![Vancleef_2](images/vancleef_bullet_2.png) |
| 3     | 1.5  | 2         | ![Vancleef_3](images/vancleef_bullet_3.png) |

: Patrones de Balas Vancleef

###Reol

  %%%BIO%%%

#### Velocidad
Sera mas lenta con respecto a Vancleef y se representara esto visualmente por un motor mas grande en la parte posterior, ya que su nave se enfoca mas en el área de disparo lo cual requiere mas energía para las armas. La siguiente tabla es el valor base de velocidad por cada nivel:

| Nivel | Velocidad |
|------:+----------:|
|     1 |         7 |
|     2 |         9 |
|     3 |        12 |

: Niveles de velocidad Reol


#### Patrones de balas
Las balas de Reol tendrán un movimiento en onda y un aspecto de láser eléctrico que se sigue un movimiento sinusoidal. La dirección de las balas irán en un arco con respecto al punto de origen, así abarcara una mayor área de ataque. A continuación se muestra como serian los patrones en cada nivel y sus atributos:

| Nivel | Daño | Velocidad |                Patrón               |
|:-----:+-----:+----------:+:-----------------------------------:|
|   1   |  0.5 |       1.2 | ![Reol_1](images/reol_bullet_1.png) |
|   2   |  0.8 |       1.8 | ![Reol_2](images/reol_bullet_2.png) |
|   3   |  1.2 |       2.5 | ![Reol_3](images/reol_bullet_3.png) |

:Patrones de Balas Reol

## Bomba
Ambos personajes contaran con un ataque secundario que es un bomba, esta bomba eliminara por completo todos los enemigos y balas que se encuentren en pantalla al momento de ser usada. Tendra un limite inicial de 1 bomba disponible máxima y este podrá ser incrementado con el powerup Incremento bombas especificado mas adelante, ademas si obtiene mas bombas que el limite, esto generara 1000 puntos extra. Al iniciar el juego no se contara con ninguna bomba disponible y con un máximo posible de 1 y se tendrá que eliminar naves enemigas para obtener alguna.

Al usar la bomba flotara hacia arriba y deberá de colisionar con algún enemigo o bala para poder explotar, con lo que se mostrara un efecto de destrucción que tornara la pantalla blanca por unos instantes, esto elimina a todos los enemigos de pantalla a excepción del jefe, el cual sufre un 5% de daño sobre su vida restante. En el caso que no colisione, saldrá de la pantalla y no tendrá efecto.

El HUD debera mostrar la cantidad de bombas que se tienen, mostrando el total de bombas que se pueden tener a la vez, mostrando el _sprite_ cuando esta disponible una bomba y una silueta cuando no se tiene una bomba.

# Componentes

## Enemigos
Esta sección explica cada tipo de nave enviga que se presentara al jugador así como sus distintos comportamientos y las variaciones que cada uno presenta al incrementar la dificultad del juego a medida que avanza el tiempo.

El juego cuenta con 6 tipo de enemigos básicos y cada uno de estos tiene variaciones que incrementan su dificultad. A su vez cada uno de ellos tendrá un patrón diferente de disparo y se podrán diferenciar visualmente. Los enemigos son nombrado apartir de sus patrones, estos son: Simple, Kamikaze, Circular, Onda, Lock-on y Jefe.

Para dar un nivel de satisfacción al jugador, cada enemigo al ser destruido reproducirá una animación de destrucción y a la vez mostrar rápidamente un puntaje que el jugador obtiene por destruirlo, este numero variara según tipo de enemigo y su dificultad. Ademas cada uno tendrá una probabilidad de crear un diamante o powerup al ser destruido, en el detalle de cada uno se definirá que powerups podrán generar. El tipo de diamante generado varia solo por la dificultad de la nave enemiga, el detalle de cada diamante se vera mas adelante.

El nivel de dificultad de los enemigos es determinada por la cantidad de tiempo que se va jugando, en la seccion Entorno se describe cuando se cambia de dificultad.
<!--- Definir los puntajes, patrones de balas, patrones de movimiento... --->
<!--- Definir cada variacion posible (3 min excepto jefe) ... --->

### Simple

### Kamikaze

### Cirucular

### Onda

### Lock-on

### Jefe

## _Powerups_
Los powerups son objetos flotantes en la pantalla que aparecen al eliminar enemigos, cada uno de ellos tendrá un efecto diferente sobre el jugador si es que se logra coger.

* Subir velocidad jugador:
: Incrementara el nivel de velocidad del personaje, de ser que se encuentre en el nivel maximo, se otorgara 300 puntos

* Subir nivel balas:
: Incrementara el nivel de balas del personaje, de ser que se encuentre en el nivel maximo, se otorgara 300 puntos

* Escudo:
: Activa un escudo, el cual estara activo por 10 segundos, todas las balas enemigas que hagan contacto con el escudo seran eliminadas.
: En caso se obtenga otro escudo este solo otorgara un puntaje extra de 2000 puntos, el tiempo previo del escudo se mantendra.

* Bomba extra:
: Agrega una bomba, si ya se tiene el máximo de bombas, este powerup otorgara 1000 puntos.

* Incremento Bombas:
: Incrementa el maximo posible de bombas, no incrementa el numero de bombas disponibles, el total maximo posible seran 3. Si ya se tiene 3, este powerup otorgara 1500 puntos.

## Diamantes
Los diamantes darán puntos extra al jugador, estos deberán ser atrapados antes de que puedan otorgar el puntaje. De ser que salgan de la pantalla, estos se perderán.

# Entorno
Esta sección explica cada ambiente que el jugador podrá ver en el juego, las variaciones entre ellos, como su apariencia gráfica y sonora, como se generan las olas de enemigos y que patrones deberá de seguir en cada uno de ellos y el objetivo.

<!--- Que enemigos se intrucen en que momento, cuando se pasa a un siguiente entorno, --->

# Flujo de Pantallas

# Interfases

# Arte


