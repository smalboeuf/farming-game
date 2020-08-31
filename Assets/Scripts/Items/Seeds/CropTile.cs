using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTile
{

    private Seed plantedSeed;
    private int daysPlanted;

    //Constructor
    public CropTile(Seed newSeed) {
        plantedSeed = newSeed;
    }

    public Seed GetPlantedSeed() {
        return plantedSeed;
    }
}
