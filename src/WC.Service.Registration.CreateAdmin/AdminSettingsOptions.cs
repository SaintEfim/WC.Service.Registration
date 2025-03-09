namespace WC.Service.Registration.CreateAdmin;

public class AdminSettingsOptions
{
    public string[] PositionNames { get; set; } = [];

    public Guid AdminPositionId { get; set; }

    public string? AdminEmailLocalPart { get; set; }

    public string? AdminEmailDomain { get; set; }

    public string? AdminRegistrationName { get; set; }

    public string? AdminRegistrationSurname { get; set; }

    public string? AdminRegistrationPatronymic { get; set; }

    public string? AdminRegistrationPassword { get; set; }
}
