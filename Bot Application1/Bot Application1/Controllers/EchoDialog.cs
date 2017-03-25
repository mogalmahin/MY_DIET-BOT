using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
namespace Bot_Application1.Controllers
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            string msg = message.Text;
            if (msg.ToLower().Contains("hi"))
            {
                await context.PostAsync("Hi,How can i help you?");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("can you show me my diet chart") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("Yes,First lets calculate your Body mass index (BMI)");
                await context.PostAsync("Tell me your height and weight respectively");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("5.4 and 50kgs") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("Your BMI is 18.9 ");
                await context.PostAsync("Underweight = < 18.5, Normal weight = 18.5–24.9, Overweight = BMI of 25 or greater");
                await context.PostAsync("You are Normal Weight. Happy eating!");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("6.0 and 45kgs") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("Your BMI is 13.5 ");
                await context.PostAsync("Underweight = < 18.5, Normal weight = 18.5–24.9, Overweight = BMI of 25 or greater");
                await context.PostAsync("You are Under Weight. Have proper food!");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("5.5 and 80kgs") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx"))
            {
                await context.PostAsync("Your BMI is 29.3 ");
                await context.PostAsync("Underweight = < 18.5, Normal weight = 18.5–24.9, Overweight = BMI of 25 or greater");
                await context.PostAsync("You are Over Weight. Follow healthy diet!");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Please check your input");
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}





