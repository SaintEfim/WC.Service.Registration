// using AutoMapper;
// using Google.Protobuf.WellKnownTypes;
// using Grpc.Net.Client;
// using WC.Service.Registration.Domain;
// using WC.Service.Registration.gRPC.Models;
//
// namespace WC.Service.Registration.gRPC.GrpcClients;
//
// public class EmployeeClientProvider : IEmployeeClientProvider
// {
//     private readonly EmployeeService.EmployeeServiceClient _client;
//     private readonly IMapper _mapper;
//
//     public EmployeeClientProvider(IEmployeeClientConfiguration clientConfiguration, IMapper mapper)
//     {
//         _mapper = mapper;
//
//         var channel = GrpcChannel.ForAddress(clientConfiguration.GetBaseUrl());
//         _client = new EmployeeService.EmployeeServiceClient(channel);
//     }
//
//     // public async Task<List<EmployeeCreateModel>> Get(CancellationToken cancellationToken)
//     // {
//     //     // var responses = await _client.GetAsync(new Empty(), cancellationToken: cancellationToken);
//     //     // return _mapper.Map<List<EmployeeCreateModel>>(responses);
//     // }
// }