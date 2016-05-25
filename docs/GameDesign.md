---
title: "Vancleef: Game Design Document"
revision: "Revisión 1"
author: 
  - "Andres Revolledo Galvez"
  - "Rodrigo Linares"
  - "Alvaro Barua"
institution: "Universidad Peruana de Ciencias Aplicadas"
documentclass: article
header-includes:
  - \usepackage{float}
classoption:
  - titlepage
papersize: a4
lang: es
fontsize: 12pt
numbersections: true
date: true
toc: true
lof: true
lot: true
graphics: true
...

# Cambios

# Visión del proyecto

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

### Movimiento

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

A continuación se detallan cada uno de los dos personajes jugables, una pequeña biografía, las diferentes habilidades de cada uno y como se comparan entre ellos.



###Vancleef

 %%%BIO%%%
- Green color pallet

#### Velocidad

Tendrá la velocidad mas alta de los dos, con una base de 10 unidades y en la siguiente tabla están los siguientes niveles de velocidad:

| Nivel | Velocidad |
|------:+----------:|
| 1     | 10        |
| 2     | 12        |
| 3     | 14        |

: Niveles de velocidad Vancleef

#### Patrón de balas
Vancleef tendrá láseres clásicos de color azul, estas tendrán un movimiento lineal hacia arriba y todas la balas serán paralelas, comenzara teniendo solo 1 punto de disparo pero a cada nivel incrementado aumentara, en la siguiente tabla se muestra como evoluciona, el daño que cada bala hace y la velocidad de viaje que tienen.

| Nivel | Daño | Velocidad | Patrón                                      |
|:-----:+-----:+----------:+:-------------------------------------------:|
| 1     | 1    | 1         | ![Vancleef_1](images/vancleef_bullet_1.png) |
| 2     | 1.2  | 1.5       | ![Vancleef_2](images/vancleef_bullet_2.png) |
| 3     | 1.5  | 2         | ![Vancleef_3](images/vancleef_bullet_3.png) |


#### Patrones de Disparo

###Reol

  %%%BIO%%%


* Niveles de daño de balas:
  1) Cada bala hace 0.7 de daño
  2) Cada bala hace 1 de daño
  3) Cada bala hace 1.3 de daño
* Patron de balas:
tendrán* Dispara 3 balas individuales rotadas en un angulo de 20 grados con respecto al punto de origen.
  * Estas balas tendrán un movimiento ondulado pero se moverán en una recta que sigue su dirección original.
  * Las balas se moverán a una velocidad de 0.66.

#### Velocidad

#### Patrones de Disparo

### Balance

# Enemigos
Esta sección explica cada tipo de nave enviga que se presentara al jugador así como sus distintos comportamientos y las variaciones que cada uno presenta al incrementar la dificultad del juego a medida que avanza el tiempo.

El juego cuenta con 6 tipo de enemigos básicos y cada uno de estos tiene variaciones que incrementan su dificultad. A su vez cada uno de ellos tendrá un patrón diferente de disparo y se podrán diferenciar visualmente. Los enemigos son nombrado apartir de sus patrones, estos son: Simple, Kamikaze, Circular, Onda, Lock-on y Jefe.

Para dar un nivel de satisfacción al jugador, cada enemigo al ser destruido reproducirá una animación de destrucción y a la vez mostrar rápidamente un puntaje que el jugador obtiene por destruirlo, este numero variara según tipo de enemigo y su dificultad. Ademas cada uno tendrá una probabilidad de crear un diamante o powerup al ser destruido, en el detalle de cada uno se definirá que powerups podrán generar. El tipo de diamante generado varia solo por la dificultad de la nave enemiga, el detalle de cada diamante se vera mas adelante.

El nivel de dificultad de los enemigos es determinada por la cantidad de tiempo que se va jugando, en la seccion Entorno se describe cuando se cambia de dificultad.

## Simple

## Kamikaze

## Cirucular

## Onda

## Lock-on

## Jefe

# _Powerups_ y Diamantes
Los powerups son objetos flotantes en la pantalla que aparecen al eliminar enemigos 

# Entorno
Esta sección explica cada ambiente que el jugador podrá ver en el juego, las variaciones entre ellos, como su apariencia gráfica y sonora, como se generan las olas de enemigos y que patrones deberá de seguir en cada uno de ellos y el objetivo.

# Flujo de Pantallas

# Arte


