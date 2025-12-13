using MediatR;

namespace RecruitmentNotifications.Messages;

public record BaseEvent : INotification
{
    DateTime SentAt { get; init; } = DateTime.UtcNow;
}
