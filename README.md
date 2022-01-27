Hi evryone

for run this project, Change token in Controllers/MessageController and set webhook using this link: https://api.telegram.org/bot<Token>/setWebhook?url=<Url>/api/message
  
  You can use ngrok for generage a server using this command:
    ngrok http -host-header=localhost <Project Port>
  
  not: You can get project port in Properties/launchSettings.json
