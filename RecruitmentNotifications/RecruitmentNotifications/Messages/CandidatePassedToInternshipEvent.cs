namespace RecruitmetNotifications.Messages;

public record CandidatePassedToInternshipEvent(string Email) : BaseEvent();
