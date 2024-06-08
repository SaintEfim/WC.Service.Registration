using System.ComponentModel.DataAnnotations;

namespace WC.Service.Registration.gRPC.Models;

public class CreateResultModel
{
    [Required] public Guid Id { get; init; }
}