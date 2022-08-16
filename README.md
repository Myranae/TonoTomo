# TonoTomo
## Learning Goals -

Learn and utilize a new, statically typed language (C#) to build scripts for a game

Learn and utilize the Unity game engine to build a game for mobile devices (and beyond)

Create a game feature that allows users to save the state of their game to the cloud using either Firebase or Unity Cloud Saves

Create a social game feature that allows users to connect, either by visiting each other in game or sharing pictures and/or information about their pets

Plan an entire game and build it from nothing to a game on my phone

Learn how to put a game in the Apple Store, Google Play Store, Steam, and/or on itch.io

Build a plan for organizing and accessing resources as needed with as minimal storage requirements as possible (probably sprite-sheet)

Review Unity SDK for additional potential features in the future

Practice building useful wireframes meant to guide front-end development


## Project Description -

TonoTomo is a social, mobile game where the user raises a critter from hatching its egg through five stages of growth to adulthood. The user must take care of TonoTomo by feeding it, giving it water, keeping it clean, and giving it love and attention. Attention can be provided by playing mini-games with the pet when it becomes bored. Show your affection by petting the critter, and keep it clean with regular baths! TonoTomo requires care on a realtime basis and tracks how much time has passed to update its needs. If you leave TonoTomo alone for too long, the critter may decide to go find another owner! How well you take care of your pet determines how it grows into an adult, so make sure to take good care of your pet! Along the way, connect with other TonoTomo owners and share your pet’s progress with them.

## MVP Feature-set - 

- One egg
- One version of each growth stage
    - baby, toddler, child, teenager, young adult, adult
    - but two special end stages for adults: one if they keep points above a certain threshold for a certain amount of time, and another if the points are frequently low
- One mini-game for all stages (fun component)
    - Stage specific games can be an add on, though a very soon add on if possible. The one mini-game will always be available for all stages
- One type of food
- Implement petting or brushing (love component)
- Implement baths and cleaning messes
    - as the same maybe (maybe just a different animation depending on if the critter is smelly/dirty or if there is a mess present
- Getting sick if health is low for too long, needing medicine to heal
- One social component; need more research
- Summary: one egg, five growth stages (plus two adult types), one game, one food (plus water), baths/cleaning mess, petting/brushing, getting sick/better, one social component

## To Play - 
The game can be access on itch.io: https://myranae.itch.io/tonotomo. To work on this game, the repo contains the scripts, scenes, and assets you would need to use in a Unity project. It was built in Unity 2021.3.6f1 but the material may be usable in newer versions as well. Contact the repo owner with any questions.