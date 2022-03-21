# SpaceStationVR
 BuidlWeek

![client](https://github.com/battlejoose/SpaceStationVR/blob/main/docs/bbf004942173b841cfe19fab1038d3f6-png.jpg)

Concept: native bindings for wallets into the unity game engine

problem: As crypto projects evolve into the metaverse most are attempting to bring game engines into the browser. This severely limits the reach of the crypto ecosystem as window objects and metmask just are incompatible with modern day game engines.

solution: By utilizing a native (on desktop) RESTful wallet api provided by the keepkey Desktop; we are able to bring full crypto features to all the top tier game engines natively without the need of browsers.


### dev flow

This is a unity project, 

unity setup:

install unity hub(https://unity3d.com/get-unity/download)

```
git clone https://github.com/battlejoose/SpaceStationVR
```

Open project in unity hub

view scenes
```
moondemo
```
open moonDemo scene.


### Required hardware

oculus quest 2: (https://www.oculus.com/quest-2/)

keepkey: (https://shapeshift.com/keepkey)

(if you do not have a keepkey the desktop app can init/load a mnemonic from metamask)

how to rig a character in VR: https://vimeo.com/652050460/dac63db320

## utilized technologies

* unity game engine
* Oculus Quest (with Oculus Link)
* photon networking sas (https://www.photonengine.com/pun)
* keepkey desktop app
* Swagger (OpenAPI) api docs (https://swagger.io/)
* pioneer.devs a generalized crypto API (https://pioneers.dev/docs/)
* opensea.io NTF info and indexing (https://opensea.io/)

### Keepkey client 

https://github.com/keepkey/keepkey-desktop/releases

open client
![client](https://github.com/BitHighlander/EthDenverHackathon/blob/main/docs/welcome-screen.png)

load wallet:
![client](https://github.com/BitHighlander/EthDenverHackathon/blob/main/docs/client-4.png)

open dev tools
![client](https://github.com/BitHighlander/EthDenverHackathon/blob/main/docs/client-3.png)

This stands up a local api you can talk to your keepkey with. 

![api](https://github.com/BitHighlander/EthDenverHackathon/blob/main/docs/client-1.png)



