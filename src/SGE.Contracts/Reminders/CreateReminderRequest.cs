namespace SGE.Contracts.Reminders;

public record CreateReminderRequest(string Text, DateTimeOffset DateTime);