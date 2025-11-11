namespace RecruitmentNotifications.Messages;

public record InterviewScheduledEvent(
    string CandidateEmail,
    string InterviewerEmail,
    DateTime ScheduledAt,
    string InterviewType
    ) : BaseEvent();
