# Space Message Proxy

## Motivation
This Program is designed to translate Messages that are sent from Space over Webhooks to a Slack channel.

## Supported Endpoints:
/issueCreated
/issueStatusChange[filter=status]

## Payloads
issueWebhook:
```
payload: WebhookEvent {
  issue: Issue {
    createdBy: CPrincipal {
      name: string 
    },
    number: int, 
    title: string, 
    channel: M2ChannelRecord {
      contact: M2ChannelContact {
        ext: M2ChannelContactInfo {
          projectKey: ProjectKey {
            key: string
          }
        }
      }
    },
    description: string?
  },
  status: {
    new: IssueStatus {
      name: string
    },
    old: IssueStatus {
      name: string
    }
  }
}
```

## Configuration
### Slack
- create an application (api.slack.com)
- Add the feature "incoming webhooks"
- create a new webhook url and bind it to a channel

### Space
1. create an application in the scope of a project
2. in the application, create webhooks to send messages to the proxy application
3. in the webhook, make sure you provide all needed information fot the proxy application
   - The Endpoint URL (see supported endpoints)
   - the header value for `x-slack-url` (whe incoming webhook url of your slack application)
   - the header value for `x-space-url` (the hostname of your space instance, to provide the correct links)
   - customize the payload to match the information above

## Deployment
The Web Api is served as a containerized Web App on Azure.
To build the image locally with the .NET 7 publish image method simply run:
- dotnet publish --os linux --arch x64 --configuration Release -p:PublishProfile=DefaultContainer -p:PublishSingleFile=true -p:SelfContained=true -p:PublishReadyToRun=true

## Prerequisites

### Github 
To push the App to the Github Container registry with github Actions and the provided token, you will have to push the image manually at the first time. After that you can configure the registry for pushes with the token.
https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry#pushing-container-images

### Azure 
To authenticate from Github actions to azure for deploying the webapp please follow the instructions:

1. create a resource group
    - `az group create --name <resourceGroupName> --location euwest`
2. create an app service plan
   - az appservice plan create -n <app-service-plan-name> -g <resource-group-name> --is-linux
3. create a containerized web app
    - `az webapp create -n <web-app-name> -g <resource-group-name> -p <app-service-plan-name> -i ghcr.io/<organization>/<image-name>:latest`
4. create a managed identity
    - `az ad sp create-for-rbac --name <identity-name> --role contributor \
      --scopes /subscriptions/<subscription-id>/resourceGroups/<resource-group-name> \
      --sdk-auth`
    - save the output for Github action secrets
### Github Action Secrets/Variabes
AZURE_CREDENTIALS = the output from 4.
RESOURCE_GROUP = Name of the resource group
APP_NAME = name of the app
APP_SERVICE_PLAN = name of the App Service Plan

!Important
- Maybe it takes some time (more than 3 hours) for azure to synchronize your apps around the globe. If you are running your apps in e.g. west europe but the github action runner is hosted in the USA, please wait some time and got not confused, that an action will fail.