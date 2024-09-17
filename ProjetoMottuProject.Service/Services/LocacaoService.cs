using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Enum;
using MotoManagementSystemProject.Domain.Interfaces.Repository;
using MotoManagementSystemProject.Domain.Interfaces.Services;
using MotoManagementSystemProject.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static MotoManagementSystemProject.Domain.Responses.CustomResponses;

namespace MotoManagementSystemProject.Service.Services
{
    public class LocacaoService(ILocacaoRepository locacaoRepository) : ILocacaoService
    {
        public async Task<Locacao> CreateLocacaoAsync(Locacao locacao)
        {
            switch(locacao.TipoPlano)
            {
                case TipoPlano.SeteDias: 
                    locacao.ValorDiaria = 30;
                    break;
                case TipoPlano.QuinzeDias:
                    locacao.ValorDiaria = 28;
                    break;
                case TipoPlano.TrintaDias:
                    locacao.ValorDiaria = 22;
                    break;
                case TipoPlano.QuarentaECincoDias:
                    locacao.ValorDiaria = 20;
                    break;
                case TipoPlano.CinquentaDias:
                    locacao.ValorDiaria = 18;
                    break;
            }
            await locacaoRepository.AddAsync(locacao);
            await locacaoRepository.SaveAsync();
            return await Task.FromResult(locacao);
        }

        public async Task<Locacao> GetLocacaoByIdAsync(string id)
        {
            var locacao = await locacaoRepository.GetByIdAsync(id);
            return await Task.FromResult(locacao);
        }

        public async Task<IEnumerable<Locacao>> GetLocacoesByMotoIdAsync(string motoId)
        {
            return await locacaoRepository.FindAsync(x => x.MotoId.Equals(motoId));
        }

        public async Task<UpdateLocacaoResponse> UpdateDataDevolucaoAsync(string id, DateTime dataDevolucao)
        {
            var updatedLocacao = await locacaoRepository.GetByIdAsync(id);
            if (updatedLocacao != null)
            {
                updatedLocacao.DataDevolucao = dataDevolucao;
                //if (updatedLocacao.)

                //    if (updatedLocacao.DataDevolucao < updatedLocacao.DataPrevisaoTermino)
                //    {
                //        dataDevolucao
                //        var diasEntreDatas = updatedLocacao.DataPrevisaoTermino - updatedLocacao.DataDevolucao;
                //        int dias = diasEntreDatas.Days;
                //        if (updatedLocacao.TipoPlano == TipoPlano.SeteDias)
                //        {
                //            var result = updatedLocacao.DataDevolucao.Subtract(updatedLocacao.DataTermino);
                //            int dias =
                //        }
                //    }

                //updatedLocacao.ValorTotal = updatedLocacao.

                await locacaoRepository.UpdateAsync(updatedLocacao);
                await locacaoRepository.SaveAsync();
                return new UpdateLocacaoResponse(true, "Data de devolução informada com sucesso", updatedLocacao);
            }
            return new UpdateLocacaoResponse(false, "Dados inválidos");
        }


    }
}
