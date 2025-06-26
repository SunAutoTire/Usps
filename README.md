# Sun Auto USPS API Client

A simple .NET client/SDK for the USPS API.

> This supports USPS API V3 only.

In situations there is a need to deal with mailing addresses, the USPS API can be a useful tool to standardize and validate addresses. This can amount to cost savings when dealing with shipping service companies.

## Installation

Use the dotnet CLI, VSCode Solution explorer, or VS package manager to install:

[TBD](https:///)

> No package has been published yet. Please check back later.

## Usage

The client expects a `IConfigurationSection` in the form:

```json
{
  "Usps":{
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret",
    "BaseUrl": "USPS API Base URL"
  }
}
```

Inject the class of your choice into your application's service collection along with the HTTP client:

```csharp
services.AddHttpClient();
services.AddScoped<Addresses>();
```

> Currently, only the `Addresses` class is implemented which returns the best standardized address for a given address.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)

## Related

[USPS Developer Portal APIs](https://developer.usps.com/apis/)

## Support

If you like this project and think it has helped in any way, consider getting tires or auto service at a Sun Auto Tire & Service location near you:

<a href="https://sun.auto/home" target="_blank"><img src="https://sun.auto/wp-content/themes/sun-auto/images/logo_sunauto.png" alt="Sun Auto Tire & Service" width="150" height="65"/></a>
