# AzureWorkerService


https://docs.microsoft.com/en-us/azure/developer/mobile-apps/notification-hubs-backend-service-xamarin-forms, documentation is used and adapted to .net core.


dotnet user-secrets init
  - dotnet user-secrets set "NotificationHub:Name" <value>
  - dotnet user-secrets set "NotificationHub:ConnectionString" <value>
  
Replace the placeholder values with your own notification hub name and connection string values. You made a note of them in the create a notification hub section. Otherwise, you can look them up in Azure.

NotificationsHub:Name:
See Name in the Essentials summary at the top of Overview.

NotificationHub:ConnectionString:
See DefaultFullSharedAccessSignature in Access Policies
  
  
Loop up to tracked area:
  
Notification file is watched by the worker every 4 seconds and the json files inside are processed.

Example JsonFile:

{
"NotificationItems": [
  {
    "requestid": "1",
    "requestDesc": "TestNotification",
    "willBeLogged": true,
    "text": "Not2!",
    "action": "action_a",
    "tags": [
    ],
    "silent": false
  }
]
}
  
  
 There are some modifications in NotificationModel to make the modification more easy to manage. (More variables are added, easy to revert)

  




