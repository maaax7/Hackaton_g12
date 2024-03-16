using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hackathon_g12.Application.Infra.BlobAzure;
using System.Net;


namespace Hackathon_g12.Application.Services.Storage;

public class StorageService : IStorageService
{
	private readonly IConteinerAzureConfigProvider _conteinerAzureConfigProvider;

	public StorageService(IConteinerAzureConfigProvider conteinerAzureConfigProvider)
	{
		_conteinerAzureConfigProvider = conteinerAzureConfigProvider;
	}

	public async Task UploadFile(BinaryData binaryData, string nome)
	{
		ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

		BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

		BlobClient blobClient = containerClient.GetBlobClient(nome);

		_ = await blobClient.UploadAsync(binaryData, true);

		_ = await blobClient.SetMetadataAsync(new Dictionary<string, string>()
		{
			{ "Nome", nome },
			{ "Upload", DateTime.Now.ToString() }
		});
	}

	//public List<ImagemResponseViewModel> PesquisarTodasImagens()
	//{
	//	List<ImagemResponseViewModel> arquivos = new();

	//	ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

	//	BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

	//	Pageable<BlobItem> blobs = containerClient.GetBlobs(BlobTraits.Metadata, BlobStates.Uncommitted);

	//	if (blobs == null || !blobs.Any()) { return null; }

	//	foreach (var blob in blobs)
	//	{
	//		BlobClient blobClient = containerClient.GetBlobClient(blob.Name);

	//		var sasBuilder = BlobSasBuilderFactory.CreateBlobSasBuilder(conteinerAzureConfig.Nome, blobClient.Name);

	//		arquivos.Add(new ImagemResponseViewModel
	//		{
	//			Nome = blob.Name,
	//			ImagemUri = blobClient.GenerateSasUri(sasBuilder)
	//		});
	//	}

	//	return arquivos;
	//}

	//public List<ImagemResponseViewModel> PesquisarTodasImagensDeletadas()
	//{
	//	List<ImagemResponseViewModel> imagens = new();

	//	ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

	//	BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

	//	Pageable<BlobItem> blobsdel = containerClient.GetBlobs(BlobTraits.All, BlobStates.Deleted);

	//	if (blobsdel == null || !blobsdel.Any())
	//	{
	//		return null;
	//	}

	//	foreach (BlobItem blobdel in blobsdel.Where(c => c.Properties.DeletedOn.HasValue))
	//	{
	//		BlobClient blobClient = containerClient.GetBlobClient(blobdel.Name);

	//		var sasBuilder = BlobSasBuilderFactory.CreateBlobSasBuilder(conteinerAzureConfig.Nome, blobClient.Name);

	//		imagens.Add(new ImagemResponseViewModel
	//		{
	//			Nome = blobdel.Name,
	//			ImagemUri = blobClient.GenerateSasUri(sasBuilder)
	//		});
	//	}

	//	return imagens;
	//}

	//public Uri PesquisarUriArquivoPorNome(string nomeArquivo)
	//{
	//	ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

	//	BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

	//	Pageable<BlobItem> blobs = containerClient.GetBlobs(BlobTraits.Metadata, BlobStates.All, nomeArquivo);

	//	if (blobs == null || !blobs.Any()) { return null; }

	//	BlobClient blobClient = containerClient.GetBlobClient(blobs.FirstOrDefault().Name);

	//	var sasBuilder = BlobSasBuilderFactory.CreateBlobSasBuilder(conteinerAzureConfig.Nome, blobClient.Name);

	//	return blobClient.GenerateSasUri(sasBuilder);
	//}

	//public async Task<int> DeletarImagemPorNome(string nomeIMG)
	//{
	//	ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

	//	BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

	//	Pageable<BlobItem> blobs = containerClient.GetBlobs(BlobTraits.Metadata, BlobStates.All, nomeIMG);

	//	if (blobs == null || !blobs.Any())
	//	{
	//		return 0;
	//	}

	//	BlobClient blobClient = containerClient.GetBlobClient(blobs.FirstOrDefault().Name);

	//	Response resposta = await blobClient.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);

	//	return resposta.Status == (int)HttpStatusCode.Accepted ? 1 : 0;

	//}

	//public async Task<int> RecuperarImagensDeletadas(string nomeImagem)
	//{
	//	ConteinerAzureConfig conteinerAzureConfig = _conteinerAzureConfigProvider.GetConteinerAzureConfig();

	//	BlobContainerClient containerClient = new(conteinerAzureConfig.Conexao, conteinerAzureConfig.Nome);

	//	Pageable<BlobItem> blobs = containerClient.GetBlobs(BlobTraits.Metadata, BlobStates.Deleted, nomeImagem);

	//	if (blobs == null || !blobs.Any())
	//	{
	//		return 0;
	//	}

	//	BlobClient blobClient = containerClient.GetBlobClient(blobs.FirstOrDefault().Name);

	//	Response resposta = await blobClient.UndeleteAsync();

	//	return resposta.Status == (int)HttpStatusCode.Accepted ? 1 : 0;
	//}
}