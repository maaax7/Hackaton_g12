using Hackathon_g12.Application.Infra.BlobAzure;
using Microsoft.Extensions.Options;

namespace Hackathon_g12.Application.Services.Storage;

public class ConteinerAzureConfigProvider : IConteinerAzureConfigProvider
{
    private readonly IOptions<ConteinerAzureConfig> _conteinerAzureConfig;

    public ConteinerAzureConfigProvider(IOptions<ConteinerAzureConfig> conteinerAzureConfig)
    {
        _conteinerAzureConfig = conteinerAzureConfig;
    }

    public ConteinerAzureConfig GetConteinerAzureConfig()
    {
        return _conteinerAzureConfig.Value;
    }
}