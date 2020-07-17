# Project Name

<img src="https://developer.nexmo.com/assets/images/Vonage_Nexmo.svg" height="48px" alt="Nexmo is now known as Vonage" />

<!-- Add a paragraph about the project. What does it do? Who is it for? Is it actively supported? Your reader just clicked on a random link from another web page and has no idea what Nexmo is ... -->

## Welcome to Nexmo

<!-- change "github-repo" at the end of the link to be the name of your repo, this helps us understand which projects are driving signups so we can do more stuff that developers love -->

If you're new to Nexmo, you can [sign up for a Nexmo account](https://dashboard.nexmo.com/sign-up?utm_source=DEV_REL&utm_medium=github&utm_campaign=github-repo) and get some free credit to get you started.




<!-- add other sections as appropriate for your repo type -->

## Prequisites

* We're going to need a Vonage Communications API Account, if you don't have one you can [sign up here](https://dashboard.nexmo.com/sign-up)
* We'll need Visual Studio 2019 to use Blazor WebAssembly
* We're going to be using [Ngrok](https://ngrok.com/) for testing

## Run Ngrok

Run ngrok will the command:

```text
ngrok http --host-header=localhost:5000 5000
```

## Update Configuration

Find your api key and api secret in [Vonage Dashboard](https://dashboard.nexmo.com), open up the `VonageSmsDashboard.Server/appsettings.json` file and change the `API_KEY` and `API_SECRET` to your api key and secret respectively.

## Configure Webhooks

Runnign the ngrok command will result in a public facing url looking like: `http://fb09abd3c106.ngrok.io`. Go to your [Vonage Dashboard](https://dashboard.nexmo.com/settings) and chagne the url for inbound messages and delivery receipts to `https://your.ngrok.hostname/webhooks/inbound-sms` and `https://your.ngrok.hostname/webhooks/dlr` respectively, change the type to `POST-JSON` and click submit to change everything.

## Run Your App

You can run the app either directly from Visual Studio, or using the .NET CLI in the `VonageSmsDashboard.Server` folder using the `dotnet run` command.


## Getting Help

We love to hear from you so if you have questions, comments or find a bug in the project, let us know! You can either:

* Open an issue on this repository
* Tweet at us! We're [@NexmoDev on Twitter](https://twitter.com/NexmoDev)
* Or [join the Nexmo Community Slack](https://developer.nexmo.com/community/slack)

## Further Reading

* Check out the Developer Documentation at <https://developer.nexmo.com>

<!-- add links to the api reference, other documentation, related blog posts, whatever someone who has read this far might find interesting :) -->


