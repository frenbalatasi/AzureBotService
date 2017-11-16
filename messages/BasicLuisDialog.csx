using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I certainly didn't understand what you just said. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("Greeting")]
    public async Task GreetingIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hello there. What can I do for you?");
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("Communication.AddContact")]
    public async Task AddContactIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I added your contact to your contact list.");
        context.Wait(MessageReceived);
    }
    [LuisIntent("Note.AddToNote")]
    public async Task AddNoteIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I added your note.");
        context.Wait(MessageReceived);
    }
}