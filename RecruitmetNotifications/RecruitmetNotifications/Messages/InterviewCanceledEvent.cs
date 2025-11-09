namespace RecruitmetNotifications.Messages;

public record InterviewCanceledEvent(
    string CandidateEmail,
    string InterviewerEmail,
    string InterviewType,
    DateTime ScheduledAt) : BaseEvent();
