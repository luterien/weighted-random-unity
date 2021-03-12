using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class WeightedRandom<T>
{
    public static T GetOne(List<Weighted<T>> objects)
    {
        int totalWeight = objects.Sum(obj => obj.Weight);
        int randNum = Random.Range(0, totalWeight + 1);

        int currentTotal = 0;

        foreach (Weighted<T> obj in objects)
        {
            if (randNum >= currentTotal && randNum <= currentTotal + obj.Weight)
                return obj.Key;

            currentTotal += obj.Weight;
        }

        throw new UnityException("Weighted Random error");
    }

    public static List<T> GetAll(List<Weighted<T>> objects, int count)
    {
        int MAX_TRIES = 15;

        List<T> results = new List<T>();

        int totalWeight = objects.Sum(obj => obj.Weight);
        int tries = 0;

        int randNum;
        int currentTotal;

        while (results.Count <= count && tries <= MAX_TRIES)
        {
            randNum = Random.Range(0, totalWeight + 1);
            currentTotal = 0;
            tries += 1;

            foreach (Weighted<T> obj in objects)
            {
                if (randNum >= currentTotal && randNum < currentTotal + obj.Weight &&
                    !results.Contains(obj.Key))
                {
                    results.Add(obj.Key);

                    if (results.Count >= count)
                        return results;
                }

                currentTotal += obj.Weight;
            }
        }

        return results;
    }
}