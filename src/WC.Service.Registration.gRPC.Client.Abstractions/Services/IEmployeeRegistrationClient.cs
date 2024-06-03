using WC.Library.Data.Repository;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC.Services;

public interface IEmployeeRegistrationClient : IRepository<EmployeeServiceClientModel>;