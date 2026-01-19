# RecruitmentNotifications

A lightweight messaging module for recruitment and HR systems.
This library provides an abstraction for publishing notification events through MassTransit using RabbitMQ.

## Key Features

✅ Strongly-typed event contracts (record events)

✅ IMessageSender abstraction — no MassTransit leaks into your application layer

✅ Clean AddNotifications() DI extension for effortless setup

✅ Uses RabbitMQ, fully configurable from appsettings.json

## 📦 Installation

Add the NuGet package:

```bash
dotnet add package RecruitmentNotifications
```

Or update your .csproj:

```
<PackageReference Include="RecruitmentNotifications" Version="1.0.0" />
```

## ⚙️ Configuration

Insert RabbitMQ settings into your configuration:

```javascript
"RabbitMQ": {
  "UserName": "guest",
  "Password": "guest",
  "HostName": "localhost",
  "VirtualHostName": "/"
}
```

## 🏗️ Dependency Injection

Register the notification messaging service:

```c#
builder.Services.AddNotifications(builder.Configuration);
```

This automatically:

-Registers IMessageSender
-Configures MassTransit
-Connects to RabbitMQ
-Applies endpoint naming convention

## 📤 Publishing Notifications (Usage Example)

Inject and call the messaging service anywhere in your Application layer:

```c#
public class CandidateAcceptedHandler
{
    private readonly IMessageSender _messageSender;

    public CandidateAcceptedHandler(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public Task HandleAsync(string candidateEmail, CancellationToken cancellationToken)
    {
        var evt = new CandidatePassedToIntershipEvent(candidateEmail);
        return _messageSender.NotifyCandidatePassedToInterview(evt, cancellationToken);
    }
}
```

No RabbitMQ knowledge needed.
No MassTransit dependency in your Domain/Application layers.
Just a clean, intention-revealing API.

## 📨 Available Events
Event	Description
CandidatePassedToIntershipEvent	Candidate moved to internship stage
InterviewScheduledEvent	Interview successfully scheduled
InterviewRescheduledEvent	Interview moved to a new date/time
InterviewCancelledEvent	Interview canceled

Add more events at any time — the messaging surface stays stable.

## 🧪 Local Development with RabbitMQ

Spin up RabbitMQ using Docker:

```bash
docker run -d --hostname rabbit --name rabbitmq \
 -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

Dashboard: http://localhost:15672

Default login: guest / guest

## 📄 License

MIT — free to use, modify, and integrate in commercial systems.
