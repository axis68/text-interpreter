﻿using Azure;
using Azure.AI.OpenAI;

var client = new OpenAIClient(
  new Uri("https://xxxxxx-oai-openaisandbox-1.openai.azure.com/"), // Enter here the server url 
  new AzureKeyCredential("12345678901234567890123456789012"));            // Insert here your Azure Key

var responseWithoutStream = await client.GetChatCompletionsAsync(
 new ChatCompletionsOptions()
  {
    DeploymentName = "gpt-35-turbo",
    Messages =
    {
      new ChatRequestSystemMessage("You are a lexical analyser"),
      new ChatRequestUserMessage("Look at the window, click the dog and finally select the page"),
      new ChatRequestAssistantMessage("{ Action: 'Look', Object: 'window' }, { Action: 'Click', Object: 'dog' }, { Action: 'Select', Object: 'page' }"),
      new ChatRequestUserMessage("Select the menu and click the button"),
    },
    Temperature = (float)0,
    MaxTokens = 350,

    NucleusSamplingFactor = (float)0.95,
    FrequencyPenalty = 0,
    PresencePenalty = 0,
  });


var response = responseWithoutStream.Value;
Console.WriteLine($"Chat gpt's answer: {response.Choices[0].Message.Content}");