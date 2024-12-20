using Domain.Models.AiAssistanc.Enums;
using Domain.Models.AiAssistanc;
using System.Text;
using Core.Interfaces.Providers;
using Application.Services.AiAssistant.Interfaces;
using Domain.Models;

namespace Application.Services.AiAssistant;
public class PromptBuilder : IPromptBuilder

{
    public PromptBuilder()
    {
    }
    private static string UserDataString(UserData userData)
    {
        var parameters = new List<string>();
        if (userData.Age > 0)
            parameters.Add($"Age: {userData.Age}");
            parameters.Add($"Gender: {userData.Gender}");
            parameters.Add($"Activity: {userData.ActivityLevel}");
        if (userData.Weight > 0)
            parameters.Add($"Weight: {userData.Weight}kg");
        if (userData.Height > 0)
            parameters.Add($"Height: {userData.Height}cm");
        if (userData.GoalBodyFatPercentage > 0)
            parameters.Add($"Goal body fat percentage: {userData.GoalBodyFatPercentage}%");
        if (userData.GoalMuscleMassPercentage > 0)
            parameters.Add($"Goal muscle mass percentage: {userData.GoalMuscleMassPercentage}%");
        if (userData.GoalWeight > 0)
            parameters.Add($"GoalWeight: {userData.GoalWeight}kg");
        if (userData.Bmr > 0)
            parameters.Add($"BMR: {userData.Bmr}");

        return $"Params: {string.Join(", ", parameters)}";
    }
    
    public string BuildPrompt(string prompt, string AiContext, Guid sessionId, IEnumerable<Message>? initialMessages = null, UserData? userData = null)
    {
        StringBuilder builder = new();

        builder.AppendLine(AiContext);

        if (userData is not null)
        {
            builder.Append(UserDataString(userData));
        }

        if (initialMessages is not null)
        {
            foreach (Message msg in initialMessages)
            {
                builder.AppendLine($"role : {msg.Sender}, content: {msg.Content}");
            }
        }
        builder.AppendLine(prompt);

        return builder.ToString();
    }
}
