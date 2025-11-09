using MassTransit;
using RecruitmetNotifications.Messages;

namespace RecruitmetNotifications.Servises;

public class MessageSender(IPublishEndpoint publishEndpoint) : IMessageSender
{
    public Task NotifyCandidatePassedToInterview(CandidatePassedToInternshipEvent message,
        CancellationToken cancellationToken) => publishEndpoint.Publish(message, cancellationToken);

    public Task NotifyInterviewCancelled(InterviewCancelledEvent message,
        CancellationToken cancellationToken) => publishEndpoint.Publish(message, cancellationToken);

    public Task NotifyInterviewRescheduled(InterviewRescheduledEvent message,
        CancellationToken cancellationToken) => publishEndpoint.Publish(message, cancellationToken);

    public Task NotifyInterviewScheduled(InterviewScheduledEvent message,
        CancellationToken cancellationToken) => publishEndpoint.Publish(message, cancellationToken);
}
