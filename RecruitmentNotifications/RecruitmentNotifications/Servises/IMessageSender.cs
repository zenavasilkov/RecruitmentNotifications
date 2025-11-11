using RecruitmentNotifications.Messages;

namespace RecruitmentNotifications.Servises;

public interface IMessageSender
{
    Task NotifyInterviewScheduled(InterviewScheduledEvent message, CancellationToken cancellationToken);
    Task NotifyInterviewRescheduled(InterviewRescheduledEvent message, CancellationToken cancellationToken);
    Task NotifyInterviewCancelled(InterviewCancelledEvent message, CancellationToken cancellationToken);
    Task NotifyCandidatePassedToInterview(CandidatePassedToInternshipEvent message, CancellationToken cancellationToken);
}
