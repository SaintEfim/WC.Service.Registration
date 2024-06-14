﻿using Microsoft.Extensions.Configuration;

namespace WC.Service.Registration.Domain;

public class EmployeeClientConfiguration : IEmployeeClientConfiguration
{
    private readonly Lazy<string> _baseUrl;

    public EmployeeClientConfiguration(IConfiguration config)
    {
        _baseUrl = new Lazy<string>(() => config.GetValue<string>("EmployeeService:Url") ??
                                          throw new InvalidOperationException(
                                              "Employee REST API service URL must be specified"));
    }

    public string GetBaseUrl()
    {
        return _baseUrl.Value;
    }
}