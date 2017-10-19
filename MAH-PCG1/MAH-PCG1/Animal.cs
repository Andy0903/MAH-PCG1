namespace MAH_PCG1
{
    abstract class Animal
    {
        Taxon type; //Används ej.
        float minTemperature;
        float maxTemperature;
        float waterNeed;
        float oxygenNeed;
        float sunshineNeed;

        public static Animal GetRandomAnimal()
        {
            switch (Universe.random.Next(0, 11))
            {
                case 0: return new FishLikeOne();
                case 1: return new FishLikeTwo();
                case 2: return new FishLikeThree();
                case 3: return new PlantLoverOne();
                case 4: return new PlantLoverTwo();
                case 5: return new HunterOne();
                case 6: return new HunterTwo();
                case 7: return new WinterOne();
                case 8: return new WinterTwo();
                case 9: return new WinterThree();
                case 10: return new RandomAnimal();
            }


            //default case, won't happen.
            return new RandomAnimal();
        }

        public Animal(Taxon type, float minTemperature, float maxTemperature, float waterNeed, float oxygenNeed, float sunshineNeed)
        {
            this.type = type;
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.waterNeed = waterNeed;
            this.oxygenNeed = oxygenNeed;
            this.sunshineNeed = sunshineNeed;
        }

        public bool AliveCheck(Planet planet)
        {
            return (planet.OxygenPercentage >= this.oxygenNeed &&
                planet.SunshinePercentage >= this.sunshineNeed &&
                planet.WaterPercentage >= this.waterNeed &&
                (minTemperature <= planet.Temperature && planet.Temperature <= maxTemperature));
        }
    }

    class FishLikeOne : Animal
    {
        public FishLikeOne() : base(Taxon.Omnivore, 1, 40, 80, 15, 30) { }
    }

    class FishLikeTwo : Animal
    {
        public FishLikeTwo() : base(Taxon.Omnivore, -25, 30, 60, 35, 30) { }
    }

    class FishLikeThree : Animal
    {
        public FishLikeThree() : base(Taxon.Omnivore, 3, 39, 75, 75, 30) { }
    }

    class PlantLoverOne : Animal
    {
        public PlantLoverOne() : base(Taxon.Herbivore, -5, 24, 67, 75, 70) { }
    }

    class PlantLoverTwo : Animal
    {
        public PlantLoverTwo() : base(Taxon.Herbivore, -10, 20, 50, 50, 50) { }
    }

    class HunterOne : Animal
    {
        public HunterOne() : base(Taxon.Carnivore, -8, 25, 60, 65, 30) { }
    }

    class HunterTwo : Animal
    {
        public HunterTwo() : base(Taxon.Carnivore, 19, 54, 20, 45, 70) { }
    }

    class WinterOne : Animal
    {
        public WinterOne() : base(Taxon.Carnivore, -20, 3, 80, 45, 60) { }
    }

    class WinterTwo : Animal
    {
        public WinterTwo() : base(Taxon.Herbivore, -30, -3, 34, 52, 73) { }
    }

    class WinterThree : Animal
    {
        public WinterThree() : base(Taxon.Omnivore, -27, 6, 50, 52, 2) { }
    }

    class RandomAnimal : Animal
    {
        public RandomAnimal() : base((Taxon)Universe.random.Next(0, 3), Universe.random.Next(-100, 100), Universe.random.Next(-100, 100), Universe.random.Next(0, 101), Universe.random.Next(0, 101), Universe.random.Next(0, 101))
        {
        }
    }

}
