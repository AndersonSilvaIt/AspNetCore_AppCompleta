using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Models;

namespace DevIO.App.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig() {
			/*Aqui ambos possuem o mesmo construtores, por isso irá funcionar, caso algum conter algum construtor com parâmetros, precisa criar uma outra configuração*/
			CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
			CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
			CreateMap<Produto, ProdutoViewModel>().ReverseMap();
		}
	}
}
