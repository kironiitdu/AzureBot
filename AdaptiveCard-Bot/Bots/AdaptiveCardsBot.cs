// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using AdaptiveCardsBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using AdaptiveCards.Templating;


namespace Microsoft.BotBuilderSamples
{
    // This bot will respond to the user's input with an Adaptive Card.
    // Adaptive Cards are a way for developers to exchange card content
    // in a common and consistent way. A simple open card format enables
    // an ecosystem of shared tooling, seamless integration between apps,
    // and native cross-platform performance on any device.
    // For each user interaction, an instance of this class is created and the OnTurnAsync method is called.
    // This is a Transient lifetime service. Transient lifetime services are created
    // each time they're requested. For each Activity received, a new instance of this
    // class is created. Objects that are expensive to construct, or have a lifetime
    // beyond the single turn, should be carefully managed.

    public class AdaptiveCardsBot : ActivityHandler
    {
        private const string WelcomeText = @"Microsoft Cloud Enablement Desk";

        // This array contains the file location of our adaptive cards
        private readonly string[] _cards =
        {
            Path.Combine(".", "Resources", "MicrosoftCloudEnablementDeskFormCard.json")

        };
        //public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        //{
        //    await SendWelcomeMessageAsync(turnContext, cancellationToken);
        //}
        protected override async Task OnEventActivityAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendWelcomeMessageAsync(turnContext, cancellationToken);
        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await SendWelcomeMessageAsync(turnContext, cancellationToken);
        }



        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {

            //Card Global Variable

            dynamic cardAttachment;
            dynamic activityValue = turnContext.Activity.Value;
            dynamic checkUserInput = turnContext.Activity.Text;

            if (checkUserInput == "start over".ToLower() || checkUserInput == "exit".ToLower() || checkUserInput == "quit".ToLower() || checkUserInput == "done".ToLower() || checkUserInput == "start again".ToLower() || checkUserInput == "restart".ToLower() || checkUserInput == "leave".ToLower() || checkUserInput == "reset".ToLower() || checkUserInput == "clear".ToLower())
            {
                turnContext.Activity.AsEndOfConversationActivity();
            }
            //Check The User Type Message
            if (turnContext.Activity.Text != null)
            {
                turnContext.Activity.AsEndOfConversationActivity();
                // await turnContext.SendActivityAsync(MessageFactory.Text("Would you like to submit request?"), cancellationToken);
                //cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "UserResponse.json"));
                //await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
            }

                      

                switch (checkUserInput)
            {
                case "":
                    cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "UserResponse.json"));
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                    break;
                case "hello":
                    cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "UserResponse.json"));
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                    break;
            }
            // Random r = new Random();
            //var cardAttachment = CreateAdaptiveCardAttachment(_cards[r.Next(_cards.Length)]);
            //var cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "UserResponse.json"));

            //Captature sumitted value
            var txt = turnContext.Activity.Text;
            dynamic val = turnContext.Activity.Value;

            // Check if the activity came from a submit action
            if (string.IsNullOrEmpty(txt) && val != null)
            {
                // Retrieve the data from the id_number field
                //var num = double.Parse(val.SimpleVal);
                dynamic valueFromUser = val.value;


                try
                {
                    dynamic checkUserConsent = valueFromUser.Value;
                    //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GlobalClassLibrary/Resources/KironTestCard.jsons");
                    switch (checkUserConsent)
                    {
                        case "yes":
                            // cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "MicrosoftCloudEnablementDeskFormCard.json"));
                                cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".\\bin\\debug\\netcoreapp2.1", "Resources", "KironTestCard.json"));  
                            await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                            break;
                        case "no":
                            await turnContext.SendActivityAsync(MessageFactory.Text("Thanks for your interaction..."), cancellationToken);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    try
                    {
                        if (string.IsNullOrEmpty(txt) && val != null)
                        {
                            // Retrive all user value
                            dynamic newVal = val.RequestSubmit;
                            dynamic firstName = val.firstName;
                            dynamic lastName = val.lastName;
                            dynamic company = val.companyName;
                            dynamic email = val.email;
                            dynamic country = val.CompactSelectVal;
                            dynamic phoneNumber = val.phoneNumber;
                            dynamic mpnId = val.mpnId;

                            // Check Null value and prompt user

                            if (val.firstName == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  first name!"), cancellationToken);
                            }
                            else if (val.lastName == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  last name!"), cancellationToken);
                            }
                            else if (val.companyName == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  company name!"), cancellationToken);
                            }
                            else if (val.email == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  email!"), cancellationToken);
                            }
                            else if (val.country == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  country!"), cancellationToken);
                            }
                            else if (val.phoneNumber = "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  phone number!"), cancellationToken);
                            }
                            else if (val.mpnId == "")
                            {
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Please enter  MPN Id!"), cancellationToken);
                            }
                            else
                            {
                                // CloudEnablementDeskReqeust objModel = new CloudEnablementDeskReqeust();

                                await turnContext.SendActivityAsync(MessageFactory.Text("You have submitted " + Environment.NewLine + firstName + " , " + Environment.NewLine + lastName + "," + Environment.NewLine + email + "," + Environment.NewLine + company + "," + Environment.NewLine + phoneNumber + "," + Environment.NewLine + mpnId + "," + Environment.NewLine + country), cancellationToken);
                                await turnContext.SendActivityAsync(MessageFactory.Text(" Thanks for your interaction..."), cancellationToken);
                            }

                        }

                    }
                    catch (Exception)
                    {
                        await turnContext.SendActivityAsync("Keep writting I am listening...");
                    }
                }


            }


        }

        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(
                        //  $"Welcome to Adaptive Cards Bot {member.Name}. {WelcomeText}",
                        $"Welcome to  {WelcomeText}",
                        cancellationToken: cancellationToken);
                    //Ask user
                    await turnContext.SendActivityAsync(MessageFactory.Text("Would you like to submit request?"), cancellationToken);
                    // Prompt User For Request
                    var cardAttachment = CreateAdaptiveCardAttachment(Path.Combine(".", "Resources", "UserResponse.json"));
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                    
                }
            }
        }

        private static Attachment CreateAdaptiveCardAttachment(string filePath)
        {
            var templateJson = @"
{
    

  ""type"": ""AdaptiveCard"",
  ""version"": ""1.0"",
  ""body"": [
    {
      ""type"": ""TextBlock"",
      ""text"": ""Hello {name}""
    },
   {
      ""type"": ""TextBlock"",
      ""text"": ""Hello {name}""
    },
  {
      ""type"": ""TextBlock"",
      ""text"": ""Hello {name}""
    }
  ],
  ""actions"": [
    {
      ""type"": ""Action.ShowCard"",
      ""title"": ""Action.ShowCard"",
      ""card"": {
        ""type"": ""AdaptiveCard"",
        ""body"": [
          {
            ""type"": ""TextBlock"",
            ""text"": ""What do you think?""
          }
        ],
        ""actions"": [
          {
            ""type"": ""Action.Submit"",
            ""title"": ""Neat!""
          }
        ]
      }
    }
  ]
}";

            var dataJson = @"
{
    ""name"": ""Mickey Mouse""
}";

            var transformer = new AdaptiveTransformer();
            var cardJson = transformer.Transform(templateJson, dataJson);

            // RND Area
            var adaptiveCardJson = File.ReadAllText(filePath);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                 Content = JsonConvert.DeserializeObject(adaptiveCardJson),
               // Content = JsonConvert.DeserializeObject(cardJson),
            };
            return adaptiveCardAttachment;
        }

        public static async Task<HttpResponseMessage> SendRequest([FromBody]dynamic param)
        {


            // Call QnA API             
            var jsonContent = JsonConvert.SerializeObject(param);
            var endpointKey = "c4b3d4a2-ba24-46f5-9ad7-ccb4e7980da6";
            var qnaMakerURI = "http://localhost:7071/api/PartnerBotDownloadSoftware";
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(qnaMakerURI);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", "EndpointKey" + endpointKey);

                var response = await client.SendAsync(request);


                //Check status code and retrive response

                if (response.IsSuccessStatusCode)
                {

                    dynamic objQnAResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                    var responseBody = await objQnAResponse.Content.ReadAsStringAsync();
                    return responseBody;


                }
                else
                {
                    dynamic result_string = await response.Content.ReadAsStringAsync();
                    return result_string;
                }

            }
        }
        
    }
}





