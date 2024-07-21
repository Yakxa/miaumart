using AutoMapper;
using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.DTOs.ProdutoDTOs;
using MiauMart.Domain.DTOs.VendaDTOs;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteCreateDTO, Cliente>();
            CreateMap<Cliente, ClienteCreateDTO>();
            CreateMap<ClienteGetDTO, Cliente>();
            CreateMap<Cliente, ClienteGetDTO>()
                .ForMember(x => x.Vendas, opt => opt.MapFrom(src => src.Vendas));
            CreateMap<ClienteGetDTO, Cliente>();


            CreateMap<ProdutoCreateDTO, Produto>();
            CreateMap<Produto, ProdutoCreateDTO>();
            CreateMap<Produto, ProdutoGetDTO>()
                .ForMember(dest => dest.Vendas, opt => opt.MapFrom(src => src.Vendas));
            CreateMap<ProdutoGetDTO, Produto>();

            // vendas atreladas ao cliente:
            CreateMap<Venda, ClienteVendaDTO>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Produto.Descricao))
                .ForMember(dest => dest.QuantidadeVenda, opt => opt.MapFrom(src => src.QuantidadeVenda))
                .ForMember(dest => dest.ValorUnitarioVenda, opt => opt.MapFrom(src => src.ValorUnitarioVenda))
                .ForMember(dest => dest.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
                .ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda));

            // vendas atreladas ao produto:
            CreateMap<Venda, ProdutoVendaDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.QuantidadeVenda, opt => opt.MapFrom(src => src.QuantidadeVenda))
                .ForMember(dest => dest.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
                .ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda));

            // infos puxadas por cada venda:
            CreateMap<Venda, VendaGetDTO>()
                .ForMember(x => x.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(x => x.DescricaoProduto, opt => opt.MapFrom(src => src.Produto.Descricao))
                .ForMember(x => x.QuantidadeVenda, opt => opt.MapFrom(src => src.QuantidadeVenda))
                .ForMember(x => x.ValorUnitarioVenda, opt => opt.MapFrom(src => src.ValorUnitarioVenda))
                .ForMember(x => x.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
                .ForMember(x => x.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda));

            CreateMap<VendaCreateDTO, Venda>();

        
        }
    }
}
