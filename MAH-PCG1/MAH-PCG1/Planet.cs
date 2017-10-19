
namespace MAH_PCG1
{
    class Planet
    {
        public float Temperature { get; private set; }
        public float WaterPercentage { get; private set; }
        public float OxygenPercentage { get; private set; }
        public float SunshinePercentage { get; private set; }
        public Animal[] Animals { get; private set; }

        public float Fitness { get; set; }

        public Planet()
        {
            Temperature = Universe.random.Next(-100, 101);
            WaterPercentage = Universe.random.Next(0, 101);
            OxygenPercentage = Universe.random.Next(0, 101);
            SunshinePercentage = Universe.random.Next(0, 101);

            const int animalsSize = 500;
            Animals = new Animal[animalsSize];
            for (int i = 0; i < animalsSize; i++)
            {
                Animals[i] = Animal.GetRandomAnimal();
            }
        }

        public Planet(float temperature, float waterPercentage, float oxygenPercentage, float sunshinePercentage, Animal[] animals)
        {
            Temperature = temperature;
            WaterPercentage = waterPercentage;
            OxygenPercentage = oxygenPercentage;
            SunshinePercentage = sunshinePercentage;
            Animals = animals;
        }
    }
}
