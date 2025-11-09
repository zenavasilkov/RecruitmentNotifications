namespace RecruitmetNotifications.Messages;

public record InterviewRescheduledEvent(
    string CandidateEmail,
    string InterviewerEmail,
    string InterviewType,
    DateTime ScheduledAt,
    DateTime RescheduledTo) : BaseEvent();
