# Procedural-Generation
# Name

Sean Lynch

# Student Number

C18357081

# Class Group

DT508

# Project Description
This project contains a proceduarlly generated city, that can be modified by use of the implemented UI. It consists of tiles which generates blocks forming towers in the loop of a iterating circle and based on certain positions within a road network. There is a ship which the user can use to navigate around the city and closely look at all the different implementations and beautiful colours. The city towers, roads and tower modification options were created without any external references or help.

# Instructions
In the game there is a canvas containing UI elements which guides the user on what they can do. Using different controls explained within canvas the player can yaw, pitch, roll, elevate and strafe their ship. If the user right click's the mouse they will freeze the ships position and activate a second canvas which allows them to modify the individual rotation of each block in the city towers, the spacing between each block in each tower, the activity of each block in each tower and the rotation of every tower at once.

# How It Works
The terrain is procedurally generated by creating a grid of vertice positions. Then within a for loop three vertices within the grid of all the vertices are located at a time and using these three points a mesh is quadrant mesh is created to form a triangle. A second triangle is then created to form a square. This process is repeated in a nested for loop causing a grid of these squares. Then using perlin noise the height of each triangle is generated based on the shade of what would be a perlin noise texture. The grey scale of the texture determines the height and depth of each triangle  forming an organic looking terrain. 
This is how the vertices for each corner of each triangle are allocated:

    int vert = 0;
        int tris = 0;
        for(int z = 0; z < zSize; z ++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //Assign points for triangle3
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

            }
            vert++;
    }

The xSize is the width of the vertices grid and the zSize is the height.
This section of code was implemented by following Brackey's procedural terrain video referenced in the references section below.

Multiple tiles can be formed in multiple loops in the shape of a circle using the formula for the circuference of a circle along with sin and cos functions to calculate the individual placement for each tile in each circle loop that is created. Each tile then generates a random height and instantiates a randomised block starting at 0 and recursively repeating reaching the max height. A roof top piece is then instantiated at the max height of the tower.

The information for the for loop was referenced from some of the code created on the Game Engines course and modified by me.
This is how the the towers are created in a for loop:

    for (int i = 0; i < num; i++)
        {
            radius += Random.Range(20, maxSpaceBetweenLayer);
            num2 += 1;
            for (int j = 0; j < num2; j++)
            {
                /* Distance around the circle */
                var radians = 2 * Mathf.PI / num2 * j;

                /* Get the vector direction */
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                float randomX = Random.Range(0f, 0f);
                float randomY = Random.Range(0f, 0f);c
                var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY) ;

                /* Get the spawn position */
                Vector3 spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point


                /* Now spawn */
                var tile = Instantiate(tilePrefab, spawnPos, tilePrefab.transform.rotation) as GameObject;
                tile.transform.parent = this.gameObject.transform;
                tileList.Add(tile);
            }
        }

This is how the recursion layers of the towers are generated:

    public void BuildTower()
    {
        float increasableValue = 0;
        for (int i = 0; i < buildingHeight; i++)
        {
            if (i != 0)
                increasableValue += blockSpacing * buildingBlockPrefabs.Count;
            for (int j = 0; j < buildingBlockPrefabs.Count; j++)
            {
                buildingBlockPosition = new Vector3(this.transform.position.x, j * blockSpacing + increasableValue, this.transform.position.z);
                GameObject buildingBlock = Instantiate(buildingBlockPrefabs[Random.Range(0, buildingBlockPrefabs.Count - 1)], buildingBlockPosition, Quaternion.identity);
                buildingBlock.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // HSV = shade and intensity values
                buildingBlock.transform.parent = this.gameObject.transform;
                instantiatedBlocks.Add(buildingBlock);
            }
        }
    }
 
 The cube blocks in each tower shoots out a ray in a random direction, selecting from a range of forward, back, left, and, right. If the ray does not collide with a primary tower block it will instantiate a new random block to the side of it at the end point of the casted ray. This newly instantiated block will repeat this process several times forming an overhanging structure to the side of the tower.
 
 The roadpathway is found as follows. On Start a beginning tile spawnns 4 road tiles to either side of it. Each time it instantiates that tile the tile adds 90 to it's rotation. Each of these tiles the shoots a ray forwards and instantiates a new road tile at the end end point of that ray. The newly Instantiated roads then rotate in a random direction a shoot another ray forward facing ray based on it's rotation. If the ray doesn't collide with another road prefab , a new road prefab gets instantiated. Each road prefab shoots out a ray to either side and corner of it. If all of those rays return true a tower prefab is instantiated at that position.
 
 This is how the road system works:
 
 
    public void ShootRays()
    {
        RaycastHit hit;
        int randomNumber = Random.Range(0, 10);

        for (int j = 0; j < 4; j++)
        {
            int degrees = 0;
            int n = Random.Range(0, 7);
            switch (n)
            {
                case 0:
                    degrees += 0;
                    break;
                case 1:
                    degrees -= 90;
                    break;
                case 2:
                    degrees += 90;
                    break;
                default:
                    degrees += 0;
                    break;
            }
            Debug.Log("Degrees = " + degrees);

            if (!Physics.Raycast(this.transform.position, transform.forward * rayDistance, out hit, rayDistance))
            {
                GameObject spaceAvailabilityDetector = Instantiate(roadPrefab, this.transform.position + transform.forward * rayDistance, this.transform.rotation);
                spaceAvailabilityDetector.transform.parent = this.gameObject.transform.parent;
                instantiateRoads.roadTiles.Add(spaceAvailabilityDetector);
            }
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y + degrees, this.transform.rotation.z);
        }
    } 
    
    
    
The individual Rotation of each block, the spacing between each block, the activity of each block and the rotation of all the towers of once are all controlled by buttons. Each block individual rotates around a random axis basde on a toggle in the HUD, when the toggle is set to false it's rotation is reset to it's original rotation. The spacing is denoted by assigning the spacing of each block to the value of the spacing slider. The activity of each block is denoted by the index of each block in a list relative to the value on it's relative slider. If the index is greater than the value of the slider it will be set to true, otherwise it will be set to false. THe rotation of the towers is determined by 3 button clicks and they rotate around their parent's starting position. These three buttons rotate the towers right around the parents position, left around it, and stop the rotation all together.

Here is how the spacing between each block works, it's function is called in Update:

    public void ModifyTower()
    {
        float increasableValue = 0;
        foreach (GameObject g in instantiatedBlocks)
        {
            for (int i = 0; i < buildingHeight; i++)
            {
                increasableValue += (blockSpacing * buildingBlockPrefabs.Count / instantiatedBlocks.Count);

                for (int j = 0; j < buildingBlockPrefabs.Count; j++)
                {
                    buildingBlockPosition2 = new Vector3(this.transform.position.x, (j * blockSpacing + increasableValue) - (blockSpacing * j) - blockSpacing, this.transform.position.z);
                    g.transform.position = buildingBlockPosition2;
                }
            }
        }
    }
   
    
Here is how the activity of each block in their correlated list is set, this function is also called in Update:

    public void BlockActivity()
    {
        if (instantiateTowers != null)
            foreach (GameObject g in instantiateTowers.tileList)
            {
                fractalGeneration = g.GetComponentInChildren<FractalGeneration>();
                if (fractalGeneration != null)
                {
                    slider.maxValue = (instantiateTowers.tileList.Count - fractalGeneration.trackOfBlocks.Count) / 3.5f;
                }
                    float minSliderValue = 0;
                    slider.minValue = minSliderValue;
                    int listLength = g.GetComponent<BuildingGenerator>().instantiatedBlocks.Count;

                    for (int i = 0; i < listLength; i++)
                    {
                        if (i > slider.value)
                            g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(false);
                        if (i < slider.value)
                            g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(true);
                    }
            }
    }

# Initial Proposal
This repository will contain the source files and code on my journey of trying to create a 3D procedurally generated city.

I plan to procedurally generate buildings in a city using recursion. The position of each building may be random or manually assigned. Each layer of the building will be instantiated with a prefab. My goal is to try and model these prefabs myself however I don't have much experience in this area. I plan for the top layer of the buildings to use perlin noise. This will randomise the height of the roofs giving an undulating look to them. Depending on time and on the complexity of things I also may use fractals to instantiate additonal prefabs on the sides of base prefabs that make up the different layers of recursion. This will add diversity and uniqueness to the city. Hopefully I can generate a quasi random terran using perlin noise to surround the city and give an all round immersing feeling to the city. The scene may be interactive, allowing players to adjust the height of buildings and the offset, scale etc of the perlin noise and I could possibly implement some sort of moving character with a goal too.

I feel like the building positions will be assigned by a base tile that is assigned manually within a for loop or randomly using a different method that decides wether to place a tile or a nullable object in each sections of a grid. The recursion layers can be generated using for loops with randomised maximum iteration amounts. They could possibly randomly select different prefabs from an array. For the fractals I could try right a rule set that tells prefabs to instantiate corresponding prefabs on their sides/edges. I could randomly set the offset of a perlin noise texture for random height generation of terain/ rooftops that players can adjust with a slider or something along those lines as well.

# References

These references helped me along the way of this project:

FRACTALS:

https://www.youtube.com/watch?v=WFtTdf3I6Ug&t=193s

https://www.youtube.com/watch?v=0jwkZKDOzfc

https://www.youtube.com/watch?v=fkRnUoXacHM

PERLIN NOISE:

https://www.youtube.com/watch?v=bG0uEXV6aHQ

https://www.youtube.com/watch?v=sUDPfC1nH_E&t=176s

BRACKEY'S :

https://www.youtube.com/watch?v=64NblGkAabk

SHIP CONTROLLER:

https://www.youtube.com/watch?v=yu3RhF7fHd8
