using Hackathon_g12.Application.Infra.BlobAzure;

namespace Hackathon_g12.Application.Services.Storage;

public interface IConteinerAzureConfigProvider
{
    ConteinerAzureConfig GetConteinerAzureConfig();
}