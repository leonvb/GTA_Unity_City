# GTA_Unity_City
Import Grand Theft Auto: Vice City map and models to Unity 3D.

## How to run
You will require Grand Theft Auto: Vice City to load the map. To load the map open the project in Unity and run it. Press the "space" key and wait 40 seconds for the map to load. If you only want a certain part of the map to load then you can change the "mapAreasToLoad" variable in the "GameLoader.cs" script.

I only wrote a basic loading script, but you can add anything you need. Auto loading textures are currently not supported, but can be manually added by extracting the textures from the required .TXD files and then applying it to the loaded model's material. If the textures don't appear correct, then flip the texture vertically in any image editor and save it. **Auto loading textures will be added in future versions.**

## GTA File formats supported
- IMG
- DFF
- IPL (partial)
- IDE (partial)
- DAT
- TXD (partial)

![Alt text](img/Screenshot.jpg?raw=true "VC_map")
