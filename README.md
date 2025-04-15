# Introduction 
This repo contains the code necessary for running the Lighthouse pipeline.
The pipeline provides audits for multiple categories on multiple pages and url's.

# Getting Started
1.	Installation process
2.	Setting the config.json
3.	Overview of how the pipeline works

# Setting the config.json
The runLighthouse.js script reads the info contained in the config.json file.
- The "config" element allows you to set multiple usefull configurations:
    * mobile and/or desktop to true or false depending on the type of device you want to audit.
    * timeouts allows you to determine how fast each function lives in case of delay
    * retry allows you to determine how many times lighthouse can try to audit a page in case it's unable to connect
- The "sites" element allows you to set multiple sites.
    * name = the name of the website you're testing
    * url = the main url of the selected website
    * pages = an array of different pages you wish to add on the website. IMPORTANT: this is an extension of the mainurl
- The "categories" element allows you to choose which catogorie of audit you want to run. You have 4 different options: "accessibility", "best-practices", "performance", "seo". These you can add or delete depending on your needs
- The threshold" element allows you to set a minimum score that the test must achieve for each category. It is very important when setting a threshold that you write the cateogries in the same way as the 4 different options (as seen above).
- Example:

```
{
  "config": {
    "mobile": true,
    "desktop": true,
    "timeouts": {
      "curl": 20000,
      "lighthouse": 300000,
      "pageLoad": 30000
    },
    "retry": {
      "attempts": 5,
      "delay": 3000,
      "backoff": 1.5
    }
  },
  "sites": [
    {
      "name": "Nutreco",
      "url": "https://www.nutreco.com/",
      "pages": [
        "en/this-is-nutreco/",
      ]
    }
  ],
  "categories": ["accessibility", "best-practices", "performance", "seo"],
  "threshold": {
    "accessibility": 40,
    "best-practices": 40
  }
}
```

# Overview of how the pipeline works
The pipeline starts by installing Lighthouse and calling the run_lighthouse.js script. Here it sets the necessary options according to the config file and runs Lighthouse testing on the provided pages.
After it has done this, the results are published inside an artifcat.
This artifcat is downloaded by the second stage of the pipeline. In this second stage, the json reports provided by Lighthouse are converted to a TRX format and published to azure devops. This is done in order to accuratly display the acquired info in the "Test" tab of the azure devops pipeline.

The pipeline uses Volta to manage it's node version, volta is acquired through a platina script.
# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)