using System;
using System.Collections;
using System.Collections.Generic;

namespace backend.Models.Response
{
    public class CartoesTarefasResponse
    {
        public List<Models.Response.CartaoTarefaResponse> Cartoes { get; set; }
        public CartoesTarefasResponse(List<Models.Response.CartaoTarefaResponse> cartoes)
        {
            this.Cartoes = cartoes;
        }
    }
}