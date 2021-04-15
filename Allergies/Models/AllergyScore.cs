using System;
using System.Collections.Generic;

namespace Allergies.Models 
{
  public class AllergyScore 
  {
    public int Score { get; private set; }

    private List<int> allergenScores = new List<int> { 1, 2, 4, 8, 16, 32, 64, 128 };
    private List<string> allergens = new List<string> { "eggs", "peanuts", "shellsfish", "strawberries", "tomatoes", "chocolate", "pollen", "cats" };
   
    private Dictionary<int, string> allergenDict = new Dictionary<int, string>();

    public AllergyScore(int score) 
    {
      Score = score;
      for (int i = 0; i < allergens.Count; i++) {
        allergenDict.Add(allergenScores[i], allergens[i]);
      }
    }

    public void PrintAllergies() 
    {
      List<string> allergyList = new List<string>();

      int nextLowerAllergenScore;
      for (int currentNum = Score; currentNum >= 1; currentNum -= nextLowerAllergenScore) {
        nextLowerAllergenScore = FindNextLowerAllergenScore(currentNum);
        string newAllergen = allergenDict[nextLowerAllergenScore];
        allergyList.Add(newAllergen);
      }

      allergyList.Reverse();

      foreach (string allergy in allergyList) {
        Console.WriteLine(allergy);
      }
    }

    private int FindNextLowerAllergenScore(int num) 
    {
      for (int i = allergenScores.Count - 1; i >= 0; i--) {
        int allergenScore = allergenScores[i];
        if (num >= allergenScore)
        {
          return allergenScore;
        }
      }
      return 0;
    }
  }
}