using RecruitmetNotifications.Messages;

namespace RecruitmetNotifications.Servises;

public interface IMessageSender
{
    Task NotifyInterviewScheduled(InterviewScheduledEvent message, CancellationToken cancellationToken);
    Task NotifyInterviewRescheduled(InterviewRescheduledEvent message, CancellationToken cancellationToken);
    Task NotifyInterviewCancelled(InterviewCancelledEvent message, CancellationToken cancellationToken);
    Task NotifyCandidatePassedToInterview(CandidatePassedToIntershipEvent message, CancellationToken cancellationToken);
}
