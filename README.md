# Withy Sound Manager

Simple Sound Manager Plugin for Unity Game Engine

## Getting Started

This simple Sound Manager is made for two main purposes; maximum simplicity and appropriate code convention, excluding hardcoded string variables, which unstable can create many bugs and problems in the game.

### Setup

Withy Sound Manager comes ready to use. All the user needs to do is import the package into the Assets folder. 

### Creating Sounds

Withy Sound Manager focuses on the special Sound Objects, which works as blueprints for making the sound. To create and play sound, user has to create the Sound Object. 

1.  Create Sound Object: Right click->Create/Withy Sound Manager/Sound Object
2.	Fill up the Sound Object with all data needed.
3.	Save Sound Object.
4.	Sound Object is ready to be used.

NOTE: Once saved the Identifier will become read only. It you wish to change it, reset the Sound Object.

## Playing Sounds

Withy Sound Manager aims for maximum simplicity as said before. That is why playing sounds with this plugin is extremely easy and straightforward. Everything can be achieved just by adding one line of code into your script:

    Withy.SoundManager.PlaySound(SoundTypes.[SOUND NAME IDENTIFIER]);
  
or

    using Withy;
    SoundManager.PlaySound(SoundTypes.[SOUND NAME IDENTIFIER]);

### Enjoy!

## Built With

  - [Unity Engine v.2021.3.6f1](https://unity3d.com/get-unity/download/archive/) - Used
    for structure, implementation and testing
  - [Creative Commons](https://creativecommons.org/) - Used to choose
    the license

## Authors

  - **Beniamin Adam Biela** -
    [DonPatch74](https://github.com/DonPatch74)

## License

This project is licensed under the [CC0 4.0 Universal](http://creativecommons.org/licenses/by/4.0)

Feel free to use it, but please add my name as contributor.
