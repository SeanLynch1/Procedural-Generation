# Procedural-Generation
This repository will contain the source files and code on my journey of trying to create a 3D procedurally generated city.

I plan to procedurally generate buildings in a city using recursion that would look like it may be set somewhere in the middle east. The position of each building may be random or manually assigned. Each layer of the building will be instantiated with a prefab. My goal is to try and model these prefabs myself however I don't have much experience in this area. I plan for the top layer of the buildings to use perlin noise. This will randomise the height of the roofs giving an undulating look to them. Depending on time and on the complexity of things I also may use fractals to instantiate additonal prefabs on the sides of base prefabs that make up the different layers of recursion. This will add diversity and uniqueness to the city. Hopefully I can generate a quasi random terran using perlin noise to surround the city and give an all round immersing feeling to the city. The scene may be interactive, allowing players to adjust the height of buildings and the offset, scale etc of the perlin noise and I could possibly implement some sort of moving character with a goal too.

I feel like the building positions will be assigned by a base tile that is assigned manually within a for loop or randomly using a different method that decides wether to place a tile or a nullable object in each sections of a grid. The recursion layers can be generated using for loops with randomised maximum iteration amounts. They could possibly randomly select different prefabs from an array. For the fractals I could try right a rule set that tells prefabs to instantiate corresponding prefabs on their sides/edges. I could randomly set the offset of a perlin noise texture for random height generation of terain/ rooftops that players can adjust with a slider or something along those lines as well.

Rerences that may help me along the way of this project:
FRACTALS:
https://www.youtube.com/watch?v=WFtTdf3I6Ug&t=193s
https://www.youtube.com/watch?v=0jwkZKDOzfc
https://www.youtube.com/watch?v=fkRnUoXacHM

PERLIN NOISE
https://www.youtube.com/watch?v=bG0uEXV6aHQ
https://www.youtube.com/watch?v=sUDPfC1nH_E&t=176s

