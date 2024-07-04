namespace WC.Service.Registration.gRPC.Client.Models.Position;

public class SearchPositionResponseModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}