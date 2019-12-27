using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AdaptiveCards;
using AdaptiveCardsBot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using static Microsoft.IdentityModel.Xml.WsTrustConstants_1_3;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaptiveCardsBot.Controllers
{
    [Route("api/[controller]")]
    public class AdaptiveCardController : Controller
    {

       
        // GET: api/<controller>
        [HttpGet]
        public object Get()
        {



            //Check file in folder
            //string folderName = "Resources";
            //dynamic files = _repositorySystemMethod.GetFileNames(folderName);

            //Read each file

            List<object> listOfObject = new List<object>();

            //foreach (var item in files)
            //{
            //    var singleFile = _repositorySystemMethod.ReadFile(folderName, item);
            //    listOfObject.Add(singleFile);

            //}

            return listOfObject;
            ////Check file in folder

            //DirectoryInfo d = new DirectoryInfo(Path.Combine("Resources"));
            //FileInfo[] Files = d.GetFiles("*.json");
            //List<object> listOfFiles = new List<object>();
            //foreach (FileInfo file in Files)
            //{
            //    string singleFile = "";
            //    singleFile = file.Name;
            //    listOfFiles.Add(singleFile);
            //}

            ////Read Each file and bind into list

            //List<object> listOfItem = new List<object>();
            //foreach (var fileName in listOfFiles)
            //{
            //    using (StreamReader r = new StreamReader(Path.Combine(".", "Resources", fileName.ToString())))
            //    {
            //        string json = r.ReadToEnd();
            //        object items = JsonConvert.DeserializeObject<object>(json);
            //        listOfItem.Add(items);

            //    }
            //}

            //return listOfItem;
        }

        // GET api/<controller>/5
        [HttpGet("{cardName}")]
        public object Get(string cardName)
        {
            //Check file in folder
            string folderName = "Resources";
            dynamic singleFile = "";
            //if (!string.IsNullOrEmpty(cardName))
            //{
            //    singleFile = _repositorySystemMethod.ReadFile(folderName, cardName.ToLower());

            //}

            //else
            //{
            //    return "Please enter valid adaptive card name!";
            //}

            return singleFile;

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]AdaptiveCardModel value)
        {
            //Extract value from param
            string jsonResult = JsonConvert.SerializeObject(value);
            string cardName = value.AdaptiveCardName;
            cardName = cardName.Replace(" ", "");

            //Adaptive Card Instance

            AdaptiveCard card = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0));

            // Check value
            if (value.RichTextBlock == "RichTextBlock")
            {
                card.Body.Add(new AdaptiveTextBlock()
                {
                    Type = "TextBlock",
                    Text = "" + value.RichTextBoxTextValue + "",
                    Size = AdaptiveTextSize.Medium
                });

            }


            if (value.TextBox == "Input.Text")
            {
                card.Body.Add(new AdaptiveTextInput()
                {

                    Id = "" + value.TextBox.Trim() + "",
                    //Speak = "<s>Please Enter Your Name</s>",
                    Placeholder = "Please Enter Your Name",
                    Style = AdaptiveTextInputStyle.Text

                });

            }

            if (value.Image == "Image")
            {
                card.Body.Add(new AdaptiveImage()
                {
                    Type = "Image",
                    Url = new Uri("" + value.ImageUrl + "")
                });
            }

            //

            card.Body.Add(new AdaptiveColumnSet()
            {

                Columns = new List<AdaptiveColumn>
                {
                    //Column 1
                    new AdaptiveColumn()
                    {
                        Type= "Column",
                        Width= "auto",
                       //Type = "TextBlock",
                       //Width = "auto",
                       Items = new List<AdaptiveElement>()
                       {
                        new AdaptiveTextBlock()
                                {
                                    Text= "name",
                                    Weight= AdaptiveTextWeight.Bolder,
                                    Separator=true,
                                    Size = AdaptiveTextSize.Large,
                                },
                          new AdaptiveTextInput()
                                {
                                    Id = "Your Name",
                                    Speak ="<s>Please Enter Your Name</s>",
                                    Placeholder = "Please Enter Your Name",
                                    Style = AdaptiveTextInputStyle.Text
                                },
                          new AdaptiveImage()
                          {
                              Type="Image",
                              Url= new Uri("https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg"),
                              Size = AdaptiveImageSize.Small,
                              Style = AdaptiveImageStyle.Person
                          }
                       }





                    },
                   //Column 2
                    new AdaptiveColumn()
                    {
                        Type= "Column",
                        Width= "auto",
                       //Type = "TextBlock",
                       //Width = "auto",
                       Items = new List<AdaptiveElement>()
                       {
                        new AdaptiveTextBlock()
                                {
                                    Text= "name",
                                    Weight= AdaptiveTextWeight.Bolder,
                                    Separator=true,
                                    Size = AdaptiveTextSize.Large,
                                },
                          new AdaptiveTextInput()
                                {
                                    Id = "Your Name",
                                    Speak = "<s>Please Enter Your Name</s>",
                                    Placeholder = "Please Enter Your Name",
                                    Style = AdaptiveTextInputStyle.Text
                                },
                          new AdaptiveImage()
                          {
                              Type="Image",
                              Url= new Uri("https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg"),
                              Size = AdaptiveImageSize.Small,
                              Style = AdaptiveImageStyle.Person
                          }
                       }





                    },
                   //Column 3
                    new AdaptiveColumn()
                    {
                        Type= "Column",
                        Width= "auto",
                       //Type = "TextBlock",
                       //Width = "auto",
                       Items = new List<AdaptiveElement>()
                       {
                        new AdaptiveTextBlock()
                                {
                                    Text= "name",
                                    Weight= AdaptiveTextWeight.Bolder,
                                    Separator=true,
                                    Size = AdaptiveTextSize.Large,
                                },
                          new AdaptiveTextInput()
                                {
                                    Id = "Your Name",
                                    Speak = "<s>Please Enter Your Name</s>",
                                    Placeholder = "Please Enter Your Name",
                                    Style = AdaptiveTextInputStyle.Text
                                },
                          new AdaptiveImage()
                          {
                              Type="Image",
                              Url= new Uri("https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg"),
                              Size = AdaptiveImageSize.Small,
                              Style = AdaptiveImageStyle.Person
                          }
                       }





                    }
                }




            });

            card.Actions.Add(new AdaptiveSubmitAction()
            {
                Type = "" + value.ButtonTypeValue + "",
                Title = "" + value.ButtonName + "",
                Data = "show me the next card",
                DataJson = ""
            });

            //new AdaptiveContainer
            //{
            //    Style = AdaptiveContainerStyle.Emphasis,
            //    Items = new List<AdaptiveElement>
            //                {
            //                    new AdaptiveTextBlock()
            //                    {
            //                        Text = "Item2 2"
            //                    }
            //                },
            //    SelectAction = new AdaptiveSubmitAction
            //    {
            //        Data = "Item 2 - I need this to be shown in webchat after user clicks",
            //        AdditionalProperties = new Dictionary<string, object> { { "BackroudProp", "Value" } }
            //    }
            //};

            //var button = new CardAction()
            //{
            //    Title = "Option 1",
            //    Type = "invoke",
            //    Value = "{\"option\": \"opt1\"}"
            //};








            //card.Body.Add(new AdaptiveTextBlock()
            //{
            //    Type = "Input.Text",
            //    Size = AdaptiveTextSize.Medium
            //});

            //card.Body.Add(new AdaptiveImage()
            //{
            //    Url = new Uri("http://adaptivecards.io/content/cats/1.png")
            //});

            // serialize the card to JSON
            string json = card.ToJson();


            //Save json File in folder
            try
            {
                if (System.IO.File.Exists("AdaptiveCardJson/" + cardName + ".json"))
                    System.IO.File.Delete("AdaptiveCardJson/" + cardName + ".json");
                var W = new StreamWriter("AdaptiveCardJson/" + cardName + ".json");
                W.WriteLine(json);
                W.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    ////string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AdaptiveCardJson/Testcard1.json");
    //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AdaptiveCardJson");
    //// string[] files = File.ReadAllLines(path);
}
