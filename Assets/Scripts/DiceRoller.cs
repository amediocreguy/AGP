using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    public TMP_Text chatBox; // Reference to the TMP Text element for the chat box

    // Function to roll a specific-sided dice
    private int RollDice(int sides)
    {
        return Random.Range(1, sides + 1);
    }

    // Function to display the result in the chat box
    private void DisplayResult(int result, int sides)
    {
        chatBox.text += "You rolled a " + sides + "-sided dice and got: " + result + "\n";
    }

    // Functions for each type of dice
    public void RollD4()
    {
        int result = RollDice(4);
        DisplayResult(result, 4);
    }

    public void RollD6()
    {
        int result = RollDice(6);
        DisplayResult(result, 6);
    }

    public void RollD8()
    {
        int result = RollDice(8);
        DisplayResult(result, 8);
    }

    public void RollD10()
    {
        int result = RollDice(10);
        DisplayResult(result, 10);
    }

    public void RollD12()
    {
        int result = RollDice(12);
        DisplayResult(result, 12);
    }

    public void RollD20()
    {
        int result = RollDice(20);
        DisplayResult(result, 20);
    }

    public void RollD100()
    {
        int result = RollDice(100);
        DisplayResult(result, 100);
    }
}
