using System;
using System.Linq;

namespace MAH_PCG1
{
    class Universe
    {
        public static Random random = new Random(1000);

        const int CandidateSize = 3000;
        Planet[] planets;

        static void Main()
        {
            Universe universe = new Universe();
            universe.Start();
        }

        void Start()
        {
            planets = new Planet[CandidateSize];
            for (int i = 0; i < CandidateSize; i++)
            {
                planets[i] = new Planet();
            }


            for (int i = 0; i < 500; i++)
            {
                float averageFitness = 0;
                foreach (Planet planet in planets)
                {
                    planet.Fitness = MeasureFitnessOfPlanets(planet);
                    averageFitness += planet.Fitness;
                }
                averageFitness /= planets.Length;

                planets = planets.OrderBy(x => x.Fitness).ToArray();

                //Console.WriteLine("\n-----------------------");
                //Console.WriteLine("Generation " + i + " Best: " + planets[planets.Length - 1].Fitness);
                //Console.WriteLine("Generation " + i + " Avg: " + averageFitness);
                //Console.WriteLine("Generation " + i + " Worst: " + planets[0].Fitness);
                //Console.WriteLine("-----------------------\n");


                //Console.WriteLine(planets[planets.Length - 1].Fitness);
                //Console.WriteLine((int)averageFitness);
                Console.WriteLine(planets[0].Fitness);

                int KillValue = planets.Length / 2;
                for (int j = 0; j < KillValue; j++)
                {
                    int backwardsCountingIndex = KillValue - j;
                    planets[j] = planets[backwardsCountingIndex];
                }

                CrossOver(KillValue);
                Mutate(KillValue);
            }
        }

        float MeasureFitnessOfPlanets(Planet planet)
        {
            int aliveAnimals = 0;

            for (int i = 0; i < planet.Animals.Length; i++)
            {
                if (planet.Animals[i].AliveCheck(planet))
                {
                    aliveAnimals++;
                }
            }

            return aliveAnimals;
        }

        void Mutate(int countToMutate)
        {
            const float mutationPercentage = 8;

            for (int i = 0; i < countToMutate; i++)
            {
                if (random.Next(0, 101) < mutationPercentage)
                {
                    float temperatureChange = random.Next(-10, 10);
                    float waterChange = random.Next(-10, 10);
                    float oxygenChange = random.Next(-10, 10);
                    float sunshineChange = random.Next(-10, 10);

                    Planet current = planets[i];
                    Planet mutated = new Planet
                        (current.Temperature + temperatureChange,
                        current.WaterPercentage + waterChange,
                        current.OxygenPercentage + oxygenChange,
                        current.SunshinePercentage + sunshineChange,
                        current.Animals);
                    planets[i] = mutated;
                }
            }
        }

        void CrossOver(int countToCrossOver)
        {
            const float crossOverPercentage = 75;

            for (int i = 0; i < countToCrossOver; i++)
            {
                if (random.Next(0, 101) < crossOverPercentage)
                {
                    Planet current = planets[i];
                    Planet other = planets[i + 1];

                    Planet child = new Planet(current.Temperature, current.WaterPercentage, other.OxygenPercentage, other.SunshinePercentage, current.Animals);

                    planets[i] = child;
                }
            }
        }
    }
}
