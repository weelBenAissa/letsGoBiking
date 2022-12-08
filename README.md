# LetsGoBiking
  ## Réalisé par : Weel BEN AISSA, Ali HAITAM
## Objectif : 
Créer les différentes parties d'une application qui permettrait à l'utilisateur de se déplacer de n'importe quel endroit de départ à n'importe quel autre endroit d'arrivée en utilisant, s'il en existent dans la ville de départ ET celle d'arrivée, des vélos 🚲 proposés par JC Decaux, sinon il sera lui proposé d'effectuer le trajet à pied 🚶‍♀️.

## Guide d'utlisation :
⬪ Ci-dessous le guide complet d'uilisation de notre projet:
WARNING : IL FAUT EXECUTER LES FICHIERS SUIVANTS EN MODE ADMINISTRATEUR.
1) Lancer l'éxécutable "letsGoBiking\RoutingServer\RoutingServer\bin\Debug\RoutingServer.exe"

2) Lancer l'exécutable "letsGoBiking\RoutingServer\ProxyCache\bin\Debug\ProxyCache.exe"  

3) Lancer la commande "activemq start" là ou vous avez téléchargé l'environnement Apache ActiveMQ

4) Executez le main du projet TestWSClient qui se trouve dans : "letsGoBiking\ClientJava\src\main\java\com\soc\testwsclient.java"

## Fonctionnement : 

⬪ Il va vous etre proposé en tout premier de rentrer une adresse de départ et une d'arrivée.
⬪ Si vous choisissez un itinéraire court la solution de marcher directement vers la destination vous sera proposé sinon les étapes pour récuperer un vélo seront écrites.
⬪ Malheureusement il y'a quelques Contrats JCDecaux qui ne contiennent pas de ville donc pour gérer cela, si vous entrez une adresse dans une ville qui n'a pas de contrat associé alors le seul chemin possible sera la marche.
⬪ Nous avons réalisé le MVP avec le proxy Cache et l'active MQ V1. 
⬪ Il ne faut pas arrêter une instruction en cours d'éxecution sous risques d'avoir des messages de la précédente queue affichés lors de la prochaine exécution.
