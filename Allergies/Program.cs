using System;
using Allergies.Models;

namespace Allergies {
  public class Program {
    public static void Main() {

      bool keepRunning;
      do {
        Console.WriteLine("Enter your allergy score: ");
        int scoreInput = int.Parse(Console.ReadLine());
        AllergyScore allergyScore = new AllergyScore(scoreInput);
        
        allergyScore.PrintAllergies();

        Console.WriteLine("Go again? (y/n)");
        keepRunning = Console.ReadLine() == "y";
        Console.WriteLine();
      } while (keepRunning);
    }
  }
}