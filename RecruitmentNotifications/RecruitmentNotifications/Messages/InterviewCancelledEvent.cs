namespace RecruitmentNotifications.Messages;

public record InterviewCancelledEvent(
    string CandidateEmail,
    string InterviewerEmail,
    string InterviewType,
    DateTime ScheduledAt) : BaseEvent();
