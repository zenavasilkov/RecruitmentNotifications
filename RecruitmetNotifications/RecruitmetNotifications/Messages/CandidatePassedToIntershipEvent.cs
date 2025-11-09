namespace RecruitmetNotifications.Messages;

public record CandidatePassedToIntershipEvent(string Email) : BaseEvent();
