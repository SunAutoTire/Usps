# Sun Auto USPS API Client

A simple .NET client/SDK for the USPS API.

> This supports USPS API V3 only.

In situations there is a need to deal with mailing addresses, the USPS API can be a useful tool to standardize and validate addresses. This can amount to cost savings when dealing with shipping service companies.

## Installation

Use the dotnet CLI, VSCode Solution explorer, or VS package manager to install:

[SunAuto.Usps.Client](https://www.nuget.org/packages/SunAuto.Usps.Client)

> The package has limited coverage of the API and is still in preview.

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

If you are using an Azure Function, you can set the configuration in the `local.settings.json` file or in the Azure portal under Application Settings.

```json
{
  "Usps:ClientId": "your-client-id",
  "Usps:ClientSecret": "your-client-secret",
  "Usps:BaseUrl": "USPS API Base URL"
}
```

Inject the class of your choice into your application's service collection along with the HTTP client using the included start up extension method:

```csharp
services.AddSatsUspsClient(configuration);
```

> Currently, only the standardized address and city & state by zip code is implemented which returns the best standardized address for a given address.

Successful requests will return a response object specific to the data which the API returns. For example, the `Addresses` class will return a `StandardizedAddressResponse` object.

Errors will throw a `ArgumentException` with a message indicating the error and more detailed information in an object added to the Data collection property of the exception containing error information deserialized from the error response, e.g.,

```json
{
    "apiVersion": "/addresses/v3/",
    "error": {
        "code": "400",
        "message": "OASValidation OpenAPI-Spec-Validation-Addresses-Request with resource oas://addresses_v3.yaml: failed with reason: [ERROR - ECMA 262 regex ^(AA|AE|AL|AK|AP|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MP|MT|NE|NV|NH|NJ|NM|NY|NC|ND|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)$ does not match input string tx: []]",
        "errors": [
            {
                "title": "openapi_validation_error",
                "detail": "The API request or response does not validate against the specification.",
                "source": "API"
            }
        ]
    }
}
```

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
